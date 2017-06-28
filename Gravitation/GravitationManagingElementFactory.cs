using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using IOInterface;
using BaseTypes;

namespace Gravity
{
    public class GravitationManagingElementFactory : IElementFactory, IExecuteble
    {
        private IElementFactory _factory;
        private IGravitationCalculator _gravitationCalculator;
        private Dictionary<IWorldElement, GravitationStatus> _gravitationElements = new Dictionary<IWorldElement, GravitationStatus>();

        public GravitationManagingElementFactory(IElementFactory factory, IGravitationCalculator gravitationCalculator)
        {
            _factory = factory;
            _gravitationCalculator = gravitationCalculator;
        }

        IWorldElement IElementFactory.CreateNewElement(IElement element)
        {
            IWorldElement worldElement = _factory.CreateNewElement(element);

            return worldElement;
        }

        void IElementFactory.DeleteElement(IWorldElement element)
        {
            if (_gravitationElements.Keys.Contains(element))
                _gravitationElements.Remove(element);

            _factory.DeleteElement(element);
        }

        void IExecuteble.ExecuteLogic()
        {
            foreach(IWorldElement key in _gravitationElements.Keys)
            {
                _gravitationCalculator.TriggerGravitation(key, _gravitationElements[key]);
            }
        }
    }
}
