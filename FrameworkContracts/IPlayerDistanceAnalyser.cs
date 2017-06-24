using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkContracts
{
    public enum Distance
    {
        VeryNear = 0,

        Near = 1,

        Far = 2,

        VeryFar = 3
    }

    public interface IPlayerDistanceAnalyser
    {
        Distance GetPlayerDistance();
    }
}
