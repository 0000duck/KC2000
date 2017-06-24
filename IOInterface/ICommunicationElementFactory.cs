using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace IOInterface
{
    public interface ICommunicationElementFactory
    {
        ICommunicationElement CreateNewElement(IElement element);
    }
}
