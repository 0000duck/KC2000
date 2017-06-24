using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkContracts
{
    public interface ICountRenderer
    {
        void RenderCount(int count, double leftCornerX, double leftCornerY);
    }
}
