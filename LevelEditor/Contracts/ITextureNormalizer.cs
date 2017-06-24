using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace LevelEditor.Contracts
{
    public interface ITextureNormalizer
    {
        void NormalizeTextures(IVisualParameters parameters, double textureSize);
    }
}
