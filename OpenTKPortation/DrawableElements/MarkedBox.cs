using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using OpenTK.Graphics.OpenGL;
using IOInterface;
using Render.Contracts;

namespace DrawableElements
{
    public class MarkedBox : IDrawable, IPhysicalParameterUpdater, ISideMarker
    {
        private class MarkedPolygon : Polygon
        {
            public string SideName { set; get; }
        }

        private List<MarkedPolygon> Polygons { set; get; }
        private VertexPosition[] Positions { set; get; }
        private string MarkedSideName { set; get; }
        private IPhysicalParameters PhysicalParameters { set; get; }

        public MarkedBox(IPhysicalParameters physicalParameters, Degree rotation)
        {
            PhysicalParameters = physicalParameters;
            CreatePolygons(physicalParameters, rotation);
        }

        void IDrawable.Draw()
        {
            GL.Disable(EnableCap.Texture2D);
            GL.Disable(EnableCap.Lighting);
            foreach (MarkedPolygon polygon in Polygons)
            {
                if(polygon.SideName.Equals(MarkedSideName) || MarkedSideName == "All")
                    GL.Color3(1.0f, 0.0f, 0.0f);
                else
                    GL.Color3(0.0f, 1.0f, 0.0f);

                GL.Begin(PrimitiveType.LineStrip);
                foreach (Vertex vertex in polygon.Vertices)
                {
                    GL.Vertex3(vertex.Position.X, vertex.Position.Y, vertex.Position.Z);
                }
                GL.End();
            }
            
            GL.Color3(1.0f, 1.0f, 1.0f);
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Lighting);
        }

        void IPhysicalParameterUpdater.UpdateParameters(IPhysicalParameters physicalParameters, Degree rotation)
        {
            PhysicalParameters = physicalParameters;
            CreatePolygons(physicalParameters, rotation);
        }

        private void CreatePolygons(IPhysicalParameters physicalParamters, Degree rotation)
        {
            Polygons = new List<MarkedPolygon>();

            float lengthX = (float)(physicalParamters.SideLengthX / 2.0) + 0.02f;
            float lengthY = (float)physicalParamters.Height + 0.02f;
            float lengthZ = (float)(physicalParamters.SideLengthY / 2.0) + 0.02f;

            if (rotation == Degree.Degree_90 || rotation == Degree.Degree_270)
            {
                float tempLengthX = lengthX;
                lengthX = lengthZ;
                lengthZ = tempLengthX;
            }

            Positions = new VertexPosition[8];

            Positions[0] = new VertexPosition { X = -lengthX, Y = 0.0f, Z = -lengthZ };
            Positions[1] = new VertexPosition { X = lengthX, Y = 0.0f, Z = -lengthZ };
            Positions[2] = new VertexPosition { X = lengthX, Y = 0.0f, Z = lengthZ };
            Positions[3] = new VertexPosition { X = -lengthX, Y = 0.0f, Z = lengthZ };

            Positions[4] = new VertexPosition { X = -lengthX, Y = lengthY, Z = -lengthZ };
            Positions[5] = new VertexPosition { X = lengthX, Y = lengthY, Z = -lengthZ };
            Positions[6] = new VertexPosition { X = lengthX, Y = lengthY, Z = lengthZ };
            Positions[7] = new VertexPosition { X = -lengthX, Y = lengthY, Z = lengthZ };

            RotatePosition(Positions, rotation);

            Polygons.Add(CreateSide(Positions[0], Positions[1], Positions[5], Positions[4]));
            Polygons.Last().SideName = "Front";          

            Polygons.Add(CreateSide(Positions[2], Positions[3], Positions[7], Positions[6]));
            Polygons.Last().SideName = "Back";

            Polygons.Add(CreateSide(Positions[3], Positions[0], Positions[4], Positions[7]));
            Polygons.Last().SideName = "Left";

            Polygons.Add(CreateSide(Positions[1], Positions[2], Positions[6], Positions[5]));
            Polygons.Last().SideName = "Right";

            Polygons.Add(CreateSide(Positions[4], Positions[5], Positions[6], Positions[7]));
            Polygons.Last().SideName = "Top";

            Polygons.Add(CreateSide(Positions[3], Positions[2], Positions[1], Positions[0]));
            Polygons.Last().SideName = "Bottom";     
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

        private MarkedPolygon CreateSide(VertexPosition position1, VertexPosition position2, VertexPosition position3, VertexPosition position4)
        {
            MarkedPolygon polygon = new MarkedPolygon();
            polygon.Vertices = new List<Vertex>();

            polygon.Vertices.Add(new Vertex { Position = position1 });
            polygon.Vertices.Add(new Vertex { Position = position2 });
            polygon.Vertices.Add(new Vertex { Position = position3 });
            polygon.Vertices.Add(new Vertex { Position = position4 });
            return polygon;
        }

        public void MarkSide(string sideName)
        {
            MarkedSideName = sideName;
        }
    }
}
