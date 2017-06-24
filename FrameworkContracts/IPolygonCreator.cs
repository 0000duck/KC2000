using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Render.Contracts;

namespace FrameworkContracts
{
    public interface IPolygonCreator
    {
        List<Polygon> CreatePolygons(double width, double height, bool centered, bool mirrored = false);
    }
}
