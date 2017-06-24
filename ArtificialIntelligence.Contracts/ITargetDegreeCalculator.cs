using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace ArtificialIntelligence.Contracts
{
    public interface ITargetDegreeCalculator
    {
        Degree CalculateTargetDegree(Position3D viewerPosition, Position3D targetPosition);
    }
}
