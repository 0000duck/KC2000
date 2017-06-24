using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Render.Contracts;
using FrameworkContracts;
using BaseTypes;

namespace DrawableElements
{
    public class LightlessAnimationRenderer : IDrawable
    {
        private IAnimation _animation;
        private List<Polygon> _polygons;
        private ITextureChanger _textureChanger;
        private IPolygonRenderer _polygonRenderer;
        private ILightSwitch _lightSwitch;
        private PercentFader _percentFader;

        public LightlessAnimationRenderer(IAnimation animation, ITextureChanger textureChanger, IPolygonRenderer polygonRenderer, List<Polygon> polygons, ILightSwitch lightSwitch, double animationDuration)
        {
            _animation = animation;
            _textureChanger = textureChanger;
            _polygonRenderer = polygonRenderer;
            _polygons = polygons;
            _lightSwitch = lightSwitch;
            _percentFader = new PercentFader(animationDuration);
        }

        void IDrawable.Draw()
        {
            if (_percentFader.IsFinished())
                _percentFader.Start();

            _lightSwitch.Off();
            _textureChanger.SetTexture(_animation.GetImage(_percentFader.GetPercent(), Degree.Degree_0).Texture.TextureId);
            _polygonRenderer.RenderPolygons(_polygons);
            _lightSwitch.On();
        }
    }
}
