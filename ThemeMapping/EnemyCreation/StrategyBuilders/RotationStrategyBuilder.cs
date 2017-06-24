using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using ThemeMapping.Contracts;
using IOInterface;
using BaseTypes;
using BaseContracts;
using ArtificialIntelligence;
using ArtificialIntelligence.Strategies.PatrolStrategies;
using ArtificialIntelligence.DegreeRotater;
using ArtificialIntelligence.Strategies.FocusStrategies;
using ArtificialIntelligence.EnemyProvider;
using ArtificialIntelligence.Strategies.AttackStrategies;
using ArtificialIntelligence.Strategies;
using CollisionDetection.CollisionDetectors;
using GameInteractionContracts;
using ArtificialIntelligence.Rotation;

namespace ThemeMapping.EnemyCreation.StrategyBuilders
{
    public class RotationStrategyBuilder : IStrategyBuilder
    {
        private ISoundSharer _soundSharer;
        private IWeaponFirererBuilder _weaponFirererBuilder;
        private IEnemyProviderCreator _enemyProviderCreator;

        public RotationStrategyBuilder(ISoundSharer soundSharer, IWeaponFirererBuilder weaponFirererBuilder, IEnemyProviderCreator enemyProviderCreator)
        {
            _soundSharer = soundSharer;
            _weaponFirererBuilder = weaponFirererBuilder;
            _enemyProviderCreator = enemyProviderCreator;
        }

        IBehaviourStrategy IStrategyBuilder.CreateStrategy(ElementTheme characterTheme, IWorldElementProvider playerProvider, IWorldElementProvider simpleSoldierProvider, IListProvider<IWorldElement> visibleListProvider, IElementCreator elementCreator, IDucker ducker, IDestructibleBodyProvider destructibleBodyProvider)
         {
            ITargetDegreeCalculator targetDegreeCalculator = new TargetDegreeCalculator();

            IRotationBehaviourMapper mapper = new FullRotationBehaviourMapper();

            //guardian
            IBehaviourStrategy guardianStrategy = new RotateStrategy(new UpdateTimer(7 + MathHelper.GetRandomValueInARange(2, true)), new Rotater(0.6, mapper));

            //focus
            IBehaviourStrategy focusStrategy = new FocusWithRotationStrategy(new EnemyBySoundProvider(playerProvider, simpleSoldierProvider, _soundSharer, new UpdateTimer(0.3)), new Rotater(0.5, mapper), targetDegreeCalculator);

            //attack
            IWorldElementProvider cachingProvider = _enemyProviderCreator.GetEnemyProvider(playerProvider, simpleSoldierProvider, visibleListProvider, targetDegreeCalculator, _soundSharer);

            IWeaponFirerer weaponFirerer = _weaponFirererBuilder.CreateWeapon(characterTheme, visibleListProvider, elementCreator, destructibleBodyProvider);
            IBehaviourStrategy attackStrategy = new RotateAndDuckAttackStrategy(cachingProvider, weaponFirerer, ducker, new Rotater(0.6, mapper), new RandomDurationGenerator(2, 1), targetDegreeCalculator);

            Dictionary<int, IBehaviourStrategy> ByPrioOrderedStrategies = new Dictionary<int, IBehaviourStrategy>();

            ByPrioOrderedStrategies.Add(1, attackStrategy);
            ByPrioOrderedStrategies.Add(2, focusStrategy);
            ByPrioOrderedStrategies.Add(3, guardianStrategy);

            IBehaviourStrategy priorizedStrategy = new PriorizedStrategy(ByPrioOrderedStrategies);
            return priorizedStrategy;
        }
    }
}
