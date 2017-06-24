using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Elements;
using CollisionDetection;
using EnvironmentAnalysis.RayTest.Cylinder;
using BaseTypes;
using EnvironmentAnalysis.Circles;
using BaseContracts;

namespace EnvironmentAnalysis.RayTest.Rays
{
    internal class StraightCollisionRay : CollisionRay
    {
        private Position3D StartPosition;
        private double CurrentRadiusOfMainCircles;
        private double MaxRayLength;

        private int SegmentCount;
        private Vector3D DirectionVector;

        private IWorldElement ExcludebleSource;
        
        private CircleInitInfo InitInfo;
        private Instruction Instruction;
        private IListProvider<IWorldElement> ListProvider { set; get; }

        internal StraightCollisionRay(Position3D startPosition, Vector3D directionVector, BesetPosition besetPositions, int radiusDivider, Instruction instruction, IListProvider<IWorldElement> listProvider, IWorldElement excludebleSource = null)
        {
            ListProvider = listProvider;
            Instruction = instruction;
            StartPosition = startPosition;
            MaxRayLength = instruction.MaxRayLength;
            ExcludebleSource = excludebleSource;
            CurrentRadiusOfMainCircles = instruction.MinimumRadiusOfMainCircles;
            DirectionVector = directionVector;

            InitInfo = new CircleInitInfo();
            InitInfo.BesetPositions = besetPositions;
            InitInfo.RadiusDivider = radiusDivider;
        }

        public override void CalculateNextSegment()
        {
            if (ReachedEndOrCollision)
                return;

            for (int i = 0; i < Instruction.NumberOfMainCirlcesPerFrame; i++)
                CreateCylinders();
        }

        private void CreateCylinders()
        {
            if (ReachedEndOrCollision)
                return;

            MainCylinder mainCircle = new MainCylinder(StartPosition.Clone(), CurrentRadiusOfMainCircles, InitInfo, DirectionVector, ExcludebleSource);

            CylinderCollisionTestResult TestResult = mainCircle.TestCollision(ExcludebleSource, ListProvider.GetList());

            if (TestResult.UncollidedPositions == 0)
            {
                ReachedEndOrCollision = true;
            }

            InitInfo.BesetPositions = TestResult.UncollidedPositions;
            ResultList.AddRange(TestResult.CollisionResults);

            SegmentCount++;

            if (EndOfRayIsReached())
            {
                ReachedEndOrCollision = true;
                return;
            }

            ProgressStartPosition();
            IncreaseRadius();
        }

        private void IncreaseRadius()
        {
            if (Instruction.GrowingCircles)
            {
                CurrentRadiusOfMainCircles *= 1.15;
                if (CurrentRadiusOfMainCircles > Instruction.MaximumRadiusOfMainCircles)
                    CurrentRadiusOfMainCircles = Instruction.MaximumRadiusOfMainCircles;
            }
        }

        private bool EndOfRayIsReached()
        {
            return CurrentRadiusOfMainCircles * 2 * SegmentCount >= MaxRayLength;
        }

        private void ProgressStartPosition()
        {
            StartPosition.PositionX += CurrentRadiusOfMainCircles * 2 * DirectionVector.X;
            StartPosition.PositionY += CurrentRadiusOfMainCircles * 2 * DirectionVector.Y;
            StartPosition.PositionZ += CurrentRadiusOfMainCircles * 2 * DirectionVector.Z;
        }
    }
}
