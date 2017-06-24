using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using ArtificialIntelligence.Contracts;
using IOInterface;
using BaseTypes;
using BaseContracts;
using GameInteractionContracts;
using ArtificialIntelligence.Strategies;

namespace ThemeMapping.EnemyCreation.StrategyBuilders
{
    public class EmptyStrategyBuilder : IStrategyBuilder
    {
        IBehaviourStrategy IStrategyBuilder.CreateStrategy(ElementTheme characterTheme, IWorldElementProvider playerProvider, IWorldElementProvider simpleSoldierProvider, IListProvider<IWorldElement> visibleListProvider, IElementCreator elementCreator, IDucker ducker, IDestructibleBodyProvider destructibleBodyProvider)
        {
            return new EmptyStrategy();
        }
    }
}
