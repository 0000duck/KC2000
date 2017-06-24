using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace ArtificialIntelligence.Contracts
{
    public interface IVulnerable
    {
        void YouGotHit(Position3D position, double destructionStrength, Vector3D directionVector);
    }
}
