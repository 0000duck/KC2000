using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using GameInteractionContracts;
using IOInterface;

namespace ElementImplementations
{
    public class SmoothMovingElement : StandardWorldElement, IAnimatable
    {
        public ICommunicationElement CommunicationElement { set; get; }

        private double _speed;
        private double _fadeoutPosition;
        private double _maxPosition;
        private double _startHeight;
        private double _fadeSpeed;
        private double _startPosition;
        private double _targetHeight;

        public SmoothMovingElement(double speed, double fadeSpeed, double startPosition, double fadeoutPosition, double maxPosition, double startHeight, double targetHeight)
        {
            _speed = speed;
            _fadeoutPosition = fadeoutPosition;
            _maxPosition = maxPosition;
            _startHeight = startHeight;
            _fadeSpeed = fadeSpeed;
            _startPosition = startPosition;
            _targetHeight = targetHeight;
        }

        public void Render()
        { 
            Position.PositionX += TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond * _speed;

            if (Position.PositionX > _maxPosition)
            {
                Position.PositionX = _startPosition;
                Position.PositionZ = _startHeight;
            }

            if (Position.PositionX > _fadeoutPosition)
            {
                Position.PositionZ -= _fadeSpeed * TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond / 2;
            }
            else if (Position.PositionZ < _targetHeight)
            {
                Position.PositionZ += _fadeSpeed * TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond * ((_targetHeight - Position.PositionZ) / (_targetHeight - _startHeight));

                if (Position.PositionZ > _targetHeight)
                    Position.PositionZ = _targetHeight;
            }

            CommunicationElement.ChangePosition(Position.PositionX, Position.PositionY, Position.PositionZ);
            CommunicationElement.RenderAnimation(Behaviour.StandardBehaviour, 0.0, Orientation, IsMarked);
        }

        public ElementTheme ElementTheme { set; get; }

        public Degree Orientation { set; get; }

        public bool IsMarked { set; get; }
    }
}
