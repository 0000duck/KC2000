using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence
{
    public class DoubleWeaponFirerer : IWeaponFirerer
    {
        private IWeaponFirerer _weaponOne;
        private IWeaponFirerer _weaponTwo;

        public DoubleWeaponFirerer(IWeaponFirerer weaponOne, IWeaponFirerer weaponTwo)
        {
            _weaponOne = weaponOne;
            _weaponTwo = weaponTwo;
        }


        void IWeaponFirerer.Fire(Position3D weaponOwnerPosition, IWorldElement targetElement, Degree weaponOwnerOrientation)
        {
            _weaponOne.Fire(weaponOwnerPosition, targetElement, weaponOwnerOrientation);
            _weaponTwo.Fire(weaponOwnerPosition, targetElement, weaponOwnerOrientation);
        }
    }
}
