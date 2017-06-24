using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace BloodEffects.Contracts
{
    public interface IWallEffectQueue
    {
        void QueueWallEffect(WallSpriteAnimationParameters wallSpriteAnimationParameters, IWorldElement wall, List<IWorldElement> allWalls, Position3D bloodCenterPosition);
    }
}
