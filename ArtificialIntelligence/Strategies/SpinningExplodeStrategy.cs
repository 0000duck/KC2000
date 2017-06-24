using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using IOInterface;
using BaseTypes;
using GameInteractionContracts;

namespace ArtificialIntelligence.Strategies
{
    public class SpinningExplodeStrategy : IBehaviourStrategy, IDestructionObserver
    {
        private IBehaviourStrategy _mainStrategy;
        private bool _rotationHasBegun;
        private double _startTime;
        private ISpinningAccelerator _spinningAccelerator;
        private double _duration;
        private IExploder _exploder;

        public SpinningExplodeStrategy(IBehaviourStrategy mainStrategy, ISpinningAccelerator spinningAccelerator, double duration, IExploder exploder)
        {
            _mainStrategy = mainStrategy;
            _spinningAccelerator = spinningAccelerator;
            _duration = duration;
            _exploder = exploder;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return (!_rotationHasBegun) && _mainStrategy.MovementCanBeBreaked();
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            BehaviourInstruction behaviourInstruction = _mainStrategy.GetInstruction(behaviourParameters);

            if (_rotationHasBegun)
            {
                Degree degree = _spinningAccelerator.GetAcceleratedDegree(behaviourParameters.Orientation);

                behaviourInstruction.ViewDegree = degree;

                if (_startTime + _duration < TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds)
                    _exploder.Explode(behaviourParameters.Position);
            }

            return behaviourInstruction;
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return _rotationHasBegun || _mainStrategy.ActivityIsNecessary();
        }

        void IDestructionObserver.NotifyFullDestruction(BodyPart bodyPart, Position3D position)
        {
            _rotationHasBegun = true;
            _startTime = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
        }

        void IDestructionObserver.NotifyInnerDestruction()
        {
            _rotationHasBegun = true;
            _startTime = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
        }
    }
}
