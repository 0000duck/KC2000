using Render.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Model
{
    public class Submodel
    {
        public string Texture { set; get; }

        public IEnumerable<Polygon> Polygons { set; get; }
    }

    public class Triangle
    {
        public double[] Corner1 { set; get; }

        public double[] Corner2 { set; get; }

        public double[] Corner3 { set; get; }
    }

    public class Face
    {
        public double[] Normal { set; get; }

        public Triangle[] Triangles { set; get; }
    }

    public class Cuboid
    {
        public double SideLengthY { set; get; }

        public double SideLengthX { set; get; }

        public double SideLengthZ { set; get; }

        public Position Center { set; get; }
    }

    public class Position
    {
        public double X { set; get; }

        public double Y { set; get; }

        public double Z { set; get; }
    }

    public class ComplexShape
    {
        public double RadiusXZ { set; get; }

        public Cuboid MainCuboid { set; get; }

        public Face[] Faces { set; get; }

        public Cuboid[] SubCuboids { set; get; }
    }
}
