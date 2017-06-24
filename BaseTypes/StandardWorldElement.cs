using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace BaseTypes
{
    public class StandardWorldElement : IWorldElement, IGroupElement
    {
        #region public properties
        public double LengthX { private set; get; }

        public double LengthY { private set; get; }

        public double Height { private set; get; }

        public double Radius { private set; get; }

        public double Weight { private set; get; }

        public Shape Shape { private set; get; }

        public Position3D Position { protected set; get; }

        public ISimpleCollisionModel MyCollisionModel { protected set; get; }

        public bool IsVirtual { set; get; }
        #endregion

        public IElementGroup Parent { set; get; }

        public StandardWorldElement()
        {

        }

        public StandardWorldElement(ISimpleCollisionModel collisionModel)
        {
            MyCollisionModel = collisionModel;
        }

        public void SetPhysicalAppearance(Shape shape, double weight, double lengthX, double lengthY, double height, double radius = 0)
        {
            Shape = shape;
            Weight = weight;
            Height = height;

            if (shape == Shape.Circle)
            {
                Radius = radius;
                LengthX = Radius * 2.0;
                LengthY = Radius * 2.0;
            }
            else
            {
                LengthX = lengthX;
                LengthY = lengthY;
            }

            if (MyCollisionModel == null)
                MyCollisionModel = new PositionOnRoomFieldModel();

            if (Position == null)
                Position = new Position3D();

            MyCollisionModel.Update(Position, LengthX, LengthY); 
        }

        public virtual void SetCenterPosition(double positionX, double positionY, double positionZ)
        {
            if (Position == null)
                Position = new Position3D();

            Position.PositionX = positionX;
            Position.PositionY = positionY;
            Position.PositionZ = positionZ;

            if (MyCollisionModel == null)
                MyCollisionModel = new PositionOnRoomFieldModel();

            MyCollisionModel.Update(Position, LengthX, LengthY); 
        }

        public void MoveIntoGivenDirection(Direction direction, double distance)
        {
            if (distance <= 0)
                return;

            Position.MoveIntoGivenDirection(direction, distance);

            MyCollisionModel.Update(Position, LengthX, LengthY);

            if (Parent != null && Parent is IComposition)
                ((IComposition)Parent).RegisterMovementOfChild(this);
        }
    }
}
