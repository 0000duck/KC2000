using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace GameInteractionContracts
{
    public class ComplexWeaponResult
    {
        public Behaviour Behaviour { set; get; }

        public double Percent { set; get; }

        public int? AmmoCount { set; get; }

        public bool NewShotTriggered { set; get;}
    }
}
