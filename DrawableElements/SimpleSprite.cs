using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace DrawableElements
{
    public class SimpleSprite : IDrawable
    {
        private List<Polygon> _polygons;
        private IPolygonRenderer _polygonRenderer;

        public SimpleSprite(IPolygonRenderer polygonRenderer, Vertex vertexOne, Vertex vertexTwo, Vertex vertexThree, Vertex vertexFour)
        {
            _polygonRenderer = polygonRenderer;
            CreatePolygons(vertexOne, vertexTwo, vertexThree, vertexFour);
        }

        private void CreatePolygons(Vertex vertexOne, Vertex vertexTwo, Vertex vertexThree, Vertex vertexFour)
        {
            _polygons = new List<Polygon>();

            Polygon triangleOne = new Polygon();

            triangleOne.Vertices = new List<Vertex>();
            triangleOne.Vertices.Add(vertexOne);
            triangleOne.Vertices.Add(vertexThree);
            triangleOne.Vertices.Add(vertexTwo);
            
            triangleOne.Normal = new Normal { Y = 1 };

            _polygons.Add(triangleOne);

            Polygon triangleTwo = new Polygon();

            triangleTwo.Vertices = new List<Vertex>();
            triangleTwo.Vertices.Add(vertexOne);
            triangleTwo.Vertices.Add(vertexFour);
            triangleTwo.Vertices.Add(vertexThree);
            
            triangleTwo.Normal = new Normal { Y = 1 };

            _polygons.Add(triangleTwo);
        }

        void IDrawable.Draw()
        {
            _polygonRenderer.RenderPolygons(_polygons);
        }
    }
}
