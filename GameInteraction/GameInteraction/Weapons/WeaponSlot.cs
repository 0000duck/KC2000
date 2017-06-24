using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using GameInteractionContracts;

namespace GameInteraction.Weapons
{
    public class WeaponSlot
    {
        public ElementTheme WeaponTheme { set; get; }

        public IComplexWeapon Weapon { set; get; }
    }
}
