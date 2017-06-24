using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using GameInteraction.BaseImplementations;
using IOInterface;

namespace GameInteraction.Weapons
{
    public class WeaponPlaceHolder : AnimatibleElement, IWeaponPlaceHolder
    {
        public ElementTheme WeaponTheme { set; get; }

        public int WeaponCount { set; get; }

        public ElementTheme AmmoTheme { set; get; }
    }
}
