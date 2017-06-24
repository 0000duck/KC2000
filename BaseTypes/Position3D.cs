using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public class Position3D
    {
        public double PositionX;
        public double PositionY;
        public double PositionZ;

        /// <summary>
        /// this method compares the distances between the X and Y coordinates and returns the longest distance
        /// </summary>
        public double Longest2DDistanceOfOneAxis(Position3D otherPosition)
        {
            double distanceX = otherPosition.PositionX > PositionX ? otherPosition.PositionX - PositionX : PositionX - otherPosition.PositionX;
            double distanceY = otherPosition.PositionY > PositionY ? otherPosition.PositionY - PositionY : PositionY - otherPosition.PositionY;

            return distanceX < distanceY ? distanceY : distanceX;
        }

        public Position3D Clone()
        {
            return new Position3D { PositionX = this.PositionX, PositionY = this.PositionY, PositionZ = this.PositionZ };
        }

        public void MoveIntoGivenDirection(Direction direction, double distance)
        {
            switch (direction)
            {
                case Direction.FromLeftToRight:
                    PositionX += distance;
                    break;
                case Direction.FromRightToLeft:
                    PositionX -= distance;
                    break;
                case Direction.FromTopToBottom:
                    PositionY -= distance;
                    break;
                case Direction.FromBottomToTop:
                    PositionY += distance;
                    break;
                case Direction.FromFloorToCeiling:
                    PositionZ += distance;
                    break;
                case Direction.FromCeilingToFloor:
                    PositionZ -= distance;
                    break;
            }
        }
    }
}
