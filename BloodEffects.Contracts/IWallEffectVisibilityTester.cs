using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using FrameworkContracts;

namespace BloodEffects.Contracts
{
    public interface IWallEffectVisibilityTester
    {
        bool WallEffectIsVisible(IWorldElement wall, SpriteVertices spriteVertices, Position3D bloodPosition, List<IWorldElement> allWalls);
    }
}
