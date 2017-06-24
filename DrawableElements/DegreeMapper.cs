using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using FrameworkContracts;

namespace DrawableElements
{
    public class DegreeMapper : IDegreeMapper
    {
        public Degree MapDegreeByCameraPerspective(Degree camera, Degree element)
        {
            int test = (int)element + 5 - (int)camera;

            if (test < 1)
                return (Degree)test + 8;

            if (test > 8)
                return (Degree)test - 8;

            return (Degree)test;
        }
    }
}
