using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.Rotation
{
    public class Degree90Rotator: IRotater
    {
        private DegreeFader _degreeFader;
        private PercentFader _percentFader;
        private double _durationPerDegree;
        private int _degreeDelta;
        private int _degreeDeltaAbs;

        public Degree90Rotator(double durationPerDegree)
        {
            _durationPerDegree = durationPerDegree;
            _degreeFader = new DegreeFader();
            _percentFader = new PercentFader(durationPerDegree);
        }

        bool IRotater.IsRotating()
        {
            return !_percentFader.IsFinished();
        }

        RotationResult IRotater.GetRotationResult()
        {
            RotationResult result = new RotationResult();

            double percent = _percentFader.GetPercent();
            result.Orientation = _degreeFader.GetInterpolatedDegree(_percentFader.GetPercent());

            double percentPerDegree = 1.0 / _degreeDeltaAbs;
            double percentOfCurrentDegree = percent;

            while (percentOfCurrentDegree - percentPerDegree > 0)
            {
                percentOfCurrentDegree -= percentPerDegree;
            }

            percentOfCurrentDegree *= _degreeDeltaAbs;

            if (_degreeDeltaAbs == 1)
            {
                result.Behaviour = IOInterface.Behaviour.StandardBehaviour;
                return result;
            }

            if (percentOfCurrentDegree >= 0.3 && percentOfCurrentDegree < 0.5)
            {
                if (_degreeDelta > 0)
                    result.Behaviour = IOInterface.Behaviour.StepWithRightFoot;
                else
                    result.Behaviour = IOInterface.Behaviour.StepWithLeftFoot;
            }
            else if (percentOfCurrentDegree >= 0.5 && percentOfCurrentDegree < 0.7)
            {
                if (_degreeDelta > 0)
                    result.Behaviour = IOInterface.Behaviour.StepWithLeftFoot;
                else
                    result.Behaviour = IOInterface.Behaviour.StepWithRightFoot;
            }
            else
                result.Behaviour = IOInterface.Behaviour.StandardBehaviour;
            return result;
        }

        void IRotater.StartRandomRotation(Degree startDegree)
        {
            _degreeDelta = 2;

            _degreeDeltaAbs = Math.Abs(_degreeDelta);

            _degreeFader.StartFadingByDelta(startDegree, _degreeDelta);
            _percentFader.UpdateDuration(_durationPerDegree * _degreeDeltaAbs);
            _percentFader.Start();
        }

        void IRotater.StartRotation(Degree startDegree, Degree endDegree)
        {
            if (startDegree == endDegree)
                return;

            _degreeDelta = _degreeFader.StartFading(startDegree, endDegree);
            _degreeDeltaAbs = Math.Abs(_degreeDelta);

            if (_degreeDeltaAbs == 3)
            {
                if (_degreeDelta > 0)
                    _degreeDelta = 2;
                else
                    _degreeDelta = -2;

                _degreeDeltaAbs = 2;
            }

            if (_degreeDeltaAbs == 5)
            {
                if (_degreeDelta > 0)
                    _degreeDelta = 4;
                else
                    _degreeDelta = -4;

                _degreeDeltaAbs = 4;
            }

            _percentFader.UpdateDuration(_durationPerDegree * _degreeDeltaAbs);
            _percentFader.Start();
        }
    }
}
