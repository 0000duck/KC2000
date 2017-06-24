using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using GameInteractionContracts;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using IOImplementation;

namespace BloodEffects
{
    public class DogBodyPartThrower: ISphereBloodTriggerer
    {
        private IElementCreator _elementCreator;
        private IDestructibleBodyProvider _destructibleBodyProvider;
        private double _distanceToFloor;
        private IRandomDirectionThrower _randomDirectionThrower;

        public DogBodyPartThrower(IElementCreator elementCreator, IDestructibleBodyProvider destructibleBodyProvider, IRandomDirectionThrower randomDirectionThrower, double distanceToFloor)
        {
            _elementCreator = elementCreator;
            _distanceToFloor = distanceToFloor;
            _destructibleBodyProvider = destructibleBodyProvider;
            _randomDirectionThrower = randomDirectionThrower;
        }

        void ISphereBloodTriggerer.TriggerBloodSphere(Position3D center)
        {
            Position3D position = center.Clone();
            position.PositionZ += _distanceToFloor;

            _elementCreator.EnqueueNewElement(new ElementImplementation { ElementTheme = ElementTheme.DogBloodTorso, StartPosition = position }, _randomDirectionThrower.ThrowElement);
        }
    }
}
