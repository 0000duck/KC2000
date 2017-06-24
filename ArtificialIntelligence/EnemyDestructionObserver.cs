using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;

namespace ArtificialIntelligence
{
    public class EnemyDestructionObserver : IEnemyDestructionObserver
    {
        private IEnemyDestructionObserver _enemyDestructionObserver;
        private bool _destroyed;

        public EnemyDestructionObserver(IEnemyDestructionObserver enemyDestructionObserver)
        {
            _enemyDestructionObserver = enemyDestructionObserver;
        }

        void IEnemyDestructionObserver.EnemyDestroyed()
        {
            if (_destroyed)
                return;

            _enemyDestructionObserver.EnemyDestroyed();
            _destroyed = true;
        }
    }
}
