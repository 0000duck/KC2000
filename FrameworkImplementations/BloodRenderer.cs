using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using FrameworkContracts;
using Render.Contracts;

namespace FrameworkImplementations
{
    public class BloodRenderer : IFullVulnerable, IDrawable, IPlayerDeathObserver
    {
        private IAnimation _animation;
        private ITextureChanger _textureChanger;
        private IDrawable _sprite;
        private PercentFader _percentFader;
        private IAlphaBlender _alphaRenderer;
        private double _factor;

        private IPlayerDeathObserver _playerHealthObserver;
        private bool _killAnimationStarted;
        private double _deathDuration;

        public BloodRenderer(IAnimation animation, ITextureChanger textureChanger, IDrawable sprite, IAlphaBlender alphaRenderer, double duration, double factor, IPlayerDeathObserver playerHealthObserver, double deathDuration)
        {
            _animation = animation;
            _textureChanger = textureChanger;
            _sprite = sprite;
            _alphaRenderer = alphaRenderer;
            _factor = factor;
            _playerHealthObserver = playerHealthObserver;
            _deathDuration = deathDuration;
            _percentFader = new PercentFader(duration);
        }

        void IVulnerable.YouGotHit(Position3D position, double destructionStrength, Vector3D directionVector)
        {
            if (_killAnimationStarted)
                return;

            _percentFader.Start();
        }

        void IExplosionVulnerable.YouGotHit(Position3D explosionPosition, double destructionStrength)
        {
            if (_killAnimationStarted)
                return;

            _percentFader.Start();
        }

        void IDrawable.Draw()
        {
            if (_killAnimationStarted)
            {
                if (_percentFader.IsFinished())
                {
                    _playerHealthObserver.PlayerGotKilled();
                }

                double percent = _percentFader.GetPercent();
                RenderBlood(percent);

                return;
            }

            if (!_percentFader.IsFinished())
            {
                double percent = _percentFader.GetPercent();
                RenderBlood((1.0 - percent) * _factor);
            }
        }

        void IPlayerDeathObserver.PlayerGotKilled()
        {
            _killAnimationStarted = true;
            _percentFader = new PercentFader(_deathDuration);
            _percentFader.Start();
        }

        private void RenderBlood(double opacity)
        {
            _alphaRenderer.BeginBlending();

            IAnimationImage texture = _animation.GetImage(0, Degree.Degree_0);
            _textureChanger.SetTexture(texture.Texture.TextureId);
            _alphaRenderer.SetOpacity(opacity);
            _sprite.Draw();

            _alphaRenderer.EndBlending();
        }
    }
}
