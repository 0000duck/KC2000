using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace FrameworkImplementations.Player
{
    public class PlayerDeathObserver : IPlayerDeathObserver
    {
        private Action _reloadLevel;

        public PlayerDeathObserver(Action reloadLevel)
        {
            _reloadLevel = reloadLevel;
        }

        void IPlayerDeathObserver.PlayerGotKilled()
        {
            _reloadLevel();
        }
    }
}
