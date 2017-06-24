using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public static class TimeAndSpeedManager
    {
        private static double SpeedPerSecondAndImpulseStrength = 0.0;

        public static double PercentTimeOfFrameOfOneSecond {private set; get; }

        public static double TotalTimeOfCurrentLevelInSeconds { private set; get; }

        public static void AddGameTimeInSeconds(double durationOfFrame)
        {
            if (durationOfFrame > 0.04)
                durationOfFrame = 0.04;

            PercentTimeOfFrameOfOneSecond = durationOfFrame;
            TotalTimeOfCurrentLevelInSeconds += durationOfFrame;
        }

        public static void Reset()
        {
            TotalTimeOfCurrentLevelInSeconds = 0;
            PercentTimeOfFrameOfOneSecond = 0;
        }

        public static void SetSpeedPerSecondAndImpulseStrength(double speed)
        {
            SpeedPerSecondAndImpulseStrength = speed;
        }

        public static double CalculateDistanceByImpulseStrength(double strength)
        {
            double distance = PercentTimeOfFrameOfOneSecond * SpeedPerSecondAndImpulseStrength * strength;

            return distance;
        }

        public static double ConvertDistanceToSpeed(double distance)
        {
            return PercentTimeOfFrameOfOneSecond != 0 ? distance / PercentTimeOfFrameOfOneSecond : distance / 0.01;
        }

        public static double ConvertSpeedToStrength(double speed)
        {
            return speed / SpeedPerSecondAndImpulseStrength;
        }
    }
}
