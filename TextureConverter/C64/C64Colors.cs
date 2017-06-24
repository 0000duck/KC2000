using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TextureConverter.C64
{
    public static class C64Colors
    {
        public static Color Black = Color.Black;
        public static Color White = Color.White;
        public static Color Red;
        public static Color Cyan;
        public static Color Violet;
        public static Color Green;
        public static Color Blue;
        public static Color Yellow;
        public static Color Orange;
        public static Color Brown;
        public static Color Lightred;
        public static Color Grey_1;
        public static Color Grey_2;
        public static Color Lightgreen;
        public static Color Lightblue;
        public static Color Grey_3;

        static C64Colors()
        {
            Red = Color.FromArgb(255,136,0,0);
            Cyan = Color.FromArgb(255, 170, 255, 238);
            Violet = Color.FromArgb(255, 204, 68, 204);
            Green = Color.FromArgb(255, 0, 204, 85);
            Blue = Color.FromArgb(255, 0, 0, 170);
            Yellow = Color.FromArgb(255, 238, 238, 119);
            Orange = Color.FromArgb(255, 221, 136, 85);
            Brown = Color.FromArgb(255, 102, 68, 0);
            Lightred = Color.FromArgb(255, 255, 119, 119);
            Grey_1 = Color.FromArgb(255, 51, 51, 51);
            Grey_2 = Color.FromArgb(255, 119, 119, 119);
            Lightgreen = Color.FromArgb(255, 170, 255, 102);
            Lightblue = Color.FromArgb(255, 0, 136, 255);
            Grey_3 = Color.FromArgb(255, 187, 187, 187);
        }
    }
}
