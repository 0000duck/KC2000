using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace GameInteractionContracts
{
    public interface IStraightFlightSimulator
    {
        void Initialize(Vector3D flightDirection, double weight);

        IList<Impulse> GetFlightImpulses(double speed);
    }
}
