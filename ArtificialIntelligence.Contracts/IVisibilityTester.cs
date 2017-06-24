using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using BaseContracts;

namespace ArtificialIntelligence.Contracts
{
    public interface IVisibilityTester
    {
        void StartVisibilityTest(IWorldElement viewingElement, IWorldElement visibilityTestElement, IListProvider<IWorldElement> listProvider);
        bool Testing();
        bool ElementIsVisible();
    }
}
