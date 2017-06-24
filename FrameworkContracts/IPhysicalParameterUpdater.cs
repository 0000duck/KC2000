using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;

namespace FrameworkContracts
{
    public interface IPhysicalParameterUpdater
    {
        void UpdateParameters(IPhysicalParameters physicalParameters, Degree rotation);
    }
}
