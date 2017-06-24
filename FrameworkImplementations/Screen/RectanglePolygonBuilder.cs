using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Render.Contracts;
using FrameworkContracts;

namespace FrameworkImplementations
{
    public class RectanglePolygonBuilder : IRectanglePolygonBuilder
    {
        Polygon IRectanglePolygonBuilder.CreatePolygon(float  leftCornerX, float leftCornerY, float lengthX, float lengthY, bool center)
        {
            float z = -0.87f;

            float startX = (float)(leftCornerX) - 0.5f - (center ? (float)lengthX * 0.5f : 0);
            float startY = (float)(leftCornerY) - 0.5f - (center ? (float)lengthY * 0.5f : 0);

            float zero = 0.01f;
            float one = 0.99f;

            Polygon rectangle = new Polygon { Vertices = new List<Vertex>() };

            rectangle.Vertices.Add(new Vertex { Position = new VertexPosition { X = startX, Y = startY, Z = z }, TextureCoordinate = new VertexTextureCoordinate { X = zero, Y = one } });
            rectangle.Vertices.Add(new Vertex { Position = new VertexPosition { X = startX, Y = startY + lengthY, Z = z }, TextureCoordinate = new VertexTextureCoordinate { X = zero, Y = zero } });
            rectangle.Vertices.Add(new Vertex { Position = new VertexPosition { X = startX + lengthX, Y = startY + lengthY, Z = z }, TextureCoordinate = new VertexTextureCoordinate { X = one, Y = zero } });
            rectangle.Vertices.Add(new Vertex { Position = new VertexPosition { X = startX + lengthX, Y = startY, Z = z }, TextureCoordinate = new VertexTextureCoordinate { X = one, Y = one } });

            return rectangle;
        }
    }
}
