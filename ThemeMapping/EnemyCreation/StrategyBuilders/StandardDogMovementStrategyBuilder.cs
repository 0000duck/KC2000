using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using ArtificialIntelligence.Contracts;
using IOInterface;
using BaseTypes;
using BaseContracts;
using ArtificialIntelligence;
using ArtificialIntelligence.PathTesting;
using CollisionDetection.CollisionDetectors;
using ArtificialIntelligence.Strategies.FocusStrategies;
using ArtificialIntelligence.EnemyProvider;
using ArtificialIntelligence.Strategies.PatrolStrategies;
using ElementImplementations.Blood;
using ArtificialIntelligence.DegreeRotater;
using ArtificialIntelligence.Strategies.AttackStrategies;
using ArtificialIntelligence.Strategies;
using GameInteractionContracts;
using CollisionDetection.CollisionDetectors.ElementFinders;

namespace ThemeMapping.EnemyCreation.StrategyBuilders
{
    class StandardDogMovementStrategyBuilder : IStrategyBuilder
    {
        private ISoundSharer _soundSharer;
        private IWeaponFirererBuilder _weaponFirererBuilder;
        private IEnemyProviderCreator _enemyProviderCreator;

        public StandardDogMovementStrategyBuilder(ISoundSharer soundSharer, IWeaponFirererBuilder weaponFirererBuilder, IEnemyProviderCreator enemyProviderCreator)
        {
            _soundSharer = soundSharer;
            _weaponFirererBuilder = weaponFirererBuilder;
            _enemyProviderCreator = enemyProviderCreator;
        }

        IBehaviourStrategy IStrategyBuilder.CreateStrategy(ElementTheme characterTheme, IWorldElementProvider playerProvider, IWorldElementProvider simpleSoldierProvider, IListProvider<IWorldElement> visibleListProvider, IElementCreator elementCreator, IDucker ducker, IDestructibleBodyProvider destructibleBodyProvider)
         {
            FootSwitcher footSwitcher = new FootSwitcher();
            ITargetDegreeCalculator targetDegreeCalculator = new TargetDegreeCalculator();

            //guardian
            IWorldElement worldElement = new StandardWorldElement(new LargePositionOnRoomFieldModel());
            IStepFreeSpaceTester stepFreeSpaceTester = new StepFreeSpaceTester(new FreeSpaceTester(new CollisionByCylinderFinder(
                new RecursiveCollidingElementFinder(new DetectorOfOverlappingElements()), worldElement), visibleListProvider, new StandardWorldElement(), 
                new SimpleRecursiveCollisionDetector(new DetectorOfOverlappingElements())), simpleSoldierProvider, 0.1);
            IBehaviourStrategy guardianStrategy = new CircleWalkStrategy(footSwitcher, new CounterClockwiseRotater(), 0.3, 20, stepFreeSpaceTester, 25);

            //attack
            IWorldElementProvider cachingProvider = _enemyProviderCreator.GetEnemyProvider(playerProvider, simpleSoldierProvider, visibleListProvider, targetDegreeCalculator, _soundSharer);

            IBehaviourStrategy attackFollowStrategy = new AirLineFollowStrategy(new SimpleFollowStrategy(new DiffusePositionProvider(simpleSoldierProvider, cachingProvider, 8, 16, 50, 3, 10), new UpdateTimer(1.5), footSwitcher, 1.0, 0.32, targetDegreeCalculator, 270), cachingProvider, targetDegreeCalculator, 2.0);
            IWeaponFirerer dogBiter = _weaponFirererBuilder.CreateWeapon(characterTheme, visibleListProvider, elementCreator, destructibleBodyProvider);
            IBehaviourStrategy attackStrategy = new SimpleAttackStrategy(cachingProvider, new DogRunDecorator(attackFollowStrategy), targetDegreeCalculator, dogBiter);

            Dictionary<int, IBehaviourStrategy> ByPrioOrderedStrategies = new Dictionary<int, IBehaviourStrategy>();

            ByPrioOrderedStrategies.Add(1, attackStrategy);
            ByPrioOrderedStrategies.Add(2, guardianStrategy);

            IBehaviourStrategy priorizedStrategy = new PriorizedStrategy(ByPrioOrderedStrategies);
            return priorizedStrategy;
        }
    }
}
