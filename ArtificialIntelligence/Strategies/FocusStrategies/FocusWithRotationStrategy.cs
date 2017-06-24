using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using IOInterface;
using BaseTypes;

namespace ArtificialIntelligence.Strategies.FocusStrategies
{
    public class FocusWithRotationStrategy : IBehaviourStrategy
    {
        private IWorldElementProvider _enemyProvider;
        private IRotater _rotater;
        private ITargetDegreeCalculator _targetDegreeCalculator;

        public FocusWithRotationStrategy(IWorldElementProvider enemyProvider, IRotater rotater, ITargetDegreeCalculator targetDegreeCalculator)
        {
            _enemyProvider = enemyProvider;
            _rotater = rotater;
            _targetDegreeCalculator = targetDegreeCalculator;
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
                IWorldElement enemy = _enemyProvider.GetElement();
                if (enemy != null)
                {
                    _rotater.StartRotation(behaviourParameters.Orientation,
                        _targetDegreeCalculator.CalculateTargetDegree(behaviourParameters.Position, enemy.Position));
                }
            }

            behaviourInstruction.ViewDegree = behaviourParameters.Orientation;
            behaviourInstruction.Percent = 0;
            behaviourInstruction.Behaviour = Behaviour.StandardBehaviour;
            return behaviourInstruction;
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return _enemyProvider.GetElement() != null;
        }
    }
}
