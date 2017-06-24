using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using BaseContracts;
using CollisionDetection.Contracts;

namespace ElementImplementations.CharacterImplementations
{
    public class BodyHeightCalculator : IBodyHeightCalculator
    {
        private enum Status
        {
            Up = 0,

            MovingDown = 1,

            Down = 2,

            MovingUp = 3,

            Stopped = 4
        }

        private PercentFader _percentFader;
        private Status _myStatus;
        private double _percent;
        private double _fullHeight;
        private IWorldElement _testObject;
        private double _duckHeight;
        private IListProvider<IWorldElement> _listProvider;
        private ICollisionDetector _collisionDetector;
 
        public BodyHeightCalculator(double fullHeight, double duckHeight, double riseUpDuration, double playerRadius, IListProvider<IWorldElement> listProvider, ICollisionDetector collisionDetector)
        {
            _fullHeight = fullHeight;
            _duckHeight = duckHeight;
            _percentFader = new PercentFader(riseUpDuration);
            _myStatus = Status.Up;
            _testObject = new StandardWorldElement();
            _testObject.SetPhysicalAppearance(Shape.Circle, 1, playerRadius * 2, playerRadius * 2, 0.15, playerRadius);
            _listProvider = listProvider;
            _collisionDetector = collisionDetector;
        }

        double IBodyHeightCalculator.CalculateBodyHeight(Position3D footPosition, bool pressedDuckKey)
        {
            switch (_myStatus)
            {
                case Status.Up:
                    if (pressedDuckKey)
                    {
                        if (_percentFader.CanBeStarted())
                        {
                            _percentFader.Start();
                            _myStatus = Status.MovingDown;
                        }
                    }
                    return _fullHeight;
                case Status.MovingDown:
                    _percent = _percentFader.GetPercent();
                    if (_percent >= 0.999)
                        _myStatus = Status.Down;
                    return _fullHeight - (_percent * _duckHeight);
                case Status.Down:
                    if (!pressedDuckKey)
                    {
                        if (_percentFader.CanBeStarted())
                        {
                            _percentFader.Start();
                            _myStatus = Status.MovingUp;
                        }
                    }
                    return _fullHeight - (_percent * _duckHeight);
                case Status.MovingUp:
                    Position3D testPosition = footPosition.Clone();
                    testPosition.PositionZ += _fullHeight - ((1 - _percent) * _duckHeight) + 0.01;
                    _testObject.SetCenterPosition(testPosition.PositionX, testPosition.PositionY, testPosition.PositionZ);
                    if (_collisionDetector.SimpleCollisionTakesPlace(_testObject, _testObject.MyCollisionModel, _listProvider.GetList()))
                        _percentFader.SkipCurrentFrame();

                    _percent = _percentFader.GetPercent();
                    if (_percent >= 0.999)
                        _myStatus = Status.Up;

                    return _fullHeight - ((1 - _percent) * _duckHeight);
            }

            return _fullHeight;
        }
    }
}
