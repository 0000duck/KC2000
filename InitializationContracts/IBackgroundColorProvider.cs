using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace InitializationContracts
{
    public interface IBackgroundColorProvider
    {
        IBackgroundColor GetBackgroundColor(int levelId);
    }
}
