using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace BloodEffects.Contracts
{
    public interface IBloodSpriteParameterCalculator
    {
        WallSpriteAnimationParameters TryToCreateSprite(IWorldElement intersectedElement, Position3D centerOfSphere, double radius);
    }
}
