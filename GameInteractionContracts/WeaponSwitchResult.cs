using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace GameInteractionContracts
{
    public class WeaponSwitchResult
    {
        public ElementTheme WeaponTheme { set; get; }

        public double Percent { set; get; }
    }
}
