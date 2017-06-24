using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using Render.Contracts;

namespace BloodEffects.SpriteCreaterImplementations
{
    public class TextureRotater : ITextureRotater
    {
        private Degree _currentDegree = Degree.Degree_0;

        void ITextureRotater.Rotate(SpriteVertices spriteVertices)
        {
            switch (_currentDegree)
            {
                case Degree.Degree_90:
                    Rotate90(spriteVertices.VertexOne);
                    Rotate90(spriteVertices.VertexTwo);
                    Rotate90(spriteVertices.VertexThree);
                    Rotate90(spriteVertices.VertexFour);
                    break;
                case Degree.Degree_180:
                    Rotate180(spriteVertices.VertexOne);
                    Rotate180(spriteVertices.VertexTwo);
                    Rotate180(spriteVertices.VertexThree);
                    Rotate180(spriteVertices.VertexFour);
                    break;
                case Degree.Degree_270:
                    Rotate270(spriteVertices.VertexOne);
                    Rotate270(spriteVertices.VertexTwo);
                    Rotate270(spriteVertices.VertexThree);
                    Rotate270(spriteVertices.VertexFour);
                    break;
            }

            _currentDegree += 2;

            if (_currentDegree > Degree.Degree_315)
                _currentDegree = Degree.Degree_0;
        }

        private void Rotate270(Vertex vertex)
        {
            float tempX = vertex.TextureCoordinate.X;
            vertex.TextureCoordinate.X = vertex.TextureCoordinate.Y;
            vertex.TextureCoordinate.Y = 1 - tempX;
        }

        private void Rotate180(Vertex vertex)
        {
            vertex.TextureCoordinate.X = 1 - vertex.TextureCoordinate.X;
            vertex.TextureCoordinate.Y = 1 - vertex.TextureCoordinate.Y;
        }

        private void Rotate90(Vertex vertex)
        {
            float tempX = vertex.TextureCoordinate.X;
            vertex.TextureCoordinate.X = 1- vertex.TextureCoordinate.Y;
            vertex.TextureCoordinate.Y = tempX;
        }
    }
}
