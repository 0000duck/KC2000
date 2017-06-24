using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace ElementImplementations.CharacterImplementations
{
    public class Ducker
    {
        private enum Status
        {
            Up = 0,

            MovingDown = 1,

            Down = 2,

            MovingUp = 3
        }

        private double DuckHeight { set; get; }
        private WaveSimulator WaveSimulator { set; get; }
        private PercentFader PercentFader { set; get; }
        private Status MyStatus { set; get; }
        private double Percent { set; get; }

        public Ducker(double duckHeight)
        {
            DuckHeight = duckHeight;
            WaveSimulator = new WaveSimulator(duckHeight);
            PercentFader = new PercentFader(0.3);
            MyStatus = Ducker.Status.Up;
            Percent = 0.0;
        }

        public double GetDuckHeight(bool playerWantsToDuck)
        {
            ChangeStatus(playerWantsToDuck);

            return WaveSimulator.GetHeight(Percent);
        }

        private void ChangeStatus(bool playerWantsToDuck)
        {
            switch (MyStatus)
            {
                case Status.Up:
                    if (playerWantsToDuck)
                    {
                        if (PercentFader.CanBeStarted())
                        {
                            PercentFader.Start();
                            MyStatus = Status.MovingDown;
                        }
                    }
                    return;
                case Status.MovingDown:
                    Percent = PercentFader.GetPercent() / 2.0;
                    if(Percent >= 0.499)
                        MyStatus = Status.Down;
                    return;
                case Status.Down:
                    if (!playerWantsToDuck)
                    {
                        if (PercentFader.CanBeStarted())
                        {
                            PercentFader.Start();
                            MyStatus = Status.MovingUp;
                        }
                    }
                    return;
                case Status.MovingUp:
                    Percent = 0.5 + PercentFader.GetPercent() / 2.0;
                    if(Percent >= 0.999)
                        MyStatus = Status.Up;
                    return;
            }
        }
    }
}
