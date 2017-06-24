using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvironmentAnalysis.RayTest.Rays
{
    internal class Instruction
    {
        public int NumberOfMainCirlcesPerFrame { set; get; }

        public bool GrowingCircles { set; get; }

        public double MaximumRadiusOfMainCircles { set; get; }

        public double MinimumRadiusOfMainCircles { set; get; }

        public double MaxRayLength { set; get; }
    }
}
