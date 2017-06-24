using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public class Vector2D
    {
        public double X { set; get; }

        public double Y { set; get; }

        public Vector2D Clone(Degree? rotationDegree)
        {
            if (rotationDegree == null || rotationDegree == Degree.Degree_0)
            {
                return new Vector2D { X = X, Y = Y };
            }

            switch (rotationDegree)
            {
                case Degree.Degree_90:
                    return new Vector2D { X = -Y, Y = X };
                case Degree.Degree_180:
                    return new Vector2D { X = -X, Y = -Y };
                case Degree.Degree_270:
                    return new Vector2D { X = Y, Y = -X };
            }

            throw new NotImplementedException(string.Format("The Degree {0} is not supported!", rotationDegree));
        }

        public void CalculateUnitLength()
        {
            double squareLength = (X * X) + (Y * Y);
            double squareRoot = Math.Sqrt(squareLength);
            X /= squareRoot;
            Y /= squareRoot;
        }
    }
}
