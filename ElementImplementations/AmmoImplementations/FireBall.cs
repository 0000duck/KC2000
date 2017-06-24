using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using IOInterface;
using BaseTypes;
using BaseContracts;

namespace ElementImplementations.AmmoImplementations
{
    public class FireBall : IAnimationInstructionProvider
    {
        private ISphereDestructionTriggerer _sphereDestructionTriggerer;
        private PercentFader _percentFader;
        private bool _triggeredExplosion;

        public FireBall(ISphereDestructionTriggerer sphereDestructionTriggerer, double timeToLive)
        {
            _sphereDestructionTriggerer = sphereDestructionTriggerer;
            _percentFader = new PercentFader(timeToLive);
            _percentFader.Start();
        }

        AnimationInstruction IAnimationInstructionProvider.GetInstructions(bool collisionWithWorld, Position3D position)
        {
            if (collisionWithWorld && !_triggeredExplosion)
            {
                _sphereDestructionTriggerer.TriggerSphericalDestruction(position);
                _triggeredExplosion = true;
            }

            double percent = _percentFader.GetPercent();

            return new AnimationInstruction 
            {
                Behaviour = Behaviour.StandardBehaviour,
                Percent = percent,
                ElementIsFinished = percent > 0.999
            };
        }
    }
}
