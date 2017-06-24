using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TextureMerger.Contracts
{
    public interface IImageCombiner
    {
        Bitmap CombineBitmaps(Bitmap lowerBody, Bitmap upperBody);
    }
}
