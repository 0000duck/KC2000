using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using IOInterface;
using BaseTypes;

namespace ElementImplementations.CharacterImplementations
{
    public class BloodExplosionNotifier : IDestructionObserver, IExitWoundObserver
    {
        private IBloodParticleByBodyPartTriggerer _bloodParticleByBodyPartTriggerer;
        private IBloodParticleByCaliberTriggerer _bloodParticleByCaliberTriggerer;

        public BloodExplosionNotifier(IBloodParticleByBodyPartTriggerer bloodParticleByBodyPartTriggerer, IBloodParticleByCaliberTriggerer bloodParticleByCaliberTriggerer)
        {
            _bloodParticleByBodyPartTriggerer = bloodParticleByBodyPartTriggerer;
            _bloodParticleByCaliberTriggerer = bloodParticleByCaliberTriggerer;

        }

        void IDestructionObserver.NotifyFullDestruction(BodyPart bodyPart, Position3D position)
        {
            _bloodParticleByBodyPartTriggerer.TriggerBloodParticle(bodyPart, position);
        }

        void IDestructionObserver.NotifyInnerDestruction()
        {

        }

        void IExitWoundObserver.NotifyExitWound(BodyPart bodyPart, Position3D position, Vector3D directionVector, double destructionStrength)
        {
            _bloodParticleByCaliberTriggerer.TriggerBloodParticle(position, directionVector, destructionStrength);
        }
    }
}
