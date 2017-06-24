using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextureConverter.Contracts;
using System.Drawing;

namespace TextureConverter.Implementations
{
    public class TransparencyDeleter : IReplacementColor
    {
        Color IReplacementColor.GetReplacementColor(Color color)
        {
            if (color.A == 255)
                return color;

            return Color.FromArgb(255, color.R, color.G, color.B);
        }
    }
}
