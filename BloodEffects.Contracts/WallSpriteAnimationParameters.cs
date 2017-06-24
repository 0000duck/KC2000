using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;
using FrameworkContracts;

namespace BloodEffects.Contracts
{
    public class WallSpriteAnimationParameters
    {
        public SpriteVertices SpriteVertices { set; get; }

        public Animation Animation { set; get; }

        public double AnimationPercent { set; get; }

        public Position3D SpriteCenterPosition { set; get; }

        public Vector3D Normal { set; get; }
    }
}
