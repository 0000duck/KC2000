using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using GameInteractionContracts;

namespace ElementImplementations.ComplexElementImplementations
{
    public class CarGroup : ElementComposition, IExecuteble
    {
        private IWorldElementProvider _elementProvider;
        private double _distancePerSecond;
        private double _maxDistance;
        private double _totalDistance;

        public CarGroup(IWorldElementProvider elementProvider, double distancePerSecond, double maxDistance)
        {
            _elementProvider = elementProvider;
            _distancePerSecond = distancePerSecond;
            _maxDistance = maxDistance;
        }

        void IExecuteble.ExecuteLogic()
        {
            double distance = TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond * _distancePerSecond * ((_maxDistance - _totalDistance) / _maxDistance);

            _totalDistance += distance;

            if (_totalDistance > _maxDistance)
            {
                _totalDistance = _maxDistance;
                return;
            }
            foreach (IWorldElement child in Children)
            {
                child.MoveIntoGivenDirection(Direction.FromLeftToRight, distance);
            }
            IWorldElement element = _elementProvider.GetElement();

            if (element == null)
                return;

            element.MoveIntoGivenDirection(Direction.FromLeftToRight, distance);
        }
    }
}
