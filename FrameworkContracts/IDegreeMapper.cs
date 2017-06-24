using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace FrameworkContracts
{
    public interface IDegreeMapper
    {
        Degree MapDegreeByCameraPerspective(Degree camera, Degree element);
    }
}
