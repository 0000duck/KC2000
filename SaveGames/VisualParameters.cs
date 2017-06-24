using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOImplementation;
using FrameworkContracts;
using IOInterface;

namespace SaveGames
{
    public class TextureCoordinate : ITextureCoordinate
    {
        public double X { set; get; }
        public double Y { set; get; }
    }

    public class Side : ISide
    {
        public ITextureCoordinate TexCoord1 { set; get; }

        public ITextureCoordinate TexCoord2 { set; get; }

        public ITextureCoordinate TexCoord3 { set; get; }

        public ITextureCoordinate TexCoord4 { set; get; }

        public Side()
        {
            Reset();
        }

        public void Reset()
        {
            TexCoord1 = new TextureCoordinate { X = 0, Y = 0 };
            TexCoord2 = new TextureCoordinate { X = 1, Y = 0 };
            TexCoord3 = new TextureCoordinate { X = 1, Y = 1 };
            TexCoord4 = new TextureCoordinate { X = 0, Y = 1 };
        }
    }

    public class VisualParameters : PhysicalAppearance, IVisualParameters
    {
        public ISide NegativeZ { set; get; }

        public ISide PositiveZ { set; get; }

        public ISide NegativeX { set; get; }

        public ISide PositiveX { set; get; }

        public ISide Bottom { set; get; }

        public ISide Top { set; get; }

        public string TextureFolder { set; get; }

        public bool IsAnimation { set; get; }

        public double AnimationDurationPerImage { set; get; }

        public TextureCoordinateDirection? TextureCoordinateDirection { set; get; }

        public VisualParameters(bool preFill = false)
        {
            if (!preFill)
                return;

            Height = 1;
            SideLengthX = 1;
            SideLengthY = 1;

            Top = new Side();
            Bottom = new Side();
            NegativeX = new Side();
            NegativeZ = new Side();
            PositiveX = new Side();
            PositiveZ = new Side();

            Weight = 50 * SideLengthX * SideLengthY * Height;
        }

        public VisualParameters(IPhysicalParameters physicalParameters)
        {
            Height = physicalParameters.Height;
            SideLengthX = physicalParameters.SideLengthX;
            SideLengthY = physicalParameters.SideLengthY;
            Shape = physicalParameters.Shape;
            Weight = physicalParameters.Weight;

            Top = new Side();
            Bottom = new Side();
            NegativeX = new Side();
            NegativeZ = new Side();
            PositiveX = new Side();
            PositiveZ = new Side();
        }

        public IVisualParameters Clone()
        {
            return new VisualParameters
            {
                AnimationDurationPerImage = AnimationDurationPerImage,
                TextureCoordinateDirection = TextureCoordinateDirection,
                Bottom = Bottom,
                Height = Height,
                IsAnimation = IsAnimation,
                NegativeX = NegativeX,
                NegativeZ = NegativeZ,
                PositiveX = PositiveX,
                PositiveZ = PositiveZ,
                Top = Top,
                TextureFolder = TextureFolder,
                SideLengthX = SideLengthX,
                SideLengthY = SideLengthY,
                Weight = Weight,
                Shape = Shape
            };
        }
    }
}
