using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using IOInterface;

namespace ArtificialIntelligence.Strategies.FocusStrategies
{
    public class AlwaysFocusStrategy : IBehaviourStrategy
    {
        private IWorldElementProvider _enemyProvider;
        private ITargetDegreeCalculator _targetDegreeCalculator;

        public AlwaysFocusStrategy(IWorldElementProvider enemyProvider, ITargetDegreeCalculator targetDegreeCalculator)
        {
            _enemyProvider = enemyProvider;
            _targetDegreeCalculator = targetDegreeCalculator;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return true;
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            BehaviourInstruction behaviourInstruction = new BehaviourInstruction();

            IWorldElement enemy = _enemyProvider.GetElement();

            if (enemy != null)
                behaviourInstruction.ViewDegree = _targetDegreeCalculator.CalculateTargetDegree(behaviourParameters.Position, enemy.Position);
            else
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
