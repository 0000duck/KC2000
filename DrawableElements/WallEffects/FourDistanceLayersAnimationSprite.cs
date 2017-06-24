using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using Render.Contracts;

namespace DrawableElements.WallEffects
{
    public class FourDistanceLayersAnimationSprite : IDrawable
    {
        private IAnimation _animation;
        private IDrawable _spriteVeryNear;
        private IDrawable _spriteNear;
        private IDrawable _spriteFar;
        private IDrawable _spriteVeryFar;
        private IPlayerDistanceAnalyser _playerDistanceAnalyser;
        private PercentFader _delayWaiter;
        private double _animationPercent;
        private ITextureChanger _textureChanger;

        public FourDistanceLayersAnimationSprite(IAnimation animation, ITextureChanger textureChanger, IDrawable spriteVeryNear, IDrawable spriteNear, IDrawable spriteFar, IDrawable spriteVeryFar, IPlayerDistanceAnalyser playerDistanceAnalyser, double delay, double animationPercent)
        {
            _animation = animation;
            _spriteVeryNear = spriteVeryNear;
            _spriteNear = spriteNear;
            _spriteFar = spriteFar;
            _spriteVeryFar = spriteVeryFar;
            _playerDistanceAnalyser = playerDistanceAnalyser;
            _animationPercent = animationPercent;
            _textureChanger = textureChanger;
            _delayWaiter = new PercentFader(delay);
            _delayWaiter.Start();
        }

        void IDrawable.Draw()
        {
            _delayWaiter.GetPercent();
            if (!_delayWaiter.IsFinished())
                return;

            _textureChanger.SetTexture(_animation.GetImage(_animationPercent).Texture.TextureId);

            Distance distance = _playerDistanceAnalyser.GetPlayerDistance();

            if (distance == Distance.VeryFar)
                _spriteVeryFar.Draw();
            else if (distance == Distance.Far)
                _spriteFar.Draw();
            else if (distance == Distance.Near)
                _spriteNear.Draw();
            else
                _spriteVeryNear.Draw();
        }
    }
}
