using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Contracts;
using BaseTypes;

namespace CollisionDetection.CollisionDetectors.ComplexElementFinders
{
    public class FilteringComplexElementFinder : IComplexElementFinder
    {
        private DetectorOfOverlappingElements _collisionDetector;
        private IElementFilter _filter;

        public FilteringComplexElementFinder(DetectorOfOverlappingElements collisionDetector, IElementFilter filter)
        {
            _collisionDetector = collisionDetector;
            _filter = filter;
        }

        public List<IWorldElement> FindCollidingElements(IWorldElement element, ISimpleCollisionModel newPositionOnRoomFieldModel, Position3D newPosition, IEnumerable<IWorldElement> allElements)
        {
            List<IWorldElement> result = new List<IWorldElement>();

            foreach (IWorldElement otherElement in allElements)
            {
                if (otherElement != element && !otherElement.IsVirtual)
                {
                    if (newPositionOnRoomFieldModel.EventuallyCollidesWith(otherElement.MyCollisionModel))
                    {
                        if(!_filter.ElementIsFiltered(otherElement))
                        {
                            if (_collisionDetector.ElementsAreOverlapping(element, newPosition, otherElement))
                            {
                                if (otherElement is IComposition)
                                {
                                    IComposition parent = (IComposition)otherElement;
                                    if (parent.Children.Count > 0)
                                    {
                                        result.AddRange(FindCollidingElements(
                                            element,
                                            newPositionOnRoomFieldModel,
                                            newPosition,
                                            parent.Children));
                                    }
                                }
                                else
                                    result.Add(otherElement);
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
