using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Render.Contracts;
using FrameworkContracts;

namespace DrawableElements
{
    public class LightlessImageRenderer : IDrawable
    {
        private ITexture _texture;
        private List<Polygon> _polygons;
        private ITextureChanger _textureChanger;
        private IPolygonRenderer _polygonRenderer;
        private ILightSwitch _lightSwitch;

        public LightlessImageRenderer(ITexture texture, ITextureChanger textureChanger, IPolygonRenderer polygonRenderer, List<Polygon> polygons, ILightSwitch lightSwitch)
        {
            _texture = texture;
            _textureChanger = textureChanger;
            _polygonRenderer = polygonRenderer;
            _polygons = polygons;
            _lightSwitch = lightSwitch;
        }

        void IDrawable.Draw()
        {
            _lightSwitch.Off();
            _textureChanger.SetTexture(_texture.TextureId);
            _polygonRenderer.RenderPolygons(_polygons);
            _lightSwitch.On();
        }
    }
}
