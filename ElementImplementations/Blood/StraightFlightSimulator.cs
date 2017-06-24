using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using GameInteractionContracts;

namespace ElementImplementations.Blood
{
    public class StraightFlightSimulator : IStraightFlightSimulator
    {
        private double _weight;
        private Vector3D _flightDirection;

        void IStraightFlightSimulator.Initialize(Vector3D flightDirection, double weight)
        {
            _weight = weight;
            _flightDirection = flightDirection;
        }

        IList<Impulse> IStraightFlightSimulator.GetFlightImpulses(double speed)
        {
            List<Impulse> impulses = new List<Impulse>();

            if (_flightDirection == null)
                return impulses;

            double strengthX = _flightDirection.X > 0 ? speed * _flightDirection.X : speed * _flightDirection.X * -1;
            double strengthY = _flightDirection.Y > 0 ? speed * _flightDirection.Y : speed * _flightDirection.Y * -1;
            double strengthZ = _flightDirection.Z > 0 ? speed * _flightDirection.Z : speed * _flightDirection.Z * -1;

            strengthX += _weight;
            strengthY += _weight;
            strengthZ += _weight;

            Impulse impulseX = new Impulse { ImpulseDirection = MathHelper.GetDirectionOfXComponent(_flightDirection), Strength = strengthX };
            Impulse impulseY = new Impulse { ImpulseDirection = MathHelper.GetDirectionOfYComponent(_flightDirection), Strength = strengthY };
            Impulse impulseZ = new Impulse { ImpulseDirection = MathHelper.GetDirectionOfZComponent(_flightDirection), Strength = strengthZ };

            impulses.Add(impulseX);
            impulses.Add(impulseY);
            impulses.Add(impulseZ);

            return impulses;
        }
    }
}
