using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using FrameworkContracts;
using BaseTypes;
using DrawableElements;
using SaveGames;
using Render.Contracts;

namespace OpenTKPortation.Implementations
{
    public class CommunicationElementFactory : ICommunicationElementFactory
    {
        private IDrawableList DrawableList { set; get; }
        private ITextureLoader TextureLoader { set; get;} 
        private IAnimationLoader AnimationLoader { set; get; }
        private IThemeLoader ThemeLoader { set; get; }
        private IPlayerCameraConnection PlayerCameraConnection { set; get; }
        private IPlayerCamera Camera { set; get; }
        private IResolutionToSizeMapper ResolutionToSizeMapper { set; get; }
        private IImageElementSorter _imageElementSorter;
        private ITextureChanger _textureChanger;
        private IWorldTranslator _worldTranslator;
        private ITextureTranslator _textureTranslator;
        private IPolygonRenderer _polygonRenderer;
        private IRenderedSideSwitcher _renderedSideSwitcher;
        private IWorldRotator _worldRotator;

        public CommunicationElementFactory(ITextureLoader textureLoader, ITextureChanger textureChanger, IAnimationLoader animationLoader, IThemeLoader themeLoader,
            IDrawableList drawableList, IImageElementSorter imageElementSorter, IPlayerCameraConnection playerCameraConnection, IPlayerCamera camera, IWorldTranslator worldTranslator,
            ITextureTranslator textureTranslator, IPolygonRenderer polygonRenderer, IRenderedSideSwitcher renderedSideSwitcher, IWorldRotator worldRotator)
        {
            DrawableList = drawableList;
            TextureLoader = textureLoader;
            AnimationLoader = animationLoader;
            ThemeLoader = themeLoader;
            PlayerCameraConnection = playerCameraConnection;
            Camera = camera;
            ResolutionToSizeMapper = new ResolutionToSizeMapper();
            _imageElementSorter = imageElementSorter;
            _textureChanger = textureChanger;
            _worldTranslator = worldTranslator;
            _textureTranslator = textureTranslator;
            _polygonRenderer = polygonRenderer;
            _renderedSideSwitcher = renderedSideSwitcher;
            _worldRotator = worldRotator;
        }

        public ICommunicationElement CreateNewElement(IElement element)
        {
            ICommunicationElement communicationElement;

            switch (element.ElementTheme)
            {
                case ElementTheme.GenericElement:
                case ElementTheme.GenericElementWithoutCollision:
                case ElementTheme.GenericElementWithoutMovement:
                case ElementTheme.SlidingDoor:
                case ElementTheme.BreakableWall:
                case ElementTheme.BleedingBody:
                case ElementTheme.MovingPalm:
                case ElementTheme.MovingTree:
                    if (!(element.Parameters is IVisualParameters))
                        throw new Exception("generic element has no visual appearance!");

                    IVisualParameters appearance = element.Parameters as IVisualParameters;
                    IDrawable sprite = null;
                    if (appearance.Shape == Shape.Circle)
                        sprite = new RotatingSprite(Camera,_polygonRenderer, _renderedSideSwitcher, _worldRotator, appearance.SideLengthX, appearance.Height);
                    else
                        sprite = new Box(appearance, element.Orientation, _polygonRenderer);

                    if (appearance.IsAnimation)
                    {
                        if (appearance.TextureCoordinateDirection.HasValue)
                            communicationElement = new LoopedAnimationSprite(AnimationLoader.LoadAnimation(appearance.TextureFolder), _textureChanger, element.StartPosition,
                                new TextureTranslationDecorator(sprite, _textureTranslator, appearance.AnimationDurationPerImage, appearance.TextureCoordinateDirection.Value), new ComplexDegreeCalculator(Camera, new DegreeMapper()), appearance.AnimationDurationPerImage, _worldTranslator);
                        else if (element.ElementTheme == ElementTheme.BreakableWall)
                            communicationElement = new AnimationSprite(AnimationLoader.LoadAnimation(appearance.TextureFolder), _textureChanger, element.StartPosition, sprite, new ComplexDegreeCalculator(Camera, new DegreeMapper()), _worldTranslator);
                        else
                            communicationElement = new LoopedAnimationSprite(AnimationLoader.LoadAnimation(appearance.TextureFolder), _textureChanger, element.StartPosition, sprite, new ComplexDegreeCalculator(Camera, new DegreeMapper()), appearance.AnimationDurationPerImage, _worldTranslator);
                        
                        DrawableList.Add((IDrawable)communicationElement);
                    }
                    else
                    {
                        ITexture image = TextureLoader.LoadTexture(appearance.TextureFolder, false);
                        communicationElement = new ImageSprite(image, _textureChanger, element.StartPosition, sprite, null, _worldTranslator);
                        _imageElementSorter.AddImageElement((IDrawable)communicationElement, image);
                    }
                    break;
                default:
                    if (element.ElementTheme == ElementTheme.ExplosiveBox && element.Parameters is IVisualParameters)
                    {
                        appearance = element.Parameters as IVisualParameters;
                        sprite = new Box(appearance, element.Orientation,_polygonRenderer);
                        ITexture image = TextureLoader.LoadTexture(appearance.TextureFolder, false);
                        communicationElement = new ImageSprite(image, _textureChanger, element.StartPosition, sprite, null, _worldTranslator);
                        _imageElementSorter.AddImageElement((IDrawable)communicationElement, image);
                        return communicationElement;
                    }
                    if (element.ElementTheme == ElementTheme.Water && element.Parameters is IVisualParameters)
                    {
                        appearance = element.Parameters as IVisualParameters;
                        sprite = new Box(appearance, element.Orientation,_polygonRenderer);
                        communicationElement = new LoopedAnimationSprite(AnimationLoader.LoadAnimation(appearance.TextureFolder), _textureChanger, element.StartPosition, sprite, new ComplexDegreeCalculator(Camera, new DegreeMapper()), appearance.AnimationDurationPerImage, _worldTranslator);
                        DrawableList.Add((IDrawable)communicationElement);
                        return communicationElement;
                    }

                    ITheme theme = ThemeLoader.LoadTheme(element.ElementTheme);
                    IAnimationImage texture = theme.GetTexture(Behaviour.StandardBehaviour, Degree.Degree_0, 0);
                    IDrawable spriteGeometry;
                    if (element.Parameters != null && element.Parameters.Shape == Shape.Rectangle)
                    {
                        IVisualParameters visualParameters = new VisualParameters(element.Parameters);
                        spriteGeometry = new Box(visualParameters, element.Orientation, _polygonRenderer);
                    }
                    else
                    {
                        spriteGeometry = new RotatingSprite(Camera, _polygonRenderer, _renderedSideSwitcher, _worldRotator, ResolutionToSizeMapper.GetSize(texture.Texture.ResolutionX), ResolutionToSizeMapper.GetSize(texture.Texture.ResolutionY));
                    }
                    communicationElement = new ThemeSprite(theme, _textureChanger, element.StartPosition.Clone(), spriteGeometry, new ComplexDegreeCalculator(Camera, new DegreeMapper()), _worldTranslator);
                    DrawableList.Add((IDrawable)communicationElement);
                    break;
            }

            return communicationElement;
        }
    }
}
