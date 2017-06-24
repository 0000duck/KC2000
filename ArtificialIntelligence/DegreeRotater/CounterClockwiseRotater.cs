using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.DegreeRotater
{
    public class CounterClockwiseRotater : IDegreeRotater
    {
        Degree IDegreeRotater.GetNextDegree(Degree degree)
        {
            Degree result = degree + 1;

            if (result > Degree.Degree_315)
                return Degree.Degree_0;

            return result;
        }
    }
}
