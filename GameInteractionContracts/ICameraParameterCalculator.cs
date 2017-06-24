using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using IOInterface;

namespace GameInteractionContracts
{
    public interface ICameraParameterCalculator
    {
        ICameraParameters CalculateCameraParameters(Position3D footPosition, double height, double viewChangeX, double viewChangeY);
    }
}
