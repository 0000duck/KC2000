using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using IOInterface;

namespace ArtificialIntelligence.Strategies.AttackStrategies
{
    public class DogRunDecorator : IBehaviourStrategy
    {
        private IBehaviourStrategy _movementStrategy;

        public DogRunDecorator(IBehaviourStrategy movementStrategy)
        {
            _movementStrategy = movementStrategy;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return _movementStrategy.MovementCanBeBreaked();
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            BehaviourInstruction behaviourInstruction = _movementStrategy.GetInstruction(behaviourParameters);

            behaviourInstruction.Behaviour = Behaviour.Run;

            return behaviourInstruction;
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return _movementStrategy.ActivityIsNecessary();
        }
    }
}
