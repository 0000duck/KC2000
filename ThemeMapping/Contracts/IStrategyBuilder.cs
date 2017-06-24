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
    public interface IStrategyBuilder
    {
        IBehaviourStrategy CreateStrategy(ElementTheme characterTheme, IWorldElementProvider playerProvider, IWorldElementProvider simpleSoldierProvider, IListProvider<IWorldElement> visibleListProvider, IElementCreator elementCreator, IDucker ducker, IDestructibleBodyProvider destructibleBodyProvider);
    }
}
