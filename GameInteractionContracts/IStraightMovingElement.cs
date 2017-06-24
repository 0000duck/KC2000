using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace GameInteractionContracts
{
    public interface IStraightMovingElement
    {
        void StartMovement(Vector3D directionVector, double metersPerSecond);
    }
}
