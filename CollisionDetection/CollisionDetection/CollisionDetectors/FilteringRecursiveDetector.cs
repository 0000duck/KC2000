using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Contracts;
using BaseTypes;

namespace CollisionDetection.CollisionDetectors
{
    public class FilteringRecursiveDetector: ICollisionDetector
    {
        private DetectorOfOverlappingElements CollisionDetector { set; get; }
        private IElementFilter _filter;

        public FilteringRecursiveDetector(DetectorOfOverlappingElements collisionDetector, IElementFilter filter)
        {
            CollisionDetector = collisionDetector;
            _filter = filter;
        }

        public bool SimpleCollisionTakesPlace(IWorldElement element, ISimpleCollisionModel newPositionOnRoomFieldModel, IEnumerable<IWorldElement> allVolumetricElements)
        {
            foreach (IWorldElement otherElement in allVolumetricElements)
            {
                if (otherElement != element && !otherElement.IsVirtual)
                {
                    if (newPositionOnRoomFieldModel.EventuallyCollidesWith(otherElement.MyCollisionModel))
                    {
                        if(!_filter.ElementIsFiltered(otherElement))
                        {
                            if (CollisionDetector.ElementsAreOverlapping(element, element.Position, otherElement))
                            {
                                if (otherElement is IComposition)
                                {
                                    IComposition parent = (IComposition)otherElement;
                                    if (parent.Children.Count > 0)
                                    {
                                        if (SimpleCollisionTakesPlace(element, newPositionOnRoomFieldModel, parent.Children))
                                            return true;
                                    }
                                }
                                else
                                    return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
