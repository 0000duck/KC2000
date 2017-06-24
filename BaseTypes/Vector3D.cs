using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public class Vector3D
    {
        public Vector3D()
        {

        }

        public double X { set; get; }

        public double Y { set; get; }

        public double Z { set; get; }

        public Vector3D Clone(Degree? degreeOfRotationAroundZAxis)
        {
            if (degreeOfRotationAroundZAxis == null || degreeOfRotationAroundZAxis == Degree.Degree_0)
            {
                return new Vector3D { X = X, Y = Y, Z = Z };
            }

            switch (degreeOfRotationAroundZAxis)
            {
                case Degree.Degree_90:
                    return new Vector3D { X = -Y, Y = X, Z = Z };
                case Degree.Degree_180:
                    return new Vector3D { X = -X, Y = -Y, Z = Z };
                case Degree.Degree_270:
                    return new Vector3D { X = Y, Y = -X, Z = Z };
            }

            return null;
        }

        public Vector2D Clone2D(Degree? degreeOfRotationAroundZAxis)
        {
            if (degreeOfRotationAroundZAxis == null || degreeOfRotationAroundZAxis == Degree.Degree_0)
            {
                return new Vector2D { X = X, Y = Y};
            }

            switch (degreeOfRotationAroundZAxis)
            {
                case Degree.Degree_90:
                    return new Vector2D { X = -Y, Y = X};
                case Degree.Degree_180:
                    return new Vector2D { X = -X, Y = -Y };
                case Degree.Degree_270:
                    return new Vector2D { X = Y, Y = -X};
            }

            return null;
        }

        public void CalculateUnitLength()
        {
            double squareLength = (X * X) + (Y * Y) + (Z * Z);
            double squareRoot = Math.Sqrt(squareLength);
            X /= squareRoot;
            Y /= squareRoot;
            Z /= squareRoot;
        }
    }
}
