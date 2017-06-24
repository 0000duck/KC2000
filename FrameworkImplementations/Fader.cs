using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;
using BaseTypes;

namespace FrameworkImplementations
{
    public class Fader : IDrawable, IFader
    {
        private ITexture _texture;
        private ITextureChanger _textureChanger;
        private IDrawable _sprite;
        private PercentFader _percentFader;
        private IAlphaBlender _alphaRenderer;
        private bool _fadeIn;
        private bool _started;
        private bool _fadeOut;
        private double _fadeOutDuration;

        public Fader(ITexture texture, ITextureChanger textureChanger, IDrawable sprite, IAlphaBlender alphaRenderer, double fadeInDuration, double fadeOutDuration)
        {
            _texture = texture;
            _textureChanger = textureChanger;
            _sprite = sprite;
            _alphaRenderer = alphaRenderer;
            _fadeOutDuration = fadeOutDuration;
            _fadeIn = true;
            _percentFader = new PercentFader(fadeInDuration);
        }

        void IDrawable.Draw()
        {
            if (_fadeIn)
            {
                if (!_started)
                {
                    _percentFader.Start();
                    _started = true;
                }
                double percent = _percentFader.GetPercent();
                RenderFadedLayer(1.0 - percent);
                if (_percentFader.IsFinished())
                {
                    _fadeIn = false;
                }
            }
            else if (_fadeOut)
            {
                RenderFadedLayer(_percentFader.GetPercent());
            }
        }

        private void RenderFadedLayer(double opacity)
        {
            _alphaRenderer.BeginBlending();

            _textureChanger.SetTexture(_texture.TextureId);
            _alphaRenderer.SetOpacity(opacity);
            _sprite.Draw();

            _alphaRenderer.EndBlending();
        }

        void IFader.FadeOut()
        {
            _fadeOut = true;
            _percentFader = new PercentFader(_fadeOutDuration);
            _percentFader.Start();
        }
    }
}
