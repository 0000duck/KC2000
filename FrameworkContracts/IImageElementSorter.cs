using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Render.Contracts;

namespace FrameworkContracts
{
    public interface IImageElementSorter
    {
        void AddImageElement(IDrawable element, ITexture texture);
    }
}
