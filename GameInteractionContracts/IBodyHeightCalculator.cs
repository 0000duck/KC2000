using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace GameInteractionContracts
{
    public interface IBodyHeightCalculator
    {
        double CalculateBodyHeight(Position3D footPosition, bool pressedDuckKey);
    }
}
