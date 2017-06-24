using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using GameInteractionContracts;
using IOInterface;

namespace ElementImplementations
{
    public class SteadyMovingElement : StandardWorldElement, IAnimatable
    {
        public ICommunicationElement CommunicationElement { set; get; }

        private double _speed;
        private double _disappearPosition;
        private double _maxPosition;
        private double _startHeight;
        private double _removeSpeed;

        public SteadyMovingElement(double speed, double removeSpeed, double disappearPosition, double maxPosition, double startHeight)
        {
            _speed = speed;
            _disappearPosition = disappearPosition;
            _maxPosition = maxPosition;
            _startHeight = startHeight;
            _removeSpeed = removeSpeed;
        }

        public void Render()
        { 
            Position.PositionX += TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond * _speed;

            if (Position.PositionX > _maxPosition)
            {
                Position.PositionX = 0.0;
                Position.PositionZ = _startHeight;
            }

            if (Position.PositionX > _disappearPosition)
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
