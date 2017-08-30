using IOInterface;
using LevelEditor.Model;
using Render.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor
{
    public class CollisionModelExporter
    {
        public static ComplexShape GetShape(List<IElement> geometry)
        {
            ComplexShape complexShape = new ComplexShape();

            List<Cuboid> subCuboids = new List<Cuboid>();

            double highestX = -100;
            double lowestX = 100;
            double highestY = -100;
            double lowestY= 100;
            double highestZ = -100;
            double lowestZ= 100;

            foreach (IElement element in geometry)
            {
                Cuboid cuboid = MapCuboid(element);
                subCuboids.Add(cuboid);

                double halfLengthX = element.Parameters.SideLengthX / 2.0;
                double halfLengthZ = element.Parameters.SideLengthY / 2.0;

                if (element.Orientation == BaseTypes.Degree.Degree_90 || element.Orientation == BaseTypes.Degree.Degree_270)
                {
                    double temp = halfLengthX;
                    halfLengthX = halfLengthZ;
                    halfLengthZ = temp;
                }

                if (element.StartPosition.PositionX - halfLengthX < lowestX)
                    lowestX = element.StartPosition.PositionX - halfLengthX;
                if (element.StartPosition.PositionX + halfLengthX > highestX)
                    highestX = element.StartPosition.PositionX + halfLengthX;

                if (element.StartPosition.PositionY - halfLengthZ < lowestZ)
                    lowestZ = element.StartPosition.PositionY - halfLengthZ;
                if (element.StartPosition.PositionY + halfLengthZ > highestZ)
                    highestZ = element.StartPosition.PositionY+ halfLengthZ;

                if (element.StartPosition.PositionZ < lowestY)
                    lowestY = element.StartPosition.PositionZ;
                if (element.StartPosition.PositionZ + element.Parameters.Height > highestY)
                    highestY = element.StartPosition.PositionZ + element.Parameters.Height;
            }

            complexShape.RadiusXZ = System.Math.Sqrt(((highestX - lowestX) / 2) * ((highestX - lowestX) / 2) + ((highestZ - lowestZ) / 2) * ((highestZ - lowestZ) / 2));
            complexShape.MainCuboid = new Cuboid
            {
                SideLengthX = highestX - lowestX,
                SideLengthZ = highestZ - lowestZ,
                SideLengthY = highestY - lowestY,
                Center = new Position
                {
                    X = 0,
                    Y = 0,
                    Z = 0
                }
            };
            complexShape.SubCuboids = subCuboids.ToArray();

            return complexShape;
        }

        private static Cuboid MapCuboid(IElement element)
        {
            double LengthX = element.Parameters.SideLengthX;
            double LengthZ = element.Parameters.SideLengthY;

            if (element.Orientation == BaseTypes.Degree.Degree_90 || element.Orientation == BaseTypes.Degree.Degree_270)
            {
                double temp = LengthX;
                LengthX = LengthZ;
                LengthZ = temp;
            }
            return new Cuboid
            {
                SideLengthX = LengthX,
                SideLengthZ = LengthZ,
                SideLengthY = element.Parameters.Height,
                Center = new Position { X = element.StartPosition.PositionX, Y = element.StartPosition.PositionZ, Z = element.StartPosition.PositionY }
            };
        }
    }
}
