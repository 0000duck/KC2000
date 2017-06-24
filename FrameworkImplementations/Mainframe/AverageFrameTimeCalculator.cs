using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace FrameworkImplementations.Mainframe
{
    public class AverageFrameTimeCalculator : IAverageFrameTimeCalculator
    {
        private uint _numberOfFrames;
        private double _fullDuration;

        void IAverageFrameTimeCalculator.Reset()
        {
            _numberOfFrames = 0;
            _fullDuration = 0;
        }

        void IAverageFrameTimeCalculator.AddFrameDuration(double duration)
        {
            if (duration > 0.05)
                return;

            _fullDuration += duration;
            _numberOfFrames++;
        }

        double? IAverageFrameTimeCalculator.GetAverage()
        {
            if (_numberOfFrames < 100)
                return null;

            return _fullDuration / _numberOfFrames;
        }
    }
}
