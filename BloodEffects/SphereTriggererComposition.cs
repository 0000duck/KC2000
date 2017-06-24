using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;

namespace BloodEffects
{
    public class SphereTriggererComposition : ISphereBloodTriggerer
    {
        private ISphereBloodTriggerer _sphereBloodTriggerer;
        private ISphereBloodTriggerer _sphereBodyPartTriggerer;

        public SphereTriggererComposition(ISphereBloodTriggerer sphereBloodTriggerer, ISphereBloodTriggerer sphereBodyPartTriggerer)
        {
            _sphereBloodTriggerer = sphereBloodTriggerer;
            _sphereBodyPartTriggerer = sphereBodyPartTriggerer;
        }

        void ISphereBloodTriggerer.TriggerBloodSphere(Position3D center)
        {
            _sphereBloodTriggerer.TriggerBloodSphere(center);
            _sphereBodyPartTriggerer.TriggerBloodSphere(center);
        }
    }
}
