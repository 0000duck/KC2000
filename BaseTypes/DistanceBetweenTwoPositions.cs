using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public class DistanceBetweenTwoPositions
    {
        private double distance = -1;

        public double SquareDistanceX { private set; get; }

        public double SquareDistanceY { private set; get; }

        public double SquareDistanceZ { private set; get; }

        private double DistanceX { set; get; }

        private double DistanceY { set; get; }

        private double DistanceZ { set; get; }

        public double SquareDistanceXY
        {
            get
            {
                return SquareDistanceX + SquareDistanceY;
            }
        }

        public double SquareDistanceXYZ
        {
            get
            {
                return SquareDistanceX + SquareDistanceY + SquareDistanceZ;
            }
        }

        public double DistanceXY
        {
            get
            {
                //we only calculate it once
                if (distance < 0)
                    distance = Math.Sqrt(SquareDistanceXY);
                return distance;
            }
        }

        public DistanceBetweenTwoPositions(Position3D positionOne, Position3D positionTwo)
        {
            DistanceX = positionOne.PositionX - positionTwo.PositionX;
            SquareDistanceX = DistanceX * DistanceX;

            DistanceY = positionOne.PositionY - positionTwo.PositionY;
            SquareDistanceY = DistanceY * DistanceY;

            DistanceZ = positionOne.PositionZ - positionTwo.PositionZ;
            SquareDistanceZ = DistanceZ * DistanceZ;
        }
    }

}
