using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Elements;

namespace EnvironmentAnalysis.RayTest.Rays
{
    public abstract class CollisionRay
    {
        protected bool ReachedEndOrCollision;
        protected List<CollisionCacheTestResult> ResultList = new List<CollisionCacheTestResult>();

        public abstract void CalculateNextSegment();

        public bool TestIsFinished()
        {
            return ReachedEndOrCollision;
        }

        public List<CollisionCacheTestResult> GetCollisionResults()
        {
            if (!TestIsFinished())
                throw new Exception("TestRay was not finished!");

            return ResultList;
        }
    }
}
