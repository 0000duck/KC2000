using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace GameInteractionContracts
{
    public interface IStorable
    {
        void SetState(IInitInformation initInformation);
        IInitInformation GetState();
    }
}
