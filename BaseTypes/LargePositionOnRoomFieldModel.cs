using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace BaseTypes
{
    public class LargePositionOnRoomFieldModel: ISimpleCollisionModel
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private int FirstYRow { get; set; }
        private int SecondYRow { get; set; }

        private int FirstXRow { get; set; }
        private int SecondXRow { get; set; }

        public void Update(Position3D position, double sideLengthX, double sideLengthY)
        {
            int shiftBit = 1;

            FirstXRow = (int)((position.PositionX - (sideLengthX / 2.0)) / PositionOnRoomFieldModel.XDivider);
            SecondXRow = (int)((position.PositionX + (sideLengthX / 2.0)) / PositionOnRoomFieldModel.XDivider);

            FirstYRow = (int)((position.PositionY - (sideLengthY / 2.0)) / PositionOnRoomFieldModel.YDivider);
            SecondYRow = (int)((position.PositionY + (sideLengthY / 2.0)) / PositionOnRoomFieldModel.YDivider);

            X = shiftBit << FirstXRow;

            while(FirstXRow < SecondXRow)
            {
                FirstXRow++;
                X = X | shiftBit << FirstXRow; 
            }

            Y = shiftBit << FirstYRow;

            while (FirstYRow < SecondYRow)
            {
                FirstYRow++;
                Y = Y | shiftBit << FirstYRow; 
            } 
        }

        public bool EventuallyCollidesWith(ISimpleCollisionModel otherCollisionModel)
        {
            if ((X & otherCollisionModel.X) != 0 && (Y & otherCollisionModel.Y) != 0)
                return true;

            return false;
        }
    }
}
