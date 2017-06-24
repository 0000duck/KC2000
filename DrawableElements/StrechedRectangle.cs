using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace DrawableElements
{
    public class StrechedRectangle : IDrawable
    {
        private List<Polygon> _triangles;
        private IPolygonRenderer _polygonRenderer;

        public StrechedRectangle(IPolygonRenderer polygonRenderer, double leftCornerX, double leftCornerY, float lengthX, float lengthY, bool center, float textureSizeX, float textureSizeY)
        {
            _polygonRenderer = polygonRenderer;
            CreateRectangle(leftCornerX, leftCornerY, lengthX, lengthY, center, textureSizeX, textureSizeY);
        }

        void IDrawable.Draw()
        {
            _polygonRenderer.RenderPolygons(_triangles);
        }

        private void CreateRectangle(double leftCornerX, double leftCornerY, float lengthX, float lengthY, bool center, float textureSizeX, float textureSizeY)
        {
            float z = -0.865f;

            float startX = (float)(leftCornerX) - 0.5f - (center ? lengthX : 0);
            float startY = (float)(leftCornerY) - 0.5f - (center ? lengthY : 0);

            _triangles = new List<Polygon>();

            Polygon polygonOne = new Polygon { Vertices = new List<Vertex>(), Normal = new Normal { Y = 1 } };

            polygonOne.Vertices.Add(new Vertex { Position = new VertexPosition { X = startX, Y = startY, Z = z }, TextureCoordinate = new VertexTextureCoordinate { X = 0, Y = textureSizeY } });
            polygonOne.Vertices.Add(new Vertex { Position = new VertexPosition { X = startX + lengthX, Y = startY + lengthY, Z = z }, TextureCoordinate = new VertexTextureCoordinate { X = textureSizeX, Y = 0 } });
            polygonOne.Vertices.Add(new Vertex { Position = new VertexPosition { X = startX + lengthX, Y = startY, Z = z }, TextureCoordinate = new VertexTextureCoordinate { X = textureSizeX, Y = textureSizeY } });
            
                      
            _triangles.Add(polygonOne);

            Polygon polygonTwo = new Polygon { Vertices = new List<Vertex>(), Normal = new Normal { Y = 1 } };

            polygonTwo.Vertices.Add(new Vertex { Position = new VertexPosition { X = startX, Y = startY, Z = z }, TextureCoordinate = new VertexTextureCoordinate { X = 0, Y = textureSizeY } });
            polygonTwo.Vertices.Add(new Vertex { Position = new VertexPosition { X = startX, Y = startY + lengthY, Z = z }, TextureCoordinate = new VertexTextureCoordinate { X = 0, Y = 0 } });
            polygonTwo.Vertices.Add(new Vertex { Position = new VertexPosition { X = startX + lengthX, Y = startY + lengthY, Z = z }, TextureCoordinate = new VertexTextureCoordinate { X = textureSizeX, Y = 0 } });
            
            
            _triangles.Add(polygonTwo);
        }
    }
}
