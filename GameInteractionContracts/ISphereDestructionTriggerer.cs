using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace GameInteractionContracts
{
    public interface ISphereDestructionTriggerer
    {
        void TriggerSphericalDestruction(Position3D position);
    }
}
