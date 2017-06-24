using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using GameInteractionContracts;
using IOInterface;

namespace FrameworkImplementations.Player
{
    public class AmmoPerWeaponCounter : IAmmoObserver, IAmmoPerWeaponCounter
    {
        private Dictionary<ElementTheme, IComplexAmmo> _ammoDic = new Dictionary<ElementTheme, IComplexAmmo>();

        void IAmmoObserver.RegisterAmmo(ElementTheme weaponTheme, IComplexAmmo ammo)
        {
            if (!_ammoDic.ContainsKey(weaponTheme))
                _ammoDic.Add(weaponTheme, ammo);
        }

        int IAmmoPerWeaponCounter.GetAmmoCountOfWeapon(ElementTheme weaponTheme)
        {
            if (_ammoDic.ContainsKey(weaponTheme))
                return _ammoDic[weaponTheme].Count;

            return 0;
        }
    }
}
