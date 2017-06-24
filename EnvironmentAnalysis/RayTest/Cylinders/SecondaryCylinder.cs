using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Elements;
using CollisionDetection;
using EnvironmentAnalysis.RayTest.Cylinder;
using BaseTypes;
using CollisionDetection.CollisionDetectors;

namespace EnvironmentAnalysis.RayTest.Cylinder
{
    internal class SecondaryCylinder : Cylinder
    {
        protected CircleInitInfo MyCircleInitInfo;
        protected CollisionInCacheDetector CollisionInCacheDetector { set; get; }

        internal SecondaryCylinder(Position3D startPosition, double radius, CircleInitInfo circleInitInfo, Vector3D directionVector)
            : base(startPosition, directionVector, radius)
        {
            MyCircleInitInfo = circleInitInfo;
            CollisionInCacheDetector = new CollisionInCacheDetector(new DetectorOfOverlappingElements());
        }

        public CylinderCollisionTestResult TestCollision(CollisionCache cache)
        {
            CollisionCacheTestResult myOwnResult = CollisionInCacheDetector.AnalyzeCollisionInCache(this, cache);

            if (!myOwnResult.IsEmpty)
            {
                return InstantiateAndTestElementaryCircles(cache);
            }
            else
            {
                return new CylinderCollisionTestResult() 
                { 
                        CollisionResults = new List<CollisionCacheTestResult>(), 
                        UncollidedPositions = MyCircleInitInfo.BesetPositions 
                };
            }
        }

        private CylinderCollisionTestResult InstantiateAndTestElementaryCircles(CollisionCache cache)
        {
            CylinderCollisionTestResult result = new CylinderCollisionTestResult();
            result.CollisionResults = new List<CollisionCacheTestResult>();
            
            Vector2D vector90Degree = DirectionVector.Clone2D(Degree.Degree_90);
            Vector2D vector270Degree = DirectionVector.Clone2D(Degree.Degree_270);
            double radius = Radius / MyCircleInitInfo.RadiusDivider;

            Position3D firstPosition = CalculateFirstPosition(vector90Degree, radius);
            Position3D secondPosition = CalculateSecondPosition(vector270Degree, radius);
            Position3D thirdPosition = CalculateThirdPosition(vector270Degree, radius);

            for (int i = 0; i < MyCircleInitInfo.RadiusDivider; i++)
            {
                if (MyCircleInitInfo.BesetPositions.HasFlag(BesetPosition.FirstPosition))
                {
                    MoveForward(firstPosition, i, radius);
                    ElementaryCylinder circle = new ElementaryCylinder(firstPosition.Clone(), DirectionVector, radius);
                    CollisionCacheTestResult testResult = circle.TestCollision(cache);
                    if (!testResult.IsEmpty)
                    {
                        testResult.OuterPositionOfCollision = firstPosition.Clone();
                        MyCircleInitInfo.BesetPositions ^= BesetPosition.FirstPosition;
                        result.CollisionResults.Add(testResult);
                    }
                }
                if (MyCircleInitInfo.BesetPositions.HasFlag(BesetPosition.SecondPosition))
                {
                    MoveForward(secondPosition, i, radius);
                    ElementaryCylinder circle = new ElementaryCylinder(secondPosition.Clone(), DirectionVector, radius);
                    CollisionCacheTestResult testResult = circle.TestCollision(cache);
                    if (!testResult.IsEmpty)
                    {
                        testResult.OuterPositionOfCollision = secondPosition.Clone();
                        MyCircleInitInfo.BesetPositions ^= BesetPosition.SecondPosition;
                        result.CollisionResults.Add(testResult);
                    }
                }
                if (MyCircleInitInfo.BesetPositions.HasFlag(BesetPosition.ThirdPosition))
                {
                    MoveForward(thirdPosition, i, radius);
                    ElementaryCylinder circle = new ElementaryCylinder(thirdPosition.Clone(), DirectionVector, radius);
                    CollisionCacheTestResult testResult = circle.TestCollision(cache);
                    if (!testResult.IsEmpty)
                    {
                        testResult.OuterPositionOfCollision = thirdPosition.Clone();
                        MyCircleInitInfo.BesetPositions ^= BesetPosition.ThirdPosition;
                        result.CollisionResults.Add(testResult);
                    }
                }
            }
            result.UncollidedPositions = MyCircleInitInfo.BesetPositions;
            return result;
        }

        private void MoveForward(Position3D position, int counter, double radius)
        {
            if (counter > 1)
                counter = 1;

            position.PositionX += DirectionVector.X * radius * counter * 2;
            position.PositionY += DirectionVector.Y * radius * counter * 2;
            position.PositionZ += DirectionVector.Z * radius * counter * 2;
        }

        private Position3D CalculateThirdPosition(Vector2D vector270Degree, double radius)
        {
            Position3D thirdPosition = new Position3D();

            thirdPosition.PositionX = StartPosition.PositionX +
                                        (vector270Degree.X * 2 * radius);

            thirdPosition.PositionY = StartPosition.PositionY +
                                        (vector270Degree.Y * 2 * radius);

            thirdPosition.PositionZ = StartPosition.PositionZ;
            return thirdPosition;
        }

        private Position3D CalculateSecondPosition(Vector2D vector270Degree, double radius)
        {
            Position3D secondPosition = new Position3D();

            secondPosition.PositionX = StartPosition.PositionX +
                                        (vector270Degree.X * (3 - MyCircleInitInfo.RadiusDivider) * radius);

            secondPosition.PositionY = StartPosition.PositionY +
                                        (vector270Degree.Y * (3 - MyCircleInitInfo.RadiusDivider) * radius);

            secondPosition.PositionZ = StartPosition.PositionZ;
            return secondPosition;
        }

        private Position3D CalculateFirstPosition(Vector2D vector90Degree, double radius)
        {
            Position3D firstPosition = new Position3D();

            firstPosition.PositionX = StartPosition.PositionX +
                                       (vector90Degree.X * (MyCircleInitInfo.RadiusDivider - 1) * radius);

            firstPosition.PositionY = StartPosition.PositionY +
                                        (vector90Degree.Y * (MyCircleInitInfo.RadiusDivider - 1) * radius);

            firstPosition.PositionZ = StartPosition.PositionZ;
            return firstPosition;
        }
    }
}
