using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace ArtificialIntelligence.Contracts
{
    public interface ISpinningAccelerator
    {
        Degree GetAcceleratedDegree(Degree currentDegree);
    }
}
