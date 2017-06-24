using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArtificialIntelligence.Contracts
{
    public interface IRandomDurationGenerator
    {

        bool IsFinished();

        void StartRandomDuration();
    }
}
