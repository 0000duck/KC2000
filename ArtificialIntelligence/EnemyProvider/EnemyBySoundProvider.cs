using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.EnemyProvider
{
    public class EnemyBySoundProvider : IWorldElementProvider
    {
        private IWorldElementProvider _enemyProvider;
        IWorldElementProvider _listenerProvider;
        private ISoundSharer _enemySoundSharer;
        private IUpdateTimer _updateTimer;
        private bool _soundOfEnemyCanBeHeared;

        public EnemyBySoundProvider(IWorldElementProvider enemyProvider, IWorldElementProvider listenerProvider, ISoundSharer enemySoundSharer, IUpdateTimer updateTimer)
        {
            _enemyProvider = enemyProvider;
            _listenerProvider = listenerProvider;
            _enemySoundSharer = enemySoundSharer;
            _updateTimer = updateTimer;
            _soundOfEnemyCanBeHeared = false;
        }

        IWorldElement IWorldElementProvider.GetElement()
        {
            if (_updateTimer.UpdateIsNecessary())
            {
                _soundOfEnemyCanBeHeared = _enemySoundSharer.SoundCanBeHeared(_listenerProvider.GetElement().Position);
            }

            return _soundOfEnemyCanBeHeared ? _enemyProvider.GetElement() : null;
        }
    }
}
