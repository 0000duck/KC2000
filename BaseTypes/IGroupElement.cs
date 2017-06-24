using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public interface IGroupElement : IWorldElement
    {
        IElementGroup Parent { set; get; }
    }
}
