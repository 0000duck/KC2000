using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TextureConverter.Contracts
{
    public interface IImageShrinker
    {
        Bitmap ShrinkImage(Bitmap source);
    }
}
