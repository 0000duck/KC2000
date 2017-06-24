using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace DrawableElements
{
    public class OpacityRenderer : IDrawable
    {
        private IAlphaBlender _alphaRenderer;
        private double _opacity;
        private IDrawable _opacityElement;

        public OpacityRenderer(IAlphaBlender alphaRenderer, double opacity, IDrawable opacityElement)
        {
            _alphaRenderer = alphaRenderer;
            _opacity = opacity;
            _opacityElement = opacityElement;
        }

        void IDrawable.Draw()
        {
            _alphaRenderer.BeginBlending();
            _alphaRenderer.SetOpacity(_opacity);
            _opacityElement.Draw();
            _alphaRenderer.EndBlending();
        }
    }
}
