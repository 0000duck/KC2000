using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace InitializationContracts
{
    public interface ISkylineElementProvider
    {
        IDrawable GetSkylineElement(int levelId);
    }
}
