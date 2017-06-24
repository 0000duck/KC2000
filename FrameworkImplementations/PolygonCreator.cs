using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace FrameworkImplementations
{
    public class PolygonCreator : IPolygonCreator
    {
        List<Render.Contracts.Polygon> IPolygonCreator.CreatePolygons(double width, double height, bool centered, bool mirrored)
        {
            List<Polygon> polygons = new List<Polygon>();

            Polygon triangleOne = new Polygon();

            float texcoordZeroX = 0.005f;
            float texcoordOneX = 0.995f;
            float texcoordZeroY = 0.005f;
            float texcoordOneY = 0.995f;

            if (mirrored)
            {
                texcoordZeroX = 0.995f;
                texcoordOneX = 0.005f;
            }

            triangleOne.Vertices = new List<Vertex>();
            triangleOne.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = -(float)(width / 2.0), Y = centered ? -(float)height / 2 : 0 },
                TextureCoordinate = new VertexTextureCoordinate { X = texcoordZeroX, Y = texcoordOneY }
            });
            triangleOne.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = -(float)(width / 2.0), Y = centered ? (float)height / 2 : (float)height },
                TextureCoordinate = new VertexTextureCoordinate { X = texcoordZeroX, Y = texcoordZeroY }
            });
            triangleOne.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = (float)(width / 2.0), Y = centered ? (float)height / 2 : (float)height },
                TextureCoordinate = new VertexTextureCoordinate { X = texcoordOneX, Y = texcoordZeroY }
            });
            triangleOne.Normal = new Normal { Y = 1 };

            polygons.Add(triangleOne);

            Polygon triangleTwo = new Polygon();

            triangleTwo.Vertices = new List<Vertex>();
            triangleTwo.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = -(float)(width / 2.0), Y = centered ? -(float)height / 2 : 0 },
                TextureCoordinate = new VertexTextureCoordinate { X = texcoordZeroX, Y = texcoordOneY }
            });
            triangleTwo.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = (float)(width / 2.0), Y = centered ? (float)height / 2 : (float)height },
                TextureCoordinate = new VertexTextureCoordinate { X = texcoordOneX, Y = texcoordZeroY }
            });
            triangleTwo.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = (float)(width / 2.0), Y = centered ? -(float)height / 2 : 0 },
                TextureCoordinate = new VertexTextureCoordinate { X = texcoordOneX, Y = texcoordOneY }
            });


            triangleTwo.Normal = new Normal { Y = 1 };

            polygons.Add(triangleTwo);

            return polygons;
        }
    }
}
