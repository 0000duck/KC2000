using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace ArtificialIntelligence.Contracts
{
    public interface IDestructibleBodyPart
    {
        void AdaptShape(Position3D position, Degree degree);
    }
}
