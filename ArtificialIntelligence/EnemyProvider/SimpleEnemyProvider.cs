using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.EnemyProvider
{
    public class SimpleEnemyProvider : IWorldElementProvider
    {
        private IWorldElement _enemy;

        IWorldElement IWorldElementProvider.GetElement()
        {
            return _enemy;
        }

        public void SetEnemy(IWorldElement enemy)
        {
            _enemy = enemy;
        }
    }
}
