using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;

namespace InitializationContracts
{
    public interface IFloorProvider
    {
        IDrawable GetRenderedFloor(int levelId);

        List<IWorldElement> GetCollisionElements(int levelId);
    }
}
