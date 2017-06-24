using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection;
using CollisionDetection.Elements;
using EnvironmentAnalysis.RayTest.Cylinder;
using BaseTypes;
using EnvironmentAnalysis.Circles;
using BaseContracts;

namespace EnvironmentAnalysis.RayTest.Rays
{
    internal class UpsplittingRay : CollisionRay
    {
        private double additionalDegree = 4;
        private int SegmentCount;
        private Position3D StartPosition;
        private VectorWithDegree DirectionVector;
        private double RadiusOfMainCircles;
        private double MaxRayLength;
        private double CurrentRayLength;
        private IWorldElement ExcludebleSource;
        private CircleInitInfo InitInfo;
        private double DiffusionDegree;
        private Instruction Instruction;

        private List<StraightCollisionRay> UpsplittedStraightRays;
        private IListProvider<IWorldElement> ListProvider { set; get; }

        public UpsplittingRay(Position3D position, VectorWithDegree directionVector, Instruction instruction, double diffusionDegree, IListProvider<IWorldElement> listProvider, IWorldElement excludebleSource = null)
        {
            ListProvider = listProvider;
            Instruction = instruction;
            StartPosition = position;
            DirectionVector = directionVector;
            MaxRayLength = Instruction.MaxRayLength;
            RadiusOfMainCircles = Instruction.MinimumRadiusOfMainCircles;
            ExcludebleSource = excludebleSource;
            DiffusionDegree = diffusionDegree;

            InitInfo = new CircleInitInfo();
            InitInfo.BesetPositions = BesetPosition.SecondPosition;
            InitInfo.RadiusDivider = 3;
        }

        public override void CalculateNextSegment()
        {
            if (ReachedEndOrCollision)
                return; 

            if (SegmentCount < 3)
            {
                CalculateMainCircleCollision();
            }
            else
            {
                InitInfo.BesetPositions = BesetPosition.FirstPosition | BesetPosition.SecondPosition | BesetPosition.ThirdPosition;
                CalculateUpsplittedRayCollision();
            }

            if (CurrentRayLength >= MaxRayLength)
            {
                ReachedEndOrCollision = true;
            }
            SegmentCount++;
        }

        private void CalculateMainCircleCollision()
        {
            double shrinkFactor = 1.0;
            if (SegmentCount == 0)
                shrinkFactor = 0.5;
            if (SegmentCount == 1)
                shrinkFactor = 0.75;

            CurrentRayLength += RadiusOfMainCircles * shrinkFactor * 2;

            MainCylinder mainCircle = new MainCylinder(StartPosition.Clone(), RadiusOfMainCircles * shrinkFactor, InitInfo, DirectionVector.Vector, ExcludebleSource);

            CylinderCollisionTestResult TestResult = mainCircle.TestCollision(ExcludebleSource, ListProvider.GetList());

            if (TestResult.UncollidedPositions == 0)
            {
                ReachedEndOrCollision = true;
            }

            StartPosition.PositionX += RadiusOfMainCircles * shrinkFactor * 2 * DirectionVector.Vector.X;
            StartPosition.PositionY += RadiusOfMainCircles * shrinkFactor * 2 * DirectionVector.Vector.Y;
            StartPosition.PositionZ += RadiusOfMainCircles * shrinkFactor * 2 * DirectionVector.Vector.Z;

            InitInfo.BesetPositions = TestResult.UncollidedPositions;
            ResultList.AddRange(TestResult.CollisionResults);
        }

        private void CalculateUpsplittedRayCollision()
        {
            if (SegmentCount == 3)
            {
                InstantiateStraightRays();
            }

            bool raysAreFinished = true;
            foreach (StraightCollisionRay ray in UpsplittedStraightRays)
            {
                if(!ray.TestIsFinished())
                    ray.CalculateNextSegment();

                if (!ray.TestIsFinished())
                    raysAreFinished = false;
            }

            if (raysAreFinished)
            {
                ReachedEndOrCollision = true;
                foreach (StraightCollisionRay ray in UpsplittedStraightRays)
                {
                    ResultList.AddRange(ray.GetCollisionResults());
                }  
            }
        }

        private void InstantiateStraightRays()
        {
            UpsplittedStraightRays = new List<StraightCollisionRay>();

            if(InitInfo.BesetPositions.HasFlag(BesetPosition.FirstPosition))
            {
                double degree = additionalDegree + DirectionVector.DegreeXY + MathHelper.GetRandomValueInARange(DiffusionDegree / 2.0);
                VectorWithDegree directionVector = new VectorWithDegree(degree, DirectionVector.DegreeZ);
                Position3D startPosition = CalculateStraightRayStartPosition(BesetPosition.FirstPosition);
                UpsplittedStraightRays.Add(new StraightCollisionRay(startPosition,
                directionVector.Vector, BesetPosition.SecondPosition, 3, Instruction,ListProvider, ExcludebleSource));
            }
            if (InitInfo.BesetPositions.HasFlag(BesetPosition.SecondPosition))
            {
                double degree = DirectionVector.DegreeXY + MathHelper.GetRandomValueInARange(DiffusionDegree / 2.0);
                VectorWithDegree directionVector = new VectorWithDegree(degree, DirectionVector.DegreeZ);
                Position3D startPosition = CalculateStraightRayStartPosition(BesetPosition.SecondPosition);
                UpsplittedStraightRays.Add(new StraightCollisionRay(startPosition,
                directionVector.Vector, BesetPosition.SecondPosition, 3, Instruction,ListProvider, ExcludebleSource));
            }
            if (InitInfo.BesetPositions.HasFlag(BesetPosition.ThirdPosition))
            {
                double degree = DirectionVector.DegreeXY + MathHelper.GetRandomValueInARange(DiffusionDegree / 2.0) - additionalDegree;
                VectorWithDegree directionVector = new VectorWithDegree(degree, DirectionVector.DegreeZ);
                Position3D startPosition = CalculateStraightRayStartPosition(BesetPosition.ThirdPosition);
                UpsplittedStraightRays.Add(new StraightCollisionRay(startPosition,
                directionVector.Vector, BesetPosition.SecondPosition, 3, Instruction,ListProvider, ExcludebleSource));
            }
        }

        private Position3D CalculateStraightRayStartPosition(BesetPosition besetPosition)
        {
            switch(besetPosition)
            {
                case BesetPosition.FirstPosition:
                    Vector2D vector90Degree = DirectionVector.Vector.Clone2D(BaseTypes.Degree.Degree_90);
                    return new Position3D() 
                    {
                        PositionX = StartPosition.PositionX + (vector90Degree.X * 2 * RadiusOfMainCircles / 9),
                        PositionY = StartPosition.PositionY + (vector90Degree.Y * 2 * RadiusOfMainCircles / 9),
                        PositionZ = StartPosition.PositionZ
                    }; 
                case BesetPosition.SecondPosition:
                    return StartPosition.Clone();
                case BesetPosition.ThirdPosition:
                    Vector2D vector270Degree = DirectionVector.Vector.Clone2D(BaseTypes.Degree.Degree_270);
                    return new Position3D()
                    {
                        PositionX = StartPosition.PositionX + (vector270Degree.X * 2 * RadiusOfMainCircles / 9),
                        PositionY = StartPosition.PositionY + (vector270Degree.Y * 2 * RadiusOfMainCircles / 9),
                        PositionZ = StartPosition.PositionZ
                    }; 
                default:
                    return null;
            }
        }
    }
}
