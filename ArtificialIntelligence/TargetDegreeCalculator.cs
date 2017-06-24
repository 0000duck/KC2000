using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence
{
    public class TargetDegreeCalculator : ITargetDegreeCalculator
    {
        Degree ITargetDegreeCalculator.CalculateTargetDegree(Position3D viewerPosition, Position3D targetPosition)
        {
            Vector2D vector = MathHelper.CreateVector2D(viewerPosition, targetPosition);
            return VectorToDegreeConverter.Convert(vector);
        }
    }
}
