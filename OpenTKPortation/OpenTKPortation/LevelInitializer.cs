using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteraction;
using GameInteraction.ThemeMapping;
using ThemeMapping;
using IOInterface;
using GameInteraction.BaseImplementations;
using BaseTypes;
using CollisionDetection;
using ElementImplementations.ActivationManagerImplementations;
using InitializationContracts;
using SaveGames;
using FrameworkContracts;
using OpenTKPortation.Implementations;
using GameInteraction.Weapons;
using DrawableElements;
using GameInteractionContracts;
using BaseContracts;
using ElementImplementations.WeaponImplementations;
using CollisionDetection.CollisionDetectors;
using DrawableElements.WallEffects;
using CollisionDetection.Elements;
using ArtificialIntelligence;
using Render;
using ArtificialIntelligence.EnemyProvider;
using Render.Contracts;
using DrawableElements.WallEffects.VisibilityTest;
using BloodEffects;
using BloodEffects.SpriteCreaterImplementations.BloodParameterCalculators;
using BloodEffects.SpriteCreaterImplementations.VertexCalculators;
using BloodEffects.SpriteCreaterImplementations;
using ElementImplementations.CharacterImplementations;
using Sound.Contracts;
using IOInterface.Events;
using FrameworkImplementations;
using ElementImplementations;
using Gravity;
using ThemeMapping.EnemyCreation;
using GameInteraction.LevelManagement;
using EnvironmentAnalysis.RayTest.Rays;
using BloodEffects.Contracts;
using ElementImplementations.AmmoImplementations;
using CollisionDetection.CollisionDetectors.ElementFinders;
using FrameworkImplementations.Player;
using FrameworkImplementations.FlyingShells;
using SaveGames.FileAccess;
using ThemeMapping.EnemyCreation.StrategyBuilders;
using FrameworkImplementations.Screen;

namespace OpenTKPortation
{
    public class LevelInitializer : IInitializer
    {
        private List<IElement> Content { set; get; }

        private ITextureLoader _textureLoader { set; get; }
        private IAnimationLoader AnimationLoader { set; get; }
        private IThemeLoader ThemeLoader { set; get; }
        private IPlayerCameraConnection PlayerCamera { set; get; }
        private IPlayerCamera Camera { set; get; }
        private IScreen Screen { set; get; }
        
        private IPlayerInstructionProvider _playerInstructionProvider;

        private IMessageRendererFactory MessageRendererFactory { set; get; }

        private EnvironmentProviders _environmentProviders;
        private ITextureChanger _textureChanger;
        private ISoundFactory _soundFactory;
        private IAlphaTester _alphaTester;
        private IWorldTranslator _worldTranslator;
        private ITextureTranslator _textureTranslator;
        private IPolygonRenderer _polygonRenderer;
        private IRenderedSideSwitcher _renderedSideSwitcher;
        private IWorldRotator _worldRotator;
        private Action _switchToNextLevel;
        private bool _frameCounter;
        private IExecuteble _screenShotCreator;
        private IDepthTestActivator _depthTestActivator;
        private IScaler _scaler;
        private IAlphaBlender _alphaRenderer;
        private IPlayerDeathObserver _playerHealthObserver;
        private Dictionary<int, IRectangle> _numbers;

        public LevelInitializer(ITextureLoader textureLoader, IAnimationLoader animationLoader, IThemeLoader themeLoader,
            IPlayerCameraConnection playerCamera, IPlayerCamera camera, IMessageRendererFactory messageRendererFactory, IScreen screen,
            IPlayerInstructionProvider playerInstructionProvider, EnvironmentProviders environmentProviders, ITextureChanger textureChanger,
            ISoundFactory soundFactory, IAlphaTester alphaTester, IWorldTranslator worldTranslator, ITextureTranslator textureTranslator, IPolygonRenderer polygonRenderer,
            IRenderedSideSwitcher renderedSideSwitcher, IWorldRotator worldRotator,
            Action switchToNextLevel, bool frameCounter, IExecuteble screenShotCreator, IDepthTestActivator depthTestActivator,
            IScaler scaler, IAlphaBlender alphaRenderer, IPlayerDeathObserver playerHealthObserver, Dictionary<int, IRectangle> numbers)
        { 
            //one meter divided through weight of a man (his movement power)
            TimeAndSpeedManager.SetSpeedPerSecondAndImpulseStrength(1.0 / 70.0);

            _textureLoader = textureLoader;
            AnimationLoader = animationLoader;
            ThemeLoader = themeLoader;
            PlayerCamera = playerCamera;
            Camera = camera;
            Screen = screen;
            MessageRendererFactory = messageRendererFactory;
            
            _playerInstructionProvider = playerInstructionProvider;
            _environmentProviders = environmentProviders;
            _textureChanger = textureChanger;
            _soundFactory = soundFactory;
            _alphaTester = alphaTester;
            _worldTranslator = worldTranslator;
            _textureTranslator = textureTranslator;
            _polygonRenderer = polygonRenderer;
            _renderedSideSwitcher = renderedSideSwitcher;
            _worldRotator = worldRotator;
            _switchToNextLevel = switchToNextLevel;
            _frameCounter = frameCounter;
            _screenShotCreator = screenShotCreator;
            _depthTestActivator = depthTestActivator;
            _scaler = scaler;
            _alphaRenderer = alphaRenderer;
            _playerHealthObserver = playerHealthObserver;
            _numbers = numbers;
        }

        public LevelUnit InitializeLevel(int levelId, SkillLevel skillLevel)
        {
            ILevelDefinitionLoader loader = new LevelDefinitionLoader(new FileSerializer());
            Content = loader.LoadLevel(levelId, skillLevel).AllElements;
            
            return InstantiateControllerObjects(levelId);
        }

        private LevelUnit InstantiateControllerObjects(int levelId)
        {
            LevelUnit levelUnit = new LevelUnit();

            ILightCollection lightCollection = _environmentProviders.LightCollectionProvider.GetCollection(levelId);
            DynamicWallEffectManager wallEffectManager = new DynamicWallEffectManager(_alphaTester);

            AlphaChannelListRenderer elements = new AlphaChannelListRenderer(_alphaTester, new List<IDrawable> { });
            ImageElementSorter imageElementSorter = new ImageElementSorter(_alphaTester);
            IDrawable sky = _environmentProviders.SkylineElementProvider.GetSkylineElement(levelId);
            IDrawable floor = _environmentProviders.FloorProvider.GetRenderedFloor(levelId);

            List<IDrawable> sounds = new List<IDrawable>();
            AlphaChannelListRenderer visualListRenderer = new AlphaChannelListRenderer(_alphaTester, sounds);
            DepthlessRenderer visualSoundRenderer = new DepthlessRenderer(_depthTestActivator, visualListRenderer);

            IDrawableList world3D = new ListRenderer(new List<IDrawable> 
            { 
                elements,
                imageElementSorter,
                wallEffectManager, 
                visualSoundRenderer
            });
            if (floor != null)
                elements.Add(floor);
            if(sky != null)
                elements.Add(sky);

            //player gui
            double digitSize = 0.04;
            IColorToPercentMapper colorToPercentMapper = new FrameworkImplementations.Screen.ColorToPercentMapper();
            ICountRenderer playerHealthMessageRenderer = new CountRenderer(_numbers,colorToPercentMapper, digitSize);
            PlayerHealthObserver playerHealthObserver = new FrameworkImplementations.Player.PlayerHealthObserver(playerHealthMessageRenderer);
            IDrawable healthSymbol = new ImageRectangle(_textureLoader.LoadTexture("Content\\Images\\health2.png", false), _textureChanger, new SurfaceRectangle(_polygonRenderer, -0.2, 0.755, 0.5f, 0.25f, false));
            
            //weapons
            IDrawable targetCross = new ImageRectangle(_textureLoader.LoadTexture("Content\\Images\\cross.png", false), _textureChanger, new SurfaceRectangle(_polygonRenderer, 0.45, 0.45, 0.1f, 0.1f, false));
            Dictionary<ElementTheme, IWeaponRenderer> weapons = new Dictionary<ElementTheme,IWeaponRenderer>();
            weapons.Add(ElementTheme.Fist, new FirelessWeaponRenderer(ThemeLoader.LoadTheme(ElementTheme.Fist), _textureChanger,
                new SurfaceRectangle(_polygonRenderer, 0, 0, 1, 1, false)));
            weapons.Add(ElementTheme.Pistol, new StandardWeaponRenderer(ThemeLoader.LoadTheme(ElementTheme.Pistol), _textureChanger,
                new SurfaceRectangle(_polygonRenderer, 0, 0, 1, 1, false), new GunFireRenderer(AnimationLoader.LoadAnimation("Content\\Animations\\GunFire"), _textureChanger, new SurfaceRectangle(_polygonRenderer, 0.18, 0.09, 0.5f, 0.5f, false), 8)));
            weapons.Add(ElementTheme.Uzi, new StandardWeaponRenderer(ThemeLoader.LoadTheme(ElementTheme.Uzi), _textureChanger,
                new SurfaceRectangle(_polygonRenderer, 0, 0, 1, 1, false), new GunFireRenderer(AnimationLoader.LoadAnimation("Content\\Animations\\GunFire"), _textureChanger, new SurfaceRectangle(_polygonRenderer, 0.18, 0.09, 0.5f, 0.5f, false), 8)));
            weapons.Add(ElementTheme.ShotGun, new StandardWeaponRenderer(ThemeLoader.LoadTheme(ElementTheme.ShotGun), _textureChanger,
                new SurfaceRectangle(_polygonRenderer, 0, 0, 1, 1, false), new GunFireRenderer(AnimationLoader.LoadAnimation("Content\\Animations\\GunFire"), _textureChanger, new SurfaceRectangle(_polygonRenderer, 0.20, 0.11, 0.5f, 0.5f, false), 8)));
            weapons.Add(ElementTheme.RocketThrower, new StandardWeaponRenderer(ThemeLoader.LoadTheme(ElementTheme.RocketThrower), _textureChanger,
                new SurfaceRectangle(_polygonRenderer, -0.42, 0, 1, 1, false), new GunFireRenderer(AnimationLoader.LoadAnimation("Content\\Animations\\GunFire"), _textureChanger, new SurfaceRectangle(_polygonRenderer, 0.13, 0.15, 0.5f, 0.5f, false), 8)));
            weapons.Add(ElementTheme.GrenadeLauncher, new StandardWeaponRenderer(ThemeLoader.LoadTheme(ElementTheme.GrenadeLauncher), _textureChanger,
                new SurfaceRectangle(_polygonRenderer, -0.25, 0, 1, 1, false),
                new GunFireRenderer(AnimationLoader.LoadAnimation("Content\\Animations\\GunFire"), _textureChanger, new SurfaceRectangle(_polygonRenderer, -0.05, -0.05, 0.8f, 0.8f, false), 7)));
            weapons.Add(ElementTheme.MG, new StandardWeaponRenderer(ThemeLoader.LoadTheme(ElementTheme.MG), _textureChanger,
                new SurfaceRectangle(_polygonRenderer, 0, 0, 1, 1, false), new GunFireRenderer(AnimationLoader.LoadAnimation("Content\\Animations\\GunFire"), _textureChanger, new SurfaceRectangle(_polygonRenderer, 0.20, 0.15, 0.5f, 0.5f, false), 8)));
            weapons.Add(ElementTheme.AtomaticMG, new StandardWeaponRenderer(ThemeLoader.LoadTheme(ElementTheme.AtomaticMG), _textureChanger,
               new SurfaceRectangle(_polygonRenderer, -0.32, 0, 1, 1, false), new GunFireRenderer(AnimationLoader.LoadAnimation("Content\\Animations\\GunFire"), _textureChanger, new SurfaceRectangle(_polygonRenderer, 0.17, 0.12, 0.5f, 0.5f, false), 8)));
            
            BloodRenderer bloodRenderer = new BloodRenderer(AnimationLoader.LoadAnimation("Content\\Animations\\PlayerBlood"), _textureChanger, new SurfaceRectangle(_polygonRenderer, -1, -0.5, 3f, 2f, false), _alphaRenderer, 0.5, 0.7, _playerHealthObserver, 1.5);
            Fader fader = new Fader(_textureLoader.LoadTexture("Content\\Images\\fadebg.png", false), _textureChanger, new SurfaceRectangle(_polygonRenderer, -1, -0.5, 3f, 2f, false), _alphaRenderer, 2, 4);
            LevelShutDown levelShutDown = new FrameworkImplementations.LevelShutDown(4, _switchToNextLevel, fader);

            Dictionary<ElementTheme, ICountRenderer> countRenderers = new Dictionary<ElementTheme, ICountRenderer>();

            IDrawable ammoBackground = new ImageRectangle(_textureLoader.LoadTexture("Content\\Images\\ammobg.png", false), _textureChanger, new SurfaceRectangle(_polygonRenderer, 0, 0, 0.25f, 0.125f, false));
            countRenderers.Add(ElementTheme.AtomaticMG, new CountIncrementer(new MovingCountRenderer(new CountRenderer(_numbers, colorToPercentMapper, digitSize), ammoBackground, _worldTranslator), 0.05));
            countRenderers.Add(ElementTheme.MG, new CountIncrementer(new MovingCountRenderer(new CountRenderer(_numbers, colorToPercentMapper, digitSize), ammoBackground, _worldTranslator), 0.05));
            countRenderers.Add(ElementTheme.GrenadeLauncher, new CountIncrementer(new MovingCountRenderer(new CountRenderer(_numbers, colorToPercentMapper, digitSize), ammoBackground, _worldTranslator), 0.05));
            countRenderers.Add(ElementTheme.RocketThrower, new CountIncrementer(new MovingCountRenderer(new CountRenderer(_numbers, colorToPercentMapper, digitSize), ammoBackground, _worldTranslator), 0.05));
            countRenderers.Add(ElementTheme.ShotGun, new CountIncrementer(new MovingCountRenderer(new CountRenderer(_numbers, colorToPercentMapper, digitSize), ammoBackground, _worldTranslator), 0.05));
            countRenderers.Add(ElementTheme.Uzi, new CountIncrementer(new MovingCountRenderer(new CountRenderer(_numbers, colorToPercentMapper, digitSize), ammoBackground, _worldTranslator), 0.05));
            countRenderers.Add(ElementTheme.Pistol, new CountIncrementer(new MovingCountRenderer( new CountRenderer(_numbers,colorToPercentMapper, digitSize), ammoBackground, _worldTranslator), 0.05));
            
            
            double rightCornerX = 1 + ((Screen.AspectRatio - 1)/ 2.0);
            IDrawable ammoMark = new ImageRectangle(_textureLoader.LoadTexture("Content\\Images\\ammoframe2.png", false),
                _textureChanger, new SurfaceRectangle(_polygonRenderer, 0.0, 0.0, 0.125f, 0.059f, false));
            ICountRenderer movingRenderer = new MovingRenderer(ammoMark, _worldTranslator);
            IAmmoPerWeaponCounter ammoPerWeaponCounter = new AmmoPerWeaponCounter();
            AmmoCountRenderer ammoCountRenderer = new AmmoCountRenderer(countRenderers, ammoPerWeaponCounter, movingRenderer, rightCornerX);
            IMultiWeaponRenderer multiWeaponRenderer = new MultiWeaponRenderer(weapons, _worldTranslator, ammoCountRenderer);
            
            List<IDrawable> surfaceList = new List<IDrawable> 
            { 
                (IDrawable)multiWeaponRenderer,
                targetCross,
                healthSymbol,
                (IDrawable)playerHealthObserver,
                ammoCountRenderer,
                bloodRenderer,
                fader
            };

            if (_frameCounter)
                surfaceList.Add(new FrameCounter(MessageRendererFactory.CreateMessageRenderer(1.0, 0.9)));
            
            levelUnit.InfoSurface2D = new AlphaChannelListRenderer(_alphaTester, surfaceList);

            levelUnit.World3D = new LightRenderer(lightCollection, world3D);

            levelUnit.Background = _environmentProviders.BackgroundColorProvider.GetBackgroundColor(levelId);

            ICommunicationElementFactory communicationElementFactory = new CommunicationElementFactory(_textureLoader, _textureChanger, AnimationLoader, ThemeLoader,
                (IDrawableList)elements, imageElementSorter, PlayerCamera, Camera, _worldTranslator, _textureTranslator, _polygonRenderer, _renderedSideSwitcher, _worldRotator);

            IPolygonCreator polygonCreator = new PolygonCreator();
            IParticleFactory particleFactory = new ParticleFactory(AnimationLoader, _textureChanger, Camera, new ResolutionToSizeMapper(), "Content\\Animations",
                _worldTranslator, _polygonRenderer, _worldRotator, polygonCreator);
            ParticleManager particleManager = new ParticleManager(particleFactory);
            elements.Add(particleManager);

            BulletManager bulletManager = new BulletManager(particleManager);
            BulletRegistration bulletRegistration = new BulletRegistration(0.06);
            NearRangeAttackRegistration nearRangeAttackRegistration = new NearRangeAttackRegistration(new RecursiveCollidingElementFinder(new DetectorOfOverlappingElements()), new NearRangeAttackSharer(), 0.05);
            
            ListProviderProvider<IWorldElement> collisionDetectionListProviderProvider = new ListProviderProvider<IWorldElement>();
            ElementCreatorProvider elementCreatorProvider = new ElementCreatorProvider();

            PlayerInstructionCache playerInstructionCache = new PlayerInstructionCache(_playerInstructionProvider);
            DoorActivator doorActivator = new ElementImplementations.ActivationManagerImplementations.DoorActivator(playerInstructionCache, 1.5);

            double lengthOfFieldUnit = 10;

            SimpleEnemyProvider playerProvider = new SimpleEnemyProvider();
            WeaponCollector weaponCollector = new WeaponCollector(elementCreatorProvider, new UpdateTimer(0.2), 0.8);
            SoundConnector soundConnector = new SoundConnector(1.5, 5, 60, 1.2, 2.5, 5, 4);
            BloodCreationQueue bloodCreationQueue = new BloodCreationQueue(wallEffectManager, new BloodAnimationSpriteFactory(AnimationLoader, _textureChanger, "Content\\Animations", 0.1, playerProvider, _polygonRenderer));

            Dictionary<IOInterface.Animation, double>  bloodSize = new Dictionary<IOInterface.Animation, double> 
                            { 
                                { IOInterface.Animation.SmallBloodLowDensity, 1.0 }, 
                                { IOInterface.Animation.BloodVerySmall1, 0.5 },
                                { IOInterface.Animation.BloodVerySmall2, 0.5 },
                                { IOInterface.Animation.BloodVerySmall3, 0.5 },
                                { IOInterface.Animation.BloodSmall1, 1.0 },
                                { IOInterface.Animation.BloodSmall2, 1 },
                                { IOInterface.Animation.BloodSmall3, 1 },
                                { IOInterface.Animation.BloodSmall4, 1 },
                                { IOInterface.Animation.BloodSmall5, 1 },
                                { IOInterface.Animation.BloodSmall6, 1 },
                                { IOInterface.Animation.BloodMedium1, 2.0},
                                { IOInterface.Animation.BloodMediumLD1, 2.0},
                                { IOInterface.Animation.BloodMediumLD2, 2.0},
                                 { IOInterface.Animation.BloodMediumLD3, 2.0},
                                 { IOInterface.Animation.BloodMediumLD4, 2.0}
                            };
            IBloodEffectCreator bloodEffectCreator = new BloodEffectFilter(new BloodEffectCreator(lengthOfFieldUnit, collisionDetectionListProviderProvider, bloodCreationQueue, new RecursiveCollidingElementFinder(new DetectorOfOverlappingElements()),
                            new List<IBloodSpriteParameterCalculator> 
                            { 
                                new PositiveXSpriteParameterCalculator(new XWallSpriteCalculator(true, 0.07), new TextureRotater(), 0.0015),
                                new NegativeXSpriteParameterCalculator(new XWallSpriteCalculator(false, 0.07), new TextureRotater(), 0.0015),
                                new PositiveZSpriteParameterCalculator(new ZWallSpriteCalculator(true, 0.07), new TextureRotater(), 0.0015),
                                new NegativeZSpriteParameterCalculator(new ZWallSpriteCalculator(false, 0.07), new TextureRotater(), 0.0015),
                                new PositiveYSpriteParameterCalculator(new YWallSpriteCalculator(true, 0.07), new TextureRotater(), 0.0015),
                                new NegativeYSpriteParameterCalculator(new YWallSpriteCalculator(false, 0.07), new TextureRotater(),0.0015) 
                            },
                            new WallEffectListFilter(), bloodSize)
                            , 1.7, bloodSize);

            IBloodAnimationSizeMapper smallCaliberBloodMapper = new BloodAnimationSizeMapper(new List<Tuple<double, Animation>>
            {
                new Tuple<double,Animation>(9.0, Animation.BloodSmall6),
                new Tuple<double,Animation>(6.0, Animation.BloodSmall2),
                new Tuple<double,Animation>(2.5, Animation.BloodVerySmall3),
                new Tuple<double,Animation>(-1, Animation.BloodVerySmall2)
            });

            IBloodAnimationSizeMapper bigCaliberBloodMapper = new BloodAnimationSizeMapper(new List<Tuple<double, Animation>>
            {
                new Tuple<double,Animation>(10, Animation.BloodMedium1),
                new Tuple<double,Animation>(8, Animation.BloodMediumLD2),
                new Tuple<double,Animation>(6, Animation.BloodMediumLD3),
                new Tuple<double,Animation>(4, Animation.BloodSmall1),
                new Tuple<double,Animation>(2.5, Animation.BloodSmall3),
                new Tuple<double,Animation>(-1, Animation.BloodSmall4)
            });

            BloodParticleByBodyPartTriggerer bloodParticleByBodyPartTriggerer = new BloodParticleByBodyPartTriggerer(particleManager, bloodEffectCreator);
                  
            //camera shaker decorator
            CameraShaker cameraShaker = new CameraShaker(new PlayerObserver(PlayerCamera), 30.0, 0.1, 20.0, 150);
            IEventToSoundMapper eventToTextMapper = new EventToTextMapper(visualListRenderer, polygonCreator, _textureLoader, _textureChanger, _polygonRenderer, _worldRotator, Camera, _worldTranslator, _scaler);

            IEventToSoundMapper eventToSoundAndTextMapper = new EventToSoundAndTextMapper(_soundFactory, eventToTextMapper);

            EnemyObserver enemyObserver = new EnemyObserver(levelShutDown);
            ExplosionManager explosionManager = new ExplosionManager(particleManager, new ExplosionSizeMapper(0, 371), cameraShaker, new PositionUpdatingSoundPlayer(eventToSoundAndTextMapper.GetSound(GameEvent.Explosion)), collisionDetectionListProviderProvider);

            IEnemyFactory enemyFactory = new EnemyFactory(bloodParticleByBodyPartTriggerer, new BloodParticleByCaliberTriggerer(particleManager, 30, 10, elementCreatorProvider, 0.5, 20),
            soundConnector, cameraShaker, new WeaponCreator(bulletRegistration, nearRangeAttackRegistration, eventToSoundAndTextMapper, particleManager, new FlyingShellFactory(particleManager)),
            enemyObserver, enemyObserver, explosionManager, particleManager, eventToSoundAndTextMapper, new VisualMindEnemyProviderCreator(eventToTextMapper), eventToTextMapper);

            HighDetailNearRangeAttackRegistration fistDestruction = new HighDetailNearRangeAttackRegistration(new FilteringRecursiveHLDElementFinder(new DetectorOfOverlappingElements(), new ElementFilter(ElementTheme.PlayerOne)),
                new NearrangeAttackParticleAndSoundDecorator(new NearRangeAttackSharer(), eventToSoundAndTextMapper.GetSound(GameEvent.FistPlayerHit), particleManager), 0.1);
            ListFillingFactory<IActivatable> ListFillingActivatableElementFactory =
                new ListFillingFactory<IActivatable>(new ElementFactory(communicationElementFactory, explosionManager,
                    bulletManager, particleManager, collisionDetectionListProviderProvider,
                    multiWeaponRenderer, cameraShaker,cameraShaker, playerInstructionCache, elementCreatorProvider,
                            weaponCollector, doorActivator, new PlayerHealth(playerHealthObserver, bloodRenderer, bloodRenderer, DestructionStrength.PlayerStrengthToEnemyWeaponFactor), enemyFactory, soundConnector,
                            playerProvider, bloodEffectCreator, bloodParticleByBodyPartTriggerer, eventToSoundAndTextMapper, smallCaliberBloodMapper, bigCaliberBloodMapper, fistDestruction, (IAmmoObserver)ammoPerWeaponCounter));

            ListFillingFactory<IWorldElement> ListFillingWorldElementFactory =
                new ListFillingFactory<IWorldElement>(ListFillingActivatableElementFactory);

            //setting the dimensions of the level
            PositionOnRoomFieldModel.XDivider = lengthOfFieldUnit;
            PositionOnRoomFieldModel.YDivider = lengthOfFieldUnit;

            GroupBuildingFactory ListFillingFactoryForCollisionDetection =
                new GroupBuildingFactory(new ComplexElementBuilder(ListFillingWorldElementFactory), new List<ElementTheme> 
                { 
                    ElementTheme.PistolBullets,
                    ElementTheme.PistolPlaceHolder,
                    ElementTheme.Pistol,
                    ElementTheme.PistolBulletPlaceHolder,
                    ElementTheme.ShotShells,
                    ElementTheme.ShotShellsPlaceHolder,
                    ElementTheme.ShotGun,
                    ElementTheme.ShotGunPlaceHolder,
                    ElementTheme.Rocket,
                    ElementTheme.EnemyRocket,
                    ElementTheme.EnemyGrenade,
                    ElementTheme.RocketThrower,
                    ElementTheme.RocketThrowerPlaceHolder,
                    ElementTheme.RocketPlaceHolder,
                    ElementTheme.RocketTriggerer,
                    ElementTheme.GrenadeLauncherPlaceHolder,
                    ElementTheme.GrenadeLauncher,
                    ElementTheme.Grenade,
                    ElementTheme.GrenadePlaceHolder,
                    ElementTheme.GrenadeTriggerer,
                    ElementTheme.FireBall,
                    ElementTheme.MG,
                    ElementTheme.MGPlaceHolder,
                    ElementTheme.MGChain,
                    ElementTheme.MGChainPlaceHolder,
                    ElementTheme.AtomaticMG,
                    ElementTheme.AtomaticMGChain,
                    ElementTheme.AtomaticMGChainPlaceHolder,
                    ElementTheme.AtomaticMGPlaceHolder,
                    ElementTheme.Uzi,
                    ElementTheme.UziBullets,
                    ElementTheme.UziPlaceHolder,
                    ElementTheme.UziBulletPlaceHolder,
                    ElementTheme.GenericElementWithoutCollision,
                    ElementTheme.StraightFlyingBloodSmall,
                    ElementTheme.StraightFlyingBloodVerySmall,
                    ElementTheme.FlyingBloodMedium,
                    ElementTheme.FlyingBloodSmall,
                    ElementTheme.MovingPalm,
                    ElementTheme.MovingCactus,
                    ElementTheme.MovingTree
                },
                new List<ElementTheme>
                {
                    ElementTheme.PlayerOne,
                    ElementTheme.SoldierShotGun,
                    ElementTheme.SoldierRocket,
                    ElementTheme.SoldierPistol,
                    ElementTheme.SoldierMG,
                    ElementTheme.FlyingSoldierFlameThrower,
                    ElementTheme.Helicopter,
                    ElementTheme.HelicopterMGOnlyB,
                    ElementTheme.SoldierTank,
                    ElementTheme.SoldierRobot,
                    ElementTheme.LastRobot,
                    ElementTheme.Dog,
                    ElementTheme.Ninja,
                    ElementTheme.Gondel,
                    ElementTheme.TokyoRail
                }, 300, 10, _environmentProviders.FloorProvider.GetCollisionElements(levelId));
            collisionDetectionListProviderProvider.ListProvider = ListFillingFactoryForCollisionDetection;

            GravitationManagingElementFactory gravityManager = new GravitationManagingElementFactory(ListFillingFactoryForCollisionDetection, new GravitationCalculator(0.01, 800));
            ThemeFacade elementCreator = new ThemeFacade(gravityManager);
            elementCreatorProvider.ElementCreator = elementCreator;

            List<IExecuteble> executebles = new List<IExecuteble> 
            {
                playerInstructionCache,
                new ElementLogicComposition(ListFillingWorldElementFactory),  
                new ElementMovementComposition(ListFillingWorldElementFactory),  
                bulletRegistration, 
                bulletManager,
                new ElementRenderComposition(ListFillingWorldElementFactory),
                elementCreator,
                weaponCollector,
                doorActivator,
                bloodCreationQueue,
                gravityManager,
                levelShutDown
            };

            if (_screenShotCreator != null)
                executebles.Add(_screenShotCreator);

            levelUnit.GameContent = new ExecutebleComposition(executebles);

            levelUnit.ElementCreator = elementCreator;
            levelUnit.Elements = Content;
            levelUnit.Id = levelId;

            CollisionRayFactory.Initialize(160);

            return levelUnit;
        }

        private class ListProviderProvider<T> : IListProviderProvider<T>
        {
            public IListProvider<T> ListProvider { set; get; }

            IListProvider<T> IListProviderProvider<T>.GetProvider()
            {
                return ListProvider;
            }
        }

        private class ElementCreatorProvider : IElementCreatorProvider
        {
            public IElementCreator ElementCreator { set; get; }

            IElementCreator IElementCreatorProvider.GetElementCreator()
            {
                return ElementCreator;
            }
        }
    }
}
