using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TextureConverter.Contracts;

namespace TextureConverter.Implementations
{
    public class BitmapColorReplacer : IBitmapColorReplacer
    {
        public Bitmap ReplaceColors(Bitmap source, IList<IReplacementColor> replacementColors)
        {
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    foreach(IReplacementColor replacementColor in replacementColors)
                    {
                        source.SetPixel(x, y, replacementColor.GetReplacementColor(source.GetPixel(x, y)));
                    }   
                }
            }
            return source;
        }
    }
}
