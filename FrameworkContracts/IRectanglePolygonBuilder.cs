using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Render.Contracts;

namespace FrameworkContracts
{
    public interface IRectanglePolygonBuilder
    {
        Polygon CreatePolygon(float leftCornerX, float leftCornerY, float lengthX, float lengthY, bool center);
    }
}
