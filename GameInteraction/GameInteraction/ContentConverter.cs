using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using CollisionDetection;
using BaseTypes;
using GameInteraction.BaseImplementations;
using GameInteraction.ThemeMapping;
using GameInteractionContracts;

namespace GameInteraction
{
    public class ContentConverter
    {
        private int LoopCounter { set; get; }
        private List<IElement> Elements { set; get; }
        private IElementCreator _elementCreator;

        public ContentConverter(List<IElement> elements, IElementCreator elementCreator)
        {
            LoopCounter = 0;
            Elements = elements;
            _elementCreator = elementCreator;
        }

        public double InstantiateNextElement()
        {
            for (int i = LoopCounter; i < Elements.Count && i < LoopCounter + 1; i++)
            {
                IElement element = Elements.ElementAt(i);

                _elementCreator.GetNewElement(element);
            }
            if (LoopCounter < Elements.Count)
                LoopCounter += 1;

            double percent = ((double)LoopCounter) / Elements.Count;
            return percent <= 1.0 ? percent : 1.0;
        }

        public bool AllElementsAreInstantiated()
        {
            return LoopCounter >= Elements.Count;
        }
    }
}
