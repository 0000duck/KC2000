using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace ArtificialIntelligence.Contracts
{
    public interface IBehaviourMapper
    {
        Behaviour MapBehaviour(Behaviour behaviour, MainBodyStatus bodyStatus);
    }
}
