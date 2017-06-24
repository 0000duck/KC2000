using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteraction.BaseImplementations;
using ArtificialIntelligence.Contracts;
using IOInterface;
using GameInteractionContracts;
using BaseContracts;
using BaseTypes;

namespace ElementImplementations.BoxImplementations
{
    public class ExplodableElement : AnimatibleElement, IExplosionVulnerable, IVulnerable
    {
        private bool _exploded;
        private double _explosionStrength;
        private double _explosionSquareRadius;
        private IExplosionManager _explosionManager;
        private IElementCreator _elementCreator;

        public ExplodableElement(IExplosionManager explosionManager, double explosionStrength, double explosionRadius, IElementCreator elementCreator)
        {
            _explosionStrength = explosionStrength;
            _explosionSquareRadius = explosionRadius * explosionRadius;
            _explosionManager = explosionManager;
            _elementCreator = elementCreator;
        }

        void IExplosionVulnerable.YouGotHit(Position3D explosionPosition, double destructionStrength)
        {
            if (_exploded)
                return;

            ExplodeAndDisappear();
        }

        private void ExplodeAndDisappear()
        {
            Position3D position = Position.Clone();
            position.PositionZ += Height / 2.0;
            _exploded = true;
            _explosionManager.StartNewExplosion(this, position, _explosionStrength, _explosionSquareRadius);
            _elementCreator.DeleteElement(this);
        }

        void IVulnerable.YouGotHit(Position3D position, double destructionStrength, Vector3D directionVector)
        {
            if (_exploded)
                return;

            ExplodeAndDisappear();
        }
    }
}
