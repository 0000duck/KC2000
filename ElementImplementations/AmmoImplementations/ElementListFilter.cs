using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Contracts;
using IOInterface;
using BaseTypes;
using GameInteractionContracts;

namespace ElementImplementations.AmmoImplementations
{
    public class ElementListFilter : IElementFilter
    {
        private IList<ElementTheme> _filteredElements;

        public ElementListFilter(IList<ElementTheme> filteredElements)
        {
            _filteredElements = filteredElements;
        }

        bool IElementFilter.ElementIsFiltered(IWorldElement element)
        {
            if (element.Shape != Shape.Circle)
                return false;

            IVisualAppearance animatable = element as IVisualAppearance;

            if (animatable == null)
                return false;

            return _filteredElements.Contains(animatable.ElementTheme);
        }
    }
}
