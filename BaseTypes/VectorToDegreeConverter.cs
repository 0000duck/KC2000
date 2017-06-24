using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public static class VectorToDegreeConverter
    {
        public static Degree Convert(Vector2D vector)
        {
            return MapVectorLengthToDegree(vector.X, vector.Y);
        }

        public static Degree Convert(Vector3D vector)
        {
            return MapVectorLengthToDegree(vector.X, vector.Y);
        }

        private static Degree MapVectorLengthToDegree(double x, double y)
        {
            double ratio = y != 0 ? x / y : x > 0 ? 10000 : -10000;

            double degreeRation22dot5 = 2.414;
            double degreeRatio67dot5 = 0.414;

            if (y >= 0)
            {
                if (x >= 0)
                {
                    if (ratio >= degreeRation22dot5)
                        return Degree.Degree_0;
                    if (ratio >= degreeRatio67dot5)
                        return Degree.Degree_45;
                    return Degree.Degree_90;
                }

                if (ratio <= -degreeRation22dot5)
                    return Degree.Degree_180;
                if (ratio <= -degreeRatio67dot5)
                    return Degree.Degree_135;
                return Degree.Degree_90;
            }
            else
            {
                if (x > 0)
                {
                    if (ratio <= -degreeRation22dot5)
                        return Degree.Degree_0;
                    if (ratio <= -degreeRatio67dot5)
                        return Degree.Degree_315;
                    return Degree.Degree_270;
                }

                if (ratio >= degreeRation22dot5)
                    return Degree.Degree_180;
                if (ratio >= degreeRatio67dot5)
                    return Degree.Degree_225;
                return Degree.Degree_270;
            }
        }
    }
}
