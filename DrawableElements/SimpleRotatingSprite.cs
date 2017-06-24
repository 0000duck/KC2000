using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace DrawableElements
{
    public class SimpleRotatingSprite : IDrawable
     {
        private List<Polygon> _polygons;
        private IPlayerCamera _camera;
        private IPolygonRenderer _polygonRenderer;
        private IWorldRotator _worldRotator;

        public SimpleRotatingSprite(IPlayerCamera camera, IPolygonRenderer polygonRenderer, IWorldRotator worldRotator, List<Polygon> polygons)
        {
            _camera = camera;
            _polygonRenderer = polygonRenderer;
            _worldRotator = worldRotator;
            _polygons = polygons;
        }

        void IDrawable.Draw()
        {
            _worldRotator.RotateY(270 - _camera.DegreeXRotation);
            _polygonRenderer.RenderPolygons(_polygons);
        }
    }
}
