using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace Gravity
{
    public interface IGravitationCalculator
    {
        void TriggerGravitation(IWorldElement element, GravitationStatus gravitationStatus);
    }
}
