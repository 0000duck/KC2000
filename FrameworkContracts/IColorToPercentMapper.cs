using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkContracts
{
    public interface IColorToPercentMapper
    {
        double MapColor(C64Color color);
    }
}
