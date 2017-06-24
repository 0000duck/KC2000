using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using IOInterface;
using BaseTypes;
using BloodEffects.Contracts;

namespace BloodEffects
{
    public class BloodEffectFilter : IBloodEffectCreator
    {
        private IBloodEffectCreator _bloodEffectCreator;
        private List<BloodEffect> _bloodEffects = new List<BloodEffect>();
        //private double _squareDistance = 0.5 * 0.5;
        private double _maximumTestHeight;
        private Dictionary<IOInterface.Animation, double> _bloodSize;
        private Dictionary<IOInterface.Animation, double> _bloodSquareDistance;
        private readonly int _maxHistoryLength = 24;

        public BloodEffectFilter(IBloodEffectCreator bloodEffectCreator, double maximumTestHeight, Dictionary<IOInterface.Animation, double> bloodSize)
        {
            _maximumTestHeight = maximumTestHeight;
            _bloodEffectCreator = bloodEffectCreator;
            _bloodSize = bloodSize;
            _bloodSquareDistance = new Dictionary<Animation, double>();

            foreach(Animation animation in _bloodSize.Keys)
            {
                _bloodSquareDistance.Add(animation, _bloodSize[animation] * _bloodSize[animation] * 0.33);
            }
        }

        void IBloodEffectCreator.CreateBloodEffect(Animation bloodAnimation, Position3D position)
        {
            if (position.PositionZ < _maximumTestHeight && !BloodEffectIsVisible(bloodAnimation, position))
                return;

            _bloodEffectCreator.CreateBloodEffect(bloodAnimation, position);
        }

        //private bool BloodEffectExists(Animation bloodAnimation, Position3D position)
        //{
        //    foreach(BloodEffect bloodEffect in _bloodEffects)
        //    {
        //        if (NewBloodIsBigger(bloodAnimation, bloodEffect.BloodAnimation))
        //            continue;

        //        if (PositionsAreTooClose(bloodEffect.Position, position, _bloodSquareDistance[bloodEffect.BloodAnimation]))
        //        {
        //            StoreBloodEffect(bloodAnimation, position);
        //            return true;
        //        }
        //    }

        //    StoreBloodEffect(bloodAnimation, position);
        //    return false;
        //}

        private bool BloodEffectIsVisible(Animation bloodAnimation, Position3D position)
        {
            foreach (BloodEffect bloodEffect in _bloodEffects)
            {
                if (NewBloodIsBigger(bloodAnimation, bloodEffect.BloodAnimation))
                    continue;

                DistanceBetweenTwoPositions distance = new DistanceBetweenTwoPositions(bloodEffect.Position, position);

                //if (NewBloodIsSmaller(bloodAnimation, bloodEffect.BloodAnimation))
                //{
                double minDistance = _bloodSquareDistance[bloodEffect.BloodAnimation];

                    if (PositionsAreTooClose(bloodEffect.Position, position, minDistance))
                    {
                        StoreBloodEffect(bloodAnimation, position);
                        return false;
                    }
                //}
                //else
                //{
                //    double minDistance = _bloodSquareDistance[bloodEffect.BloodAnimation];

                //    if (PositionsAreTooClose(bloodEffect.Position, position, minDistance))
                //    {
                //        StoreBloodEffect(bloodAnimation, position);
                //        return false;
                //    }
                //}
            }

            StoreBloodEffect(bloodAnimation, position);
            return true;
        }

        private void StoreBloodEffect(Animation bloodAnimation, Position3D position)
        {
            _bloodEffects.Add(new BloodEffect { Position = position, BloodAnimation = bloodAnimation });

            if (_bloodEffects.Count > _maxHistoryLength)
                _bloodEffects.RemoveAt(0);
        }

        private bool PositionsAreTooClose(Position3D positionOne, Position3D positionTwo, double squareDistance)
        {
            DistanceBetweenTwoPositions distance = new DistanceBetweenTwoPositions(positionOne, positionTwo);

            if (distance.SquareDistanceX > squareDistance)
                return false;

            if (distance.SquareDistanceY > squareDistance)
                return false;

            if (distance.SquareDistanceZ > squareDistance)
                return false;

            return true;
        }

        private bool NewBloodIsBigger(Animation newBlood, Animation oldBlood)
        {
            return _bloodSize[newBlood] > _bloodSize[oldBlood];
        }

        private bool NewBloodIsSmaller(Animation newBlood, Animation oldBlood)
        {
            return _bloodSize[newBlood] < _bloodSize[oldBlood];
        }
    }
}
