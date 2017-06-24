using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using IOInterface;
using BaseTypes;
using Render.Contracts;

namespace DrawableElements
{
    public class CurveFlyingParticle : IAnimationParticle
    {
        private Animation _animationType;
        private IAnimation _animation;
        private Position3D _position;
        private IDrawable _sprite;
        private PercentFader _percentFader;
        private ITextureChanger _textureChanger;
        private IWorldTranslator _worldTranslator;
        private double _fallDistance;
        private double _maxHeight;

        public CurveFlyingParticle(Animation animationType, ITextureChanger textureChanger, IAnimation animation, IDrawable sprite, double duration, IWorldTranslator worldTranslator)
        {
            _animation = animation;
            _sprite = sprite;
            _animationType = animationType;
            _textureChanger = textureChanger;
            _percentFader = new PercentFader(duration);
            _worldTranslator = worldTranslator;
        }

        void IDrawable.Draw()
        {
            double percent = _percentFader.GetPercent();

            _textureChanger.SetTexture(_animation.GetImage(percent, Degree.Degree_0).Texture.TextureId);

            _worldTranslator.Store();

            double y;
            if (percent >= 0.5)
            {
                _fallDistance += TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond * _maxHeight;
                y = -_fallDistance; 
            }
            else
                y = Math.Sin(percent * 2 * Math.PI) * 0.8;

            _worldTranslator.TranslateWorld(_position.PositionX, _position.PositionY + y, _position.PositionZ);

            _sprite.Draw();

            _worldTranslator.Reset();
        }

        Animation IAnimationParticle.Animation
        {
            get { return _animationType; }
        }

        bool IParticle.IsFinished()
        {
            return _percentFader.IsFinished();
        }

        void IParticle.Start(Position3D position)
        {
            _position = new Position3D { PositionX = position.PositionX, PositionY = position.PositionZ, PositionZ = position.PositionY };
            _percentFader.Start();
            _fallDistance = 0;
            _maxHeight = _position.PositionY * 4;
        }
    }
}
