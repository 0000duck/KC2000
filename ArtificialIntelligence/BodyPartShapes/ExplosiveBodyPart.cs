using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using IOInterface;

namespace ArtificialIntelligence.BodyPartShapes
{
    public class ExplosiveBodyPart : IVulnerable
    {
        private IExplosionManager _explosionManager;
        private double _strength;
        private double _explosionStrength;
        private double _radius;
        private bool _exploded;

        public ExplosiveBodyPart(IExplosionManager explosionManager, double strength, double explosionStrength, double radius)
        {
            _explosionManager = explosionManager;
            _strength = strength;
            _explosionStrength = explosionStrength;
            _radius = radius;
        }

        void IVulnerable.YouGotHit(Position3D position, double destructionStrength, Vector3D directionVector)
        {
            if (_exploded)
                return;

            _strength -= destructionStrength;

            if (_strength <= 0)
            {
                _explosionManager.StartNewExplosion(null, position, _explosionStrength, _radius * _radius);
                _exploded = true;
            }
        }
    }
}
