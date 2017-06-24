using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseContracts;

namespace BaseTypes
{
    public class PercentLooper : IPercentLooper
    {
        private enum LoopDirection
        {
            Undefined = 0,

            Forward = 1,

            Backward = 2
        }

        private double Duration { set; get; }
        private bool Backward { set; get; }
        private LoopDirection CurrentLoopDirection { set; get; }
        private PercentFader PercentFader { set; get; }

        public PercentLooper(double duration, bool backward)
        {
            Duration = duration;
            Backward = backward;
            CurrentLoopDirection = LoopDirection.Undefined;
        }

        double IPercentLooper.GetPercent()
        {
            if (PercentFader == null)
            {
                PercentFader = new PercentFader(Duration);
                PercentFader.Start();
            }

            double percent = PercentFader.GetPercent();

            switch (CurrentLoopDirection)
            {
                case LoopDirection.Undefined:
                    CurrentLoopDirection = LoopDirection.Forward;
                    return percent;
                case LoopDirection.Forward:
                    if (percent >= 1.0)
                    {
                        if (Backward)
                        {
                            CurrentLoopDirection = LoopDirection.Backward;
                        }
                        PercentFader.Start();
                    }
                    return percent;
                case LoopDirection.Backward:
                    if (percent >= 1.0)
                    {
                        CurrentLoopDirection = LoopDirection.Forward;
                        PercentFader.Start();
                    }
                    return 1.0 - percent;
            }

            return percent;
        }
    }
}
