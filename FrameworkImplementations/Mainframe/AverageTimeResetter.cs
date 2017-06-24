using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace FrameworkImplementations.Mainframe
{
    public class AverageTimeResetter : IGameModeObserver
    {
        private IAverageFrameTimeCalculator _averageFrameTimeCalculator;

        public AverageTimeResetter(IAverageFrameTimeCalculator averageFrameTimeCalculator)
        {
            _averageFrameTimeCalculator = averageFrameTimeCalculator;
        }

        void IGameModeObserver.NotifyGameModeChange(GameMode nextGameMode)
        {
            if (nextGameMode == GameMode.Game || nextGameMode == GameMode.Menu)
                _averageFrameTimeCalculator.Reset();
        }
    }
}
