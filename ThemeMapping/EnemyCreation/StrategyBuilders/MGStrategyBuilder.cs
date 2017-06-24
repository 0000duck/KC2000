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
using ArtificialIntelligence.Strategies.PatrolStrategies;
using ArtificialIntelligence;
using ArtificialIntelligence.Strategies.AttackStrategies;
using ArtificialIntelligence.Rotation;
using ArtificialIntelligence.Strategies.FocusStrategies;

namespace ThemeMapping.EnemyCreation.StrategyBuilders
{
    public class MGStrategyBuilder : IStrategyBuilder
    {
        private IEnemyProviderCreator _enemyProviderCreator;
        private IWeaponFirererBuilder _weaponFirererBuilder;

        public MGStrategyBuilder(IEnemyProviderCreator enemyProviderCreator, IWeaponFirererBuilder weaponFirererBuilder)
        {
            _enemyProviderCreator = enemyProviderCreator;
            _weaponFirererBuilder = weaponFirererBuilder;
        }

        IBehaviourStrategy IStrategyBuilder.CreateStrategy(ElementTheme characterTheme, IWorldElementProvider playerProvider, IWorldElementProvider simpleSoldierProvider, IListProvider<IWorldElement> visibleListProvider, IElementCreator elementCreator, IDucker ducker, IDestructibleBodyProvider destructibleBodyProvider)
        {
            IRotationBehaviourMapper rotationMapper = new SimpleStandardBehaviourMapper();
            //guardian
            IBehaviourStrategy guardianStrategy = new RotateStrategy(new UpdateTimer(7 + MathHelper.GetRandomValueInARange(2, true)), new Rotater(0.7, rotationMapper));

            //attack
            ITargetDegreeCalculator targetDegreeCalculator = new TargetDegreeCalculator();
            
            IWorldElementProvider cachingProvider = _enemyProviderCreator.GetEnemyProvider(playerProvider, simpleSoldierProvider, visibleListProvider, targetDegreeCalculator, null);
            MGRotationDecoratorStrategy mgRotationDecoratorStrategy = new MGRotationDecoratorStrategy(cachingProvider, new AcceleratedSpeedProvider(2.5, 7), 6.9);
            IWeaponFirerer weaponFirerer = _weaponFirererBuilder.CreateWeapon(characterTheme, visibleListProvider, elementCreator, destructibleBodyProvider);
            mgRotationDecoratorStrategy.SetWeaponFirerer(weaponFirerer);

            IBehaviourStrategy rotateStrategy = new FocusWithRotationStrategy(mgRotationDecoratorStrategy, new Rotater(0.7, rotationMapper), targetDegreeCalculator);
            IBehaviourStrategy attackStrategy = new SimpleAttackStrategy(mgRotationDecoratorStrategy, rotateStrategy, targetDegreeCalculator, mgRotationDecoratorStrategy);

            Dictionary<int, IBehaviourStrategy> ByPrioOrderedStrategies = new Dictionary<int, IBehaviourStrategy>();

            ByPrioOrderedStrategies.Add(1, attackStrategy);
            ByPrioOrderedStrategies.Add(2, guardianStrategy);

            IBehaviourStrategy priorizedStrategy = new PriorizedStrategy(ByPrioOrderedStrategies);
            mgRotationDecoratorStrategy.SetStrategy(priorizedStrategy);

            return mgRotationDecoratorStrategy;
        }
    }
}
