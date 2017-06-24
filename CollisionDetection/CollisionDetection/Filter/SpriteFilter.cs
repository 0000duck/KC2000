using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Contracts;
using BaseTypes;

namespace CollisionDetection.Filter
{
    public class SpriteFilter : IElementFilter
    {
        bool IElementFilter.ElementIsFiltered(IWorldElement element)
        {
            return element.Shape == Shape.Circle;
        }
    }
}
