using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public static class MathHelper
    {
        private static Random RandomGenerator = new Random();

        public static double SinusOf45Degree = 0.707;

        public static Vector2D ConvertDegreeToVector(double degree)
        {
            Vector2D vector = new Vector2D();

            if (degree > 360)
            {
                degree -= 360;

                if (degree > 720)
                {
                    degree = ((int)degree) % 360;
                }
            }
            else if (degree < 0)
            {
                degree += 360;

                if (degree < -360)
                {
                    degree = -(((int)-degree) % 360);

                    degree += 360;
                }
            }

            double rad = degree / 180 * Math.PI;

            vector.X = Math.Cos(rad);
            vector.Y = Math.Sin(rad);

            return vector;
        }

        public static Vector3D ConvertDegreeToVector(double degreeXY, double degreeZ)
        {
            Vector2D mainVector = ConvertDegreeToVector(degreeXY);
            Vector2D zVector = ConvertDegreeToVector(degreeZ);

            Vector3D vector = new Vector3D();
            vector.X = mainVector.X * zVector.X;
            vector.Y = mainVector.Y * zVector.X;
            vector.Z = zVector.Y;

            return vector;
        }

        public static Vector3D CreateVectorWithXYLengthOne(double degreeXY, double degreeZ)
        {
            Vector2D vectorXY = MathHelper.ConvertDegreeToVector(degreeXY);
            Vector2D vectorZ = MathHelper.ConvertDegreeToVector(degreeZ);

            Vector3D vector = new Vector3D();
            vector.X = vectorXY.X;
            vector.Y = vectorXY.Y;
            if (vectorZ.X > 0.0001 || vectorZ.X < -0.0001)
                vector.Z = vectorZ.Y / vectorZ.X;
            else
                vector.Z = vectorZ.Y / 0.0001;

            return vector;
        }

        public static double GetRandomValueInARange(double maxValue, bool symmetricAroundZero = true)
        {
            double randomValue = RandomGenerator.NextDouble();

            if (symmetricAroundZero)
            {
                randomValue -= 0.5;

                return maxValue * randomValue * 2;
            }
            else
            {
                return maxValue * randomValue;
            }
        }

        public static Direction GetDirectionOfXComponent(Vector2D vector)
        {
            if (vector.X > 0)
                return Direction.FromLeftToRight;

            return Direction.FromRightToLeft;
        }

        public static Direction GetDirectionOfYComponent(Vector2D vector)
        {
            if (vector.Y > 0)
                return Direction.FromBottomToTop;

            return Direction.FromTopToBottom;
        }

        public static Direction GetDirectionOfXComponent(Vector3D vector)
        {
            if (vector.X > 0)
                return Direction.FromLeftToRight;

            return Direction.FromRightToLeft;
        }

        public static Direction GetDirectionOfYComponent(Vector3D vector)
        {
            if (vector.Y > 0)
                return Direction.FromBottomToTop;

            return Direction.FromTopToBottom;
        }

        public static Direction GetDirectionOfZComponent(Vector3D vector)
        {
            if (vector.Z > 0)
                return Direction.FromFloorToCeiling;

            return Direction.FromCeilingToFloor;
        }

        public static Vector3D CreateVectorWithXYLengthOne(Position3D firstPosition, Position3D secondPosition)
        {
            Vector3D vector = new Vector3D();

            vector.X = secondPosition.PositionX - firstPosition.PositionX;
            vector.Y = secondPosition.PositionY - firstPosition.PositionY;
            vector.Z = secondPosition.PositionZ - firstPosition.PositionZ;

            DistanceBetweenTwoPositions distance = new DistanceBetweenTwoPositions(firstPosition, secondPosition);

            vector.X /= distance.DistanceXY;
            vector.Y /= distance.DistanceXY;
            vector.Z /= distance.DistanceXY;

            return vector;
        }

        public static Vector2D CreateVector2D(Position3D firstPosition, Position3D secondPosition)
        {
            return new Vector2D 
            { 
                X = secondPosition.PositionX - firstPosition.PositionX, 
                Y = secondPosition.PositionY - firstPosition.PositionY 
            };
        }

        public static Vector3D CreateVector3D(Position3D firstPosition, Position3D secondPosition)
        {
            return new Vector3D
            {
                X = secondPosition.PositionX - firstPosition.PositionX,
                Y = secondPosition.PositionY - firstPosition.PositionY,
                Z = secondPosition.PositionZ - firstPosition.PositionZ
            };
        }
    }
}
