using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using FrameworkContracts;
using BaseTypes;

namespace FrameworkImplementations
{
    public class LevelShutDown : IEnemiesEliminatedObserver, IExecuteble
    {
        private bool _allEnemiesKilled;
        private PercentFader _delayTimer;
        private Action _switchToNextLevel;
        private bool _switchedToNextLevel;
        private IFader _fader;

        public LevelShutDown(double delayInSeconds, Action switchToNextLevel, IFader fader)
        {
            _delayTimer = new PercentFader(delayInSeconds);

            _switchToNextLevel = switchToNextLevel;
            _fader = fader;
        }

        void IEnemiesEliminatedObserver.AllEnemiesAreEliminated()
        {
            _allEnemiesKilled = true;
            _fader.FadeOut();
            _delayTimer.Start();
        }

        void IExecuteble.ExecuteLogic()
        {
            if (!_allEnemiesKilled)
                return;

            if (_switchedToNextLevel)
                return;

            _delayTimer.GetPercent();

            if (!_delayTimer.IsFinished())
                return;

            _switchToNextLevel();

            _switchedToNextLevel = true;
        }
    }
}
