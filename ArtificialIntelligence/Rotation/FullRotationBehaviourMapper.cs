using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using IOInterface;

namespace ArtificialIntelligence.Rotation
{
    public class FullRotationBehaviourMapper : IRotationBehaviourMapper
    {
        Behaviour IRotationBehaviourMapper.DetermineBehaviour(double percentOfCurrentDegree, int degreeDelta)
        {
            if (percentOfCurrentDegree < 0.1666 || percentOfCurrentDegree > 0.8333)
                return Behaviour.StandardBehaviour;

            if (percentOfCurrentDegree <= 0.5)
                return degreeDelta > 0 ? Behaviour.RotateRight : Behaviour.RotateLeft;

            return degreeDelta > 0 ? Behaviour.RotateLeft : Behaviour.RotateRight;
        }
    }
}
