using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;

namespace ArtificialIntelligence
{
    public class DestructibleBodyProvider : IDestructibleBodyProvider
    {
        private IDestructibleBody _destructibleBody;

        IDestructibleBody IDestructibleBodyProvider.GetDestructibleBody()
        {
            return _destructibleBody;
        }

        void IDestructibleBodyProvider.SetDestructibleBody(IDestructibleBody destructibleBody)
        {
            _destructibleBody = destructibleBody;
        }
    }
}
