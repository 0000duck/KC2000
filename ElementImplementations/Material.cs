using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using GameInteraction.BaseImplementations;
using IOInterface;
using BaseTypes;

namespace ElementImplementations
{
    public class Material : AnimatibleElement, IVulnerable
    {
        private Animation _animation;
        private IParticleManager _particleManager;

        public Material(Animation animation, IParticleManager particleManager, ISimpleCollisionModel collisionModel)
        {
            _animation = animation;
            _particleManager = particleManager;
            MyCollisionModel = collisionModel;
        }

        void IVulnerable.YouGotHit(Position3D position, double destructionStrength, Vector3D directionVector)
        {
            _particleManager.StartNewParticleAnimation(position, _animation);
        }
    }
}
