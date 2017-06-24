using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;
using FrameworkContracts;
using BloodEffects.Contracts;

namespace BloodEffects
{
    public class BloodParticleByBodyPartTriggerer : IBloodParticleByBodyPartTriggerer
    {
        private IParticleManager _particleManager;
        private IBloodEffectCreator _bloodEffectCreator;

        public BloodParticleByBodyPartTriggerer(IParticleManager particleManager, IBloodEffectCreator bloodEffectCreator)
        {
            _particleManager = particleManager;
            _bloodEffectCreator = bloodEffectCreator;
        }
        void IBloodParticleByBodyPartTriggerer.TriggerBloodParticle(BodyPart bodyPart, Position3D position)
        {
            switch (bodyPart)
            {
                case BodyPart.Head:
                case BodyPart.Arms:
                    _bloodEffectCreator.CreateBloodEffect(Animation.BloodSmall1, position);
                    _particleManager.StartNewParticleAnimation(position, Animation.SmallBodyExplosion);
                    break;
                case BodyPart.Legs:
                case BodyPart.Torso:
                case BodyPart.Corpse:
                    _bloodEffectCreator.CreateBloodEffect(Animation.BloodMedium1, position);
                    _particleManager.StartNewParticleAnimation(position, Animation.MediumBodyExplosion);
                    break;
                case BodyPart.Full:
                    _bloodEffectCreator.CreateBloodEffect(Animation.BloodMediumLD1, position);
                    _particleManager.StartNewParticleAnimation(position, Animation.BigBodyExplosion);
                    break;
            }
        }
    }
}
