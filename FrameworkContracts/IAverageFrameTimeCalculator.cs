using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkContracts
{
    public interface IAverageFrameTimeCalculator
    {
        void Reset();

        void AddFrameDuration(double duration);

        double? GetAverage();
    }
}
