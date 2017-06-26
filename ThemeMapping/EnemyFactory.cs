using GameInteractionContracts;
using BaseTypes;
using IOInterface;
using ArtificialIntelligence.Contracts;
using ArtificialIntelligence;
using ArtificialIntelligence.EnemyProvider;
using BaseContracts;
using ThemeMapping.EnemyCreation;
using ThemeMapping.EnemyCreation.BodyBuilders;
using ThemeMapping.EnemyCreation.StrategyBuilders;
using ThemeMapping.Contracts;
using IOInterface.Events;
using FrameworkContracts;
using ThemeMapping.EnemyCreation.CharacterRemovers;

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
                case ElementTheme.SoldierShotGun:
                    factory = new EnemyBuilder(new ShotGunSoldierBodyBuilder(), new WalkForwardStrategyBuilder(new SoundTriggeredThoughtToTextAdapter(_soundSharer, _eventToTextMapper.GetSound(GameEvent.PlayerHeard), 2, 10), _weaponCreator, _elementProviderCreator),
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
                case ElementTheme.Dog:
                    factory = new EnemyBuilder(new DogBodyBuilder(), new StandardDogMovementStrategyBuilder(_soundSharer, _weaponCreator, new DistanceEnemyProviderCreator()),
                        _bloodParticleByCaliberTriggerer, _bloodParticleByBodyPartTriggerer, new DogCharacterRemoverBuilder(_bloodParticleByBodyPartTriggerer),
                        _weaponLooserFactory, _enemyDestructionObserver, _collapseStrategyFactory, _behaviourMapper);
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
