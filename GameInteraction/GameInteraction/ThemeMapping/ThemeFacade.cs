using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;
using GameInteraction.BaseImplementations;
using GameInteraction.Weapons;
using CollisionDetection;
using GameInteractionContracts;
using BaseContracts;

namespace GameInteraction.ThemeMapping
{
    public class ThemeFacade : IElementCreator, IExecuteble
    {
        private class EnqueuedElement
        {
            public IElement Element { set; get; }

            public Action<IWorldElement> ReturnCreatedElement { set; get; }
        }

        private List<EnqueuedElement> _enqueuedElements;
        private List<IWorldElement> _changedElements;
        private IElementFactory _elementFactory;

        public ThemeFacade(IElementFactory elementFactory)
        {
            _elementFactory = elementFactory;
            _enqueuedElements = new List<EnqueuedElement>();
            _changedElements = new List<IWorldElement>();
        }

        IWorldElement IElementCreator.GetNewElement(IElement element)
        {
            return _elementFactory.CreateNewElement(element);
        }

        void IElementCreator.EnqueueNewElement(IElement element, Action<IWorldElement> returnCreatedElement = null)
        {
            _enqueuedElements.Add(new EnqueuedElement { Element = element, ReturnCreatedElement = returnCreatedElement });
        }

        void IElementCreator.DeleteElement(IWorldElement element)
        {
            if (_changedElements.Contains(element))
                return;

            if (element is IElementGroup)
            {
                if (((IElementGroup)element).Children != null && ((IElementGroup)element).Children.Count > 0)
                {
                    foreach (IGroupElement child in ((IElementGroup)element).Children.ToList())
                    {
                        ((IElementGroup)element).RemoveChild(child);
                        _changedElements.Add(child);
                    }
                }
            }
            
            _changedElements.Add(element);
        }

        void IExecuteble.ExecuteLogic()
        {
            for (int i = 0; i < 6; i++ )
                DequeueElement();

                foreach (IWorldElement element in _changedElements)
                {
                    _elementFactory.DeleteElement(element);
                }
            _changedElements.Clear();
        }

        private void DequeueElement()
        {
            if (_enqueuedElements.Count == 0)
                return;

            EnqueuedElement enqueuedElement = _enqueuedElements.First();

            IWorldElement element = _elementFactory.CreateNewElement(enqueuedElement.Element);
            if (enqueuedElement.ReturnCreatedElement != null)
                enqueuedElement.ReturnCreatedElement(element);

            _enqueuedElements.RemoveAt(0);
        }
    }
}
