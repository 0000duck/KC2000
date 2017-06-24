using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using FrameworkContracts;

namespace BloodEffects.Contracts
{
    public interface IWallSpriteCalculator
    {
        SpriteVertices CalculateVertices(IWorldElement intersectedElement, Position3D spriteCenterPosition, double fullSideLength);
    }
}
