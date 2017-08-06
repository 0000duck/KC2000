using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicPlayer.Songs;

namespace MusicPlayer.Player
{
    public class InstrumentPlayer : IPlayer
    {
        private IPlayer[] _players;
        private int _currentIndex;

        public InstrumentPlayer(Instrument instrument)
        {
            _players = new FragmentPlayerV2[instrument.Elements.Count];

            int index = 0;

            foreach (SongElement element in instrument.Elements)
            {
                _players[index] = new FragmentPlayerV2(element);
                index++;
            }

            _currentIndex = 0;
        }

        public void Play(int milliSeconds)
        {
            if (_players[_currentIndex].IsFinished())
            {
                if (_currentIndex == _players.Count() - 1)
                    return;

                _currentIndex++;
            }

            _players[_currentIndex].Play(milliSeconds);
        }

        public bool IsFinished()
        {
            return _players[_currentIndex].IsFinished() && _currentIndex == _players.Count() - 1;
        }
    }
}
