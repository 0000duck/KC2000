using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletteBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Palette64lg();
        }
        static void Palette64()
        { 
            Bitmap palette = new Bitmap(8, 8);
            int x = 0;
            int y = 0;

            for (int r = 0; r < 256; r+=85)
            {
                for (int g = 0; g < 256; g+= 85)
                {
                    for (int b = 0; b < 256; b += 85)
                    {
                        Color color = Color.FromArgb(r, g, b);
                        palette.SetPixel(x, y, color);
                        x++;

                        if (x > 7)
                        {
                            x = 0;
                            y++;
                        }
                    }
                }
            }
            
            palette.Save("test.bmp");
        }
        static void Palette64lg()
        {
            Bitmap palette = new Bitmap(4, 16);
            int x = 0;
            int y = 0;

            for (int r = 0; r < 256; r += 85)
            {
                for (int g = 0; g < 256; g += 85)
                {
                    for (int b = 0; b < 256; b += 85)
                    {
                        Color color = Color.FromArgb(r, g, b);
                        palette.SetPixel(x, y, color);
                        x++;

                        if (x > 3)
                        {
                            x = 0;
                            y++;
                        }
                    }
                }
            }

            palette.Save("testlg.bmp");
        }
        static void Palette27()
        {
            Bitmap palette = new Bitmap(8, 8);
            int x = 0;
            int y = 0;

            for (int r = 0; r < 256; r += 127)
            {
                for (int g = 0; g < 256; g += 127)
                {
                    for (int b = 0; b < 256; b += 127)
                    {
                        Color color = Color.FromArgb(r, g, b);
                        palette.SetPixel(x, y, color);
                        x++;

                        if (x > 7)
                        {
                            x = 0;
                            y++;
                        }
                    }
                }
            }

            palette.Save("test2.bmp");
        }
        static void Palette125()
        {
            Bitmap palette = new Bitmap(12, 12);
            int x = 0;
            int y = 0;

            for (int r = 0; r < 256; r += 63)
            {
                for (int g = 0; g < 256; g += 63)
                {
                    for (int b = 0; b < 256; b += 63)
                    {
                        Color color = Color.FromArgb(r, g, b);
                        palette.SetPixel(x, y, color);
                        x++;

                        if (x > 11)
                        {
                            x = 0;
                            y++;
                        }
                    }
                }
            }

            palette.Save("test3.bmp");
        }
    }
}
