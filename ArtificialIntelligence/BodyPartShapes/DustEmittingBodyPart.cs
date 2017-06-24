using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using IOInterface;

namespace ArtificialIntelligence.BodyPartShapes
{
    public class DustEmittingBodyPart : IVulnerable
    {
        private IParticleManager _particleManager;
        private IVulnerable _vulnerable;
        private Animation _animation;

        public DustEmittingBodyPart(IVulnerable vulnerable, IParticleManager particleManager, Animation animation = Animation.Dust)
        {
            _vulnerable = vulnerable;
            _particleManager = particleManager;
            _animation = animation;
        }

        void IVulnerable.YouGotHit(Position3D position, double destructionStrength, Vector3D directionVector)
        {
            _particleManager.StartNewParticleAnimation(position, _animation);
            _vulnerable.YouGotHit(position, destructionStrength, directionVector);
        }
    }
}
