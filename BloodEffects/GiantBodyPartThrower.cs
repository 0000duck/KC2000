using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using GameInteractionContracts;
using ArtificialIntelligence.Contracts;
using IOImplementation;
using BaseTypes;

namespace BloodEffects
{
    public class GiantBodyPartThrower: ISphereBloodTriggerer
    {
        private IElementCreator _elementCreator;
        private IDestructibleBodyProvider _destructibleBodyProvider;
        private double _distanceToFloor;
        private IRandomDirectionThrower _randomDirectionThrower;

        public GiantBodyPartThrower(IElementCreator elementCreator, IDestructibleBodyProvider destructibleBodyProvider, IRandomDirectionThrower randomDirectionThrower, double distanceToFloor)
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


            if (_destructibleBodyProvider.GetDestructibleBody().BodyStatus != MainBodyStatus.NoHead)
            {
                Position3D positionHead = position.Clone();
                positionHead.PositionZ += 0.6;
            }
        }
    }
}
