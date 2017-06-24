using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArtificialIntelligence.Contracts
{
    public interface IDestructibleBodyProvider
    {
        IDestructibleBody GetDestructibleBody();
        void SetDestructibleBody(IDestructibleBody destructibleBody);
    }
}
