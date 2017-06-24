using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using BaseContracts;
using ArtificialIntelligence.Contracts;

namespace ThemeMapping.Contracts
{
    public interface IEnemyProviderCreator
    {
        IWorldElementProvider GetEnemyProvider(IWorldElementProvider enemyProvider, IWorldElementProvider soldierProvider, IListProvider<IWorldElement> visibleListProvider, ITargetDegreeCalculator targetDegreeCalculator, ISoundSharer soundSharer);
    }
}
