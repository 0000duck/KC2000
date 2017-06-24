using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace DrawableElements
{
    public class Floor : IDrawable
    {
        private ITexture Texture { set; get; }
        private List<Polygon> Polygons { set; get; }
        private ITextureChanger _textureChanger;
        private IPolygonRenderer _polygonRenderer;

        public Floor(ITexture texture, ITextureChanger textureChanger, IPolygonRenderer polygonRenderer, double lengthX, double lengthZ, double height, float textureX, float textureY, float startX = 0, float startZ = 0)
        {
            Texture = texture;
            _textureChanger = textureChanger;
            _polygonRenderer = polygonRenderer;
            CreatePolygons(lengthX, lengthZ, height, textureX, textureY, startX, startZ);
        }

        private void CreatePolygons(double lengthX, double lengthZ, double height, float textureX, float textureY, float startX, float startZ)
        {
            float additionalX = 0;
            float additionalZ = 0;

            Polygons = new List<Polygon>();

            Polygon triangleOne = new Polygon();

            triangleOne.Vertices = new List<Vertex>();
            triangleOne.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = startX - additionalX, Z = startZ -additionalZ, Y = (float)height },
                TextureCoordinate = new VertexTextureCoordinate { X = 0, Y = textureY }
            });
            triangleOne.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = startX + (float)lengthX + additionalX, Y = (float)height, Z = startZ + (float)lengthZ + additionalZ },
                TextureCoordinate = new VertexTextureCoordinate { X = textureX, Y = 0 }
            });
            triangleOne.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = startX - additionalX, Y = (float)height, Z = startZ + (float)lengthZ + additionalZ },
                TextureCoordinate = new VertexTextureCoordinate { X = 0, Y = 0 }
            });
            triangleOne.Normal = new Normal { X = 0, Y = 1, Z = 0 };

            Polygons.Add(triangleOne);

            Polygon triangleTwo = new Polygon();

            triangleTwo.Vertices = new List<Vertex>();
            triangleTwo.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = startX - additionalX, Z = startZ  + - additionalZ, Y = (float)height },
                TextureCoordinate = new VertexTextureCoordinate { X = 0, Y = textureY }
            });
            triangleTwo.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = startX + (float)lengthX + additionalX, Z = startZ  + - additionalZ + additionalZ, Y = (float)height },
                TextureCoordinate = new VertexTextureCoordinate { X = textureX, Y = textureY }
            });
            triangleTwo.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = startX + (float)lengthX + additionalX, Y = (float)height, Z = startZ + (float)lengthZ + additionalZ },
                TextureCoordinate = new VertexTextureCoordinate { X = textureX, Y = 0 }
            });
            triangleTwo.Normal = new Normal { X = 0, Y = 1, Z = 0 };

            Polygons.Add(triangleTwo);
        }

        public void Draw()
        {
            _textureChanger.SetTexture(Texture.TextureId);

            _polygonRenderer.RenderPolygons(Polygons);
        }
    }
}
