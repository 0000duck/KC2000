using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;

namespace ArtificialIntelligence.Contracts
{
    public class RotationResult
    {
        public Degree Orientation { get; set; }

        public Behaviour Behaviour { get; set; }
    }
}
