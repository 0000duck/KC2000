using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence
{
    public class UpdateTimer : IUpdateTimer
    {
        private double _timeToWaitInSeconds;
        private double _lastUpdate;

        public UpdateTimer(double timeToWaitInSeconds)
        {
            _timeToWaitInSeconds = timeToWaitInSeconds;
            _lastUpdate = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - _timeToWaitInSeconds;
        }

        bool IUpdateTimer.UpdateIsNecessary()
        {
            if (_lastUpdate + _timeToWaitInSeconds > TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds)
                return false;

            _lastUpdate = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
            return true;
        }
    }
}
