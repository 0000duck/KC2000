using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using ArtificialIntelligence.Contracts;

namespace ArtificialIntelligence.EnemyProvider
{
    public class HearableEnemyProvider : IWorldElementProvider
    {
        private IWorldElementProvider _enemyProvider;
        private IWorldElementProvider _listenerProvider;
        private ISoundSharer _soundSharer;
        private IUpdateTimer _updateTimer;
        private IWorldElement _enemy;

        public HearableEnemyProvider(IWorldElementProvider enemyProvider, IWorldElementProvider listenerProvider, ISoundSharer soundSharer, IUpdateTimer updateTimer)
        {
            _enemyProvider = enemyProvider;
            _listenerProvider = listenerProvider;
            _soundSharer = soundSharer;
            _updateTimer = updateTimer;
        }

        IWorldElement IWorldElementProvider.GetElement()
        {
            if (!_updateTimer.UpdateIsNecessary())
                return _enemy;

            IWorldElement listener = _listenerProvider.GetElement();

            if(listener == null)
                return _enemy;

            if (_soundSharer.SoundIsNearEnoughToIdentifyPosition(listener.Position))
                _enemy = _enemyProvider.GetElement();
            else
                _enemy = null;

            return _enemy;
        }
    }
}
