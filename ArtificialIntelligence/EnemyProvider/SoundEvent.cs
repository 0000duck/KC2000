using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.EnemyProvider
{
    public class SoundEvent
    {
        public NoiseLevel NoiseLevel { set; get; }

        public double TimeStamp { set; get; }

        public Position3D Position { set; get; }
    }
}
