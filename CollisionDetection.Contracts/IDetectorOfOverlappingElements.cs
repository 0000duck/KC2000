using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace CollisionDetection.Contracts
{
    public interface IDetectorOfOverlappingElements
    {
        bool ElementsAreOverlapping(IWorldElement ElementOne, Position3D newPositionOfElementOne, IWorldElement ElementTwo);
    }
}
