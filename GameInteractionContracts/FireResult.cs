using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameInteractionContracts
{
    public struct FireResult
    {
        public int CountOfFiredAmmo { set; get; }

        public int RestOfAmmo { set; get; }
    }
}
