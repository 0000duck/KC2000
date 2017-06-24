using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using IOInterface;
using GameInteractionContracts;
using BaseTypes;

namespace ThemeMapping.Contracts
{
    public interface IWeaponLooserFactory
    {
        IDestructionObserver CreateWeaponLooser(ElementTheme character, IWorldElementProvider characterProvider, IElementCreator elementCreator);
    }
}
