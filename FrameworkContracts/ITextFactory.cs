using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkContracts
{
    public interface ITextFactory
    {
        IScreenText CreateText(double leftCornerX, double leftCornerY, string text);
    }
}
