using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using IOInterface;

namespace ArtificialIntelligence.Rotation
{
    public class Rotater : IRotater
    {
        private DegreeFader _degreeFader;
        private PercentFader _percentFader;
        private double _durationPerDegree;
        private int _degreeDelta;
        private int _degreeDeltaAbs;
        private IRotationBehaviourMapper _rotationBehaviourMapper;

        public Rotater(double durationPerDegree, IRotationBehaviourMapper rotationBehaviourMapper)
        {
            _rotationBehaviourMapper = rotationBehaviourMapper;
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

            result.Behaviour = _rotationBehaviourMapper.DetermineBehaviour(percentOfCurrentDegree, _degreeDelta);

            return result;
        }

        void IRotater.StartRandomRotation(Degree startDegree)
        {
            _degreeDelta = (int)MathHelper.GetRandomValueInARange(4, true);

             while (_degreeDelta == 0)
             {
                 _degreeDelta = (int)MathHelper.GetRandomValueInARange(4, true);
             }

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
            _percentFader.UpdateDuration(_durationPerDegree * _degreeDeltaAbs);
            _percentFader.Start();
        }
    }
}
