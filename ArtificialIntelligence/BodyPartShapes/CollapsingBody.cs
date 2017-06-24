using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using IOInterface;

namespace ArtificialIntelligence.BodyPartShapes
{
    public class CollapsingBody : StandardWorldElement, IDestructibleBodyPart, IVulnerable, IDestructionObserver
    {
        private double _heightStart;
        private double _radius;
        private double _heightDifference;
        private IVulnerable _vulnerableBodyPart;
        private PercentFader _percentFader;

        public CollapsingBody(double heightStart, double heightEnd, double radius, double fallingDuration, IVulnerable vulnerableBodyPart)
        {
            _heightStart = heightStart;
            _heightDifference = heightStart - heightEnd;
            _radius = radius;
            _vulnerableBodyPart = vulnerableBodyPart;
            _percentFader = new PercentFader(fallingDuration);
        }

        void IVulnerable.YouGotHit(Position3D position, double destructionStrength, Vector3D directionVector)
        {
            _vulnerableBodyPart.YouGotHit(position, destructionStrength, directionVector);
        }

        void IDestructibleBodyPart.AdaptShape(Position3D position, Degree degree)
        {
            SetCenterPosition(position.PositionX, position.PositionY, position.PositionZ);

            SetPhysicalAppearance(Shape.Circle, 1, _radius * 2, _radius * 2, _heightStart - (_percentFader.GetPercent() * _heightDifference), _radius);
        }

        void IDestructionObserver.NotifyFullDestruction(BodyPart bodyPart, Position3D position)
        {
            _percentFader.Start();
        }

        void IDestructionObserver.NotifyInnerDestruction()
        {
            _percentFader.Start();
        }
    }
}
