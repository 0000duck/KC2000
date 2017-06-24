using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using CollisionDetection.Contracts;

namespace CollisionDetection.CollisionDetectors.ComplexElementFinders
{
    public class ComplexElementFinder : IComplexElementFinder
    {
        private DetectorOfOverlappingElements _collisionDetector;

        public ComplexElementFinder(DetectorOfOverlappingElements collisionDetector)
        {
            _collisionDetector = collisionDetector;
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
            return result;
        }
    }
}
