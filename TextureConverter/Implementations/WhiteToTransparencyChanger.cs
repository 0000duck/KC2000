using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextureConverter.Contracts;
using System.Drawing;

namespace TextureConverter.Implementations
{
    public class WhiteToTransparencyChanger : IReplacementColor
    {
        Color IReplacementColor.GetReplacementColor(Color color)
        {
            if (color.GetBrightness() == 1.0)
            {
                return Color.FromArgb(0, color.R, color.G, color.B);
            }

            return color;
        }
    }
}
