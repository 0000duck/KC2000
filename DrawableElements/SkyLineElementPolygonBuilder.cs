using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using OpenTK;
using Render.Contracts;

namespace DrawableElements
{
    public class SkyLineElementPolygonBuilder
    {
        private List<Polygon> _polygons;

        public List<Polygon> CreatePolygons(double length = 188, double height = 188, double centerX = 160, double centerY = -90, double centerZ = 160, int numberOfUnits = 12, int startDegree = 0, float distance = 350, bool adaptTextureSize = false)
        {
            _polygons = new List<Polygon>();
            Vertex[] vertices = CreateRawVertices(length, height, centerY, adaptTextureSize);
            for (int i = startDegree; i < 360; i += ((360) / numberOfUnits))
            {
                MoveAndRotateElement(vertices, i, centerX, centerZ, distance);
            }
            return _polygons;
        }

        private Vertex[] CreateRawVertices(double lengthX, double height, double centerY, bool adaptTextureSize)
        {
            Vertex[] vertices = new Vertex[4];

            float one = 0.997f;
            float zero = 0.003f;

            double xfactor = lengthX / height;
            //float one = 1f;
            //float zero = 0.0f;

            vertices[0] = new Vertex();
            vertices[0].Position = new VertexPosition { X = -(float)lengthX / 2, Y = (float)centerY };
            vertices[0].TextureCoordinate = new VertexTextureCoordinate { X = (float)(adaptTextureSize ? one * xfactor : one), Y = one };

            vertices[1] = new Vertex();
            vertices[1].Position = new VertexPosition { X = (float)lengthX / 2, Y = (float)centerY };
            vertices[1].TextureCoordinate = new VertexTextureCoordinate { X = zero, Y = one };

            vertices[2] = new Vertex();
            vertices[2].Position = new VertexPosition { X = (float)lengthX / 2, Y = (float)height + (float)centerY };
            vertices[2].TextureCoordinate = new VertexTextureCoordinate { X = zero, Y = zero };

            vertices[3] = new Vertex();
            vertices[3].Position = new VertexPosition { X = -(float)lengthX / 2, Y = (float)height + (float)centerY };
            vertices[3].TextureCoordinate = new VertexTextureCoordinate { X = (float)(adaptTextureSize ? one * xfactor : one), Y = zero };

            return vertices;
        }

        private void MoveAndRotateElement(Vertex[] vertices, double degree, double centerX, double centerZ,float distance)
        {
            Vertex[] rotatedVertices = RotateVertices(vertices, degree, centerX, centerZ, distance);
            CreatePolygon(rotatedVertices); 
        }

        private void CreatePolygon(Vertex[] rotatedVertices)
        {
            Polygon triangleOne = new Polygon();

            triangleOne.Vertices = new List<Vertex>();
            triangleOne.Vertices.Add(new Vertex
            {
                Position = rotatedVertices[0].Position,
                TextureCoordinate = rotatedVertices[0].TextureCoordinate
            });
            triangleOne.Vertices.Add(new Vertex
            {
                Position = rotatedVertices[1].Position,
                TextureCoordinate = rotatedVertices[1].TextureCoordinate
            });
            triangleOne.Vertices.Add(new Vertex
            {
                Position = rotatedVertices[2].Position,
                TextureCoordinate = rotatedVertices[2].TextureCoordinate
            });
            triangleOne.Normal = new Normal { Y = 1 };

            _polygons.Add(triangleOne);

            Polygon triangleTwo = new Polygon();

            triangleTwo.Vertices = new List<Vertex>();
            triangleTwo.Vertices.Add(new Vertex
            {
                Position = rotatedVertices[0].Position,
                TextureCoordinate = rotatedVertices[0].TextureCoordinate
            });
            triangleTwo.Vertices.Add(new Vertex
            {
                Position = rotatedVertices[2].Position,
                TextureCoordinate = rotatedVertices[2].TextureCoordinate
            });
            triangleTwo.Vertices.Add(new Vertex
            {
                Position = rotatedVertices[3].Position,
                TextureCoordinate = rotatedVertices[3].TextureCoordinate
            });

            triangleTwo.Normal = new Normal { Y = 1 };

            _polygons.Add(triangleTwo);
        }

        private Vertex[] RotateVertices(Vertex[] vertices, double degree, double centerX, double centerZ, float distance)
        {
            Vertex[] rotatedVertices = new Vertex[4];

            rotatedVertices[0] = RotateVertex(vertices[0], degree, centerX, centerZ, distance);
            rotatedVertices[1] = RotateVertex(vertices[1], degree, centerX, centerZ, distance);
            rotatedVertices[2] = RotateVertex(vertices[2], degree, centerX, centerZ, distance);
            rotatedVertices[3] = RotateVertex(vertices[3], degree, centerX, centerZ, distance);

            return rotatedVertices;
        }

        private Vertex RotateVertex(Vertex vertex, double degree, double centerX, double centerZ, float distance)
        {
            double rad = degree / 180 * Math.PI;

            Matrix4 matrixRotation = Matrix4.CreateRotationY((float)rad);
            Matrix4 matrixTranslation = Matrix4.CreateTranslation(0, 0, distance);
            Matrix4 fullMatrix = Matrix4.Mult(matrixTranslation, matrixRotation);

            Vector3 vector = Vector3.Transform(new Vector3(vertex.Position.X, vertex.Position.Y, vertex.Position.Z), fullMatrix);

            Vertex rotatedVertex = new Vertex();
            rotatedVertex.Position = new VertexPosition();
            rotatedVertex.Position.X = vector.X + (float)centerX;
            rotatedVertex.Position.Z = vector.Z + (float)centerZ;
            rotatedVertex.Position.Y = vector.Y;
            rotatedVertex.TextureCoordinate = vertex.TextureCoordinate;

            return rotatedVertex;
        }
    }
}
