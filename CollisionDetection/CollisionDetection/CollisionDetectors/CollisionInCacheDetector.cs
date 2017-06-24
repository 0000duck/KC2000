using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Elements;
using BaseTypes;

namespace CollisionDetection.CollisionDetectors
{
    public class CollisionInCacheDetector
    {
        private DetectorOfOverlappingElements CollisionDetector { set; get; }

        public CollisionInCacheDetector(DetectorOfOverlappingElements collisionDetector)
        {
            CollisionDetector = collisionDetector;
        }

        public CollisionCacheTestResult AnalyzeCollisionInCache(IWorldElement elementOne, CollisionCache cachedRoomsAndElements)
        {
            CollisionCacheTestResult result = new CollisionCacheTestResult();

            foreach (IWorldElement element in cachedRoomsAndElements.Elements)
            {
                if (CollisionDetector.ElementsAreOverlapping(elementOne, elementOne.Position, element))
                {
                    result.CollidedElement = element;
                    return result;
                }
            }

            return result;
        }
        
    }
}
