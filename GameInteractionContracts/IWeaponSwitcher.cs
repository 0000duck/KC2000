using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace GameInteractionContracts
{
    public interface IWeaponSwitcher
    {
        void StartSwitching(ElementTheme currentWeapon, ElementTheme desiredWeapon);

        bool IsSwitching();

        WeaponSwitchResult GetResult();
    }
}
