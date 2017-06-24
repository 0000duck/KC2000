using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using ElementImplementations.CharacterImplementations;

namespace ElementImplementations.ComplexElementImplementations
{
    public class RectangleMovingElementGroup : ElementComposition, IExecuteble
    {
        private double _distancePerSecond;
        private double _totalDistanceX;
        private double _totalDistanceY;
        private double _maxdistanceX;
        private double _maxdistanceY;
        private bool _xdirection;
        private bool _positive;

        public RectangleMovingElementGroup(double distancePerSecond, double distanceX, double distanceY, bool xdirection, bool positive)
        {
            _distancePerSecond = distancePerSecond;
            _maxdistanceX = distanceX;
            _maxdistanceY = distanceY;
            _xdirection = xdirection;
            _positive = positive;
        }

        void IExecuteble.ExecuteLogic()
        {
            double distance = TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond * _distancePerSecond;

            Direction direction;

            if (_xdirection)
            {
                _totalDistanceX += distance;

                if (_positive)
                {
                    direction = Direction.FromLeftToRight;
                }
                else
                {
                    direction = Direction.FromRightToLeft;
                }

                if (_totalDistanceX >= _maxdistanceX)
                {
                    _xdirection = false;
                    _totalDistanceX = 0;
                }
            }
            else
            {
                _totalDistanceY += distance;

                if (_positive)
                {
                    direction = Direction.FromBottomToTop;
                }
                else
                {
                    direction = Direction.FromTopToBottom;
                }

                if (_totalDistanceY >= _maxdistanceY)
                {
                    _xdirection = true;
                    _totalDistanceY = 0;
                    _positive = !_positive;
                }
            }

            foreach (IWorldElement child in Children)
            {
                if (child is PlayerDrivenElement)
                {
                    ((IMovableByImpulse)child).MoveByDistance(direction, distance);
                }
                else
                    child.MoveIntoGivenDirection(direction, distance);
            }
        }
    }
}
