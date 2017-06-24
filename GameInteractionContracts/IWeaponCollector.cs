using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace GameInteractionContracts
{
    public interface IWeaponCollector
    {
        void AddWeaponOwner(IElementGroup weaponOwner);

        void AddWeaponPlaceHolder(IWeaponPlaceHolder weaponPlaceHolder);
    }
}
