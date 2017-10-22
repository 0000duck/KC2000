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
            //Palette64lg();
            Palette8();
        }
        static void PaletteRows()
        {
            Bitmap palette = new Bitmap(5, 17);
            int x = 0;
            int y = 0;

            //for (int r = 0; r < 256; r += 85)
            //{
            //    for (int g = 0; g < 256; g += 85)
            //    {
            //        for (int b = 0; b < 256; b += 85)
            //        {
            //            Color color = Color.FromArgb(r, g, b);
            //            palette.SetPixel(x, y, color);
            //            x++;

            //            if (x > 7)
            //            {
            //                x = 0;
            //                y++;
            //            }
            //        }
            //    }
            //}
            // 85, 170, 255

            Color[] colors = new[] 
            {
                Color.FromArgb(85,0,0),
                Color.FromArgb(170,0,0),
                Color.FromArgb(255,0,0),

                Color.FromArgb(0,85,0),
                Color.FromArgb(0,170,0),
                Color.FromArgb(0,255,0),

                Color.FromArgb(0,0,85),
                Color.FromArgb(0,0,170),
                Color.FromArgb(0,0,255),

                Color.FromArgb(85,85,0),
                Color.FromArgb(170,170,0),
                Color.FromArgb(255,255,0),

                Color.FromArgb(85,0,85),
                Color.FromArgb(170,0,170),
                Color.FromArgb(255,0,255),

                Color.FromArgb(0,85,85),
                Color.FromArgb(0,170,170),
                Color.FromArgb(0,255,255),

                Color.FromArgb(85,85,85),
                Color.FromArgb(170,170,170),
                Color.FromArgb(255,255,255),

                Color.FromArgb(85,85,170),
                Color.FromArgb(170,170,255),
                Color.FromArgb(255,255,170),

                Color.FromArgb(85,170,85),
                Color.FromArgb(170,255,170),
                Color.FromArgb(255,170,255),

                Color.FromArgb(170,85,85),
                Color.FromArgb(255,170,170),
                Color.FromArgb(170,255,255),

                Color.FromArgb(85,85,170),
                Color.FromArgb(170,170,85),
                Color.FromArgb(255,255,85),

                Color.FromArgb(85,170,85),
                Color.FromArgb(170,255,85),
                Color.FromArgb(255,85,255),

                Color.FromArgb(170,85,85),
                Color.FromArgb(85,170,170),
                Color.FromArgb(85,255,255),

                Color.FromArgb(85,170,255),
                Color.FromArgb(255,170,85),
                Color.FromArgb(170,85,255),

                Color.FromArgb(255,85,170),
                Color.FromArgb(0,170,85),
                Color.FromArgb(0,85,255),

                Color.FromArgb(170,85,0),
                Color.FromArgb(255,85,0),
                Color.FromArgb(255,170,0),

                Color.FromArgb(255,85,85),
                Color.FromArgb(85,255,85),
                Color.FromArgb(85,85,255),
            };

            for( int row = 0; row < 17; row++)
            {
                for(int col = 0; col < 3; col++)
                {
                    palette.SetPixel(col, row, colors[(row * 3) + col]);
                }
            }

            palette.Save("colors 21.bmp");
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

        static void Palette8()
        {
            Bitmap palette = new Bitmap(8, 8);
            int x = 0;
            int y = 0;

            for (int r = 0; r < 256; r += 255)
            {
                for (int g = 0; g < 256; g += 255)
                {
                    for (int b = 0; b < 256; b += 255)
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

            palette.Save("8 colors.bmp");
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
