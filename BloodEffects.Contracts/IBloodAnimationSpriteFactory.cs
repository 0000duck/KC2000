using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace BloodEffects.Contracts
{
    public interface IBloodAnimationSpriteFactory
    {
        IDrawable CreateBloodSprite(WallSpriteAnimationParameters wallSpriteAnimationParameters);
    }
}
