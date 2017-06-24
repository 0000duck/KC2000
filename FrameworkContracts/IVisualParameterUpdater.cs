using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace FrameworkContracts
{
    public interface IVisualParameterUpdater
    {
        void UpdateParameters(IVisualParameters visualAppearance, Degree rotation);
    }
}
