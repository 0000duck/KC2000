using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;

namespace ElementImplementations.ComplexElementImplementations
{
    public class StraightMovingGroup : ElementComposition, IExecuteble
    {
        private double _distancePerSecond;
        private double _totalDistance;
        private double _maxDistance;
        private Direction _direction;
        private double? _maxDistance2;

        public StraightMovingGroup(double distancePerSecond, double maxDistance, Direction direction, double? maxDistance2 = null)
        {
            _distancePerSecond = distancePerSecond;
            _maxDistance = maxDistance;
            _direction = direction;
            _maxDistance2 = maxDistance2;
        }

        void IExecuteble.ExecuteLogic()
        {
            if (_totalDistance > _maxDistance)
            {
                if (_maxDistance2.HasValue)
                {
                    _maxDistance = _maxDistance2.Value;
                    _maxDistance2 = null;
                }

                foreach (IWorldElement child in Children)
                {
                    switch (_direction)
                    { 
                        case Direction.FromLeftToRight:
                            child.SetCenterPosition(child.Position.PositionX - _maxDistance, child.Position.PositionY, child.Position.PositionZ);
                            break;
                        case Direction.FromRightToLeft:
                            child.SetCenterPosition(child.Position.PositionX + _maxDistance, child.Position.PositionY, child.Position.PositionZ);
                            break;
                        case Direction.FromTopToBottom:
                            child.SetCenterPosition(child.Position.PositionX, child.Position.PositionY + _maxDistance, child.Position.PositionZ);
                            break;
                        case Direction.FromBottomToTop:
                            child.SetCenterPosition(child.Position.PositionX, child.Position.PositionY - _maxDistance, child.Position.PositionZ);
                            break;
                    }
                }

                _totalDistance = 0;
                return;
            }

            double distance = TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond * _distancePerSecond;
            _totalDistance += distance;

            foreach (IWorldElement child in Children)
            {
                child.MoveIntoGivenDirection(_direction, distance);
            }
        }
    }
}
