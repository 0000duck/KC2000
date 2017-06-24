using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using IOInterface;

namespace ArtificialIntelligence
{
    public class EmptyDucker : IDucker
    {

        bool IDucker.IsDucking()
        {
            return false;
        }

        void IDucker.StartDucking()
        {
            
        }

        DuckResult IDucker.GetDuckResult()
        {
            return new DuckResult 
            {
                Behaviour = Behaviour.StandardBehaviour,
            };
        }
    }
}
