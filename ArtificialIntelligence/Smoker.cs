using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using IOInterface;

namespace ArtificialIntelligence
{
    public class Smoker : ISmoker
    {
        private IParticleManager _particleManager;
        private IUpdateTimer _updateTimer;
        private Animation _animation;
        private double _smokeHeight;

        public Smoker(IParticleManager particleManager, IUpdateTimer updateTimer, Animation animation, double smokeHeight)
        {
            _particleManager = particleManager;
            _updateTimer = updateTimer;
            _animation = animation;
            _smokeHeight = smokeHeight;
        }

        void ISmoker.Smoke(Position3D position)
        {
            if (_updateTimer.UpdateIsNecessary())
            {
                Position3D smokePosition = position.Clone();
                smokePosition.PositionZ += _smokeHeight;
                _particleManager.StartNewParticleAnimation(smokePosition, _animation);
            }
        }
    }
}
