using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public class WaveSimulator
    {
        private double Maximum { set; get; }

        public WaveSimulator(double maximum)
        {
            Maximum = maximum;
        }

        public double GetHeight(double percent)
        {
            return Math.Sin(percent * Math.PI) * Maximum;
        }
    }
}
