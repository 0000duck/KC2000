using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteraction;
using GameInteractionContracts;
using BaseTypes;
using ArtificialIntelligence.Contracts;

namespace ThemeMapping.Contracts
{
    public interface ICharacterRemoverBuilder
    {
        ICharacterRemover CreateCharacterRemover(IElementCreator elementCreator, IWorldElementProvider simpleSoldierProvider, IDestructibleBodyProvider destructibleBodyProvider, IEnemyDestructionObserver enemyDestructionObserver);
    }
}
