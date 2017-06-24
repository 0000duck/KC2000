using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public class DirectionHelper
    {
        public static Direction GetOpposingDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.FromLeftToRight:
                    return Direction.FromRightToLeft;
                case Direction.FromRightToLeft:
                    return Direction.FromLeftToRight;
                case Direction.FromBottomToTop:
                    return Direction.FromTopToBottom;
                case Direction.FromTopToBottom:
                    return Direction.FromBottomToTop;
                case Direction.FromFloorToCeiling:
                    return Direction.FromCeilingToFloor;
                case Direction.FromCeilingToFloor:
                    return Direction.FromFloorToCeiling;
                default: return 0;
            }
        }

        public static Direction GetDirectionOfLongestDistanceVector(Position3D positionOne, Position3D positionTwo, double influence = 1.0)
        {
            double distanceXOfThePositions = positionTwo.PositionX - positionOne.PositionX;

            double distanceYOfThePositions = positionTwo.PositionY - positionOne.PositionY;

            if (Math.Abs(distanceXOfThePositions) * influence >= Math.Abs(distanceYOfThePositions))
            {
                if (distanceXOfThePositions > 0)
                {
                    return Direction.FromLeftToRight;
                }
                else
                {
                    return Direction.FromRightToLeft;
                }
            }
            else
            {
                if (distanceYOfThePositions > 0)
                {
                    return Direction.FromBottomToTop;
                }
                else
                {
                    return Direction.FromTopToBottom;
                }
            }
        }

        public static Direction GetDirectionOfShortestDistanceVector(Position3D positionOne, Position3D positionTwo, double influence = 1.0)
        {
            double distanceXOfThePositions = positionTwo.PositionX - positionOne.PositionX;

            double distanceYOfThePositions = positionTwo.PositionY - positionOne.PositionY;

            if (Math.Abs(distanceXOfThePositions) * influence < Math.Abs(distanceYOfThePositions))
            {
                if (distanceXOfThePositions > 0)
                {
                    return Direction.FromLeftToRight;
                }
                else
                {
                    return Direction.FromRightToLeft;
                }
            }
            else
            {
                if (distanceYOfThePositions > 0)
                {
                    return Direction.FromBottomToTop;
                }
                else
                {
                    return Direction.FromTopToBottom;
                }
            }
        }

        public static Direction GetDirectionOfLongestDistanceVectorOfNearestPosition(Position3D positionOne, List<Position3D> otherPositions)
        {

            Position3D nearestPosition = otherPositions.First();

            double earlierDistance = double.MaxValue;

            foreach (Position3D position in otherPositions)
            {
                double distanceXOfThePositions = positionOne.PositionX > position.PositionX ?
                positionOne.PositionX - position.PositionX : position.PositionX - positionOne.PositionX;

                double distanceYOfThePositions = positionOne.PositionY > position.PositionY ?
                    positionOne.PositionY - position.PositionY : position.PositionY - positionOne.PositionY;

                double distance = (distanceXOfThePositions * distanceXOfThePositions) + (distanceYOfThePositions * distanceYOfThePositions);

                if (earlierDistance > distance)
                {
                    earlierDistance = distance;
                    nearestPosition = position;
                }
            }

            return GetDirectionOfLongestDistanceVector(positionOne, nearestPosition);
        }
    }
}
