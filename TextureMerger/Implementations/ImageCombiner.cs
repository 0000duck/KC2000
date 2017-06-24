using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextureMerger.Contracts;
using System.Drawing;

namespace TextureMerger.Implementations
{
    public class ImageCombiner : IImageCombiner
    {
        private struct Pixel
        {
            public int X { set; get; }

            public int Y { set; get; }
        }

        public Bitmap CombineBitmaps(Bitmap lowerBody, Bitmap upperBody)
        {
            Bitmap combinedBitmap = new Bitmap(lowerBody);

            Pixel startPixelLowerBody = FindStartPixelOfLowerBody(lowerBody);
            Pixel startPixelUpperBody = FindStartPixelOfUpperBody(upperBody);
            Pixel upperBodyAccessVector = Substract(startPixelUpperBody, startPixelLowerBody);
            CopyImageToNewImage(combinedBitmap, upperBody, startPixelLowerBody, upperBodyAccessVector);

            return combinedBitmap;
        }

        private Pixel Substract(Pixel startPixelUpperBody, Pixel startPixelLowerBody)
        {
            return new Pixel {X = startPixelUpperBody.X - startPixelLowerBody.X, Y = startPixelUpperBody.Y - startPixelLowerBody.Y };
        }

        private void CopyImageToNewImage(Bitmap lowerBody, Bitmap upperBody, Pixel startPixel, Pixel upperBodyAccessVector)
        {
            for (int y = 0; y <= startPixel.Y; y++)
            {
                for (int x = 0; x < lowerBody.Width; x++)
                {
                    int upperBodyX = x + upperBodyAccessVector.X;
                    int upperBodyY = y + upperBodyAccessVector.Y;

                    if (upperBodyX < 0 || upperBodyY < 0 || upperBodyX >= upperBody.Width || upperBodyY >= upperBody.Height)
                        continue;

                    Color color = upperBody.GetPixel(upperBodyX, upperBodyY);
                    lowerBody.SetPixel(x, y, color);
                }
            }
        }

        private Pixel FindStartPixelOfLowerBody(Bitmap lowerBody)
        {
            for (int y = 0; y < lowerBody.Height; y++)
            {
                for (int x = 0; x < lowerBody.Width; x++)
                {
                    Color color = lowerBody.GetPixel(x, y);
                    if (color.B != 255 || color.G != 255 || color.R != 255)
                    {
                        return new Pixel { X = x, Y = y };
                    }
                }
            }

            throw new Exception("Only white pixels found!");
        }

        private Pixel FindStartPixelOfUpperBody(Bitmap upperBody)
        {
            for (int y = upperBody.Height - 1; y >= 0; y--)
            {
                for (int x = 0; x < upperBody.Width; x++)
                {
                    Color color = upperBody.GetPixel(x, y);
                    if (color.B != 255 || color.G != 255 || color.R != 255)
                    {
                        return new Pixel { X = x, Y = y };
                    }
                }
            }

            throw new Exception("Only white pixels found!");
        }
    }
}
