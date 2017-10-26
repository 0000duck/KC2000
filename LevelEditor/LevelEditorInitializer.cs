using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InitializationContracts;
using ElementImplementations.ActivationManagerImplementations;
using IOInterface;
using ThemeMapping;
using GameInteraction.BaseImplementations;
using SaveGames;
using GameInteraction;
using GameInteraction.ThemeMapping;
using CollisionDetection;
using BaseTypes;
using LevelEditor.Elements;
using FrameworkContracts;
using DrawableElements;
using GameInteractionContracts;
using BaseContracts;
using Render.Contracts;
using EnvironmentAnalysis.RayTest.Rays;
using IOImplementation;
using SaveGames.FileAccess;

namespace LevelEditor
{
    public class LevelEditorInitializer : IInitializer
    {
        private List<IElement> Content { set; get; }

        #region properties for savegames
        private ILevelStateGrabber LevelStateGrabber { set; get; }
        #endregion

        private ITextureLoader TextureLoader { set; get; }
        private IAnimationLoader AnimationLoader { set; get; }
        private IThemeLoader ThemeLoader { set; get; }
        private IPlayerCameraConnection PlayerCamera { set; get; }
        private IPlayerCamera Camera { set; get; }
        private IScreen Screen { set; get; }

        private IPlayerInstructionProvider _playerInstructionProvider;

        private IMessageRendererFactory MessageRendererFactory { set; get; }
        private EnvironmentProviders _environmentProviders;
        private ITextureChanger _textureChanger;
        private IAlphaTester _alphaTester;
        private IWorldTranslator _worldTranslator;
        private IPolygonRenderer _polygonRenderer;
        private IRenderedSideSwitcher _renderedSideSwitcher;
        private IWorldRotator _worldRotator;
        private IExecuteble _screenShotCreator;
        private SkillLevel _skillLevel;
        private ILevelElementSplitter _levelElementSplitter;

        public LevelEditorInitializer(ITextureLoader textureLoader, IAnimationLoader animationLoader, IThemeLoader themeLoader,
            IPlayerCameraConnection playerCamera, IPlayerCamera camera, IMessageRendererFactory messageRendererFactory, IScreen screen,
             IPlayerInstructionProvider playerInstructionProvider, EnvironmentProviders environmentProviders,
            ITextureChanger textureChanger, IAlphaTester alphaTester, IWorldTranslator worldTranslator, IPolygonRenderer polygonRenderer,
            IRenderedSideSwitcher renderedSideSwitcher, IWorldRotator worldRotator, IExecuteble screenShotCreator,
            ILevelElementSplitter levelElementSplitter)
        {
            TextureLoader = textureLoader;
            AnimationLoader = animationLoader;
            ThemeLoader = themeLoader;
            PlayerCamera = playerCamera;
            Camera = camera;
            Screen = screen;
            MessageRendererFactory = messageRendererFactory;

            //one meter divided through weight of a man (his movement power)
            TimeAndSpeedManager.SetSpeedPerSecondAndImpulseStrength(1.0 / 70.0);
            _playerInstructionProvider = playerInstructionProvider;
            _environmentProviders = environmentProviders;
            _textureChanger = textureChanger;
            _alphaTester = alphaTester;
            _worldTranslator = worldTranslator;
            _polygonRenderer = polygonRenderer;
            _renderedSideSwitcher = renderedSideSwitcher;
            _worldRotator = worldRotator;
            _screenShotCreator = screenShotCreator;
            _levelElementSplitter = levelElementSplitter;
        }

        public LevelUnit InitializeLevel(int levelId, SkillLevel skillLevel)
        {
            Content = new List<IElement>();

            ILevelDefinitionLoader loader = new LevelDefinitionLoader(new FileSerializer());
            LevelSaveGame saveGame = loader.LoadLevel(levelId, skillLevel);
            if (saveGame != null)
                Content = saveGame.AllElements;
            _skillLevel = skillLevel;

            return InstantiateControllerObjects(levelId);
        }

        private LevelUnit InstantiateControllerObjects(int levelId)
        {
            LevelUnit levelUnit = new LevelUnit();

            ILightCollection lightCollection = _environmentProviders.LightCollectionProvider.GetCollection(levelId);
            IDrawableList elements = new AlphaChannelListRenderer(_alphaTester, new List<IDrawable> { });
            IDrawable sky = _environmentProviders.SkylineElementProvider.GetSkylineElement(levelId);
            IDrawable floor = _environmentProviders.FloorProvider.GetRenderedFloor(levelId);

            if (floor != null)
                elements.Add(floor);
            if (sky != null)
                elements.Add(sky);

            elements.Add(new MarkedCenter());

            IMessageRenderer target = MessageRendererFactory.CreateMessageRenderer(0.48, 0.48);
            target.RenderMessage("O");
            IMessageRenderer headerRenderer = MessageRendererFactory.CreateMessageRenderer(-0.3, 0.15);
            IMessageRenderer optionRenderer = MessageRendererFactory.CreateMessageRenderer(-0.3, 0.05);
            levelUnit.InfoSurface2D = new ListRenderer(new List<IDrawable> 
            { 
                new FrameCounter(MessageRendererFactory.CreateMessageRenderer(0.9, 0.9)), 
                (IDrawable)target,
                (IDrawable)headerRenderer,
                (IDrawable)optionRenderer
            });

            levelUnit.World3D = new LightRenderer(lightCollection, elements);

            levelUnit.Background = _environmentProviders.BackgroundColorProvider.GetBackgroundColor(levelId);

            ICommunicationElementFactory communicationElementFactory = new CommunicationElementFactory(TextureLoader, _textureChanger, AnimationLoader, ThemeLoader,
                (IDrawableList)elements, PlayerCamera, Camera, _worldTranslator, _polygonRenderer, _renderedSideSwitcher, _worldRotator);

            AnimationListProvider animationList = new AnimationListProvider("Content\\Animations");
            ImageListProvider imageList = new ImageListProvider("Content\\Images");

            ListProviderProvider<IWorldElement> listProviderProvider = new ListProviderProvider<IWorldElement>();
            ElementCreatorProvider elementCreatorProvider = new ElementCreatorProvider();

            ListFillingFactory<IActivatable> ListFillingActivatableElementFactory =
                new ListFillingFactory<IActivatable>(new ElementaryLevelEditorFactory(communicationElementFactory,
                    new WorldEditor(headerRenderer, optionRenderer, new ElementCreator(animationList, imageList, new TextureNormalizer(), new DoorWayCreator(imageList, new TextureNormalizer(), elementCreatorProvider), elementCreatorProvider), new ElementManipulator(elementCreatorProvider)), 
                    animationList, imageList, listProviderProvider,
                    _playerInstructionProvider));

            ListFillingFactory<IWorldElement> ListFillingWorldElementFactory =
                new ListFillingFactory<IWorldElement>(ListFillingActivatableElementFactory);

            ListFillingFactory<IWorldElement> ListFillingFactoryForSaveGames =
                new ListFillingFactory<IWorldElement>(
                new ComplexElementLevelEditorBuilder(ListFillingWorldElementFactory));

            ListFillingFactory<IWorldElement> ListFillingFactoryForCollisionDetection =
                new ListFillingFactory<IWorldElement>(ListFillingFactoryForSaveGames);

            listProviderProvider.ListProvider = ListFillingFactoryForCollisionDetection;

            LevelStateGrabber = new LevelStateGrabberDecorator(new LevelStateGrabber(ListFillingFactoryForSaveGames.GetList()), ListFillingFactoryForSaveGames.GetList());

            LevelSaveTriggerer saveGameSerializer = new LevelSaveTriggerer(LevelStateGrabber,
                new LevelSerializer(new FileSerializer(), _levelElementSplitter),
                levelId, _skillLevel);

            ThemeFacade elementCreator = new ThemeFacade(ListFillingFactoryForCollisionDetection);
            elementCreatorProvider.ElementCreator = elementCreator;

            List<IExecuteble> executebles = new List<IExecuteble> 
            {
                new ElementLogicComposition(ListFillingWorldElementFactory),  
                new ElementMovementComposition(ListFillingWorldElementFactory),  
                new ElementRenderComposition(ListFillingWorldElementFactory),
                elementCreator,
                new QuickSaveTrigger(_playerInstructionProvider, new List<ISaveGameObserver> { saveGameSerializer })
            };
            if (_screenShotCreator != null)
                executebles.Add(_screenShotCreator);

            levelUnit.GameContent = new ExecutebleComposition(executebles);

            levelUnit.ElementCreator = elementCreator;
            levelUnit.Elements = Content;
            levelUnit.Id = levelId;

            CollisionRayFactory.Initialize(400);

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
