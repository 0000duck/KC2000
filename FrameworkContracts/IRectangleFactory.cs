using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Render.Contracts;

namespace FrameworkContracts
{
    public interface IRectangleFactory
    {
        IRectangle CreateRectangle(double leftCornerX, double leftCornerY, double lengthX, double lengthY, char? character = null, string image = null, bool center = true);
    }
}
