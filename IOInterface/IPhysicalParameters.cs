using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace IOInterface
{
    public interface IPhysicalParameters
    {
        double Weight { get; set; }

        /// <summary>
        /// use this for the cirlce (SidelengthX = 2 * radius)
        /// </summary>
        double SideLengthX { get; set; }

        /// <summary>
        /// for a cirlce this can be empty
        /// </summary>
        double SideLengthY { get; set; }

        double Height { get; set; }

        Shape Shape { get; set; }
    }
}
