using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace GameInteractionContracts
{
    public interface IAmmoPerWeaponCounter
    {
        int GetAmmoCountOfWeapon(ElementTheme weaponTheme);
    }
}
