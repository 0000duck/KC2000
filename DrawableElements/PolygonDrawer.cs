using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace DrawableElements
{
    public class PolygonDrawer : IDrawable
    {
        private List<Polygon> _polygons;
        private IPolygonRenderer _polygonRenderer;

        public PolygonDrawer(IPolygonRenderer polygonRenderer, List<Polygon> polygons)
        {
            _polygonRenderer = polygonRenderer;
            _polygons = polygons;
        }

        void IDrawable.Draw()
        {
            _polygonRenderer.RenderPolygons(_polygons);
        }
    }
}
