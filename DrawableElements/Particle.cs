using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using IOInterface;
using Render.Contracts;

namespace DrawableElements
{
    public class Particle : IAnimationParticle
    {
        private Animation _animationType;
        private IAnimation _animation;
        private Position3D _position;
        private IDrawable _sprite;
        private PercentFader _percentFader;
        private ITextureChanger _textureChanger;
        private IWorldTranslator _worldTranslator;

        public Particle(Animation animationType, ITextureChanger textureChanger, IAnimation animation, IDrawable sprite, double duration, IWorldTranslator worldTranslator)
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
            _textureChanger.SetTexture(_animation.GetImage(_percentFader.GetPercent(), Degree.Degree_0).Texture.TextureId);

            _worldTranslator.Store();

            _worldTranslator.TranslateWorld(_position.PositionX, _position.PositionY, _position.PositionZ);

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
        }
    }
}
