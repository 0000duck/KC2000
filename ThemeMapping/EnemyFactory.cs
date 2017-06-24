using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using IOInterface;
using ArtificialIntelligence.Contracts;
using ArtificialIntelligence;
using ArtificialIntelligence.BodyPartShapes;
using ElementImplementations.CharacterImplementations;
using ArtificialIntelligence.EnemyProvider;
using BaseContracts;
using CollisionDetection.CollisionDetectors;
using ArtificialIntelligence.Strategies.PatrolStrategies;
using ArtificialIntelligence.Strategies.FocusStrategies;
using ArtificialIntelligence.Strategies.AttackStrategies;
using ElementImplementations.WeaponImplementations;
using ArtificialIntelligence.Strategies;
using GameInteraction;
using ArtificialIntelligence.DegreeRotater;
using ThemeMapping.EnemyCreation;
using ThemeMapping.EnemyCreation.BodyBuilders;
using ThemeMapping.EnemyCreation.StrategyBuilders;
using ThemeMapping.Contracts;
using IOInterface.Events;
using FrameworkContracts;
using ThemeMapping.EnemyCreation.CharacterRemovers;
using ArtificialIntelligence.Strategies.Spinning;
using Sound.Contracts;

namespace ThemeMapping
{
    public class EnemyFactory : IEnemyFactory
    {
        private IBloodParticleByBodyPartTriggerer _bloodParticleByBodyPartTriggerer;
        private IBloodParticleByCaliberTriggerer _bloodParticleByCaliberTriggerer;
        private ISoundSharer _soundSharer;
        private IWeaponFirererBuilder _weaponCreator;
        private IEnemyProviderCreator _elementProviderCreator;
        private IQuakeTriggerer _quakeTriggerer;
        private IWeaponLooserFactory _weaponLooserFactory;
        private IEnemyCreationObserver _enemyCreationObserver;
        private IEnemyDestructionObserver _enemyDestructionObserver;
        private IExplosionManager _explosionManager;
        private IParticleManager _particleManager;
        private ICollapseStrategyFactory _collapseStrategyFactory;
        private IBehaviourMapper _behaviourMapper;
        private IBehaviourMapper _onlyStandardBehaviourMapper;
        private IEventToSoundMapper _eventToSoundAndTextMapper;
        private IEventToSoundMapper _eventToTextMapper;

        public EnemyFactory(IBloodParticleByBodyPartTriggerer bloodParticleByBodyPartTriggerer,
            IBloodParticleByCaliberTriggerer bloodParticleByCaliberTriggerer, ISoundSharer soundSharer, IQuakeTriggerer quakeTriggerer,
            IWeaponFirererBuilder weaponFirererBuilder, IEnemyCreationObserver enemyCreationObserver, IEnemyDestructionObserver enemyDestructionObserver,
            IExplosionManager explosionManager, IParticleManager particleManager, IEventToSoundMapper eventToSoundAndTextMapper, IEnemyProviderCreator elementProviderCreator, IEventToSoundMapper eventToTextMapper)
        {
            _bloodParticleByBodyPartTriggerer = bloodParticleByBodyPartTriggerer;
            _bloodParticleByCaliberTriggerer = bloodParticleByCaliberTriggerer;
            _soundSharer = soundSharer;
            _quakeTriggerer = quakeTriggerer;
            _weaponCreator = weaponFirererBuilder;
            _enemyCreationObserver = enemyCreationObserver;
            _enemyDestructionObserver = enemyDestructionObserver;
            _explosionManager = explosionManager;
            _particleManager = particleManager;
            _eventToSoundAndTextMapper = eventToSoundAndTextMapper;
            _eventToTextMapper = eventToTextMapper;
            _elementProviderCreator = elementProviderCreator;
            _weaponLooserFactory = new WeaponLooserFactory();
            _collapseStrategyFactory = new CollapseStrategyFactory(_explosionManager);
            _behaviourMapper = new BehaviourMapper();
            _onlyStandardBehaviourMapper = new StandardBehaviourMapper();
        }

        IWorldElement IEnemyFactory.CreateEnemy(IElement element, IWorldElementProvider playerProvider, IListProvider<IWorldElement> listProvider, IElementCreator elementCreator)
        {
            IEnemyFactory factory = null;

            switch (element.ElementTheme)
            {
                case ElementTheme.SoldierRocket:
                    factory = new EnemyBuilder(new RocketSoldierBodyBuilder(), new WalkForwardStrategyBuilder(new SoundTriggeredThoughtToTextAdapter(_soundSharer, _eventToTextMapper.GetSound(GameEvent.PlayerHeard), 2, 10), _weaponCreator, _elementProviderCreator),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new StandardSoldierCharacterRemoverBuilder(_bloodParticleByBodyPartTriggerer),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _behaviourMapper);
                    break;
                case ElementTheme.SoldierRocketF:
                    factory = new EnemyBuilder(new RocketSoldierBodyBuilder(), new FixStrategyBuilder(new SoundTriggeredThoughtToTextAdapter(_soundSharer, _eventToTextMapper.GetSound(GameEvent.PlayerHeard), 2, 10), _weaponCreator, _elementProviderCreator),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new StandardSoldierCharacterRemoverBuilder(_bloodParticleByBodyPartTriggerer),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _behaviourMapper);
                    break;
                case ElementTheme.SoldierRocketR:
                    factory = new EnemyBuilder(new RocketSoldierBodyBuilder(), new RotationStrategyBuilder(new SoundTriggeredThoughtToTextAdapter(_soundSharer, _eventToTextMapper.GetSound(GameEvent.PlayerHeard), 2, 10), _weaponCreator, _elementProviderCreator),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new StandardSoldierCharacterRemoverBuilder(_bloodParticleByBodyPartTriggerer),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _behaviourMapper);
                    break;
                case ElementTheme.SoldierShotGun:
                    factory = new EnemyBuilder(new ShotGunSoldierBodyBuilder(), new WalkForwardStrategyBuilder(new SoundTriggeredThoughtToTextAdapter(_soundSharer, _eventToTextMapper.GetSound(GameEvent.PlayerHeard), 2, 10), _weaponCreator, _elementProviderCreator),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new StandardSoldierCharacterRemoverBuilder(_bloodParticleByBodyPartTriggerer),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _behaviourMapper);
                    break;
                case ElementTheme.Ninja:
                    factory = new EnemyBuilder(new ShotGunSoldierBodyBuilder(), new NinjaStrategyBuilder(new SoundTriggeredThoughtToTextAdapter(_soundSharer, _eventToTextMapper.GetSound(GameEvent.PlayerHeard), 2, 10), _weaponCreator, _elementProviderCreator),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new StandardSoldierCharacterRemoverBuilder(_bloodParticleByBodyPartTriggerer),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _behaviourMapper);
                    break;
                case ElementTheme.SoldierShotGunF:
                    factory = new EnemyBuilder(new ShotGunSoldierBodyBuilder(), new FixStrategyBuilder(new SoundTriggeredThoughtToTextAdapter(_soundSharer, _eventToTextMapper.GetSound(GameEvent.PlayerHeard), 2, 10), _weaponCreator, _elementProviderCreator),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new StandardSoldierCharacterRemoverBuilder(_bloodParticleByBodyPartTriggerer),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _behaviourMapper);
                    break;
                case ElementTheme.SoldierShotGunR:
                    factory = new EnemyBuilder(new ShotGunSoldierBodyBuilder(), new RotationStrategyBuilder(new SoundTriggeredThoughtToTextAdapter(_soundSharer, _eventToTextMapper.GetSound(GameEvent.PlayerHeard), 2, 10), _weaponCreator, _elementProviderCreator),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new StandardSoldierCharacterRemoverBuilder(_bloodParticleByBodyPartTriggerer),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _behaviourMapper);
                    break;
                case ElementTheme.SoldierPistol:
                    factory = new EnemyBuilder(new PistolSoldierBodyBuilder(), new WalkSidewardStrategyBuilder(new SoundTriggeredThoughtToTextAdapter(_soundSharer, _eventToTextMapper.GetSound(GameEvent.PlayerHeard), 2, 10), _weaponCreator, _elementProviderCreator),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new StandardSoldierCharacterRemoverBuilder(_bloodParticleByBodyPartTriggerer),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _behaviourMapper);
                    break;
                case ElementTheme.SoldierPistolR:
                    factory = new EnemyBuilder(new PistolSoldierBodyBuilder(), new RotationStrategyBuilder(new SoundTriggeredThoughtToTextAdapter(_soundSharer, _eventToTextMapper.GetSound(GameEvent.PlayerHeard), 2, 10), _weaponCreator, _elementProviderCreator),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new StandardSoldierCharacterRemoverBuilder(_bloodParticleByBodyPartTriggerer),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _behaviourMapper);
                    break;
                case ElementTheme.SoldierPistolF:
                    factory = new EnemyBuilder(new PistolSoldierBodyBuilder(), new FixDuckStrategyBuilder(new SoundTriggeredThoughtToTextAdapter(_soundSharer, _eventToTextMapper.GetSound(GameEvent.PlayerHeard), 2, 10), _weaponCreator, _elementProviderCreator),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new StandardSoldierCharacterRemoverBuilder(_bloodParticleByBodyPartTriggerer),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _behaviourMapper);
                    break;
                case ElementTheme.Capitalist1:
                case ElementTheme.Capitalist2:
                case ElementTheme.Capitalist3:
                    factory = new EnemyBuilder(new CapitalistBodyBuilder(), new CapitalistBuilder(new SoundTriggeredThoughtToTextAdapter(_soundSharer, _eventToTextMapper.GetSound(GameEvent.PlayerHeard), 2, 10), _weaponCreator, _elementProviderCreator),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new StandardSoldierCharacterRemoverBuilder(_bloodParticleByBodyPartTriggerer),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _behaviourMapper, 1.6);
                    break;
                case ElementTheme.SoldierMG:
                    factory = new EnemyBuilder(new GiantSoldierBodyBuilder(), new GiantWalkForwardStrategyBuilder(new SoundTriggeredThoughtToTextAdapter(_soundSharer, _eventToTextMapper.GetSound(GameEvent.PlayerHeard), 4, 10), _weaponCreator, _elementProviderCreator, _quakeTriggerer),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new GiantCharacterRemoverBuilder(_bloodParticleByBodyPartTriggerer),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _behaviourMapper);
                    break;
                case ElementTheme.FlyingSoldierFlameThrower:
                    factory = new EnemyBuilder(new FlyingGiantBuilder(_explosionManager, _particleManager), new FlyingGiantStrategyBuilder(new SoundTriggeredThoughtToTextAdapter(_soundSharer, _eventToTextMapper.GetSound(GameEvent.PlayerHeard), 4, 10), _weaponCreator, _elementProviderCreator),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new GiantCharacterRemoverBuilder(_bloodParticleByBodyPartTriggerer),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _onlyStandardBehaviourMapper);
                    break;
                case ElementTheme.SoldierTank:
                    factory = new EnemyBuilder(new TankBuilder(_explosionManager, _particleManager), new TankStrategyBuilder(new SoundTriggeredThoughtToTextAdapter(_soundSharer, _eventToTextMapper.GetSound(GameEvent.PlayerHeard), 4, 10), _weaponCreator, _elementProviderCreator),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new GiantCharacterRemoverBuilder(_bloodParticleByBodyPartTriggerer),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _onlyStandardBehaviourMapper);
                    break;
                case ElementTheme.SoldierRobot:
                    factory = new EnemyBuilder(new RobotBuilder(_particleManager), new RobotWalkForwardStrategyBuilder(new SoundTriggeredThoughtToTextAdapter(_soundSharer, _eventToTextMapper.GetSound(GameEvent.PlayerHeard), 4, 10), _weaponCreator, _elementProviderCreator, _quakeTriggerer),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new RobotRemoverBuilder(_bloodParticleByBodyPartTriggerer, _eventToSoundAndTextMapper.GetSound(GameEvent.Explosion)),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _behaviourMapper);
                    break;
                case ElementTheme.LastRobot:
                    factory = new EnemyBuilder(new LastRobotBuilder(_particleManager), new LastRobotWalkForwardStrategyBuilder(new SoundTriggeredThoughtToTextAdapter(_soundSharer, _eventToTextMapper.GetSound(GameEvent.PlayerHeard), 4, 10), _weaponCreator, _elementProviderCreator, _quakeTriggerer),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new RobotRemoverBuilder(_bloodParticleByBodyPartTriggerer, _eventToSoundAndTextMapper.GetSound(GameEvent.Explosion)),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _behaviourMapper);
                    break;
                case ElementTheme.Helicopter:
                    ISound helicopterSound = _eventToSoundAndTextMapper.GetSound(GameEvent.HelicopterRotor);
                    HelicopterCollapseStrategy helicopterCollapseStrategy = new HelicopterCollapseStrategy(new Smoker(_particleManager, new UpdateTimer(0.3), Animation.Smoke, 3));
                    factory = new EnemyBuilder(new HelicopterBuilder(helicopterCollapseStrategy, _particleManager), new HelicopterStrategyBuilder(_soundSharer, _weaponCreator,
                        _elementProviderCreator, helicopterCollapseStrategy, _explosionManager, helicopterSound),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new HelicopterRemoverBuilder(_bloodParticleByBodyPartTriggerer, helicopterSound, false),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _onlyStandardBehaviourMapper);
                    break;
                case ElementTheme.HelicopterMGOnlyB:
                    helicopterSound = _eventToSoundAndTextMapper.GetSound(GameEvent.HelicopterRotor);
                    helicopterCollapseStrategy = new HelicopterCollapseStrategy(new Smoker(_particleManager, new UpdateTimer(0.3), Animation.Smoke, 3));
                    factory = new EnemyBuilder(new HelicopterBuilder(helicopterCollapseStrategy, _particleManager), new HelicopterBackwardStrategyBuilder(_soundSharer, _weaponCreator,
                        _elementProviderCreator, helicopterCollapseStrategy, _explosionManager, helicopterSound),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new HelicopterRemoverBuilder(_bloodParticleByBodyPartTriggerer, helicopterSound, true),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _onlyStandardBehaviourMapper);
                    break;
                case ElementTheme.Dog:
                    factory = new EnemyBuilder(new DogBodyBuilder(), new StandardDogMovementStrategyBuilder(_soundSharer, _weaponCreator, new DistanceEnemyProviderCreator()),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new DogCharacterRemoverBuilder(_bloodParticleByBodyPartTriggerer),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _behaviourMapper);
                    break;
                case ElementTheme.DogF:
                    factory = new EnemyBuilder(new DogBodyBuilder(), new EmptyStrategyBuilder(),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new DogCharacterRemoverBuilder(_bloodParticleByBodyPartTriggerer),
                        _weaponLooserFactory, new EmptyDestructionObserver(), _collapseStrategyFactory, _behaviourMapper);
                    break;
                case ElementTheme.AutoMG:
                    factory = new EnemyBuilder(new MGBuilder(_particleManager), new MGStrategyBuilder(new MGEnemyProviderCreator(), _weaponCreator),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new MGRemoverBuilder(_particleManager),
                        _weaponLooserFactory, new EmptyDestructionObserver(), _collapseStrategyFactory, _behaviourMapper);
                    break;
            }

            if (element.ElementTheme != ElementTheme.DogF && element.ElementTheme != ElementTheme.AutoMG)
                _enemyCreationObserver.EnemyCreated();

            return factory.CreateEnemy(element, playerProvider, listProvider, elementCreator);
        }
    }
}
