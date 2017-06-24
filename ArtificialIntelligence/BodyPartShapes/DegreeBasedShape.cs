using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Elements;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.BodyPartShapes
{
    public class DegreeBasedShape : StandardWorldElement, IDestructibleBodyPart, IVulnerable
    {
        private double _relativeHeightAboveHip;
        private IHipHeightProvider _hipHeightProvider;
        private Degree _degree;
        private double _distanceFromCenter;
        private IVulnerable _vulnerableBodyPart;

        public DegreeBasedShape(double height, double radius, double relativeHeightAboveHip, Degree degree, double distanceFromCenter, IHipHeightProvider hipHeightProvider, IVulnerable vulnerableBodyPart)
        {
            _relativeHeightAboveHip = relativeHeightAboveHip;
            _hipHeightProvider = hipHeightProvider;
            _degree = degree;
            _distanceFromCenter = distanceFromCenter;
            _vulnerableBodyPart = vulnerableBodyPart;
            SetPhysicalAppearance(Shape.Circle, 1, radius * 2, radius * 2, height, radius);
        }

        void IDestructibleBodyPart.AdaptShape(Position3D position, Degree degree)
        {
            Position3D myPosition = position.Clone();
            myPosition.PositionZ += _hipHeightProvider.GetRelativeHipHeight() + _relativeHeightAboveHip;

            Degree rotatedDegree = (int)_degree + degree - 1;

            if (rotatedDegree > Degree.Degree_315)
                rotatedDegree -= Degree.Degree_315;

            Vector2D vector = VectorCreator.CreateVector(_distanceFromCenter, rotatedDegree);
            myPosition.PositionX += vector.X;
            myPosition.PositionY += vector.Y;

            SetCenterPosition(myPosition.PositionX, myPosition.PositionY, myPosition.PositionZ);
        }

        void IVulnerable.YouGotHit(Position3D position, double destructionStrength, Vector3D directionVector)
        {
            _vulnerableBodyPart.YouGotHit(position, destructionStrength, directionVector);
        }
    }
}
