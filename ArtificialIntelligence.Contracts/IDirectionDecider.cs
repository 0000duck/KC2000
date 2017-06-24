using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace ArtificialIntelligence.Contracts
{
    public interface IDirectionDecider
    {
        Degree? GetMovementDirection(int desiredNumberOfSteps, Degree orientation); 
    }
}
