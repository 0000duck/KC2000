using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using FrameworkContracts;
using DrawableElements;
using BaseTypes;
using LevelEditor.CommunicationElements;
using SaveGames;
using Render.Contracts;

namespace LevelEditor
{
    public class CommunicationElementFactory : ICommunicationElementFactory
    {
        private IDrawableList DrawableList { set; get; }
        private ITextureLoader TextureLoader { set; get; }
        private IAnimationLoader AnimationLoader { set; get; }
        private IThemeLoader ThemeLoader { set; get; }
        private IPlayerCameraConnection PlayerCamera { set; get; }
        private IPlayerCamera Camera { set; get; }
        private IResolutionToSizeMapper ResolutionToSizeMapper { set; get; }
        private ITextureChanger _textureChanger;
        private IWorldTranslator _worldTranslator;
        private IPolygonRenderer _polygonRenderer;
        private IRenderedSideSwitcher _renderedSideSwitcher;
        private IWorldRotator _worldRotator;

        public CommunicationElementFactory(ITextureLoader textureLoader, ITextureChanger textureChanger, IAnimationLoader animationLoader, IThemeLoader themeLoader,
            IDrawableList drawableList, IPlayerCameraConnection playerCamera, IPlayerCamera camera, IWorldTranslator worldTranslator, IPolygonRenderer polygonRenderer,
            IRenderedSideSwitcher renderedSideSwitcher, IWorldRotator worldRotator)
        {
            DrawableList = drawableList;
            TextureLoader = textureLoader;
            AnimationLoader = animationLoader;
            ThemeLoader = themeLoader;
            PlayerCamera = playerCamera;
            Camera = camera;
            ResolutionToSizeMapper = new ResolutionToSizeMapper();
            _textureChanger = textureChanger;
            _worldTranslator = worldTranslator;
            _polygonRenderer = polygonRenderer;
            _renderedSideSwitcher = renderedSideSwitcher;
            _worldRotator = worldRotator;
        }

        public ICommunicationElement CreateNewElement(IElement element)
        {
            ICommunicationElement communicationElement;
            IDrawable sprite = null;
            IDrawable markedSprite;

            switch (element.ElementTheme)
            {
                case ElementTheme.Fist:
                case ElementTheme.Pistol:
                case ElementTheme.PistolBullets:
                
                    return null;
                case ElementTheme.PlayerOne:
                    communicationElement = new PlayerCommunicationElement(PlayerCamera);
                    break;
                default:
                    if (element.Parameters != null && element.Parameters is IVisualParameters)
                    {
                        IVisualParameters appearance = element.Parameters as IVisualParameters;

                        if (appearance.Shape == Shape.Circle)
                            sprite = new RotatingSprite(Camera,_polygonRenderer,_renderedSideSwitcher, _worldRotator, appearance);
                        else
                            sprite = new Box(appearance, element.Orientation, _polygonRenderer);

                        markedSprite = new MarkedBox(appearance, element.Orientation);

                        if (appearance.IsAnimation)
                        {
                            IAnimation animation = AnimationLoader.LoadAnimation(appearance.TextureFolder);
                            communicationElement = new EditorAnimationSprite(AnimationLoader,_textureChanger, animation, element.StartPosition, sprite, markedSprite, new SimpleDegreeCalculator(Camera, new DegreeMapper()), appearance.AnimationDurationPerImage, _worldTranslator);
                        }
                        else
                        {
                            ITexture texture = TextureLoader.LoadTexture(appearance.TextureFolder, false);
                            communicationElement = new EditorImageSprite(TextureLoader, texture, _textureChanger, element.StartPosition, sprite, markedSprite, _worldTranslator);
                        }
                    }
                    else
                    {
                        ITheme theme = ThemeLoader.LoadTheme(element.ElementTheme);
                        IAnimationImage texture = theme.GetTexture(Behaviour.StandardBehaviour, Degree.Degree_0, 0);
                        IDrawable spriteGeometry;
                        if (element.Parameters != null && element.Parameters.Shape == Shape.Rectangle)
                        {
                            IVisualParameters parameters = new VisualParameters(element.Parameters);
                            spriteGeometry = new Box(parameters, element.Orientation, _polygonRenderer);
                        }
                        else
                        {
                            spriteGeometry = new RotatingSprite(Camera,_polygonRenderer, _renderedSideSwitcher, _worldRotator, ResolutionToSizeMapper.GetSize(texture.Texture.ResolutionX), ResolutionToSizeMapper.GetSize(texture.Texture.ResolutionY));
                        }
                        communicationElement = new ThemeSprite(theme,_textureChanger,
                        element.StartPosition.Clone(), spriteGeometry, new ComplexDegreeCalculator(Camera, new DegreeMapper()), _worldTranslator);
                    }
                    break;
            }

            if (communicationElement is IDrawable)
                DrawableList.Add((IDrawable)communicationElement);

            return communicationElement;
        }
    }
}
