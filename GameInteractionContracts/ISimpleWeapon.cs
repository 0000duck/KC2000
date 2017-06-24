using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using BaseContracts;

namespace GameInteractionContracts
{
    public interface ISimpleWeapon
    {
        void Fire(Position3D weaponPosition, Position3D targetPosition, IListProvider<IWorldElement> customicedListProvider);
    }
}
