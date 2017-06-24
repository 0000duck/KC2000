using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using GameInteractionContracts;
using BaseTypes;
using ArtificialIntelligence.Contracts;
using IOImplementation;

namespace BloodEffects
{
    public class SphereBodyPartByBodyStatusTriggerer : ISphereBloodTriggerer
    {
        private IElementCreator _elementCreator;
        private IDestructibleBodyProvider _destructibleBodyProvider;
        private double _distanceToFloor;
        private IRandomDirectionThrower _randomDirectionThrower;

        public SphereBodyPartByBodyStatusTriggerer(IElementCreator elementCreator, IDestructibleBodyProvider destructibleBodyProvider, IRandomDirectionThrower randomDirectionThrower, double distanceToFloor)
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

            if (_destructibleBodyProvider.GetDestructibleBody().BodyStatus != MainBodyStatus.NoLegs)
            {
                _elementCreator.EnqueueNewElement(new ElementImplementation { ElementTheme = ElementTheme.FlyingShoe, StartPosition = position }, _randomDirectionThrower.ThrowElement);
            }

            if (_destructibleBodyProvider.GetDestructibleBody().BodyStatus != MainBodyStatus.NoTorso)
            {
                Position3D positionTorso = position.Clone();
                positionTorso.PositionZ += 0.4;
                _elementCreator.EnqueueNewElement(new ElementImplementation { ElementTheme = ElementTheme.BloodTorso, StartPosition = positionTorso }, _randomDirectionThrower.ThrowElement);
            }

            if (_destructibleBodyProvider.GetDestructibleBody().BodyStatus != MainBodyStatus.NoTorso && _destructibleBodyProvider.GetDestructibleBody().BodyStatus != MainBodyStatus.NoHead)
            {
                Position3D positionHead = position.Clone();
                positionHead.PositionZ += 0.4;
                _elementCreator.EnqueueNewElement(new ElementImplementation { ElementTheme = ElementTheme.Skull, StartPosition = positionHead }, _randomDirectionThrower.ThrowElement);
            }
        }
    }
}
