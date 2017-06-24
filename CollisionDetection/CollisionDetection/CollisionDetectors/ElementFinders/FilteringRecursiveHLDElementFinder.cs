using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Contracts;
using BaseTypes;

namespace CollisionDetection.CollisionDetectors.ElementFinders
{
    public class FilteringRecursiveHLDElementFinder : ICollidingElementFinder
    {
        private IDetectorOfOverlappingElements _detectorOfOverlappingElements;
        private IElementFilter _filter;

        public FilteringRecursiveHLDElementFinder(IDetectorOfOverlappingElements detectorOfOverlappingElements, IElementFilter filter)
        {
            _detectorOfOverlappingElements = detectorOfOverlappingElements;
            _filter = filter;
        }

        List<IWorldElement> ICollidingElementFinder.FindCollidingElements(IWorldElement element, ISimpleCollisionModel newPositionOnRoomFieldModel, IEnumerable<IWorldElement> allElements)
        {
            List<IWorldElement> result = new List<IWorldElement>();

            foreach (IWorldElement otherElement in allElements)
            {
                if (otherElement != element && !otherElement.IsVirtual)
                {
                    if (newPositionOnRoomFieldModel.EventuallyCollidesWith(otherElement.MyCollisionModel))
                    {
                        if (!_filter.ElementIsFiltered(otherElement))
                        {
                            if (_detectorOfOverlappingElements.ElementsAreOverlapping(element, element.Position, otherElement))
                            {
                                if (otherElement is IComposition)
                                {
                                    IComposition parent = (IComposition)otherElement;
                                    if (parent.Children.Count > 0)
                                    {
                                        result.AddRange(((ICollidingElementFinder)this).FindCollidingElements(
                                            element,
                                            newPositionOnRoomFieldModel,
                                            parent.Children));
                                    }
                                }
                                else if (otherElement is IHighLevelOfDetail)
                                {
                                    result.AddRange(((ICollidingElementFinder)this).FindCollidingElements(
                                            element,
                                            newPositionOnRoomFieldModel,
                                            (otherElement as IHighLevelOfDetail).GetHigherDetails()));
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
