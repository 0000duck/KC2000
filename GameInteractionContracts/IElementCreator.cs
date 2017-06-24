using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using IOInterface;

namespace GameInteractionContracts
{
    public interface IElementCreator
    {
        IWorldElement GetNewElement(IElement element);

        void EnqueueNewElement(IElement element, Action<IWorldElement> returnCreatedElement = null);

        void DeleteElement(IWorldElement element);
    }
}
