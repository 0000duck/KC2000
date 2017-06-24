using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace DrawableElements
{
    public class SurfaceRectangle : IDrawable
    {
        private List<Polygon> _triangles;
        private IPolygonRenderer _polygonRenderer;

        public SurfaceRectangle(IPolygonRenderer polygonRenderer, double leftCornerX, double leftCornerY, float lengthX, float lengthY, bool center, float textureZero = 0.01f, float textureOne = 0.99f)
        {
            _polygonRenderer = polygonRenderer;
            CreateRectangle(leftCornerX, leftCornerY, lengthX, lengthY, center, textureZero, textureOne);
        }

        void IDrawable.Draw()
        {
            _polygonRenderer.RenderPolygons(_triangles);
        }

        private void CreateRectangle(double leftCornerX, double leftCornerY, float lengthX, float lengthY, bool center, float textureZero, float textureOne)
        {
            float z = -0.865f;

            float startX = (float)(leftCornerX) - 0.5f - (center ? lengthX : 0);
            float startY = (float)(leftCornerY) - 0.5f - (center ? lengthY : 0);

            _triangles = new List<Polygon>();

            Polygon polygonOne = new Polygon { Vertices = new List<Vertex>(), Normal = new Normal { Y = 1 } };

            polygonOne.Vertices.Add(new Vertex { Position = new VertexPosition { X = startX, Y = startY, Z = z }, TextureCoordinate = new VertexTextureCoordinate { X = textureZero, Y = textureOne } });
            polygonOne.Vertices.Add(new Vertex { Position = new VertexPosition { X = startX + lengthX, Y = startY + lengthY, Z = z }, TextureCoordinate = new VertexTextureCoordinate { X = textureOne, Y = textureZero } });
            polygonOne.Vertices.Add(new Vertex { Position = new VertexPosition { X = startX + lengthX, Y = startY, Z = z }, TextureCoordinate = new VertexTextureCoordinate { X = textureOne, Y = textureOne } });
            
                      
            _triangles.Add(polygonOne);

            Polygon polygonTwo = new Polygon { Vertices = new List<Vertex>(), Normal = new Normal { Y = 1 } };

            polygonTwo.Vertices.Add(new Vertex { Position = new VertexPosition { X = startX, Y = startY, Z = z }, TextureCoordinate = new VertexTextureCoordinate { X = textureZero, Y = textureOne } });
            polygonTwo.Vertices.Add(new Vertex { Position = new VertexPosition { X = startX, Y = startY + lengthY, Z = z }, TextureCoordinate = new VertexTextureCoordinate { X = textureZero, Y = textureZero } });
            polygonTwo.Vertices.Add(new Vertex { Position = new VertexPosition { X = startX + lengthX, Y = startY + lengthY, Z = z }, TextureCoordinate = new VertexTextureCoordinate { X = textureOne, Y = textureZero } });
            
            
            _triangles.Add(polygonTwo);
        }
    }
}
