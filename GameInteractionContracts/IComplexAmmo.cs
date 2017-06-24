using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace GameInteractionContracts
{
    public interface IComplexAmmo
    {
        int Count { get; }

        AmmoFireResult Fire(Position3D position, VectorWithDegree directionVector);
    }
}
