using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace FrameworkContracts
{
    public interface IDynamicWallEffectManager
    {
        void AddWallEffect(IDrawable effect, Position3D position);
    }
}
