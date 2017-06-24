using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sound.Contracts;
using FrameworkContracts;
using Render.Contracts;
using BaseTypes;
using BaseContracts;

namespace FrameworkImplementations
{
    public class VisualSoundAnimation : ISound, IDrawable
    {
        private IAnimation _animation;
        private ITextureChanger _textureChanger;
        private Position3D _lastGivenPosition;
        private IList<IParticle> _textParticles;
        private IPercentFader _percentFader;

        public VisualSoundAnimation(IAnimation animation, ITextureChanger textureChanger, IList<IParticle> textParticles)
        {
            _animation = animation;
            _textureChanger = textureChanger;
            _textParticles = textParticles;
            _percentFader = new PercentFader(1.5);
        }

        void ISound.Play()
        {
            if (_lastGivenPosition == null)
                return;

            IParticle particle = _textParticles.FirstOrDefault(x=>x.IsFinished());

            if (particle == null)
                return;

            particle.Start(_lastGivenPosition);
        }

        void ISound.Stop()
        {
        }

        void ISound.SetPosition(float x, float y, float z)
        {
            _lastGivenPosition = new Position3D { PositionX = x, PositionY = y, PositionZ = z };
        }

        void IDrawable.Draw()
        {
            if (_percentFader.IsFinished())
                _percentFader.Start();

            _textureChanger.SetTexture(_animation.GetImage(_percentFader.GetPercent()).Texture.TextureId);

            foreach (IParticle particle in _textParticles)
            {
                if (!particle.IsFinished())
                    particle.Draw();
            }
        }
    }
}
