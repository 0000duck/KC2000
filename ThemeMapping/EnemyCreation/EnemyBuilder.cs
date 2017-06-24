using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using IOInterface;
using BaseContracts;
using ThemeMapping.Contracts;
using ArtificialIntelligence.EnemyProvider;
using ArtificialIntelligence;
using CollisionDetection.CollisionDetectors;
using ArtificialIntelligence.Contracts;
using GameInteraction;
using ElementImplementations.CharacterImplementations;
using ArtificialIntelligence.Strategies;
using BloodEffects;
using CollisionDetection.Contracts;
using CollisionDetection.CollisionDetectors.ComplexElementFinders;
using CollisionDetection.CollisionDetectors.ElementFinders;

namespace ThemeMapping.EnemyCreation
{
    public class EnemyBuilder : IEnemyFactory
    {
        private IBodyBuilder _bodyBuilder;
        private IStrategyBuilder _strategyBuilder;
        private IBloodParticleByBodyPartTriggerer _bloodParticleByBodyPartTriggerer;
        private IBloodParticleByCaliberTriggerer _bloodParticleByCaliberTriggerer;
        private ICharacterRemoverBuilder _characterRemoverBuilder;
        private IWeaponLooserFactory _weaponLooserFactory;
        private IEnemyDestructionObserver _enemyDestructionObserver;
        private IComplexElementFinder _complexElementFinder = new ComplexElementFinder(new DetectorOfOverlappingElements());
        private ICollapseStrategyFactory _collapseStrategyFactory;
        private IBehaviourMapper _behaviourMapper;
        private double _collapseTime;
        private double _collapseTimeWithoutLegs;


        public EnemyBuilder(IBodyBuilder bodyBuilder, IStrategyBuilder strategyBuilder, IBloodParticleByCaliberTriggerer bloodParticleByCaliberTriggerer,
            IBloodParticleByBodyPartTriggerer bloodParticleByBodyPartTriggerer,  ICharacterRemoverBuilder characterRemoverBuilder,
            IWeaponLooserFactory weaponLooserFactory, IEnemyDestructionObserver enemyDestructionObserver, ICollapseStrategyFactory collapseStrategyFactory, IBehaviourMapper behaviourMapper,
            double collapseTime = 0.8, double collapseTimeWithoutLegs = 0.5)
        {
            _bodyBuilder = bodyBuilder;
            _strategyBuilder = strategyBuilder;
            _bloodParticleByBodyPartTriggerer = bloodParticleByBodyPartTriggerer;
            _bloodParticleByCaliberTriggerer = bloodParticleByCaliberTriggerer;
            _characterRemoverBuilder = characterRemoverBuilder;
            _weaponLooserFactory = weaponLooserFactory;
            _enemyDestructionObserver = enemyDestructionObserver;
            _collapseStrategyFactory = collapseStrategyFactory;
            _behaviourMapper = behaviourMapper;
            _collapseTime = collapseTime;
            _collapseTimeWithoutLegs = collapseTimeWithoutLegs;
        }

        IWorldElement IEnemyFactory.CreateEnemy(IElement element, IWorldElementProvider playerProvider, IListProvider<IWorldElement> listProvider, IElementCreator elementCreator)
        {
            SimpleEnemyProvider simpleSoldierProvider = new SimpleEnemyProvider();
            IListProvider<IWorldElement> visibleListProvider = new ViewFieldElementListProvider(simpleSoldierProvider, listProvider,
                new UpdateTimer(3.0), new EventualElementFinder(), new ViewFieldElementProvider(70, 5, 100), 2.0);

            IDucker ducker = new ArtificialIntelligence.Ducker(new RandomDurationGenerator(2, 1), 0.4);

            IDestructibleBodyProvider destructibleBodyProvider = new DestructibleBodyProvider();
            IBehaviourStrategy mainStrategy = _strategyBuilder.CreateStrategy(element.ElementTheme, playerProvider, simpleSoldierProvider, visibleListProvider, elementCreator, ducker, destructibleBodyProvider);

            CollapsedBodyShrinker collapsedBodyReplacer = new CollapsedBodyShrinker(simpleSoldierProvider, 1.0);

            
            IDestructionObserver weaponLooser = _weaponLooserFactory.CreateWeaponLooser(element.ElementTheme, simpleSoldierProvider, elementCreator);
            IEnemyDestructionObserver enemyDestructionObserver = new EnemyDestructionObserver(_enemyDestructionObserver);
            IBehaviourStrategy collapseStrategy = _collapseStrategyFactory.BuildCollapseStrategy(element.ElementTheme, mainStrategy, _collapseTime, _collapseTimeWithoutLegs, weaponLooser, collapsedBodyReplacer, enemyDestructionObserver);

            ICharacterRemover characterRemover = _characterRemoverBuilder.CreateCharacterRemover(elementCreator, simpleSoldierProvider, destructibleBodyProvider, enemyDestructionObserver);

            BloodExplosionNotifier bloodExplosionNotifier = new BloodExplosionNotifier(_bloodParticleByBodyPartTriggerer, _bloodParticleByCaliberTriggerer);

            IDestructibleBody destructibleBody = _bodyBuilder.CreateBody((IDestructionObserver)collapseStrategy, weaponLooser, characterRemover, bloodExplosionNotifier, bloodExplosionNotifier, _collapseTime, _collapseTimeWithoutLegs, ducker);
            IWorldElement worldElement = new VolitionDrivenElement(collapseStrategy, destructibleBody, visibleListProvider, new ImpulseConverter(), _behaviourMapper, characterRemover, _complexElementFinder);
            simpleSoldierProvider.SetEnemy(worldElement);
            destructibleBodyProvider.SetDestructibleBody(destructibleBody);

            return worldElement;
        }
    }
}
