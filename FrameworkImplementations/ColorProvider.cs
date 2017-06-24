using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using System.Drawing;

namespace FrameworkImplementations
{
    public class ColorProvider : IColorProvider
    {
        Color IColorProvider.GetColor(C64Color colorType)
        {
            switch (colorType)
            {
                case C64Color.Red:
                    return Color.FromArgb(255,136,0,0);
                case C64Color.Cyan:
                    return Color.FromArgb(255, 170, 255, 238);
                case C64Color.Violet:
                    return Color.FromArgb(255, 204, 68, 204);
                case C64Color.Green:
                    return Color.FromArgb(255, 0, 204, 85);
                case C64Color.Blue:
                    return Color.FromArgb(255, 0, 0, 170);
                case C64Color.Yellow:
                    return Color.FromArgb(255, 238, 238, 119);
                case C64Color.Orange:
                    return Color.FromArgb(255, 221, 136, 85);
                case C64Color.Brown:
                    return Color.FromArgb(255, 102, 68, 0);
                case C64Color.Lightred:
                    return Color.FromArgb(255, 255, 119, 119);
                case C64Color.Grey_1:
                    return Color.FromArgb(255, 51, 51, 51);
                case C64Color.Grey_2:
                    return Color.FromArgb(255, 119, 119, 119);
                case C64Color.Grey_3:
                    return Color.FromArgb(255, 187, 187, 187);
                case C64Color.Lightgreen:
                    return Color.FromArgb(255, 170, 255, 102);
                case C64Color.Lightblue:
                    return Color.FromArgb(255, 0, 136, 255);
                case C64Color.Black:
                    return Color.FromArgb(255, 0, 0, 0);
                case C64Color.White:
                    return Color.FromArgb(255, 255, 255, 255);
            }
            throw new NotImplementedException();
        }
    }
}
