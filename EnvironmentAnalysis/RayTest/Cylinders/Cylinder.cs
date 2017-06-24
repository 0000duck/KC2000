using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Elements;
using BaseTypes;
using CollisionDetection;

namespace EnvironmentAnalysis.RayTest.Cylinder
{
    internal abstract class Cylinder : StandardWorldElement
    {
        protected Position3D StartPosition;
        protected double CylinderRadius;
        protected Vector3D DirectionVector;
        private const double MinimumHeight = 0.05;

        internal Cylinder(Position3D startPosition, Vector3D directionVector, double radius)
        {
            StartPosition = startPosition;
            CylinderRadius = radius;
            DirectionVector = directionVector;
            SetSizeAndCenter();
        }

        protected void SetSizeAndCenter()
        {
            double height = Math.Abs(DirectionVector.Z) * CylinderRadius * 2;
            if (height <= MinimumHeight)
                height = MinimumHeight;

            //the Z component of the directionvector determines the height
            SetPhysicalAppearance(Shape.Circle, 1, CylinderRadius * 2, CylinderRadius * 2, height, CylinderRadius);
            Position3D centerPosition = new Position3D();
            centerPosition.PositionX = StartPosition.PositionX + (DirectionVector.X * CylinderRadius);
            centerPosition.PositionY = StartPosition.PositionY + (DirectionVector.Y * CylinderRadius);
            if (DirectionVector.Z > 0)
            {
                centerPosition.PositionZ = StartPosition.PositionZ;
            }
            else
            {
                centerPosition.PositionZ = StartPosition.PositionZ - height;
            }
            SetCenterPosition(centerPosition.PositionX, centerPosition.PositionY, centerPosition.PositionZ);
        }
    }
}
