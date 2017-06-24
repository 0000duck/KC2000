using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace GameInteractionContracts
{
    public interface IQuakeTriggerer
    {
        void TriggerRelativeQuake(Position3D quakePosition, double strengthPercent);

        void TriggerAbsoluteQuake(double strengthPercent);
    }
}
