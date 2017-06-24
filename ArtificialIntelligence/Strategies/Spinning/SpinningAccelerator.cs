using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.Strategies.Spinning
{
    public class SpinningAccelerator : ISpinningAccelerator
    {
        private Degree? _startDegree;
        private double _acceleratedValue;
        private double _speed;
        private double _acceleration;

        public SpinningAccelerator(double acceleration)
        {
            _acceleration = acceleration;
        }

        Degree ISpinningAccelerator.GetAcceleratedDegree(Degree currentDegree)
        {
            if (!_startDegree.HasValue)
                _startDegree = currentDegree;

            int degree = (int)_startDegree.Value;

            _speed += TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond * _acceleration;
            _acceleratedValue += _speed * TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond;

            degree += (int)_acceleratedValue;

            while (degree > 8)
            {
                degree -= 8;
            }

            return (Degree)degree;
        }
    }
}
