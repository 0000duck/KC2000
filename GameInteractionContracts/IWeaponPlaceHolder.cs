using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace GameInteractionContracts
{
    public interface IWeaponPlaceHolder
    {
        ElementTheme WeaponTheme { set; get; }

        int WeaponCount { set; get; }

        ElementTheme AmmoTheme { set; get; }
    }
}
