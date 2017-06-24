using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using ThemeMapping.Contracts;
using GameInteractionContracts;
using IOInterface;
using BaseTypes;
using BaseContracts;
using ArtificialIntelligence;
using CollisionDetection.CollisionDetectors;
using ArtificialIntelligence.Strategies.PatrolStrategies;
using ArtificialIntelligence.DegreeRotater;
using ArtificialIntelligence.PathTesting;
using ArtificialIntelligence.Rotation;
using ArtificialIntelligence.Strategies.FocusStrategies;
using ArtificialIntelligence.EnemyProvider;
using ArtificialIntelligence.Strategies.AttackStrategies;
using ArtificialIntelligence.Strategies;
using ArtificialIntelligence.Strategies.Spinning;
using Gravity;
using Sound.Contracts;
using CollisionDetection.CollisionDetectors.ElementFinders;

namespace ThemeMapping.EnemyCreation.StrategyBuilders
{
    public class HelicopterStrategyBuilder : IStrategyBuilder
    {
        private ISoundSharer _soundSharer;
        private IWeaponFirererBuilder _weaponFirererBuilder;
        private IEnemyProviderCreator _enemyProviderCreator;
        private HelicopterCollapseStrategy _helicopterCollapseStrategy;
        private IExplosionManager _explosionManager;
        private ISound _helicopterSound;

        public HelicopterStrategyBuilder(ISoundSharer soundSharer, IWeaponFirererBuilder weaponFirererBuilder, IEnemyProviderCreator enemyProviderCreator,
            HelicopterCollapseStrategy helicopterCollapseStrategy, IExplosionManager explosionManager, ISound helicopterSound)
        {
            _soundSharer = soundSharer;
            _weaponFirererBuilder = weaponFirererBuilder;
            _enemyProviderCreator = enemyProviderCreator;
            _helicopterCollapseStrategy = helicopterCollapseStrategy;
            _explosionManager = explosionManager;
            _helicopterSound = helicopterSound;
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
            IBehaviourStrategy guardianStrategy = new CircleWalkStrategy(footSwitcher, new CounterClockwiseRotater(), 0.6, 15, stepFreeSpaceTester, 400);

            //focus
            IRotationBehaviourMapper mapper = new FullRotationBehaviourMapper();
            IBehaviourStrategy focusStrategy = new FocusWithRotationStrategy(new EnemyBySoundProvider(playerProvider, simpleSoldierProvider, _soundSharer, new UpdateTimer(0.3)), new Rotater(0.7, mapper), targetDegreeCalculator);

            //attack
            IWorldElementProvider cachingProvider = _enemyProviderCreator.GetEnemyProvider(playerProvider, simpleSoldierProvider, visibleListProvider, targetDegreeCalculator, _soundSharer);

            IBehaviourStrategy attackFollowStrategy = new SimpleFollowStrategy(new PositionProvider(cachingProvider), new UpdateTimer(2.0), footSwitcher, 0.7, 0.6, targetDegreeCalculator, 65);
            IBehaviourStrategy rotateStrategy = new FocusWithRotationStrategy(cachingProvider, new Rotater(0.7, mapper), targetDegreeCalculator);
            IWeaponFirerer bothArmFirerer = _weaponFirererBuilder.CreateWeapon(characterTheme, visibleListProvider, elementCreator, destructibleBodyProvider);
            IBehaviourStrategy movementStrategy = new FollowOrRotateStrategy(attackFollowStrategy, rotateStrategy, new FollowDecider(simpleSoldierProvider, new ViewFieldElementProvider(17, -2, 8), new SimpleRecursiveCollisionDetector(new DetectorOfOverlappingElements()), visibleListProvider));
            IBehaviourStrategy attackStrategy = new SimpleAttackStrategy(cachingProvider, movementStrategy, targetDegreeCalculator, bothArmFirerer);

            Dictionary<int, IBehaviourStrategy> ByPrioOrderedStrategies = new Dictionary<int, IBehaviourStrategy>();

            ByPrioOrderedStrategies.Add(1, attackStrategy);
            ByPrioOrderedStrategies.Add(2, focusStrategy);
            ByPrioOrderedStrategies.Add(3, guardianStrategy);

            IBehaviourStrategy priorizedStrategy = new HoverStrategy(new PriorizedStrategy(ByPrioOrderedStrategies), new PercentLooper(0.15, false), 5, simpleSoldierProvider, 50);

            _helicopterCollapseStrategy.SetMainStrategy(priorizedStrategy);

            _helicopterCollapseStrategy.SetSpinningStrategy(new SpinningGravityStrategy(simpleSoldierProvider,
                new SpinningAccelerator(4), new GravitationCalculator(0.01, 100), new Exploder(_explosionManager, DestructionStrength.HelicopterSelfExplosion, 4)));

            return new LoopedSoundUpdater( _helicopterSound, _helicopterCollapseStrategy);
        }
    }
}
