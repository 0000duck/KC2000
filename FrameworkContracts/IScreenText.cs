using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkContracts
{
    public interface IScreenText
    {
        double Width { get; }

        double Height { get; }

        double LeftCornerX { get; }

        double LowerCornerY { get; }

        void DrawColor(C64Color c64Color = C64Color.Black);

        void DrawAllColors();

        void DrawFlickering();
    }
}
