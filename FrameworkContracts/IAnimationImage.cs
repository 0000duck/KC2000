using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Render.Contracts;

namespace FrameworkContracts
{
    public interface IAnimationImage
    {
        ITexture Texture { get; }

        bool IsMirrored { get; }
    }
}
