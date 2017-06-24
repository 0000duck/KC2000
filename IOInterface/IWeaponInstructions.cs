using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOInterface
{
    public interface IWeaponInstructions
    {
        bool FiredPressed { set; get; }

        bool PreviousWeapon { set; get; }

        bool NextWeapon { set; get; }

        int? Number { set; get; }
    }
}
