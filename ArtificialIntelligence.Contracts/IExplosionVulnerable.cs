using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace ArtificialIntelligence.Contracts
{
    public interface IExplosionVulnerable
    {
        void YouGotHit(Position3D explosionPosition, double destructionStrength);
    }
}
