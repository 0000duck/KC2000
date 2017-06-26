using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteraction.BaseImplementations;
using IOInterface;
using GameInteraction;
using BaseTypes;
using CollisionDetection;
using GameInteraction.Weapons;
using ElementImplementations.CharacterImplementations;
using ElementImplementations.AmmoImplementations;
using ElementImplementations.WeaponImplementations;
using ElementImplementations;
using ElementImplementations.DoorImplementations;
using GameInteractionContracts;
using ArtificialIntelligence.Contracts;
using ArtificialIntelligence.Strategies;
using ArtificialIntelligence.Strategies.AttackStrategies;
using ArtificialIntelligence.EnemyProvider;
using ArtificialIntelligence;
using ArtificialIntelligence.Strategies.PatrolStrategies;
using ArtificialIntelligence.DegreeRotater;
using BaseContracts;
using ArtificialIntelligence.Strategies.FocusStrategies;
using CollisionDetection.CollisionDetectors;
using CollisionDetection.Contracts;
using ArtificialIntelligence.BodyPartShapes;
using CollisionDetection.Elements;
using ElementImplementations.Blood;
using FrameworkContracts;
using ElementImplementations.BoxImplementations;
using IOInterface.Events;
using ElementImplementations.ComplexElementImplementations;
using CollisionDetection.Filter;
using BloodEffects.Contracts;
using BloodEffects;
using CollisionDetection.CollisionDetectors.ComplexElementFinders;

namespace ThemeMapping
{
    public class ElementFactory : IElementFactory
    {
        private ICommunicationElementFactory CommunicationElementFactory { set; get; }
        private IExplosionManager ExplosionManager { set; get; }
        private IBulletManager BulletManager { set; get; }
        
        private IParticleManager ParticleManager { set; get; }
        private SimpleEnemyProvider EnemyProvider { set; get; }
        private IListProviderProvider<IWorldElement> ListProviderProvider { set; get; }
        private ISoundObserver _soundObserver;
        private IMultiWeaponRenderer _multiWeaponRenderer;
        private IPlayerObserver _playerObserver;
        private IPlayerInstructionProvider _playerInstructionProvider;
        private IElementCreatorProvider _elementCreatorProvider;
        private IQuakeTriggerer _quakeTriggerer;

        private IWeaponCollector _weaponCollector;
        private IDoorOpener _doorOpener;
        private IFullVulnerable _playerVulnerability;
        private IEnemyFactory _enemyFactory;

        private IBloodEffectCreator _bloodEffectCreator;
        private IBloodParticleByBodyPartTriggerer _bloodParticleByBodyPartTriggerer;
        private IEventToSoundMapper _eventToSoundMapper;
        private ISphereDestructionTriggerer _sphereDestructionTriggererForFireBalls;
        private IComplexElementFinder _complexElementFinder = new ComplexElementFinder(new DetectorOfOverlappingElements());
        private IComplexElementFinder _spriteFilteringcomplexElementFinder = new FilteringComplexElementFinder(new DetectorOfOverlappingElements(), new SpriteFilter());

        private IBloodAnimationSizeMapper _smallCaliberBloodMapper;
        private IBloodAnimationSizeMapper _bigCaliberBloodMapper;

        private IDestructionRegistration _fistDestructionRegistration;
        private IAmmoObserver _ammoObserver;

        public ElementFactory(ICommunicationElementFactory communicationElementFactory, IExplosionManager explosionManager, IBulletManager playerBulletManager, 
            IParticleManager particleMananger, IListProviderProvider<IWorldElement> listProviderProvider,
            IMultiWeaponRenderer multiWeaponRenderer, IPlayerObserver playerObserver, IQuakeTriggerer quakeTriggerer,
            IPlayerInstructionProvider playerInstructionProvider, IElementCreatorProvider elementCreatorProvider, IWeaponCollector weaponCollector
            , IDoorOpener doorOpener, IFullVulnerable playerVulnerability, IEnemyFactory enemyFactory, ISoundObserver soundObserver, SimpleEnemyProvider playerProvider,
            IBloodEffectCreator bloodEffectCreator, IBloodParticleByBodyPartTriggerer bloodParticleByBodyPartTriggerer,
            IEventToSoundMapper eventToSoundMapper, IBloodAnimationSizeMapper smallCaliberBloodMapper, IBloodAnimationSizeMapper bigCaliberBloodMapper,
            IDestructionRegistration fistDestructionRegistration, IAmmoObserver ammoObserver)
        {
            CommunicationElementFactory = communicationElementFactory;
            ExplosionManager = explosionManager;
            BulletManager = playerBulletManager;
            ParticleManager = particleMananger;
            ListProviderProvider = listProviderProvider;
            EnemyProvider = playerProvider;
            _soundObserver = soundObserver;
            _multiWeaponRenderer = multiWeaponRenderer;
            _playerObserver = playerObserver;
            _playerInstructionProvider = playerInstructionProvider;
            _elementCreatorProvider = elementCreatorProvider;
            _weaponCollector = weaponCollector;
            _doorOpener = doorOpener;
            _playerVulnerability = playerVulnerability;
            _enemyFactory = enemyFactory;
            _bloodEffectCreator = bloodEffectCreator;
            _bloodParticleByBodyPartTriggerer = bloodParticleByBodyPartTriggerer;
            _quakeTriggerer = quakeTriggerer;
            _eventToSoundMapper = eventToSoundMapper;

            _smallCaliberBloodMapper = smallCaliberBloodMapper;

            _bigCaliberBloodMapper = bigCaliberBloodMapper;

            _fistDestructionRegistration = fistDestructionRegistration;
            _ammoObserver = ammoObserver;
        }

        public IWorldElement CreateNewElement(IElement element)
        {
            IWorldElement worldElement = null;

            if (element.Parameters == null)
                element.Parameters = AppearanceMapper.GetInstance().GetAppearance(element.ElementTheme);

            IPhysicalParameters parameters = element.Parameters;

            if (parameters != null && element.Orientation > Degree.Degree_0)
            {
                parameters = AppearanceRotater.RotateByDegree(parameters, element.Orientation);
            }

            switch (element.ElementTheme)
            {
                case ElementTheme.ShotGun:
                    AmmoFirerer ammoGroup = new AmmoFirerer();
                    _ammoObserver.RegisterAmmo(ElementTheme.ShotGun, ammoGroup);
                    FirePositionCalculator weaponLengthCalculator = new FirePositionCalculator(0, 0.4, ammoGroup);
                    worldElement = new ComplexWeapon(ammoGroup, new PermanentFireringWeapon(1.3, weaponLengthCalculator, new SoundPlayer(_eventToSoundMapper.GetSound(GameEvent.ShotGunPlayer), _soundObserver, NoiseLevel.High)));
                    break;
                case ElementTheme.ShotGunPlaceHolder:
                    worldElement = new WeaponPlaceHolder
                    {
                         WeaponTheme = ElementTheme.ShotGun,
                         WeaponCount = 1,
                         AmmoTheme = ElementTheme.ShotShells
                    };
                    _weaponCollector.AddWeaponPlaceHolder((IWeaponPlaceHolder)worldElement);
                    break;
                case ElementTheme.ShotShells:
                    worldElement = new ComplexAmmo(BulletManager, EnemyProvider, ListProviderProvider.GetProvider(), true, DestructionStrength.PlayerShotGunStrength, 8);
                    break;
                case ElementTheme.ShotShellsPlaceHolder:
                    worldElement = new WeaponPlaceHolder
                    {
                         WeaponTheme = ElementTheme.ShotGun,
                         WeaponCount = 0,
                         AmmoTheme = ElementTheme.ShotShells
                    };
                    _weaponCollector.AddWeaponPlaceHolder((IWeaponPlaceHolder)worldElement);
                    break;
                case ElementTheme.PistolBulletPlaceHolder:
                    worldElement = new WeaponPlaceHolder
                    {
                        WeaponTheme = ElementTheme.Pistol,
                        WeaponCount = 0,
                        AmmoTheme = ElementTheme.PistolBullets
                    };
                    _weaponCollector.AddWeaponPlaceHolder((IWeaponPlaceHolder)worldElement);
                    break;
                case ElementTheme.PistolPlaceHolder:
                    worldElement = new WeaponPlaceHolder
                    {
                        WeaponTheme = ElementTheme.Pistol,
                        WeaponCount = 1,
                        AmmoTheme = ElementTheme.PistolBullets
                    };
                    _weaponCollector.AddWeaponPlaceHolder((IWeaponPlaceHolder)worldElement);
                    break;
                case ElementTheme.PistolBullets:
                    worldElement = new ComplexAmmo(BulletManager, EnemyProvider, ListProviderProvider.GetProvider(), false, DestructionStrength.PlayerPistolStrength, 6);
                    break;
                case ElementTheme.Pistol:
                    ammoGroup = new AmmoFirerer();
                    _ammoObserver.RegisterAmmo(ElementTheme.Pistol, ammoGroup);
                    weaponLengthCalculator = new FirePositionCalculator(0, 0.2, ammoGroup);
                    worldElement = new ComplexWeapon(ammoGroup, new LoadingWeapon(
                        new PermanentFireringWeapon(0.4, weaponLengthCalculator, new SoundPlayer(_eventToSoundMapper.GetSound(GameEvent.PistolShotPlayer), _soundObserver, NoiseLevel.High)), 6, 0.8));
                    break;
                case ElementTheme.Fist:
                    ammoGroup = new AmmoFirerer();
                    ((IElementGroup)ammoGroup).AddChild(new InfiniteNearrangeAmmo(_fistDestructionRegistration, DestructionStrength.PlayerFistStrength, ListProviderProvider.GetProvider()));
                    weaponLengthCalculator = new FirePositionCalculator(-0.1, 0.3, ammoGroup);
                    worldElement = new ComplexWeapon(ammoGroup, new DelayedFireringWeapon(0.6, weaponLengthCalculator, 0.25, new SoundPlayer(_eventToSoundMapper.GetSound(GameEvent.FistPlayer), _soundObserver, NoiseLevel.Low)));
                    break;
                case ElementTheme.ExplosiveBox:
                    worldElement = new MovableExplodableElement(ExplosionManager, 150, 4, _elementCreatorProvider.GetElementCreator(), ListProviderProvider.GetProvider(), _complexElementFinder);
                    break;
                case ElementTheme.AmmoBox:
                    worldElement = new AmmoBox(30, _elementCreatorProvider.GetElementCreator(), new List<ElementTheme> { ElementTheme.PistolBulletPlaceHolder, ElementTheme.ShotShellsPlaceHolder, ElementTheme.MGChainPlaceHolder }, ParticleManager, ListProviderProvider.GetProvider(), _complexElementFinder);
                    break;
                case ElementTheme.RocketBox:
                    worldElement = new AmmoBox(30, _elementCreatorProvider.GetElementCreator(), new List<ElementTheme> { ElementTheme.RocketPlaceHolder }, ParticleManager, ListProviderProvider.GetProvider(), _complexElementFinder);
                    break;
                case ElementTheme.FireDeleter:
                    worldElement = new ExplodableElement(ExplosionManager, 80, 2, _elementCreatorProvider.GetElementCreator());
                    break;
                case ElementTheme.SlidingDoor:
                    worldElement = new SlidingDoor(element.StartPosition, ListProviderProvider.GetProvider());
                    _doorOpener.AddDoor((IActivatable)worldElement);
                    break;
                case ElementTheme.PlayerOne:
                    WeaponManager weaponManager = new WeaponManager(_multiWeaponRenderer, (IAmmoPerWeaponCounter) _ammoObserver, new List<WeaponSlot> 
                    {
                        new WeaponSlot
                        {
                            WeaponTheme = ElementTheme.Fist
                        },
                        new WeaponSlot
                        {
                            WeaponTheme = ElementTheme.Pistol
                        },
                        new WeaponSlot
                        {
                            WeaponTheme = ElementTheme.Uzi
                        },
                        new WeaponSlot
                        {
                            WeaponTheme = ElementTheme.ShotGun
                        },
                        new WeaponSlot
                        {
                            WeaponTheme = ElementTheme.RocketThrower
                        },
                        new WeaponSlot
                        {
                            WeaponTheme = ElementTheme.GrenadeLauncher
                        },
                        new WeaponSlot
                        {
                            WeaponTheme = ElementTheme.MG
                        },
                        new WeaponSlot
                        {
                            WeaponTheme = ElementTheme.AtomaticMG
                        }
                    }, new WeaponSwitcher(0.6), ElementTheme.Fist);

                    worldElement = new PlayerDrivenElement(280, parameters.Height,ListProviderProvider.GetProvider(),
                        new ImpulseConverter(), _soundObserver, weaponManager, weaponManager,
                        _playerObserver, _playerInstructionProvider, _playerVulnerability, _complexElementFinder, new CameraParameterCalculator(((int)element.Orientation - 1) * 45),
                        new BodyHeightCalculator(parameters.Height, 0.8, 0.3, parameters.SideLengthX / 2.0, ListProviderProvider.GetProvider(), new SimpleRecursiveCollisionDetector(new DetectorOfOverlappingElements())));
                    EnemyProvider.SetEnemy(worldElement);
                    _weaponCollector.AddWeaponOwner((IElementGroup)worldElement);
                    _doorOpener.SetPlayer(worldElement);
                    break;
                case ElementTheme.SoldierShotGun:
                case ElementTheme.SoldierShotGunR:
                case ElementTheme.SoldierShotGunF:
                case ElementTheme.SoldierPistolF:
                case ElementTheme.SoldierPistol:
                case ElementTheme.SoldierPistolR:
                case ElementTheme.Dog:
                case ElementTheme.AutoMG:
                    worldElement = _enemyFactory.CreateEnemy(element, EnemyProvider, ListProviderProvider.GetProvider(), _elementCreatorProvider.GetElementCreator());
                    break;
                case ElementTheme.GenericElement:
                    worldElement = new ImpulseProcessingAnimatableElement(ListProviderProvider.GetProvider(), _complexElementFinder);
                    break;
                case ElementTheme.GenericElementWithoutCollision:
                    worldElement = new FixAnimatibleElement(new NoPositionOnRoomFieldModel());
                    break;
                case ElementTheme.GenericElementWithoutMovement:
                    worldElement = new FixAnimatibleElement(new LargePositionOnRoomFieldModel());
                    break;
                case ElementTheme.StraightFlyingBloodVerySmall:
                    worldElement = new StraightTransportationElement(new FilteringRecursiveDetector(new DetectorOfOverlappingElements(), new SpriteFilter()), ListProviderProvider.GetProvider(), _elementCreatorProvider.GetElementCreator(),
                       new ExitWoundBlood(_bloodEffectCreator, _smallCaliberBloodMapper, parameters.SideLengthX / 1, 0.4, element.StartPosition), true);
                    break;
                case ElementTheme.StraightFlyingBloodSmall:
                    worldElement = new StraightTransportationElement(new FilteringRecursiveDetector(new DetectorOfOverlappingElements(), new SpriteFilter()), ListProviderProvider.GetProvider(), _elementCreatorProvider.GetElementCreator(),
                      new ExitWoundBlood(_bloodEffectCreator, _bigCaliberBloodMapper, parameters.SideLengthX / 1, 0.4, element.StartPosition), true);
                    break;
                case ElementTheme.FlyingBloodSmall:
                    worldElement = new FlyingBloodVisible(ListProviderProvider.GetProvider(), _elementCreatorProvider.GetElementCreator(), _bloodEffectCreator,
                        ParticleManager, new StraightFlightSimulator(), Animation.SmallBloodLowDensity, 1600, _spriteFilteringcomplexElementFinder);
                    break;
                case ElementTheme.FlyingBloodMedium:
                    worldElement = new FlyingBloodVisible(ListProviderProvider.GetProvider(), _elementCreatorProvider.GetElementCreator(), _bloodEffectCreator,
                        ParticleManager, new StraightFlightSimulator(), Animation.BloodMediumLD4, 1600, _spriteFilteringcomplexElementFinder);
                    break;
                case ElementTheme.FlyingShoe:
                case ElementTheme.BloodTorso:
                case ElementTheme.Skull:
                case ElementTheme.DogBloodTorso:
                case ElementTheme.GiantTorso:
                case ElementTheme.GiantSkull:
                case ElementTheme.BloodyPart:
                case ElementTheme.Bowls:
                    worldElement = new FlyingBodyPart(ListProviderProvider.GetProvider(), new StraightFlightSimulator(), 1600, 0.8, 0.5, _spriteFilteringcomplexElementFinder,
                        (worldelement, position) =>
                        {
                            _bloodParticleByBodyPartTriggerer.TriggerBloodParticle(BodyPart.Head, position);
                            _elementCreatorProvider.GetElementCreator().DeleteElement(worldelement);
                        }, Behaviour.LyingOnFloor);
                    break;
                case ElementTheme.InvisibleElement:
                    worldElement = new StandardWorldElement(new LargePositionOnRoomFieldModel());
                    break;
                case ElementTheme.BleedingBody:
                    worldElement = new Material(Animation.VerySmallBodyExplosion, ParticleManager, new PositionOnRoomFieldModel());
                    break;
                case ElementTheme.BreakableWall:
                    worldElement = new BreakableWall(36,30);
                    break;
            }

            if (worldElement is IVisualAppearance)
            {
                IVisualAppearance visualElement = (IVisualAppearance)worldElement;
                visualElement.ElementTheme = element.ElementTheme;
                visualElement.Orientation = element.Orientation;
            }

            worldElement.SetCenterPosition(element.StartPosition.PositionX, element.StartPosition.PositionY, element.StartPosition.PositionZ);
            if(parameters != null)
                worldElement.SetPhysicalAppearance(parameters.Shape,parameters.Weight, parameters.SideLengthX, parameters.SideLengthY, parameters.Height, parameters.SideLengthX / 2.0);

            if (element.ElementTheme == ElementTheme.GenericElementWithoutCollision)
                worldElement.SetPhysicalAppearance(parameters.Shape, parameters.Weight, 0, 0, 0, 0);

            if (worldElement is IStorable && element.InitInformation != null && element.InitInformation.InitValues.Count > 0)
            {
                (worldElement as IStorable).SetState(element.InitInformation);
            }

            if (worldElement is IAnimatable == false)
                return worldElement;

            IAnimatable animatableElement = (IAnimatable)worldElement;

            ICommunicationElement communicationElement = CommunicationElementFactory.CreateNewElement(element);
            animatableElement.CommunicationElement = communicationElement;

            return worldElement;
        }

        public void DeleteElement(IWorldElement element)
        {
        }
    }
}
