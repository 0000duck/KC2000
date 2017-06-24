using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace GameInteractionContracts
{
    public class AnimationInstruction
    {
        public Behaviour Behaviour { set; get; }

        public double Percent { set; get; }

        public bool ElementIsFinished { set; get; }
    }
}
