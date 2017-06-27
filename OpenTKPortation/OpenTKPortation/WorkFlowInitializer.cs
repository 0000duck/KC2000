using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using Render.Contracts;
using FrameworkImplementations.Player;
using Sound;
using Render;
using OpenTKPortation.Implementations;
using FrameworkImplementations;
using FrameworkImplementations.Animation;
using FrameworkImplementations.Mainframe;
using FrameworkContracts;
using IOInterface;
using FrameworkImplementations.Theme;
using FrameworkImplementations.Screen;
using InitializationContracts;
using OpenTKPortation.Implementations.Providers;
using Profile;
using SaveGames.FileAccess;
using OpenTKPortation;
using DrawableElements;
using LevelEditor;
using Profile.Contracts;
using Sound.Contracts;
using BaseTypes;
using Menu;
using System.Drawing;


namespace KillCommando
{
    public class WorkFlowInitializer
    {
        public IExecuteble InitWorkFlow(IMouseController mouseController,
            IPressedKeyDetector pressedKeyDetector, 
            Configuration.Configuration configuration, 
            Action clickedExit, 
            List<int> levelIds, 
            IScreen screen,
            Action swapBuffer
            )
        {
            PlayerCamera playerCamera = new PlayerCamera(new Listener());
            ICamera camera = new Camera(playerCamera, screen);

            ITextureChanger textureChanger = new TextureChanger();
            TextureCache textureCache = new TextureCache(new TextureLoader(textureChanger));
            AnimationLoader animationLoader = new AnimationLoader(textureCache);
            LevelIdSwitcher levelIdSwitcher = new LevelIdSwitcher(levelIds);
            if (configuration.StartLevelId.HasValue)
                ((ILevelIdSwitcher)levelIdSwitcher).SetSpecificLevel(configuration.StartLevelId.Value);

            ScenarioAnimationLoader scenarioAnimationLoader = new ScenarioAnimationLoader(animationLoader, new ScenarioProvider(),
                new List<string> { ElementTheme.SoldierRocket.ToString(), ElementTheme.SoldierShotGun.ToString(), ElementTheme.SoldierPistol.ToString(), ElementTheme.SoldierMG.ToString(), 
                    ElementTheme.FlyingSoldierFlameThrower.ToString(), ElementTheme.Helicopter.ToString(), ElementTheme.HelicopterMGOnlyB.ToString(), ElementTheme.SoldierTank.ToString(), 
                    ElementTheme.SoldierRobot.ToString(), ElementTheme.LastRobot.ToString() }, levelIdSwitcher);

            IThemeLoader themeLoader = new StrategyRemover(new ThemeLoader(scenarioAnimationLoader, "Content\\ElementThemes"));

            TextureCache textureCacheMenu = new TextureCache(new TextureLoader(textureChanger));
            AnimationLoader animationLoaderMenu = new AnimationLoader(textureCacheMenu);
            RectangleFactory rectangleFactoryMenu = new RectangleFactory(animationLoaderMenu, textureChanger, new PolygonRenderer(), "Content\\MenuThemes\\Characters", "Content\\MenuThemes\\Images");
            ITextFactory textFactory = new TextFactory(animationLoaderMenu, new RectanglePolygonBuilder(), textureChanger, new ColorToPercentMapper() ,new PolygonRenderer(), "Content\\MenuThemes\\Characters", 0.05);
            BufferLoader bufferLoader = new BufferLoader(new WavFileReader());
            SoundFactory soundFactory = new SoundFactory(bufferLoader, 100, ((float)configuration.SoundVolume) / 100.0f);
            SoundFactory musicFactory = new SoundFactory(bufferLoader, 80, ((float)configuration.MusicVolume) / 133.0f);
            IContentDisposer contentDisposer = new ResourceComposition(textureCache, soundFactory);

            TriangleRenderer polygonRenderer = new TriangleRenderer();
            EnvironmentProviders environmentProviders = new EnvironmentProviders
            {
                BackgroundColorProvider = new BackgroundColorProvider(new ColorProvider()),
                FloorProvider = new FloorProvider(textureCache, textureChanger, polygonRenderer),
                SkylineElementProvider = new SkylineElementProvider(textureCache, textureChanger, new TextureTranslator(), polygonRenderer, new LightSwitch(), animationLoader),
                LightCollectionProvider = new LightCollectionProvider()
            };

            SkillLevelRepository skillLevelRepository = new SkillLevelRepository();
            IInitializer initializer = null;
            IList<ILevelLoader> loader = new List<ILevelLoader>();
            WorldTranslator worldTranslator = new WorldTranslator();
            IExecuteble screenShotMaker = configuration.ScreenShotMaker ? new GifCamera("C:\\Screenshots\\trailer\\snow\\Pic", 50, 0.04, configuration.Resolution.X, configuration.Resolution.Y, pressedKeyDetector) : null;
            AlphaTester alphaTester = new AlphaTester();
            IPercentDrivenSprite fadeOutAnimation = new AnimationByPercentSprite(new AlphaChannelListRenderer(alphaTester, new List<IDrawable> { new SurfaceRectangle(polygonRenderer, -1, 0.0, 3f, 3f, false, textureOne: 10f) }),
                animationLoaderMenu.LoadAnimation("Content\\Animations\\Black"), textureChanger, true);

            ProfileAccessor profileLoader = new ProfileAccessor("Profile", "StandardProfile", new FileSerializer());

            LevelElementSplitter levelElementSplitter = new LevelElementSplitter(new List<ElementTheme> 
            { 
                ElementTheme.PlayerOne,
                ElementTheme.SoldierPistol,
                ElementTheme.SoldierPistolF,
                ElementTheme.SoldierPistolR,
                ElementTheme.SoldierRocket,
                ElementTheme.SoldierRocketF,
                ElementTheme.SoldierRocketR,
                ElementTheme.SoldierShotGun,
                ElementTheme.SoldierShotGunF,
                ElementTheme.SoldierShotGunR,
                ElementTheme.SoldierTank,
                ElementTheme.SoldierMG,
                ElementTheme.SoldierRobot,
                ElementTheme.LastRobot,
                ElementTheme.FlyingSoldierFlameThrower,
                ElementTheme.Helicopter,
                ElementTheme.HelicopterMGOnlyB,
                ElementTheme.Dog,
                ElementTheme.AutoMG,
                ElementTheme.Ninja,
                ElementTheme.Capitalist1,
                ElementTheme.Capitalist2,
                ElementTheme.Capitalist3,
                ElementTheme.AtomaticMGChainPlaceHolder,
                ElementTheme.AtomaticMGPlaceHolder,
                ElementTheme.PistolPlaceHolder,
                ElementTheme.PistolBulletPlaceHolder,
                ElementTheme.ShotGunPlaceHolder,
                ElementTheme.ShotShellsPlaceHolder,
                ElementTheme.MGPlaceHolder,
                ElementTheme.MGChainPlaceHolder,
                ElementTheme.GrenadeLauncherPlaceHolder,
                ElementTheme.GrenadePlaceHolder,
                ElementTheme.RocketThrowerPlaceHolder,
                ElementTheme.RocketPlaceHolder,
                ElementTheme.UziPlaceHolder,
                ElementTheme.UziBulletPlaceHolder,
            });

            TextureTranslator textureTranslator = new TextureTranslator();
            GameModeProvider[] gameModeProviderArray = new GameModeProvider[1];
            RectanglePolygonBuilder rPB = new RectanglePolygonBuilder();
            PolygonRenderer polygonRendererPolygons = new PolygonRenderer();

            if (configuration.LevelEditor)
            {
                initializer = new LevelEditorInitializer(textureCache, animationLoader, themeLoader,
                        playerCamera, playerCamera, new MessageRendererFactory(textFactory), screen,
                        new LevelEditorPlayerInstructionMapper(new PlayerInstructionMapper(pressedKeyDetector, mouseController, configuration.MouseSensitivity),
                            pressedKeyDetector, mouseController),
                        environmentProviders, textureChanger, alphaTester, worldTranslator,
                        polygonRenderer, new RenderedSideSwitcher(), new WorldRotator(), screenShotMaker, levelElementSplitter);
            }
            else // standard
            {
                Dictionary<int, IRectangle> numbers = new Dictionary<int, IRectangle>();
                
                double numberSize = 0.04;

                numbers.Add(0, new Rectangle2D(animationLoaderMenu.LoadAnimation("Content\\MenuThemes\\Characters\\0"), textureChanger, polygonRendererPolygons, rPB, 0, 0, numberSize, numberSize, false));
                numbers.Add(1, new Rectangle2D(animationLoaderMenu.LoadAnimation("Content\\MenuThemes\\Characters\\1"), textureChanger, polygonRendererPolygons, rPB, 0, 0, numberSize, numberSize, false));
                numbers.Add(2, new Rectangle2D(animationLoaderMenu.LoadAnimation("Content\\MenuThemes\\Characters\\2"), textureChanger, polygonRendererPolygons, rPB, 0, 0, numberSize, numberSize, false));
                numbers.Add(3, new Rectangle2D(animationLoaderMenu.LoadAnimation("Content\\MenuThemes\\Characters\\3"), textureChanger, polygonRendererPolygons, rPB, 0, 0, numberSize, numberSize, false));
                numbers.Add(4, new Rectangle2D(animationLoaderMenu.LoadAnimation("Content\\MenuThemes\\Characters\\4"), textureChanger, polygonRendererPolygons, rPB, 0, 0, numberSize, numberSize, false));
                numbers.Add(5, new Rectangle2D(animationLoaderMenu.LoadAnimation("Content\\MenuThemes\\Characters\\5"), textureChanger, polygonRendererPolygons, rPB, 0, 0, numberSize, numberSize, false));
                numbers.Add(6, new Rectangle2D(animationLoaderMenu.LoadAnimation("Content\\MenuThemes\\Characters\\6"), textureChanger, polygonRendererPolygons, rPB, 0, 0, numberSize, numberSize, false));
                numbers.Add(7, new Rectangle2D(animationLoaderMenu.LoadAnimation("Content\\MenuThemes\\Characters\\7"), textureChanger, polygonRendererPolygons, rPB, 0, 0, numberSize, numberSize, false));
                numbers.Add(8, new Rectangle2D(animationLoaderMenu.LoadAnimation("Content\\MenuThemes\\Characters\\8"), textureChanger, polygonRendererPolygons, rPB, 0, 0, numberSize, numberSize, false));
                numbers.Add(9, new Rectangle2D(animationLoaderMenu.LoadAnimation("Content\\MenuThemes\\Characters\\9"), textureChanger, polygonRendererPolygons, rPB, 0, 0, numberSize, numberSize, false));

               

                initializer = new LevelInitializer(textureCache, animationLoader, themeLoader, playerCamera, playerCamera,
                        new MessageRendererFactory(textFactory),
                        screen, new PlayerInstructionMapper(pressedKeyDetector, mouseController, configuration.MouseSensitivity), environmentProviders,
                        textureChanger, soundFactory, alphaTester, worldTranslator, textureTranslator,
                        polygonRenderer, new RenderedSideSwitcher(), new WorldRotator(), () => 
                        {
                            int levelId = ((ILevelIdProvider)levelIdSwitcher).GetLevelId();
                            if (levelId == 28)
                            {
                                FrameworkImplementations.Fader fader = new FrameworkImplementations.Fader(((ITextureLoader)textureCacheMenu).LoadTexture("Content\\Images\\fadebg.png", false), textureChanger, new SurfaceRectangle(polygonRenderer, -1, -0.5, 3f, 2f, false), new AlphaBlender(), 2, 2);
                                FinalAnimationRenderer finalAnimationRenderer = new FinalAnimationRenderer(swapBuffer,
                                    new ImageRectangle(((ITextureLoader)textureCacheMenu).LoadTexture("Content\\Images\\finale.png", false), textureChanger,
                                    new SurfaceRectangle(polygonRenderer, 0, 0, 1f, 1f, false)),
                                    new BackgroundColor(Color.Black),
                                    fader, fader);
                                finalAnimationRenderer.RenderAnimation();
                                gameModeProviderArray[0].Reset();
                                return;
                            }

                            ((ILevelIdSwitcher)levelIdSwitcher).SwitchToNextLevel();
                            ProfileInformation info = ((IProfileLoader)profileLoader).LoadProfile();
                            info.NextLevel = ((ILevelIdProvider)levelIdSwitcher).GetLevelId();
                            info.SkillLevel = ((ISkillLevelProvider)skillLevelRepository).GetSkillLevel();
                            ((IProfileSaver)profileLoader).SaveProfile(info);
                            loader.First().LoadLevel();
                        }, configuration.FrameCounter, screenShotMaker, new DepthTestActivator(),
                        new Scaler(), new AlphaBlender(), new PlayerDeathObserver(() =>
                        {
                            loader.First().LoadLevel();
                        }), numbers);
            }

            IntroRenderer introRenderer = new FrameworkImplementations.IntroRenderer(swapBuffer,
                new TranslationAnimatedSprite(new ImageRectangle(((ITextureLoader)textureCacheMenu).LoadTexture("Content\\MenuThemes\\allcolors.bmp", false), textureChanger,
                    new SurfaceRectangle(polygonRenderer, -2, -2, 5f, 15f, false, 40)), worldTranslator, new Position3D { PositionX = 0 }, new Position3D { PositionY = -8 }));
            introRenderer.RenderAnimation();
            TimeAndSpeedManager.Reset();

            GameModeProvider gameModeProvider = new GameModeProvider(new FrameworkImplementations.PressedKeyEncapsulator(Keys.Escape, pressedKeyDetector));
            gameModeProviderArray[0] = gameModeProvider;

            LevelLoader levelLoader = new LevelLoader(initializer, gameModeProvider, levelIdSwitcher, contentDisposer, new StandardResourcePreloader(animationLoader, "Content\\Animations", themeLoader), skillLevelRepository);
            loader.Add(levelLoader);

            GameStartInitializer gameStarter = new GameStartInitializer(((ILevelLoader)levelLoader).LoadLevel, configuration.StartLevelId.HasValue ? (ILevelIdSwitcher)(new FakeIdSetter()) : levelIdSwitcher, skillLevelRepository);

            Rectangle2DImage mouse = new Rectangle2DImage(((ITextureLoader)textureCacheMenu).LoadTexture("Content\\Images\\cross.png", false), textureChanger, polygonRendererPolygons, rPB, 0, 0, 0.1, 0.1, true);
            MainMenu menu = new MainMenu(mouse, textFactory,
                screen, clickedExit, mouseController, pressedKeyDetector, profileLoader, gameStarter, () =>
            {
                ProfileInformation info = ((IProfileLoader)profileLoader).LoadProfile();
                ((IGameStartInitializer)gameStarter).SetLevelId(info.NextLevel.Value);
                ((IGameStartInitializer)gameStarter).SetSkillLevel(info.SkillLevel);
                ((IGameStartInitializer)gameStarter).Start();
            });
            BackgroundSwitcher backgroundSwitcher = new BackgroundSwitcher(soundFactory, new BackgroundColor(Color.Black), levelLoader, new BackgroundColor(Color.Black), mouseController);
            gameModeProvider.AddObserver(backgroundSwitcher);
            gameModeProvider.AddObserver(menu);

            IDrawable loadingRenderer = new LoadingRenderer(levelLoader,
                new PercentDrivenList(new List<IPercentDrivenSprite> {
                new TranslationAnimatedSprite(new ImageRectangle(((ITextureLoader)textureCacheMenu).LoadTexture("Content\\Images\\black.bmp", false), textureChanger,
                    new SurfaceRectangle(polygonRenderer, 0.3, 0.3, 0.4f, 0.1f, false)), worldTranslator, new Position3D { PositionX = 0 }, new Position3D { PositionX = 0.3 }),
                new AnimationByPercentSprite(new SurfaceRectangle(polygonRenderer, 0.12, 0.4, 0.8f, 0.4f, false), animationLoaderMenu.LoadAnimation("Content\\Animations\\Loading"),textureChanger, factor:3)
                }
                    ), 1);


            IDrawable loadScreen = new AlphaChannelListRenderer(new AlphaTester(), new List<IDrawable> 
            { 
                new ImageRectangle(((ITextureLoader)textureCacheMenu).LoadTexture("Content\\Images\\blue.bmp", false), textureChanger,
                    new SurfaceRectangle(polygonRenderer, 0.3, 0.3, 0.4f, 0.1f, false)),
                loadingRenderer
            });

            IDrawable menuBackground = new ListRenderer(new List<IDrawable>
            {
            });

            IDrawable renderer = new MainRenderer(gameModeProvider, new AlphaChannelListRenderer(new AlphaTester(),
                new List<IDrawable> { menuBackground, (IDrawable)menu }), loadScreen, camera, levelLoader);

            

            IExecuteble gameLogic = new Updater(gameModeProvider, levelLoader, menu);

            return new FrameWorkflow(gameLogic, renderer);
        }

        private class FakeIdSetter : ILevelIdSwitcher
        {
            void ILevelIdSwitcher.SwitchToNextLevel()
            { }

            void ILevelIdSwitcher.SetSpecificLevel(int id)
            { }
        }
    }
}
