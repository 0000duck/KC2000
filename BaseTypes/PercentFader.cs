using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseContracts;

namespace BaseTypes
{
    public class PercentFader : IPercentFader
    {
        private double DurationInSeconds;
        private double StartTimeInSeconds;
        private double Percent;

        public PercentFader(double duration)
        {
            Percent = 1.0;
            DurationInSeconds = duration;
            StartTimeInSeconds = -duration;
        }

        public void Start()
        {
            StartTimeInSeconds = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
            Percent = 0.0;
        }

        public void Start(double percent)
        {
            StartTimeInSeconds = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - (DurationInSeconds * percent);
            Percent = percent;
        }

        public void UpdateDuration(double duration)
        {
            DurationInSeconds = duration;
        }

        public bool CanBeStarted()
        {
            return Percent < 0.04 || Percent > 0.96;
        }

        public bool IsFinished()
        {
            return Percent > 0.999;
        }

        public double GetPercent()
        {
            if (Percent >= 1.0)
                return 1.0;

            Percent = (TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - StartTimeInSeconds) / DurationInSeconds;
            return Percent >= 1.0 ? 1.0 : Percent;
        }

        public void SkipCurrentFrame()
        {
            StartTimeInSeconds += TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond;
        }
    }
}
