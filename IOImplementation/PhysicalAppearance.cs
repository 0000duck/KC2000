using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using IOInterface;

namespace IOImplementation
{
    public class PhysicalAppearance : IPhysicalParameters
    {
        public double Weight { set; get; }

        /// <summary>
        /// use this for the cirlce (SidelengthX = 2 * radius)
        /// </summary>
        public double SideLengthX { set; get; }

        /// <summary>
        /// for a cirlce this can be empty
        /// </summary>
        public double SideLengthY { set; get; }

        public double Height { set; get; }

        public Shape Shape { set; get; }
    }
}
