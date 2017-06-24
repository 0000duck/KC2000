using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence
{
    public class RandomDurationGenerator : IRandomDurationGenerator
    {
        private double _averageDuration;
        private double _variance;
        private double _currentDuration;
        private double _startTime;

        public RandomDurationGenerator(double averageDuration, double variance)
        {
            _averageDuration = averageDuration;
            _variance = variance;
            _currentDuration = 0;
            _startTime = -1;
        }
        bool IRandomDurationGenerator.IsFinished()
        {
            return TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - _startTime > _currentDuration;
        }

        void IRandomDurationGenerator.StartRandomDuration()
        {
            _currentDuration = _averageDuration + MathHelper.GetRandomValueInARange(_variance, true);
            _startTime = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
        }
    }
}
