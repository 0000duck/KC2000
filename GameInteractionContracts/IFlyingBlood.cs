using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace GameInteractionContracts
{
    public interface IFlyingBlood
    {
        void StartFlight(Vector3D directionVector, double speed, double timeToLiveInSeconds);
    }
}
