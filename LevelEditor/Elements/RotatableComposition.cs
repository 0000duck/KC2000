using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElementImplementations.ComplexElementImplementations;
using CollisionDetection;
using BaseTypes;
using GameInteraction.BaseImplementations;
using GameInteractionContracts;

namespace LevelEditor.Elements
{
    public class RotatableComposition : ElementComposition, IRotateble
    {
        void IRotateble.RotateLeft(bool degree90 = false)
        {
            //RotateLeftOwnOrientation();

            if (Children == null || Children.Count == 0)
                return;

            foreach (IGroupElement element in Children)
            {
                if (element is IRotateble)
                {
                    (element as IRotateble).RotateLeft(true);
                }

                Position3D relativePosition = CalculateRelativePosition(element.Position, Position);
                Position3D rotatedPosition = RotatePositionLeft(relativePosition);
                Position3D absolutePosition = CalculateAbsolutePosition(rotatedPosition, Position);
                element.SetCenterPosition(absolutePosition.PositionX, absolutePosition.PositionY, absolutePosition.PositionZ);
            }
        }

        void IRotateble.RotateRight(bool degree90 = false)
        {
            //RotateRightOwnOrientation();

            if (Children == null || Children.Count == 0)
                return;

            foreach (IGroupElement element in Children)
            {
                if (element is IRotateble)
                {
                    (element as IRotateble).RotateRight(true);

                    Position3D relativePosition = CalculateRelativePosition(element.Position, Position);
                    Position3D rotatedPosition = RotatePositionRight(relativePosition);
                    Position3D absolutePosition = CalculateAbsolutePosition(rotatedPosition, Position);
                    element.SetCenterPosition(absolutePosition.PositionX, absolutePosition.PositionY, absolutePosition.PositionZ);
                }
            }
        }

        private Position3D RotatePositionRight(Position3D relativePosition)
        {
            return new Position3D
            {
                PositionX = -relativePosition.PositionY,
                PositionY = relativePosition.PositionX,
                PositionZ = relativePosition.PositionZ
            };
        }

        private Position3D RotatePositionLeft(Position3D relativePosition)
        {
            return new Position3D
            {
                PositionX = relativePosition.PositionY,
                PositionY = -relativePosition.PositionX,
                PositionZ = relativePosition.PositionZ
            };
        }

        private Position3D CalculateAbsolutePosition(Position3D childPosition, Position3D parentPosition)
        {
            return new Position3D
            {
                PositionX = childPosition.PositionX + parentPosition.PositionX,
                PositionY = childPosition.PositionY + parentPosition.PositionY,
                PositionZ = childPosition.PositionZ + parentPosition.PositionZ
            };
        }

        private Position3D CalculateRelativePosition(Position3D childPosition, Position3D parentPosition)
        {
            return new Position3D
            {
                PositionX = childPosition.PositionX - parentPosition.PositionX,
                PositionY = childPosition.PositionY - parentPosition.PositionY,
                PositionZ = childPosition.PositionZ - parentPosition.PositionZ
            };
        }

        private void RotateLeftOwnOrientation()
        {
            Orientation += 2;
            if (Orientation > Degree.Degree_315)
                Orientation = Degree.Degree_0;
        }

        private void RotateRightOwnOrientation()
        {
            Orientation -= 2;
            if (Orientation > Degree.Degree_0)
                Orientation = Degree.Degree_270;
        }
    }
}
