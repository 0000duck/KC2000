using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace ArtificialIntelligence.Contracts
{
    public interface IRotationBehaviourMapper
    {
        Behaviour DetermineBehaviour(double percentOfCurrentDegree, int degreeDelta);
    }
}
