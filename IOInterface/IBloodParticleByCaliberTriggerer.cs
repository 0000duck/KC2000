using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace IOInterface
{
    public interface IBloodParticleByCaliberTriggerer
    {
        void TriggerBloodParticle(Position3D bloodPosition, Vector3D directionVector, double caliber);
    }
}
