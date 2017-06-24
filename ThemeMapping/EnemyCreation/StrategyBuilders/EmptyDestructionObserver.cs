using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;

namespace ThemeMapping.EnemyCreation.StrategyBuilders
{
    class EmptyDestructionObserver : IEnemyDestructionObserver
    {
        void IEnemyDestructionObserver.EnemyDestroyed()
        {

        }
    }
}
