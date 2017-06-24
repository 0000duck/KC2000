using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameInteractionContracts
{
    public interface IElementCreatorProvider
    {
        IElementCreator GetElementCreator();
    }
}
