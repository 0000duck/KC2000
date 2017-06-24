using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using ArtificialIntelligence.Contracts;
using IOInterface;
using ArtificialIntelligence;
using BaseTypes;
using CollisionDetection.CollisionDetectors.ElementFinders;
using CollisionDetection.CollisionDetectors;
using ArtificialIntelligence.Rotation;
using ArtificialIntelligence.Strategies.FocusStrategies;
using ArtificialIntelligence.Strategies.AttackStrategies;
using ArtificialIntelligence.EnemyProvider;
using ArtificialIntelligence.PathTesting;
using ArtificialIntelligence.Strategies.PatrolStrategies;
using ArtificialIntelligence.DegreeRotater;
using ArtificialIntelligence.Strategies;
using BaseContracts;
using GameInteractionContracts;

namespace ThemeMapping.EnemyCreation.StrategyBuilders
{
    public class TankStrategyBuilder : IStrategyBuilder
  {
        private ISoundSharer _soundSharer;
        private IWeaponFirererBuilder _weaponFirererBuilder;
        private IEnemyProviderCreator _enemyProviderCreator;

        public TankStrategyBuilder(ISoundSharer soundSharer, IWeaponFirererBuilder weaponFirererBuilder, IEnemyProviderCreator enemyProviderCreator)
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
                new SimpleRecursiveCollisionDetector(new DetectorOfOverlappingElements())), simpleSoldierProvider, 1);
            IBehaviourStrategy guardianStrategy = new CircleWalkStrategy(footSwitcher, new CounterClockwiseRotater(), 0.3, 10, stepFreeSpaceTester, 100);

            //focus
            IRotationBehaviourMapper mapper = new FullRotationBehaviourMapper();
            IBehaviourStrategy focusStrategy = new FocusWithRotationStrategy(new EnemyBySoundProvider(playerProvider, simpleSoldierProvider, _soundSharer, new UpdateTimer(0.3)), new Rotater(0.7, mapper), targetDegreeCalculator);

            //attack
            IWorldElementProvider cachingProvider = _enemyProviderCreator.GetEnemyProvider(playerProvider, simpleSoldierProvider, visibleListProvider, targetDegreeCalculator, _soundSharer);

            IBehaviourStrategy attackFollowStrategy = new SimpleFollowStrategy(new PositionProvider(cachingProvider), new UpdateTimer(2.0), footSwitcher, 0.5, 0.3, targetDegreeCalculator, 100);
            IBehaviourStrategy rotateStrategy = new FocusWithRotationStrategy(cachingProvider, new Rotater(0.7, mapper), targetDegreeCalculator);
            IWeaponFirerer bothArmFirerer = _weaponFirererBuilder.CreateWeapon(characterTheme, visibleListProvider, elementCreator, destructibleBodyProvider);
            IBehaviourStrategy movementStrategy = new FollowOrRotateStrategy(attackFollowStrategy, rotateStrategy, new FollowDecider(simpleSoldierProvider, new ViewFieldElementProvider(3.6, -0.6, 2), new SimpleRecursiveCollisionDetector(new DetectorOfOverlappingElements()), visibleListProvider));
            IBehaviourStrategy attackStrategy = new SimpleAttackStrategy(cachingProvider, movementStrategy, targetDegreeCalculator, bothArmFirerer);

            Dictionary<int, IBehaviourStrategy> ByPrioOrderedStrategies = new Dictionary<int, IBehaviourStrategy>();

            ByPrioOrderedStrategies.Add(1, attackStrategy);
            ByPrioOrderedStrategies.Add(2, focusStrategy);
            ByPrioOrderedStrategies.Add(3, guardianStrategy);

            IBehaviourStrategy priorizedStrategy = new PriorizedStrategy(ByPrioOrderedStrategies);


            return priorizedStrategy;
        }
    }
}
