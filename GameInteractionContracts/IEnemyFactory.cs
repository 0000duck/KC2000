using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using IOInterface;
using BaseContracts;

namespace GameInteractionContracts
{
    public interface IEnemyFactory
    {
        IWorldElement CreateEnemy(IElement element, IWorldElementProvider playerProvider, IListProvider<IWorldElement> listProvider, IElementCreator elementCreator);
    }
}
