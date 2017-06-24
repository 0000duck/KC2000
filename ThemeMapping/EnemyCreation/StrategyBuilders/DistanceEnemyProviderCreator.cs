using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using BaseTypes;
using BaseContracts;
using ArtificialIntelligence.Contracts;
using ArtificialIntelligence.EnemyProvider;

namespace ThemeMapping.EnemyCreation.StrategyBuilders
{
    class DistanceEnemyProviderCreator : IEnemyProviderCreator
    {
        IWorldElementProvider IEnemyProviderCreator.GetEnemyProvider(IWorldElementProvider enemyProvider, IWorldElementProvider soldierProvider, IListProvider<IWorldElement> visibleListProvider, ITargetDegreeCalculator targetDegreeCalculator, ISoundSharer soundSharer)
        {
            IWorldElementProvider enemyFilter = new EnemyByDistanceFilter(enemyProvider, soldierProvider, 50.0);

            return enemyFilter;
        }
    }
}
