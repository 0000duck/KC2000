using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public interface IElementGroup
    {
        IList<IGroupElement> Children { get; } 

        void RemoveChild(IGroupElement child);

        void AddChild(IGroupElement child);
    }
}
