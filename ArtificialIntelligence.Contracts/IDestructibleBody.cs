using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace ArtificialIntelligence.Contracts
{
    public interface IDestructibleBody
    {
        MainBodyStatus BodyStatus { get; }

        IList<IWorldElement> GetBodyParts(Position3D position, Degree degree);
    }
}
