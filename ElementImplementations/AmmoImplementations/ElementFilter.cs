using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Contracts;
using BaseTypes;
using GameInteractionContracts;
using IOInterface;

namespace ElementImplementations.AmmoImplementations
{
    public class ElementFilter : IElementFilter
    {
        private ElementTheme _filteredElement;

        public ElementFilter(ElementTheme filteredElement)
        {
            _filteredElement = filteredElement;
        }

        bool IElementFilter.ElementIsFiltered(IWorldElement element)
        {
            if (element.Shape != Shape.Circle)
                return false;

            IVisualAppearance animatable = element as IVisualAppearance;

            if (animatable == null)
                return false;

            return animatable.ElementTheme == _filteredElement;
        }
    }
}
