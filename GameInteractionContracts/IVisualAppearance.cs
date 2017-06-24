using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;

namespace GameInteractionContracts
{
    public interface IVisualAppearance
    {
        ElementTheme ElementTheme { set; get; }
        Degree Orientation { set; get; }
        bool IsMarked { set; get; }
    }
}
