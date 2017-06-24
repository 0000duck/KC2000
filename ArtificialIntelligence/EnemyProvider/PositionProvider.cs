using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace ArtificialIntelligence.EnemyProvider
{
    public class PositionProvider : IPositionProvider
    {
        private IWorldElementProvider _enemyProvider;

        public PositionProvider(IWorldElementProvider enemyProvider)
        {
            _enemyProvider = enemyProvider;
        }

        Position3D IPositionProvider.GetPosition()
        {
            IWorldElement enemy = _enemyProvider.GetElement();

            if (enemy == null)
                return null;

            return enemy.Position;
        }
    }
}
