using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using IOInterface.Events;
using BaseTypes;
using IOInterface;

namespace FrameworkImplementations.FlyingShells
{
    public class FlyingShellFactory : IFlyingShellFactory
    {
        private IParticleManager _particleManager;

        public FlyingShellFactory(IParticleManager particleManager)
        {
            _particleManager = particleManager;
        }

        IFireEventObserver IFlyingShellFactory.CreateFlyingShell(IOInterface.Animation shellAnimation)
        {
            return new FlyingShell(_particleManager, shellAnimation);
        }
    }
}
