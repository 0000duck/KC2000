using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;
using CollisionDetection;

namespace GameInteractionContracts
{
    public interface IElementFactory
    {
        IWorldElement CreateNewElement(IElement element);

        void DeleteElement(IWorldElement element);
    }
}
