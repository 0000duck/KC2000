using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using IOImplementation;

namespace ThemeMapping
{
    public class AppearanceRotater
    {
        public static IPhysicalParameters RotateByDegree(IPhysicalParameters appearance, BaseTypes.Degree degree)
        {
            if(appearance.Shape == BaseTypes.Shape.Circle)
                return appearance;

            IPhysicalParameters parameters = new PhysicalAppearance
            {
                Height = appearance.Height,
                SideLengthX = appearance.SideLengthX,
                SideLengthY = appearance.SideLengthY,
                Weight = appearance.Weight,
                Shape = appearance.Shape
            };
            switch (degree)
            {
                case BaseTypes.Degree.Degree_90:
                case BaseTypes.Degree.Degree_270:
                    parameters.SideLengthX = appearance.SideLengthY;
                    parameters.SideLengthY = appearance.SideLengthX;
                    break;
            }

            return parameters;
        }
    }
}
