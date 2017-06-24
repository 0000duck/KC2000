using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using GameInteractionContracts;
using IOInterface;

namespace ElementImplementations
{
    public class ReverseMovingElement : StandardWorldElement, IAnimatable
    {
        public ICommunicationElement CommunicationElement { set; get; }

        private double _speed;
        private double _disappearPosition;
        private double _startPosition;
        private double _startHeight;
        private double _removeSpeed;
        private double _fadeOutPosition;

        public ReverseMovingElement(double speed, double removeSpeed, double fadeOutPosition, double disappearPosition, double startPosition, double startHeight)
        {
            _speed = speed;
            _disappearPosition = disappearPosition;
            _startPosition = startPosition;
            _startHeight = startHeight;
            _removeSpeed = removeSpeed;
            _fadeOutPosition = fadeOutPosition;
        }

        public void Render()
        { 
            Position.PositionX -= TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond * _speed;

            if (Position.PositionX < _disappearPosition)
            {
                Position.PositionX = _startPosition;
                Position.PositionZ = _startHeight;
            }

            if (Position.PositionX < _fadeOutPosition)
            {
                Position.PositionZ -= _removeSpeed * TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond;
            }

            CommunicationElement.ChangePosition(Position.PositionX, Position.PositionY, Position.PositionZ);
            CommunicationElement.RenderAnimation(Behaviour.StandardBehaviour, 0.0, Orientation, IsMarked);
        }

        public ElementTheme ElementTheme { set; get; }

        public Degree Orientation { set; get; }

        public bool IsMarked { set; get; }
    }
}
