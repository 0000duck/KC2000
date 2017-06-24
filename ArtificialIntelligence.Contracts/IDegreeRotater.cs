using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace ArtificialIntelligence.Contracts
{
    public interface IDegreeRotater
    {
        Degree GetNextDegree(Degree degree);
    }
}
