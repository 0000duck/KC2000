using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using BaseContracts;

namespace GameInteraction
{
    public class ElementRenderComposition : IExecuteble
    {
        private IListProvider<IWorldElement> _allElementsProvider;

        public ElementRenderComposition(IListProvider<IWorldElement> allElementsProvider)
        {
            _allElementsProvider = allElementsProvider;
        }

        void IExecuteble.ExecuteLogic()
        {
            foreach (IWorldElement element in _allElementsProvider.GetList())
            {
                if (element is IAnimatable)
                    ((IAnimatable)element).Render();
            }
        }
    }
}
