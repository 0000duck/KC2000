﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using ArtificialIntelligence.Contracts;
using ArtificialIntelligence;
using IOInterface;
using BaseTypes;
using BaseContracts;
using CollisionDetection.CollisionDetectors;
using ArtificialIntelligence.PathTesting;
using ArtificialIntelligence.Strategies.PatrolStrategies;
using ArtificialIntelligence.Strategies.FocusStrategies;
using ArtificialIntelligence.EnemyProvider;
using ArtificialIntelligence.DegreeRotater;
using ElementImplementations.Blood;
using ArtificialIntelligence.Strategies.AttackStrategies;
using ArtificialIntelligence.Strategies;
using GameInteractionContracts;
using ArtificialIntelligence.Rotation;
using CollisionDetection.CollisionDetectors.ElementFinders;

namespace ThemeMapping.EnemyCreation.StrategyBuilders
{
    public class NinjaStrategyBuilder : IStrategyBuilder
    {
        private ISoundSharer _soundSharer;
        private IWeaponFirererBuilder _weaponFirererBuilder;
        private IEnemyProviderCreator _enemyProviderCreator;

        public NinjaStrategyBuilder(ISoundSharer soundSharer, IWeaponFirererBuilder weaponFirererBuilder, IEnemyProviderCreator enemyProviderCreator)
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
                new SimpleRecursiveCollisionDetector(new DetectorOfOverlappingElements())), simpleSoldierProvider, 0.6);
            IBehaviourStrategy guardianStrategy = new CircleWalkStrategy(footSwitcher, new CounterClockwiseRotater(), 0.5, 10, stepFreeSpaceTester, 50);

            //focus
            IRotationBehaviourMapper mapper = new FullRotationBehaviourMapper();
            IBehaviourStrategy focusStrategy = new FocusWithRotationStrategy(new EnemyBySoundProvider(playerProvider, simpleSoldierProvider, _soundSharer, new UpdateTimer(0.3)), new Rotater(0.5, mapper), targetDegreeCalculator);

            //attack
            IWorldElementProvider cachingProvider = _enemyProviderCreator.GetEnemyProvider(playerProvider, simpleSoldierProvider, visibleListProvider, targetDegreeCalculator, _soundSharer);

            IBehaviourStrategy walkWith90DegreeStrategy = new SidewardWalkerStrategy(cachingProvider, new UpdateTimer(2.0), 0.4, 0.2, targetDegreeCalculator, Degree.Degree_90, 170);
            IBehaviourStrategy walkWith270DegreeStrategy = new SidewardWalkerStrategy(cachingProvider, new UpdateTimer(2.0), 0.4, 0.2, targetDegreeCalculator, Degree.Degree_270, 170);
            IBehaviourStrategy attackFollowStrategy = new JumpDecorator(new SimpleFollowStrategy(new PositionProvider(cachingProvider), new UpdateTimer(2.0), footSwitcher, 0.4, 0.2, targetDegreeCalculator, 170), simpleSoldierProvider, 450, 1.0);
            IBehaviourStrategy rotateStrategy = new FocusWithRotationStrategy(cachingProvider, new Rotater(0.6, mapper), targetDegreeCalculator);

            IWeaponFirerer bothArmFirerer = _weaponFirererBuilder.CreateWeapon(characterTheme, visibleListProvider, elementCreator, destructibleBodyProvider);
            IBehaviourStrategy movementStrategy = new SideWalkControlStrategy(attackFollowStrategy, walkWith90DegreeStrategy, walkWith270DegreeStrategy, rotateStrategy, new DirectionDecider(stepFreeSpaceTester), new RandomDurationGenerator(0.5, 0.2), 5);
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
