using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using ArtificialIntelligence.Contracts;

namespace ElementImplementations.WeaponImplementations
{
    public class NearRangeAttackSharer : INearRangeAttackSharer
    {
        void INearRangeAttackSharer.ShareAttackDamage(IList<IWorldElement> allAttackedElements, Position3D position, Vector3D directionVectorUnitLength, double destructionStrength)
        {
            foreach (IWorldElement collidingElement in allAttackedElements)
            {
                if (collidingElement is IVulnerable)
                {
                    (collidingElement as IVulnerable).YouGotHit(position, destructionStrength, directionVectorUnitLength);
                }
            }
        }
    }
}
