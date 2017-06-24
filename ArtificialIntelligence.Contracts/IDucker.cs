using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArtificialIntelligence.Contracts
{
    public interface IDucker
    {
        bool IsDucking();

        void StartDucking();

        DuckResult GetDuckResult();
    }
}
