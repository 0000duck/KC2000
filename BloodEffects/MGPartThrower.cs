using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;
using GameInteractionContracts;
using IOImplementation;

namespace BloodEffects
{
    public class MGPartThrower : ISphereBloodTriggerer
    {
        private IElementCreator _elementCreator;
        private double _distanceFromCeiling;
        private IRandomDirectionThrower _randomDirectionThrower;

        public MGPartThrower(IElementCreator elementCreator, IRandomDirectionThrower randomDirectionThrower, double distanceFromCeiling)
        {
            _elementCreator = elementCreator;
            _distanceFromCeiling = distanceFromCeiling;
            _randomDirectionThrower = randomDirectionThrower;
        }

        void ISphereBloodTriggerer.TriggerBloodSphere(Position3D center)
        {
            Position3D position = center.Clone();
            position.PositionZ -= _distanceFromCeiling;

        }
    }
}
