using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace ArtificialIntelligence.Contracts
{
    public interface IWeaponFirerer
    {
        void Fire(Position3D weaponOwnerPosition, IWorldElement targetElement, Degree weaponOwnerOrientation);
    }
}
