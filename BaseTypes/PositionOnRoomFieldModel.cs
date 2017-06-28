using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace BaseTypes
{
    public class PositionOnRoomFieldModel : ISimpleCollisionModel
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private int FirstYRow { get; set; }
        private int SecondYRow { get; set; }

        private int FirstXRow { get; set; }
        private int SecondXRow { get; set; }

        public static double XDivider;
        public static double YDivider;

        public void Update(Position3D position, double sideLengthX, double sideLengthY)
        {
            int shiftBit = 1;

            FirstXRow = (int)((position.PositionX - (sideLengthX / 2.0)) / XDivider);
            SecondXRow = (int)((position.PositionX + (sideLengthX / 2.0)) / XDivider);

            FirstYRow = (int)((position.PositionY - (sideLengthY / 2.0)) / YDivider);
            SecondYRow = (int)((position.PositionY + (sideLengthY / 2.0)) / YDivider);

            X = shiftBit << FirstXRow;
            X = X | shiftBit << SecondXRow; 

            Y = shiftBit << FirstYRow;
            Y = Y | shiftBit << SecondYRow; 
        }

        public bool EventuallyCollidesWith(ISimpleCollisionModel otherCollisionModel)
        {
            if (otherCollisionModel == null)
                return false;
            if ((X & otherCollisionModel.X) != 0 && (Y & otherCollisionModel.Y) != 0)
                return true;

            return false;
        }
    }
}
