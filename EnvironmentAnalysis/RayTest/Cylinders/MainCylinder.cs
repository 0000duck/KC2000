using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Elements;
using CollisionDetection;
using EnvironmentAnalysis.RayTest.Cylinder;
using BaseTypes;
using EnvironmentAnalysis.RayTest;
using CollisionDetection.CollisionDetectors;

namespace EnvironmentAnalysis.Circles
{
    internal class MainCylinder : Cylinder
    {
        protected CircleInitInfo MyCircleInitInfo;   
        protected IWorldElement ExcludebleSource;

        private CacheCreatingCollisionDetector CacheCreatingCollisionDetector { set; get; }

        internal MainCylinder(Position3D startPosition, double radius, CircleInitInfo circleInitInfo, Vector3D directionVector, IWorldElement excludebleSource)
            : base(startPosition, directionVector, radius)
        {
            MyCircleInitInfo = circleInitInfo;
            ExcludebleSource = excludebleSource;
            CacheCreatingCollisionDetector = new CacheCreatingCollisionDetector(new DetectorOfOverlappingElements());
            ValidateCircleInitInfo();
        }
    
        public CylinderCollisionTestResult TestCollision(IWorldElement excludebleSource, IEnumerable<IWorldElement> list)
        {
            CollisionCache cache = CacheCreatingCollisionDetector.TestCollisionAndFillCache(this, this.MyCollisionModel, list,
                excludebleSource);
            
            if (cache.IsEmpty)
            {
                CylinderCollisionTestResult cacheResult = new CylinderCollisionTestResult();
                cacheResult.CollisionResults = new List<CollisionCacheTestResult>();
                cacheResult.UncollidedPositions = MyCircleInitInfo.BesetPositions;
                return cacheResult;
            }

            return InstantiateAndTestSecondaryCircles(cache);
        }

        private CylinderCollisionTestResult InstantiateAndTestSecondaryCircles(CollisionCache cache)
        {
            CylinderCollisionTestResult cacheResult = new CylinderCollisionTestResult();
            cacheResult.CollisionResults = new List<CollisionCacheTestResult>();
            cacheResult.UncollidedPositions = MyCircleInitInfo.BesetPositions;

            double radius = CylinderRadius / 3.0;

            for (int i = 0; i < 3; i++)
            {
                if (MyCircleInitInfo.BesetPositions == 0)
                    continue;

                Position3D startPosition = CalculatePosition(radius, i);

                SecondaryCylinder circle = new SecondaryCylinder(startPosition.Clone(), radius, MyCircleInitInfo, DirectionVector);
                CylinderCollisionTestResult testResult = circle.TestCollision(cache);

                MyCircleInitInfo.BesetPositions = testResult.UncollidedPositions;
                cacheResult.CollisionResults.AddRange(testResult.CollisionResults);
            }
            cacheResult.UncollidedPositions = MyCircleInitInfo.BesetPositions;

            return cacheResult;
        }

        private Position3D CalculatePosition(double radius, int i)
        {
            Position3D position = new Position3D();
            position.PositionX = StartPosition.PositionX + (DirectionVector.X * i * 2 * radius);
            position.PositionY = StartPosition.PositionY + (DirectionVector.Y * i * 2 * radius);
            position.PositionZ = StartPosition.PositionZ + (DirectionVector.Z * i * 2 * radius);
            return position;
        }

        private void ValidateCircleInitInfo()
        {
            if (MyCircleInitInfo.RadiusDivider == 2 && MyCircleInitInfo.BesetPositions.HasFlag(BesetPosition.ThirdPosition))
                throw new Exception("MyCircleInitInfo is invalid!");

            if (MyCircleInitInfo.RadiusDivider > 3 || MyCircleInitInfo.RadiusDivider < 2)
                throw new Exception("MyCircleInitInfo is invalid!");
        }
    }
}
