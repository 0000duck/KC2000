using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Elements;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.BodyPartShapes
{
    public class HipDependentShape : StandardWorldElement, IDestructibleBodyPart, IVulnerable
    {
        private double _radius;
        private IHipHeightProvider _hipHeightProvider;
        private IVulnerable _vulnerableBodyPart;

        public HipDependentShape(double radius, IHipHeightProvider hipHeightProvider, IVulnerable vulnerableBodyPart)
        {
            _radius = radius;
            _hipHeightProvider = hipHeightProvider;
            _vulnerableBodyPart = vulnerableBodyPart;
        }

        void IDestructibleBodyPart.AdaptShape(Position3D position, Degree degree)
        {
            SetCenterPosition(position.PositionX, position.PositionY, position.PositionZ);
            SetPhysicalAppearance(Shape.Circle, 1, _radius * 2, _radius * 2, _hipHeightProvider.GetRelativeHipHeight(), _radius);
        }

        void IVulnerable.YouGotHit(Position3D position, double destructionStrength, Vector3D directionVector)
        {
            _vulnerableBodyPart.YouGotHit(position, destructionStrength, directionVector);
        }
    }
}
