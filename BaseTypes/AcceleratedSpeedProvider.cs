using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseContracts;

namespace BaseTypes
{
    public class AcceleratedSpeedProvider : IAcceleratedSpeedProvider
    {
        private double _accelerationPerSecond;
        private double? _lastAccelerationTime;
        private double? _lastDeaccelerationTime;
        private double _maxSpeed;
        private double _speed;

        public AcceleratedSpeedProvider(double accelerationPerSecond, double maxSpeed)
        {
            _accelerationPerSecond = accelerationPerSecond;
            _maxSpeed = maxSpeed;
        }

        void IAcceleratedSpeedProvider.StartAcceleration()
        {
            if (_lastAccelerationTime.HasValue)
                return;

            _lastAccelerationTime = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
            _lastDeaccelerationTime = null;
        }

        void IAcceleratedSpeedProvider.EndAcceleration()
        {
            if (_lastDeaccelerationTime.HasValue)
                return;

            _lastAccelerationTime = null;
            _lastDeaccelerationTime = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
        }

        double IAcceleratedSpeedProvider.GetSpeed()
        {
            if (_lastAccelerationTime.HasValue)
            {
                _speed += (TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - _lastAccelerationTime.Value) * _accelerationPerSecond;

                if (_speed > _maxSpeed)
                    _speed = _maxSpeed;

                _lastAccelerationTime = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
            }
            else if (_lastDeaccelerationTime.HasValue)
            {
                _speed -= (TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - _lastDeaccelerationTime.Value) * _accelerationPerSecond;

                if (_speed < 0)
                    _speed = 0;

                _lastDeaccelerationTime = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
            }
            return _speed;
        }
    }
}
