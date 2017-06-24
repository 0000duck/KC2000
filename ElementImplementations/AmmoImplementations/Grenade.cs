using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using IOInterface;

namespace ElementImplementations.AmmoImplementations
{
    public class Grenade : IAnimationInstructionProvider
    {
        private IExplosionManager _explosionManager;
        private double _destructionStrength;
        private double _destructionSquareRadius;
        private PercentFader _percentFader;

        public Grenade(IExplosionManager explosionManager, double destructionStrength, double destructionRadius, double rotationDuration)
        {
            _explosionManager = explosionManager;
            _destructionStrength = destructionStrength;
            _destructionSquareRadius = destructionRadius * destructionRadius;
            _percentFader = new PercentFader(rotationDuration);
            _percentFader.Start();
        }

        AnimationInstruction IAnimationInstructionProvider.GetInstructions(bool collisionWithWorld, Position3D position)
        {
            if (collisionWithWorld)
            {
                _explosionManager.StartNewExplosion(null, position, _destructionStrength, _destructionSquareRadius);
            }

            return new AnimationInstruction
            {
                Behaviour = Behaviour.StandardBehaviour,
                Percent = _percentFader.GetPercent(),
                ElementIsFinished = collisionWithWorld
            };
        }
    }
}
