using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace FrameworkImplementations.Mainframe
{
    public class FrameTimeProvider
    {
        private Stopwatch _stopwatch;

        public FrameTimeProvider()
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public double GetTimeInSecondsSinceLastFrame()
        {
            _stopwatch.Stop();
            decimal ticks = (decimal)_stopwatch.ElapsedTicks;

            double timeInSeconds = (double)(ticks / ((decimal)Stopwatch.Frequency));

            if (timeInSeconds < 0.006)
            {
                int sleepTime = 6 - (int)(timeInSeconds * 1000);

                _stopwatch.Restart();
                Thread.Sleep(sleepTime);
                _stopwatch.Stop();
                ticks = (decimal)_stopwatch.ElapsedTicks;
                timeInSeconds += (double)(ticks / ((decimal)Stopwatch.Frequency));
            }

            _stopwatch.Restart();

            return timeInSeconds;
        }
    }
}
