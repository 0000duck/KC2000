using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface.Events;
using BaseTypes;
using FrameworkContracts;
using IOInterface;

namespace FrameworkImplementations.FlyingShells
{
    public class FlyingShell : IFireEventObserver
    {
        private IOInterface.Animation _animation;
        private IParticleManager _particleManager;

        public FlyingShell(IParticleManager particleManager, IOInterface.Animation animation)
        {
            _particleManager = particleManager;
            _animation = animation;
        }

        void IFireEventObserver.NotifyShot(Position3D position)
        {
            _particleManager.StartNewParticleAnimation(position, _animation);
        }
    }
}
