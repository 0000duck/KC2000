using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace CollisionDetection.Contracts
{
    public interface ICollidingElementFinder
    {
        List<IWorldElement> FindCollidingElements(IWorldElement element, ISimpleCollisionModel newPositionOnRoomFieldModel, IEnumerable<IWorldElement> allElements);
    }
}
