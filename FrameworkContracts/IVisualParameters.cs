using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace FrameworkContracts
{
    public interface ITextureCoordinate
    {
        double X { set; get; }
        double Y { set; get; }
    }

    public interface ISide
    {
        ITextureCoordinate TexCoord1 { set; get; }

        ITextureCoordinate TexCoord2 { set; get; }

        ITextureCoordinate TexCoord3 { set; get; }

        ITextureCoordinate TexCoord4 { set; get; }

        void Reset();
    }

    public enum TextureCoordinateDirection
    {
        PositiveX = 1,

        NegativeX = 2,

        PositiveY = 3,

        NegativeY = 4,

        PositiveXNegativeY = 5,

        NegativeXNegativeY = 6
    }

    public interface IVisualParameters : IPhysicalParameters
    {
        ISide NegativeZ { set; get; }

        ISide PositiveZ { set; get; }

        ISide NegativeX { set; get; }

        ISide PositiveX { set; get; }

        ISide Bottom { set; get; }

        ISide Top { set; get; }

        string TextureFolder { set; get; }

        bool IsAnimation { set; get; }

        double AnimationDurationPerImage { set; get; }

        TextureCoordinateDirection? TextureCoordinateDirection { set; get; }

        IVisualParameters Clone();
    }
}
