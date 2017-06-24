using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Elements;
using BaseTypes;

namespace CollisionDetection.CollisionDetectors
{
    public class CacheCreatingCollisionDetector
    {
        private DetectorOfOverlappingElements CollisionDetector { set; get; }

        public CacheCreatingCollisionDetector(DetectorOfOverlappingElements collisionDetector)
        {
            CollisionDetector = collisionDetector;
        }

        public CollisionCache TestCollisionAndFillCache(IWorldElement ElementOne,
            ISimpleCollisionModel newPositionOnRoomFieldModel,
            IEnumerable<IWorldElement> allVolumetricElements,
            IWorldElement excludebleSource)
        {
            CollisionCache cache = new CollisionCache();
            
            //instantiating the list to avoid null reference
            cache.Elements = new List<IWorldElement>();

            FillCacheWithCollidingElements(ElementOne, newPositionOnRoomFieldModel, allVolumetricElements, excludebleSource, cache);

            return cache;
        }

        private void FillCacheWithCollidingElements(IWorldElement ElementOne, 
            ISimpleCollisionModel newPositionOnRoomFieldModel, 
            IEnumerable<IWorldElement> allVolumetricElements, 
            IWorldElement excludebleSource, 
            CollisionCache cache)
        {
            foreach (IWorldElement element in allVolumetricElements)
            {
                if (element != ElementOne && element != excludebleSource && !element.IsVirtual)
                {
                    if (newPositionOnRoomFieldModel.EventuallyCollidesWith(element.MyCollisionModel))
                    {
                        if (CollisionDetector.ElementsAreOverlapping(ElementOne, ElementOne.Position, element))
                        {
                            if (element is IComposition)
                            {
                                IComposition parent = (IComposition)element;
                                if (parent.Children.Count > 0)
                                {
                                    FillCacheWithCollidingElements(
                                        ElementOne,
                                        newPositionOnRoomFieldModel,
                                        parent.Children,
                                        excludebleSource, cache);
                                }
                            }
                            else if (element is IHighLevelOfDetail)
                            {
                                FillCacheWithCollidingElements(
                                        ElementOne,
                                        newPositionOnRoomFieldModel,
                                        (element as IHighLevelOfDetail).GetHigherDetails(),
                                        excludebleSource, cache);
                            }
                            else
                            {
                                cache.Elements.Add(element);
                            }   
                        }
                    }
                }
            }
        }
    }
}
