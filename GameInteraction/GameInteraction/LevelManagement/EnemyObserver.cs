using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;

namespace GameInteraction.LevelManagement
{
    public class EnemyObserver : IEnemyCreationObserver, IEnemyDestructionObserver
    {
        private int _createdEnemyCounter;
        private int _destroyedEnemyCounter;
        private IEnemiesEliminatedObserver _enemiesEliminatedObserver;

        public EnemyObserver(IEnemiesEliminatedObserver enemiesEliminatedObserver)
        {
            _enemiesEliminatedObserver = enemiesEliminatedObserver;
        }

        void IEnemyCreationObserver.EnemyCreated()
        {
            _createdEnemyCounter++;
        }

        void IEnemyDestructionObserver.EnemyDestroyed()
        {
            _destroyedEnemyCounter++;
            CheckForRespawnCredit();
        }

        private void CheckForRespawnCredit()
        {
            if (_destroyedEnemyCounter == _createdEnemyCounter)
                _enemiesEliminatedObserver.AllEnemiesAreEliminated();
        }
    }
}
