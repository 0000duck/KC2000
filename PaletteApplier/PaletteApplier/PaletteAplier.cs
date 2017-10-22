using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletteApplier
{
    class PaletteAplier
    {
        //private const uint colorStep = 255;
        private const uint colorStep = 85;
        //private const uint colorStep = 51;

        public Bitmap Apply(Bitmap source)
        {
            Bitmap copy = new Bitmap(source.Width, source.Height);

            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    copy.SetPixel(x, y, FindPaletteColor(source.GetPixel(x, y), x, y));
                }
            }

            return copy;
        }

        Color FindPaletteColor(Color sourceColor, int x, int y)
        {
            uint sourceBlue = sourceColor.B;
            uint sourceGreen = sourceColor.G;
            uint sourceRed = sourceColor.R;

            uint targetBlue = (sourceColor.B / colorStep) * colorStep;
            uint targetGreen = (sourceColor.G / colorStep) * colorStep;
            uint targetRed = (sourceColor.R / colorStep) * colorStep;

            uint deltaBlue = sourceBlue - targetBlue;
            uint deltaRed = sourceRed - targetRed;
            uint deltaGreen = sourceGreen - targetGreen;

            bool blueIsMiddleValue = true;
            bool blueAdded = false;
            if (deltaBlue < colorStep * 0.25)
            {
                blueIsMiddleValue = false;
            }
            else if (deltaBlue > colorStep * 0.75)
            {
                blueIsMiddleValue = false;
                targetBlue += colorStep;
                blueAdded = true;
            }

            bool redIsMiddleValue = true;
            bool redAdded = false;
            if (deltaRed < colorStep * 0.25)
            {
                redIsMiddleValue = false;
            }
            else if (deltaRed > colorStep * 0.75)
            {
                redIsMiddleValue = false;
                targetRed += colorStep;
                redAdded = true;
            }

            bool greenIsMiddleValue = true;
            bool greenAdded = false;
            if (deltaGreen < colorStep * 0.25)
            {
                greenIsMiddleValue = false;
            }
            else if (deltaGreen > colorStep * 0.75)
            {
                greenIsMiddleValue = false;
                targetGreen += colorStep;
                greenAdded = true;
            }

            if (!blueIsMiddleValue && !greenIsMiddleValue && !redIsMiddleValue)
                return Color.FromArgb(
                    (int)targetRed, 
                    (int)targetGreen, 
                    (int)targetBlue);

            if ((x % 2 == 0 && y % 2 == 1) || (x % 2 == 1 && y % 2 == 0))
            {
                // hell
                return Color.FromArgb(
                (int)targetRed,
                (int)targetGreen,
                (int)targetBlue);
            }

            return Color.FromArgb(
                    redIsMiddleValue ? (int)(targetRed + colorStep) : (int)targetRed,
                    greenIsMiddleValue ? (int)(targetGreen + colorStep) : (int)targetGreen,
                    blueIsMiddleValue ? (int)(targetBlue + colorStep) : (int)targetBlue);
        }
    }
}
