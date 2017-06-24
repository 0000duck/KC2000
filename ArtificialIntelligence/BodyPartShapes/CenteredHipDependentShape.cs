using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using CollisionDetection.Elements;
using BaseTypes;

namespace ArtificialIntelligence.BodyPartShapes
{
    public class CenteredHipDependentShape : StandardWorldElement, IDestructibleBodyPart, IVulnerable
    {
        private double _relativeHeightAboveHip;
        private IHipHeightProvider _hipHeightProvider;
        private IVulnerable _vulnerableBodyPart;

        public CenteredHipDependentShape(double height, double radius, double relativeHeightAboveHip, IHipHeightProvider hipHeightProvider, IVulnerable vulnerableBodyPart)
        {
            _relativeHeightAboveHip = relativeHeightAboveHip;
            _hipHeightProvider = hipHeightProvider;
            _vulnerableBodyPart = vulnerableBodyPart;
            SetPhysicalAppearance(BaseTypes.Shape.Circle, 1, radius * 2, radius * 2, height, radius);
        }

        void IDestructibleBodyPart.AdaptShape(Position3D position, Degree degree)
        {
            Position3D myPosition = position.Clone();
            myPosition.PositionZ += _hipHeightProvider.GetRelativeHipHeight() + _relativeHeightAboveHip;

            SetCenterPosition(myPosition.PositionX, myPosition.PositionY, myPosition.PositionZ);
        }

        void IVulnerable.YouGotHit(Position3D position, double destructionStrength, Vector3D directionVector)
        {
            _vulnerableBodyPart.YouGotHit(position, destructionStrength, directionVector);
        }
    }
}
