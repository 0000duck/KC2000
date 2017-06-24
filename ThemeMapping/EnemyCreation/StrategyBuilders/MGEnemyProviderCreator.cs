using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using BaseTypes;
using ArtificialIntelligence.EnemyProvider;
using BaseContracts;
using ArtificialIntelligence.Contracts;
using ArtificialIntelligence;

namespace ThemeMapping.EnemyCreation.StrategyBuilders
{
    public class MGEnemyProviderCreator : IEnemyProviderCreator
    {
        IWorldElementProvider IEnemyProviderCreator.GetEnemyProvider(IWorldElementProvider enemyProvider, IWorldElementProvider soldierProvider, IListProvider<IWorldElement> visibleListProvider, ITargetDegreeCalculator targetDegreeCalculator, ISoundSharer soundSharer)
        {
            IWorldElementProvider enemyFilter = new WorldElementDegreeAndDistanceFilter(enemyProvider, soldierProvider, targetDegreeCalculator, 75.0);
            IWorldElementProvider visibleEnemyProvider = new VisibleEnemyProvider(enemyFilter, soldierProvider, visibleListProvider, new VisibilityTester(75), new UpdateTimer(1.5));
            IWorldElementProvider cachingProvider = new CachingEnemyProvider(visibleEnemyProvider, 8);
            return cachingProvider;
        }
    }
}
