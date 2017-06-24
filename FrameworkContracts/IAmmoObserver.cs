using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using GameInteractionContracts;

namespace FrameworkContracts
{
    public interface IAmmoObserver
    {
        void RegisterAmmo(ElementTheme weaponTheme, IComplexAmmo ammo);
    }
}
