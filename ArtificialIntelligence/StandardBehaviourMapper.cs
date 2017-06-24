using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using IOInterface;

namespace ArtificialIntelligence
{
    public class StandardBehaviourMapper : IBehaviourMapper
    {
        Behaviour IBehaviourMapper.MapBehaviour(Behaviour behaviour, MainBodyStatus bodyStatus)
        {
            switch (bodyStatus)
            {
                case MainBodyStatus.DeadlyInjured:
                case MainBodyStatus.FullBody:
                    return Behaviour.StandardBehaviour;
                case MainBodyStatus.NoHead:
                    return Behaviour.StandardBehaviourH;
                case MainBodyStatus.NoTorso:
                    return Behaviour.StandardBehaviourT;
                case MainBodyStatus.NoArms:
                    return Behaviour.StandardBehaviourA;
            }
            
            return Behaviour.StandardBehaviour;
        }
    }
}
