using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace GameInteractionContracts
{
    public interface INearRangeAttackSharer
    {
        void ShareAttackDamage(IList<IWorldElement> allAttackedElements, Position3D position, Vector3D directionVectorUnitLength, double destructionStrength);
    }
}
