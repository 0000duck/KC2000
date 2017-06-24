using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sound.Contracts;
using FrameworkContracts;
using Render.Contracts;
using BaseTypes;

namespace FrameworkImplementations
{
    public class VisualSound : ISound, IDrawable
    {
        private ITexture _texture;
        private ITextureChanger _textureChanger;
        private Position3D _lastGivenPosition;
        private IList<IParticle> _textParticles;
        

        public VisualSound(ITexture texture, ITextureChanger textureChanger, IList<IParticle> textParticles)
        {
            _texture = texture;
            _textureChanger = textureChanger;
            _textParticles = textParticles;
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
            _textureChanger.SetTexture(_texture.TextureId);

            foreach (IParticle particle in _textParticles)
            {
                if (!particle.IsFinished())
                    particle.Draw();
            }
        }
    }
}
