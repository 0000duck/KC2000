using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace ArtificialIntelligence.Contracts
{
    public interface IFreeSpaceTester
    {
        int GetNumberOfFreeUnits(Position3D excludedStartPosition, Vector3D directionVector, double radius, double minHeight, int desiredUnits);
    }
}
