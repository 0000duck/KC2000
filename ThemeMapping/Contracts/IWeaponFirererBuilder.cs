using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseContracts;
using BaseTypes;
using IOInterface;
using ArtificialIntelligence.Contracts;

namespace ThemeMapping.Contracts
{
    public interface IWeaponFirererBuilder
    {
        IWeaponFirerer CreateWeapon(ElementTheme characterTheme, IListProvider<IWorldElement> visibleListProvider, IElementCreator elementCreator, IDestructibleBodyProvider destructibleBodyProvider);
    }
}
