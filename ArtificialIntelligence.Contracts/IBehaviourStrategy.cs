using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;

namespace ArtificialIntelligence.Contracts
{
    public interface IBehaviourStrategy
    {
        bool MovementCanBeBreaked();

        BehaviourInstruction GetInstruction(BehaviourParameters behaviourParameters);

        bool ActivityIsNecessary();
    }
}
