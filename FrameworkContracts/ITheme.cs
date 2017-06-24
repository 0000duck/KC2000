using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using IOInterface;

namespace FrameworkContracts
{
    public interface ITheme
    {
        IAnimationImage GetTexture(Behaviour behaviour, Degree degree, double percent);
    }
}
