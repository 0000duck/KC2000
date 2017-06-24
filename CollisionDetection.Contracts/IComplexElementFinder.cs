using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace CollisionDetection.Contracts
{
    public interface IComplexElementFinder
    {
        List<IWorldElement> FindCollidingElements(IWorldElement element, ISimpleCollisionModel newPositionOnRoomFieldModel, Position3D newPosition, IEnumerable<IWorldElement> allElements);
    }
}
