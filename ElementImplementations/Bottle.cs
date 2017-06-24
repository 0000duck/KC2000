using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using GameInteraction.BaseImplementations;
using ArtificialIntelligence.Contracts;
using BaseContracts;
using BaseTypes;
using GameInteractionContracts;
using CollisionDetection.Contracts;

namespace ElementImplementations
{
    public class Bottle : ImpulseProcessingAnimatableElement, IVulnerable, IExplosionVulnerable
    {
        private IParticleManager _particleManager;
        private IElementCreator _elementCreator;

        public Bottle(IParticleManager particleManager, IListProvider<IWorldElement> listProvider, IElementCreator elementCreator, IComplexElementFinder complexElementFinder)
            :base(listProvider, complexElementFinder)
        {
            _particleManager = particleManager;
            _elementCreator = elementCreator;
        }

        void IVulnerable.YouGotHit(BaseTypes.Position3D position, double destructionStrength, BaseTypes.Vector3D directionVector)
        {
            _particleManager.StartNewParticleAnimation(Position.Clone(), Animation.Glass);
            _elementCreator.DeleteElement(this);
        }

        void IExplosionVulnerable.YouGotHit(BaseTypes.Position3D explosionPosition, double destructionStrength)
        {
            _particleManager.StartNewParticleAnimation(Position.Clone(), Animation.Glass);
            _elementCreator.DeleteElement(this);
        }
    }
}
