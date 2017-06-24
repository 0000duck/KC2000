using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace IOInterface
{
    public interface ISphereBloodTriggerer
    {
        void TriggerBloodSphere(Position3D center);
    }
}
