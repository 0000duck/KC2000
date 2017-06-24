using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using CollisionDetection.Contracts;

namespace CollisionDetection.CollisionDetectors.ElementFinders
{
    public class EventualElementFinder : ICollidingElementFinder
    {
        List<IWorldElement> ICollidingElementFinder.FindCollidingElements(IWorldElement element, ISimpleCollisionModel newPositionOnRoomFieldModel, IEnumerable<IWorldElement> allElements)
        {
            List<IWorldElement> result = new List<IWorldElement>();

            foreach (IWorldElement movableObject in allElements)
            {
                if (movableObject != element && !movableObject.IsVirtual)
                {
                    if (newPositionOnRoomFieldModel.EventuallyCollidesWith(movableObject.MyCollisionModel))
                    {
                        result.Add(movableObject); 
                    }
                }
            }
            return result;
        }
    }
}
