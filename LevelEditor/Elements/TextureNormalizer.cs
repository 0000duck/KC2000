using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using LevelEditor.Contracts;

namespace LevelEditor.Elements
{
    public class TextureNormalizer : ITextureNormalizer
    {
        void ITextureNormalizer.NormalizeTextures(IVisualParameters parameters, double textureSize)
        {
            if (parameters.Bottom != null)
            {
                NormalizeSide(parameters.Bottom, parameters.SideLengthX, parameters.SideLengthY, textureSize);
            }

            if (parameters.Top != null)
            {
                NormalizeSide(parameters.Top, parameters.SideLengthX, parameters.SideLengthY, textureSize);
            }

            if (parameters.PositiveX != null)
            {
                NormalizeSide(parameters.PositiveX, parameters.SideLengthY, parameters.Height, textureSize);
            }

            if (parameters.NegativeX != null)
            {
                NormalizeSide(parameters.NegativeX, parameters.SideLengthY, parameters.Height, textureSize);
            }

            if (parameters.PositiveZ != null)
            {
                NormalizeSide(parameters.PositiveZ, parameters.SideLengthX, parameters.Height, textureSize);
            }

            if (parameters.NegativeZ != null)
            {
                NormalizeSide(parameters.NegativeZ, parameters.SideLengthX, parameters.Height, textureSize);
            }
        }

        private void NormalizeSide(ISide side, double x, double y, double textureSize)
        {
            side.Reset();

            side.TexCoord1.X *= (x / textureSize);
            side.TexCoord1.Y *= (y / textureSize);

            side.TexCoord2.X *= (x / textureSize);
            side.TexCoord2.Y *= (y / textureSize);

            side.TexCoord3.X *= (x / textureSize);
            side.TexCoord3.Y *= (y / textureSize);

            side.TexCoord4.X *= (x / textureSize);
            side.TexCoord4.Y *= (y / textureSize);
        }
    }
}
