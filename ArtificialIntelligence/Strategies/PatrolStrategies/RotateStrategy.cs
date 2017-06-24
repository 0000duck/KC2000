using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using IOInterface;

namespace ArtificialIntelligence.Strategies.PatrolStrategies
{
    public class RotateStrategy : IBehaviourStrategy
    {
        private IUpdateTimer _updateTimer;
        private IRotater _rotater;

        public RotateStrategy(IUpdateTimer updateTimer, IRotater rotater)
        {
            _updateTimer = updateTimer;
            _rotater = rotater;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return !_rotater.IsRotating();
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            BehaviourInstruction behaviourInstruction = new BehaviourInstruction();

            if (_rotater.IsRotating())
            {
                RotationResult result = _rotater.GetRotationResult();
                behaviourInstruction.ViewDegree = result.Orientation;
                behaviourInstruction.Behaviour = result.Behaviour;

                return behaviourInstruction;
            }
            else
            {
                if (_updateTimer.UpdateIsNecessary())
                    _rotater.StartRandomRotation(behaviourParameters.Orientation);
            }

            behaviourInstruction.ViewDegree = behaviourParameters.Orientation;
            behaviourInstruction.Percent = 0;
            behaviourInstruction.Behaviour = Behaviour.StandardBehaviour;

            return behaviourInstruction;
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return true;
        }
    }
}
