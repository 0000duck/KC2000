using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Elements;
using CollisionDetection;
using BaseTypes;
using CollisionDetection.CollisionDetectors;

namespace EnvironmentAnalysis.RayTest.Cylinder
{
    internal class ElementaryCylinder : Cylinder
    {
        protected CollisionInCacheDetector CollisionInCacheDetector { set; get; }

        internal ElementaryCylinder(Position3D startPosition, Vector3D directionVector, double radius)
           : base(startPosition,  directionVector,  radius)
        {
            CollisionInCacheDetector = new CollisionInCacheDetector(new DetectorOfOverlappingElements());
        }

        public CollisionCacheTestResult TestCollision(CollisionCache cache)
        {
            return CollisionInCacheDetector.AnalyzeCollisionInCache(this, cache);
        }
    }
}
