using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.Strategies.Spinning
{
    public class Exploder : IExploder
    {
        private IExplosionManager _explosionManager;
        private double _strength;
        private double _radius;

        public Exploder(IExplosionManager explosionManager, double strength, double radius)
        {
            _explosionManager = explosionManager;
            _strength = strength;
            _radius = radius;
        }

        void IExploder.Explode(Position3D position)
        {
            _explosionManager.StartNewExplosion(null, position, _strength, _radius * _radius);
        }
    }
}
