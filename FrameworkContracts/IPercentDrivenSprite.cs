using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkContracts
{
    public interface IPercentDrivenSprite : IDrawable
    {
        void SetPercent(double percent);
    }
}
