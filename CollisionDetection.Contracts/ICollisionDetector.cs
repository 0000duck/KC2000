using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace CollisionDetection.Contracts
{
    public interface ICollisionDetector
    {
        bool SimpleCollisionTakesPlace(IWorldElement element, ISimpleCollisionModel newPositionOnRoomFieldModel, IEnumerable<IWorldElement> allVolumetricElements);
    }
}
