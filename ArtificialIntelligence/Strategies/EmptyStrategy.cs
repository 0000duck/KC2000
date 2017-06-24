using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;

namespace ArtificialIntelligence.Strategies
{
    public class EmptyStrategy : IBehaviourStrategy
    {
        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            BehaviourInstruction behaviourInstruction = new BehaviourInstruction();
            behaviourInstruction.Behaviour = IOInterface.Behaviour.StandardBehaviour;
            behaviourInstruction.MovementDegree = null;
            behaviourInstruction.ViewDegree = behaviourParameters.Orientation;
            behaviourInstruction.Percent = 0.0;

            return behaviourInstruction;
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return false;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return true;
        }
    }
}
