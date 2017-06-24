using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace BaseTypes
{
    public interface IWorldElement
    {
        double LengthX { get; }

        double LengthY { get; }

        double Height { get; }

        double Radius { get; }

        double Weight { get; }

        Shape Shape { get; }

        Position3D Position { get; }

        ISimpleCollisionModel MyCollisionModel { get; }

        bool IsVirtual { get; }

        void SetPhysicalAppearance(Shape shape, double weight, double lengthX, double lengthY, double height, double radius = 0);

        void SetCenterPosition(double positionX, double positionY, double positionZ);

        void MoveIntoGivenDirection(Direction direction, double distance);
    }
}
