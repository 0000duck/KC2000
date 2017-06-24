using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FrameworkContracts
{
    public interface IColorProvider
    {
        Color GetColor(C64Color colorType);
    }
}
