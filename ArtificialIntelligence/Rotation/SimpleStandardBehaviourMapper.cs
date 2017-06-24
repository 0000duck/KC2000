using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using IOInterface;

namespace ArtificialIntelligence.Rotation
{
    public class SimpleStandardBehaviourMapper : IRotationBehaviourMapper
    {
        Behaviour IRotationBehaviourMapper.DetermineBehaviour(double percentOfCurrentDegree, int degreeDelta)
        {
            return Behaviour.StandardBehaviour;
        }
    }
}
