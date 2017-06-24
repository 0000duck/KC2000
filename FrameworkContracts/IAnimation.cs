using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace FrameworkContracts
{
    public interface IAnimation
    {
        IAnimationImage GetImage(double percentageOfAnimation, Degree degree = Degree.Degree_0);

        IAnimationImage GetFirstImage(Degree degree = Degree.Degree_0);
    }
}
