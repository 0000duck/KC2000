using BaseTypes;
using FrameworkContracts;
using Render.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor
{
    public class PolygonExporter
    {
        public List<Polygon> CreatePolygons(IVisualParameters visualAppearance, Degree rotation)
        {
            List<Polygon>  Polygons = new List<Polygon>();

            float lengthX = (float)(visualAppearance.SideLengthX / 2.0);
            float lengthY = (float)visualAppearance.Height;
            float lengthZ = (float)(visualAppearance.SideLengthY / 2.0);

            if (rotation == Degree.Degree_90 || rotation == Degree.Degree_270)
            {
                float tempLengthX = lengthX;
                lengthX = lengthZ;
                lengthZ = tempLengthX;
            }

            VertexPosition[] Positions = new VertexPosition[8];

            Positions[0] = new VertexPosition { X = -lengthX, Y = 0.0f, Z = -lengthZ };
            Positions[1] = new VertexPosition { X = lengthX, Y = 0.0f, Z = -lengthZ };
            Positions[2] = new VertexPosition { X = lengthX, Y = 0.0f, Z = lengthZ };
            Positions[3] = new VertexPosition { X = -lengthX, Y = 0.0f, Z = lengthZ };

            Positions[4] = new VertexPosition { X = -lengthX, Y = lengthY, Z = -lengthZ };
            Positions[5] = new VertexPosition { X = lengthX, Y = lengthY, Z = -lengthZ };
            Positions[6] = new VertexPosition { X = lengthX, Y = lengthY, Z = lengthZ };
            Positions[7] = new VertexPosition { X = -lengthX, Y = lengthY, Z = lengthZ };

            RotatePosition(Positions, rotation);

            if (visualAppearance.NegativeZ != null)
            {
                Polygons.AddRange(CreateSide(Positions[5], Positions[4], Positions[0], Positions[1],
                    visualAppearance.NegativeZ.TexCoord1, visualAppearance.NegativeZ.TexCoord2, visualAppearance.NegativeZ.TexCoord3, visualAppearance.NegativeZ.TexCoord4));
            }

            if (visualAppearance.PositiveZ != null)
            {
                Polygons.AddRange(CreateSide(Positions[7], Positions[6], Positions[2], Positions[3],
                    visualAppearance.PositiveZ.TexCoord1, visualAppearance.PositiveZ.TexCoord2, visualAppearance.PositiveZ.TexCoord3, visualAppearance.PositiveZ.TexCoord4));
            }

            if (visualAppearance.NegativeX != null)
            {
                Polygons.AddRange(CreateSide(Positions[4], Positions[7], Positions[3], Positions[0],
                    visualAppearance.NegativeX.TexCoord1, visualAppearance.NegativeX.TexCoord2, visualAppearance.NegativeX.TexCoord3, visualAppearance.NegativeX.TexCoord4));
            }

            if (visualAppearance.PositiveX != null)
            {
                Polygons.AddRange(CreateSide(Positions[6], Positions[5], Positions[1], Positions[2],
                    visualAppearance.PositiveX.TexCoord1, visualAppearance.PositiveX.TexCoord2, visualAppearance.PositiveX.TexCoord3, visualAppearance.PositiveX.TexCoord4));
            }

            if (visualAppearance.Top != null)
            {
                Polygons.AddRange(CreateSide(Positions[4], Positions[5], Positions[6], Positions[7],
                    visualAppearance.Top.TexCoord1, visualAppearance.Top.TexCoord2, visualAppearance.Top.TexCoord3, visualAppearance.Top.TexCoord4));
            }

            if (visualAppearance.Bottom != null)
            {
                Polygons.AddRange(CreateSide(Positions[3], Positions[2], Positions[1], Positions[0],
                    visualAppearance.Bottom.TexCoord1, visualAppearance.Bottom.TexCoord2, visualAppearance.Bottom.TexCoord3, visualAppearance.Bottom.TexCoord4));
            }

            return Polygons;
        }

        private void RotatePosition(VertexPosition[] positions, Degree rotation)
        {
            VertexPosition temp0 = positions[0];
            VertexPosition temp1 = positions[1];
            VertexPosition temp2 = positions[2];
            VertexPosition temp3 = positions[3];
            VertexPosition temp4 = positions[4];
            VertexPosition temp5 = positions[5];
            VertexPosition temp6 = positions[6];
            VertexPosition temp7 = positions[7];

            switch (rotation)
            {
                case Degree.Degree_90:
                    positions[0] = temp3;
                    positions[1] = temp0;
                    positions[2] = temp1;
                    positions[3] = temp2;
                    positions[4] = temp7;
                    positions[5] = temp4;
                    positions[6] = temp5;
                    positions[7] = temp6;
                    break;
                case Degree.Degree_180:
                    positions[0] = temp2;
                    positions[1] = temp3;
                    positions[2] = temp0;
                    positions[3] = temp1;
                    positions[4] = temp6;
                    positions[5] = temp7;
                    positions[6] = temp4;
                    positions[7] = temp5;
                    break;
                case Degree.Degree_270:
                    positions[0] = temp1;
                    positions[1] = temp2;
                    positions[2] = temp3;
                    positions[3] = temp0;
                    positions[4] = temp5;
                    positions[5] = temp6;
                    positions[6] = temp7;
                    positions[7] = temp4;
                    break;
            }
        }

        private List<Polygon> CreateSide(VertexPosition position1, VertexPosition position2, VertexPosition position3, VertexPosition position4,
            ITextureCoordinate textureCoordinate1, ITextureCoordinate textureCoordinate2, ITextureCoordinate textureCoordinate3, ITextureCoordinate textureCoordinate4)
        {
            List<Polygon> polygons = new List<Polygon>();
            Polygon triangleOne = CreateTriangle(position1, position2, position3, textureCoordinate1, textureCoordinate2, textureCoordinate3);

            triangleOne.Normal = CalculateNormal(position1, position2, position3);

            polygons.Add(triangleOne);

            Polygon triangleTwo = CreateTriangle(position1, position3, position4, textureCoordinate1, textureCoordinate3, textureCoordinate4);

            triangleTwo.Normal = triangleOne.Normal;

            polygons.Add(triangleTwo);
            return polygons;
        }

        private Polygon CreateTriangle(VertexPosition position1, VertexPosition position2, VertexPosition position3,
            ITextureCoordinate textureCoordinate1, ITextureCoordinate textureCoordinate2, ITextureCoordinate textureCoordinate3)
        {
            Polygon triangle = new Polygon();

            triangle.Vertices = new List<Vertex>();
            triangle.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = position1.X, Y = position1.Y, Z = position1.Z },
                TextureCoordinate = new VertexTextureCoordinate { X = (float)textureCoordinate1.X, Y = (float)textureCoordinate1.Y }
            });
            triangle.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = position2.X, Y = position2.Y, Z = position2.Z },
                TextureCoordinate = new VertexTextureCoordinate { X = (float)textureCoordinate2.X, Y = (float)textureCoordinate2.Y }
            });
            triangle.Vertices.Add(new Vertex
            {
                Position = new VertexPosition { X = position3.X, Y = position3.Y, Z = position3.Z },
                TextureCoordinate = new VertexTextureCoordinate { X = (float)textureCoordinate3.X, Y = (float)textureCoordinate3.Y }
            });

            return triangle;
        }

        private Normal CalculateNormal(VertexPosition position1, VertexPosition position2, VertexPosition position3)
        {
            float positiveZero = 0.001f;
            float negativeZero = 0.001f;

            if (position1.Z > positiveZero && position2.Z > positiveZero && position3.Z > positiveZero)
            {
                return new Normal { Z = 1 };
            }

            if (position1.Z < positiveZero && position2.Z < positiveZero && position3.Z < positiveZero)
            {
                return new Normal { Z = -1 };
            }

            if (position1.X > positiveZero && position2.X > positiveZero && position3.X > positiveZero)
            {
                return new Normal { X = 1 };
            }

            if (position1.X < negativeZero && position2.X < negativeZero && position3.X < negativeZero)
            {
                return new Normal { X = -1 };
            }

            if (position1.Y > positiveZero && position2.Y > positiveZero && position3.Y > positiveZero)
            {
                return new Normal { Y = 1 };
            }

            if (position1.Y < positiveZero && position2.Y < positiveZero && position3.Y < positiveZero)
            {
                return new Normal { Y = -1 };
            }

            throw new Exception("Normal kann nicht berechnet werden!");
        }
    }
}
