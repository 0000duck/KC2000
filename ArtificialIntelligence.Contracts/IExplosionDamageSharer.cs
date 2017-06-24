using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace ArtificialIntelligence.Contracts
{
    public interface IExplosionDamageSharer
    {
        void ShareDamage(Position3D explosionPosition, double destructionStrength, IList<IWorldElement> bodyParts);
    }
}
