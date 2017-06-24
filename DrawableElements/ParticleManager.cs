using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;
using FrameworkContracts;

namespace DrawableElements
{
    public class ParticleManager : IParticleManager, IDrawable
    {
        private IParticleFactory _particleFactory;

        private List<IAnimationParticle> _particles;

        public ParticleManager(IParticleFactory particleFactory)
        {
            _particleFactory = particleFactory;
            _particles = new List<IAnimationParticle>();
        }

        void IParticleManager.StartNewParticleAnimation(Position3D position, Animation animation)
        {
            IAnimationParticle particle = _particles.Find(x => x.Animation == animation && x.IsFinished());

            if (particle == null)
            {
                particle = _particleFactory.CreateParticle(animation);
                _particles.Add(particle);
            }

            particle.Start(position);
        }

        void IDrawable.Draw()
        {
            foreach (IAnimationParticle particle in _particles)
            {
                if (particle.IsFinished())
                    continue;

                particle.Draw();
            }
        }
    }
}
