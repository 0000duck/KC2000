using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TextureConverter.Contracts;

namespace TextureConverter.Implementations
{
    public class ReplacementColor : IReplacementColor
    {
        private Color TargetColor { set; get; }
        private Color SourceColor { set; get; }

        public ReplacementColor(int sourceR, int sourceG, int sourceB, int targetR, int targetG, int targetB)
        {
            SourceColor = Color.FromArgb(255, sourceR, sourceG, sourceB);
            TargetColor = Color.FromArgb(255, targetR, targetG, targetB);
        }

        public ReplacementColor(int sourceR, int sourceG, int sourceB, Color targetColor)
        {
            SourceColor = Color.FromArgb(255, sourceR, sourceG, sourceB);
            TargetColor = targetColor;
        }

        public Color GetReplacementColor(Color color)
        {
            if (ColorHasToBeReplaced(color))
                return TargetColor;
            return color;
        }

        private bool ColorHasToBeReplaced(Color color)
        {
            return color.R == SourceColor.R && color.G == SourceColor.G && color.B == SourceColor.B;
        }
    }
}
