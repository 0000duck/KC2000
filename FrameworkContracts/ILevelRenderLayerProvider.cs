using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkContracts
{
    public interface ILevelRenderLayerProvider
    {
        IDrawable Get3DWorld();

        IDrawable Get2DSurface();
    }
}
