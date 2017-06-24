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
using CollisionDetection.CollisionDetectors;
using ArtificialIntelligence.Strategies.PatrolStrategies;
using ArtificialIntelligence.PathTesting;
using ElementImplementations.Blood;
using ArtificialIntelligence.DegreeRotater;
using ArtificialIntelligence.Strategies.FocusStrategies;
using ArtificialIntelligence.EnemyProvider;
using ArtificialIntelligence.Strategies.AttackStrategies;
using ArtificialIntelligence.Strategies;
using GameInteractionContracts;
using ArtificialIntelligence.Rotation;
using CollisionDetection.CollisionDetectors.ElementFinders;

namespace ThemeMapping.EnemyCreation.StrategyBuilders
{
    public class RobotWalkForwardStrategyBuilder : IStrategyBuilder
    {
        private ISoundSharer _soundSharer;
        private IWeaponFirererBuilder _weaponFirererBuilder;
        private IEnemyProviderCreator _enemyProviderCreator;
        private IQuakeTriggerer _quakeTriggerer;

        public RobotWalkForwardStrategyBuilder(ISoundSharer soundSharer, IWeaponFirererBuilder weaponFirererBuilder, IEnemyProviderCreator enemyProviderCreator, IQuakeTriggerer quakeTriggerer)
        {
            _soundSharer = soundSharer;
            _weaponFirererBuilder = weaponFirererBuilder;
            _enemyProviderCreator = enemyProviderCreator;
            _quakeTriggerer = quakeTriggerer;
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
            IBehaviourStrategy guardianStrategy = new CircleWalkStrategy(footSwitcher, new CounterClockwiseRotater(), 0.4, 7, stepFreeSpaceTester, 150);

            //focus
            IRotationBehaviourMapper mapper = new FullRotationBehaviourMapper();
            IBehaviourStrategy focusStrategy = new FocusWithRotationStrategy(new EnemyBySoundProvider(playerProvider, simpleSoldierProvider, _soundSharer, new UpdateTimer(0.3)), new Degree90Rotator(0.7), targetDegreeCalculator);

            //attack
            IWorldElementProvider cachingProvider = _enemyProviderCreator.GetEnemyProvider(playerProvider, simpleSoldierProvider, visibleListProvider, targetDegreeCalculator, _soundSharer);

            IBehaviourStrategy attackFollowStrategy = new SimpleFollowStrategy(new PositionProvider(cachingProvider), new UpdateTimer(2.0), footSwitcher, 0.7, 0.3, targetDegreeCalculator, 180);
            IBehaviourStrategy rotateStrategy = new FocusWithRotationStrategy(cachingProvider, new Degree90Rotator(0.7), targetDegreeCalculator);
            IWeaponFirerer bothArmFirerer = _weaponFirererBuilder.CreateWeapon(characterTheme, visibleListProvider, elementCreator, destructibleBodyProvider);
            IBehaviourStrategy movementStrategy = new FollowOrRotateStrategy(attackFollowStrategy, rotateStrategy, new FollowDecider(simpleSoldierProvider, new ViewFieldElementProvider(3.6, -0.6, 2), new SimpleRecursiveCollisionDetector(new DetectorOfOverlappingElements()), visibleListProvider));
            IBehaviourStrategy attackStrategy = new SimpleAttackStrategy(cachingProvider, movementStrategy, targetDegreeCalculator, bothArmFirerer);

            Dictionary<int, IBehaviourStrategy> ByPrioOrderedStrategies = new Dictionary<int, IBehaviourStrategy>();

            ByPrioOrderedStrategies.Add(1, attackStrategy);
            ByPrioOrderedStrategies.Add(2, focusStrategy);
            ByPrioOrderedStrategies.Add(3, guardianStrategy);

            IBehaviourStrategy priorizedStrategy = new PriorizedStrategy(ByPrioOrderedStrategies);

            IBehaviourStrategy quakeDecorator = new StepQuakeStrategy(priorizedStrategy, _quakeTriggerer, 0.7);

            return quakeDecorator;
        }
    }
}
