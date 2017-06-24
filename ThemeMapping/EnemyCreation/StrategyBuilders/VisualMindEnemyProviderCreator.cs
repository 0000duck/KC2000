using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using BaseTypes;
using ArtificialIntelligence.EnemyProvider;
using ArtificialIntelligence;
using BaseContracts;
using ArtificialIntelligence.Contracts;
using FrameworkContracts;
using IOInterface.Events;

namespace ThemeMapping.EnemyCreation.StrategyBuilders
{
    public class VisualMindEnemyProviderCreator : IEnemyProviderCreator
    {
        private IEventToSoundMapper _eventToSoundMapper;

        public VisualMindEnemyProviderCreator(IEventToSoundMapper eventToSoundMapper)
        {
            _eventToSoundMapper = eventToSoundMapper;
        }

        IWorldElementProvider IEnemyProviderCreator.GetEnemyProvider(IWorldElementProvider enemyProvider, IWorldElementProvider soldierProvider, IListProvider<IWorldElement> visibleListProvider, ITargetDegreeCalculator targetDegreeCalculator, ISoundSharer soundSharer)
        {
            IWorldElementProvider enemyFilter = new WorldElementDegreeAndDistanceFilter(enemyProvider, soldierProvider, targetDegreeCalculator, 75.0);
            IWorldElementProvider visibleEnemyProvider = new VisibleEnemyProvider(enemyFilter, soldierProvider, visibleListProvider, new VisibilityTester(75), new UpdateTimer(1.5));
            IWorldElementProvider hearableEnemyProvider = new HearableEnemyProvider(enemyProvider, soldierProvider, soundSharer, new UpdateTimer(1));
            IWorldElementProvider earAndEyeCombiner = new EarAndEyeCombiner(visibleEnemyProvider, hearableEnemyProvider);
            IWorldElementProvider cachingProvider = new CachingEnemyProvider(earAndEyeCombiner, 5);
            return new LostVisibilityTriggeredThoughtToTextAdapter(cachingProvider, soldierProvider, 3, _eventToSoundMapper.GetSound(GameEvent.PlayerOutOfSight));
        }
    }
}
