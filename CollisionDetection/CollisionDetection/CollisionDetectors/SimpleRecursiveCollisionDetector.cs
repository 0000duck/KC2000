using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Elements;
using BaseTypes;
using CollisionDetection.Contracts;

namespace CollisionDetection.CollisionDetectors
{
    public class SimpleRecursiveCollisionDetector : ICollisionDetector
    {
        private DetectorOfOverlappingElements CollisionDetector { set; get; }

        public SimpleRecursiveCollisionDetector(DetectorOfOverlappingElements collisionDetector)
        {
            CollisionDetector = collisionDetector;
        }

        public bool SimpleCollisionTakesPlace(IWorldElement element, ISimpleCollisionModel newPositionOnRoomFieldModel, IEnumerable<IWorldElement> allVolumetricElements)
        {
            foreach (IWorldElement movableObject in allVolumetricElements)
            {
                if (movableObject != element && !movableObject.IsVirtual)
                {
                    if (newPositionOnRoomFieldModel.EventuallyCollidesWith(movableObject.MyCollisionModel))
                    {
                        if (CollisionDetector.ElementsAreOverlapping(element, element.Position, movableObject))
                        {
                            if (movableObject is IComposition)
                            {
                                IComposition parent = (IComposition)movableObject;
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
            return false;
        }
    }
}
