using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using IOInterface;

namespace ArtificialIntelligence.Contracts
{
    public class BehaviourInstruction
    {
        public Behaviour Behaviour { set; get; }

        public Direction? Direction { set; get; }

        public Degree ViewDegree { set; get; }

        public Degree? MovementDegree { set; get; }

        public Vector2D MovementVector { set; get; }

        public double Percent { set; get; }

        public double? Speed { set; get; } 
    }
}
