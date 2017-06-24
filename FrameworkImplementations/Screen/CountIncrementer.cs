using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;

namespace FrameworkImplementations.Screen
{
    public class CountIncrementer : ICountRenderer
    {
        private ICountRenderer _countRenderer;
        private double _incrementDuration;
        private double _lastCountChange;
        private int _currentCount;

        public CountIncrementer(ICountRenderer countRenderer, double incrementDuration)
        {
            _countRenderer = countRenderer;
            _incrementDuration = incrementDuration;
        }

        void ICountRenderer.RenderCount(int count, double leftCornerX, double leftCornerY)
        {
            if(_lastCountChange + _incrementDuration <= TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds)
            {
                if(count > _currentCount)
                    _currentCount++;
                else if(count < _currentCount)
                    _currentCount--;

                _lastCountChange = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
            }

            _countRenderer.RenderCount(_currentCount, leftCornerX, leftCornerY);
        }
    }
}