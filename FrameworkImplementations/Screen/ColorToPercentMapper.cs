using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace FrameworkImplementations.Screen
{
    public class ColorToPercentMapper : IColorToPercentMapper
    {
        double IColorToPercentMapper.MapColor(C64Color color)
        {
            switch (color)
            {
                case C64Color.Black:
                    return (0.0625 * 1) - 0.01;
                case C64Color.White:
                    return (0.0625 * 2) - 0.01;
                case C64Color.Blue:
                    return (0.0625 * 3) - 0.01;
                case C64Color.Green:
                    return (0.0625 * 4) - 0.01;
                case C64Color.Yellow:
                    return (0.0625 * 5) - 0.01;
                case C64Color.Red:
                    return (0.0625 * 6) - 0.01;
                case C64Color.Violet:
                    return (0.0625 * 7) - 0.01;
                case C64Color.Cyan:
                    return (0.0625 * 8) - 0.01;
                case C64Color.Orange:
                    return (0.0625 * 9) - 0.01;
                case C64Color.Grey_1:
                    return (0.0625 * 10) - 0.01;
                case C64Color.Grey_2:
                    return (0.0625 * 11) - 0.01;
                case C64Color.Grey_3:
                    return (0.0625 * 12) - 0.01;
                case C64Color.Lightblue:
                    return (0.0625 * 13) - 0.01;
                case C64Color.Lightgreen:
                    return (0.0625 * 14) - 0.01;
                case C64Color.Lightred:
                    return (0.0625 * 15) - 0.01;
                case C64Color.Brown:
                    return (0.0625 * 16) - 0.01;
                default:
                    return 0.0;
            }
        }
    }
}
