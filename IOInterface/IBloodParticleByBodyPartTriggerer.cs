using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace IOInterface
{
    public interface IBloodParticleByBodyPartTriggerer
    {
        void TriggerBloodParticle(BodyPart bodyPart, Position3D position);
    }
}
