using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicPlayer.Songs;

namespace MusicPlayer.Player
{
    public class FragmentPlayer
     {
        private SongElement _element;
        private int _currentIndex;
        private int _millisecondsOfCurrentSound;
        private int _millisecondsOfCurrentBeat;

        public FragmentPlayer(SongElement element)
        {
            _element = element;

            _currentIndex = -1;
            _millisecondsOfCurrentBeat = _element.MilliSecondsPerBeat;
            _millisecondsOfCurrentSound = 0;
        }

        public void Play(int milliSeconds)
        {
            if (_millisecondsOfCurrentBeat == _element.MilliSecondsPerBeat)
            {
                //cancel current sound
                if (_currentIndex > 0)
                {
                    _element.Sounds[_currentIndex].Stop();
                }

                if (_currentIndex == _element.Sounds.Count() - 1)
                    return;

                _millisecondsOfCurrentBeat = 0;
                _millisecondsOfCurrentSound = 0;
                _currentIndex++;
                _element.Sounds[_currentIndex].Play();
            }

            if (_millisecondsOfCurrentSound == _element.MilliSecondsPerSound && _currentIndex >= 0)
                _element.Sounds[_currentIndex].Stop();

            _millisecondsOfCurrentBeat += milliSeconds;
            _millisecondsOfCurrentSound+= milliSeconds;
        }

        public bool IsFinished()
        {
            bool finished = _currentIndex == _element.Sounds.Count() - 1 && _millisecondsOfCurrentBeat == _element.MilliSecondsPerBeat;
            
            if(finished)
            {
                _element.Sounds[_currentIndex].Stop();
            }
            
            return finished;
        }
    }
}
