using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseContracts;
using BaseTypes;

namespace GameInteraction
{
    public class ElementLogicComposition : IExecuteble
    {
        private IListProvider<IWorldElement> _allElementsProvider;

        public ElementLogicComposition(IListProvider<IWorldElement> allElementsProvider)
        {
            _allElementsProvider = allElementsProvider;
        }

        void IExecuteble.ExecuteLogic()
        {
            foreach (IWorldElement element in _allElementsProvider.GetList())
            {
                if (element is IExecuteble)
                    (element as IExecuteble).ExecuteLogic();
            }
        }
    }
}
