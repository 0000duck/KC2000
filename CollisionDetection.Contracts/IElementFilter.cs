using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace CollisionDetection.Contracts
{
    public interface IElementFilter
    {
        bool ElementIsFiltered(IWorldElement element);
    }
}
