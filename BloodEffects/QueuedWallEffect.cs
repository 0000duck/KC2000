using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using BloodEffects.Contracts;

namespace BloodEffects
{
    public class QueuedWallEffect
    {
        public WallSpriteAnimationParameters WallSpriteAnimationParameters { set; get; }

        public IWorldElement Wall { set; get; }

        public List<IWorldElement> AllWalls { set; get; }

        public Position3D BloodCenterPosition { set; get; } 
    }
}
