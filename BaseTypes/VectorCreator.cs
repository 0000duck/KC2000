using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public static class VectorCreator
    {
        public static Vector2D CreateVector(double vectorLength, Degree degree)
        {
            Vector2D vector = new Vector2D();

            switch (degree)
            {
                case Degree.Degree_0:
                    vector.X = vectorLength;
                    vector.Y = 0;
                    break;
                case Degree.Degree_45:
                    vector.X = vectorLength * MathHelper.SinusOf45Degree;
                    vector.Y = vectorLength * MathHelper.SinusOf45Degree;
                    break;
                case Degree.Degree_90:
                    vector.X = 0;
                    vector.Y = vectorLength;
                    break;
                case Degree.Degree_135:
                    vector.X = -vectorLength * MathHelper.SinusOf45Degree;
                    vector.Y = vectorLength * MathHelper.SinusOf45Degree;
                    break;
                case Degree.Degree_180:
                    vector.X = -vectorLength;
                    vector.Y = 0;
                    break;
                case Degree.Degree_225:
                    vector.X = -vectorLength * MathHelper.SinusOf45Degree;
                    vector.Y = -vectorLength * MathHelper.SinusOf45Degree;
                    break;
                case Degree.Degree_270:
                    vector.X = 0;
                    vector.Y = -vectorLength;
                    break;
                case Degree.Degree_315:
                    vector.X = vectorLength * MathHelper.SinusOf45Degree;
                    vector.Y = -vectorLength * MathHelper.SinusOf45Degree;
                    break;
            }
            return vector;
        }
    }
}
