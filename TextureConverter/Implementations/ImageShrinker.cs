using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TextureConverter.Contracts;

namespace TextureConverter.Implementations
{
    public class ImageShrinker : IImageShrinker
    {
        private int _shrinkfactor;

        public ImageShrinker(int shrinkFactor)
        {
            _shrinkfactor = shrinkFactor;
        }

        public Bitmap ShrinkImage(Bitmap source)
        {
            Bitmap output = new Bitmap(source, new Size { Width = source.Width / _shrinkfactor, Height = source.Height / _shrinkfactor });

            CopyAndInterpolatePixels(source, output);

            return output;
        }

        private void CopyAndInterpolatePixels(Bitmap source, Bitmap output)
        {
            for (int x = 0; x < output.Width; x++)
            {
                for (int y = 0; y < output.Height; y++)
                {
                    Color color = CopyAndInterpolatePixels(source, x, y);

                    output.SetPixel(x, y, color);
                }
            }
        }

        private Color CopyAndInterpolatePixels(Bitmap source, int outputx, int outputy)
        {
            int sourceLowestX = outputx * _shrinkfactor;
            int sourceLowestY = outputy * _shrinkfactor;

            List<Color> colors = new List<Color>();

            for (int x = sourceLowestX; x < sourceLowestX + _shrinkfactor; x++)
            {
                for (int y = sourceLowestY; y < sourceLowestY + _shrinkfactor; y++)
                {
                    colors.Add(source.GetPixel(x, y));
                }
            }

            return CopyAndInterpolatePixels(colors);
        }

        private Color CopyAndInterpolatePixels(List<Color> colors)
        {
            int red = 0;
            int green = 0;
            int blue = 0;
            int alpha = 0;

            int pixelCounter = colors.Count;

            foreach (Color color in colors)
            {
                red += color.R;
                green += color.G;
                blue += color.B;
                alpha += color.A;
            }

            return Color.FromArgb((alpha / pixelCounter) > 129 ? 255 : 0, red / pixelCounter, green / pixelCounter, blue / pixelCounter);
        }
    }
}
