using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Elements;
using CollisionDetection;
using EnvironmentAnalysis.RayTest.Cylinder;
using BaseTypes;
using BaseContracts;

namespace EnvironmentAnalysis.RayTest.Rays
{
    public enum TestingPurpose
    {
        SingleRay = 1,
        UpsplittingRay = 2,
        ParallelDoubleRay = 3
    }

    public static class CollisionRayFactory
    {
        private static double MainCircleMinimumRadius;
        private static double MainCircleMaximumRadius;
        private static double MaxRayLength;

        public static void Initialize(double distanceOfMaximumVisibility)
        {
            MainCircleMinimumRadius = 0.4;
            MainCircleMaximumRadius = 2.0;

            MaxRayLength = distanceOfMaximumVisibility;
        }

        public static CollisionRay GenerateRay(Position3D startPosition, VectorWithDegree directionVector, TestingPurpose purpose, TestQuality testQuality, IListProvider<IWorldElement> listProvider, IWorldElement excludebleSource = null, double? maxRayDistance = null)
        {
            Instruction instruction = GetInstruction(testQuality, maxRayDistance);

            switch (purpose)
            {
                case TestingPurpose.SingleRay:
                    return CreateSingleRay(startPosition, excludebleSource, directionVector.Vector, instruction, listProvider);
                case TestingPurpose.UpsplittingRay:
                    return CreateUpsplittingRay(startPosition, excludebleSource, directionVector, instruction, listProvider);
                case TestingPurpose.ParallelDoubleRay:
                    return CreateParallelDoubleRay(startPosition, excludebleSource, directionVector.Vector, instruction, listProvider); 
            }

            return null;
        }

        public static CollisionRay GenerateRay(Position3D startPosition, Vector3D directionVector, TestingPurpose purpose, TestQuality testQuality, IListProvider<IWorldElement> listProvider, IWorldElement excludebleSource = null, double? maxRayDistance = null)
        {
            Instruction instruction = GetInstruction(testQuality, maxRayDistance);

            switch (purpose)
            {
                case TestingPurpose.SingleRay:
                    return CreateSingleRay(startPosition, excludebleSource, directionVector, instruction, listProvider);
                case TestingPurpose.UpsplittingRay:
                    throw new NotImplementedException();
                case TestingPurpose.ParallelDoubleRay:
                    return CreateParallelDoubleRay(startPosition, excludebleSource, directionVector, instruction, listProvider);
            }

            return null;
        }

        public static CollisionRay GenerateRay(Position3D startPosition, Position3D lookAtPosition, TestQuality testQuality, IListProvider<IWorldElement> listProvider, IWorldElement excludebleSource = null, double? maxRayDistance = null)
        {
            Instruction instruction = GetInstruction(testQuality, maxRayDistance);

            Vector3D vector = MathHelper.CreateVectorWithXYLengthOne(startPosition, lookAtPosition);

            DistanceBetweenTwoPositions distance = new DistanceBetweenTwoPositions(startPosition, lookAtPosition);

            if (instruction.MaxRayLength > distance.DistanceXY)
                instruction.MaxRayLength = distance.DistanceXY;
  
            return CreateSingleRay(startPosition, excludebleSource, vector, instruction, listProvider);
        }

        private static CollisionRay CreateParallelDoubleRay(Position3D startPosition, IWorldElement excludebleSource, Vector3D directionVector, Instruction instruction, IListProvider<IWorldElement> listProvider)
        {
            return new StraightCollisionRay(startPosition.Clone(),
              directionVector, BesetPosition.FirstPosition | BesetPosition.SecondPosition, 2, instruction, listProvider, excludebleSource);
        }

        private static CollisionRay CreateSingleRay(Position3D startPosition, IWorldElement excludebleSource, Vector3D directionVector, Instruction instruction, IListProvider<IWorldElement> listProvider)
        {
            return new StraightCollisionRay(startPosition.Clone(),
                directionVector, BesetPosition.SecondPosition, 3, instruction, listProvider, excludebleSource);
        }

        private static CollisionRay CreateUpsplittingRay(Position3D startPosition, IWorldElement excludebleSource, VectorWithDegree directionVector, Instruction instruction, IListProvider<IWorldElement> listProvider)
        {
            return new UpsplittingRay(startPosition.Clone(),
                directionVector, instruction, 4.0, listProvider, excludebleSource);
        }

        private static Instruction GetInstruction(TestQuality quality, double? maxRayLength = null)
        {
            Instruction instruction = new Instruction();

            switch(quality)
            {
                case TestQuality.Low:
                    instruction.GrowingCircles = false;
                    instruction.MaximumRadiusOfMainCircles = MainCircleMaximumRadius;
                    instruction.MinimumRadiusOfMainCircles = MainCircleMaximumRadius;
                    instruction.NumberOfMainCirlcesPerFrame = 1;
                    if (maxRayLength.HasValue)
                        instruction.MaxRayLength = maxRayLength.Value;
                    else
                        instruction.MaxRayLength = MaxRayLength * 0.66;
                    break;
                case TestQuality.Medium:
                    instruction.GrowingCircles = true;
                    instruction.MaximumRadiusOfMainCircles = MainCircleMaximumRadius;
                    instruction.MinimumRadiusOfMainCircles = (MainCircleMinimumRadius + MainCircleMaximumRadius) / 2.0;
                    instruction.NumberOfMainCirlcesPerFrame = 1;
                    if (maxRayLength.HasValue)
                        instruction.MaxRayLength = maxRayLength.Value;
                    else
                        instruction.MaxRayLength = MaxRayLength;
                    break;
                case TestQuality.High:
                    instruction.GrowingCircles = true;
                    instruction.MaximumRadiusOfMainCircles = MainCircleMaximumRadius;
                    instruction.MinimumRadiusOfMainCircles = MainCircleMinimumRadius;
                    instruction.NumberOfMainCirlcesPerFrame = 2;
                    if (maxRayLength.HasValue)
                        instruction.MaxRayLength = maxRayLength.Value;
                    else
                        instruction.MaxRayLength = MaxRayLength;
                    break;
            }
            return instruction;
        }
    }
}
