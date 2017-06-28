using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InitializationContracts;
using FrameworkContracts;
using DrawableElements;
using Render.Contracts;

namespace OpenTKPortation.Implementations.Providers
{
    public class SkylineElementProvider : ISkylineElementProvider
    {
        private ITextureLoader _textureLoader;
        private ITextureChanger _textureChanger;
        private IPolygonRenderer _polygonRenderer;
        private ILightSwitch _lightSwitch;
        private IAnimationLoader _animationLoader;
        private ITextureTranslator _textureTranslator;

        public SkylineElementProvider(ITextureLoader textureLoader, ITextureChanger textureChanger, ITextureTranslator textureTranslator, IPolygonRenderer polygonRenderer, ILightSwitch lightSwitch, IAnimationLoader animationLoader)
        {
            _textureLoader = textureLoader;
            _textureChanger = textureChanger;
            _textureTranslator = textureTranslator;
            _polygonRenderer = polygonRenderer;
            _lightSwitch = lightSwitch;
            _animationLoader = animationLoader;
        }
        IDrawable ISkylineElementProvider.GetSkylineElement(int levelId)
        {
            switch (levelId)
            {
                default:
                    return null;// new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\Images\\white.bmp", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons(), _lightSwitch);
            }
        }
    }
}
