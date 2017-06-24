using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicPlayer.Songs;

namespace MusicPlayer.Player
{
    public class FragmentPlayerV2
    {
        private SongElement _element;
        private int _currentIndex;
        private int _millisecondsOfCurrentSound;
        private int _millisecondsOfCurrentBeat;
        private bool _finished;

        public FragmentPlayerV2(SongElement element)
        {
            _element = element;

            _currentIndex = -1;
            _millisecondsOfCurrentBeat = 0;
            _millisecondsOfCurrentSound = 0;
        }

        public void Play(int milliSeconds)
        {
            _millisecondsOfCurrentBeat += milliSeconds;
            _millisecondsOfCurrentSound += milliSeconds;

            if (_currentIndex == -1)
            {
                _currentIndex++;
                _element.Sounds[_currentIndex].Play();   
                return;
            }

            if (_millisecondsOfCurrentBeat >= _element.MilliSecondsPerBeat)
            {
                //cancel current sound
                _element.Sounds[_currentIndex].Stop();

                if (_currentIndex == _element.Sounds.Count() - 1)
                    return;

                _millisecondsOfCurrentBeat -= _element.MilliSecondsPerBeat;
                _millisecondsOfCurrentSound -= _element.MilliSecondsPerBeat;
                //_millisecondsOfCurrentBeat = 0;
                //_millisecondsOfCurrentSound = 0;
                _currentIndex++;
                _element.Sounds[_currentIndex].Play();
            }

            if (_millisecondsOfCurrentSound >= _element.MilliSecondsPerSound)
                _element.Sounds[_currentIndex].Stop();
        }

        public bool IsFinished()
        {
            if (_finished)
                return true;

            _finished = _currentIndex == _element.Sounds.Count() - 1 && _millisecondsOfCurrentBeat >= _element.MilliSecondsPerBeat;

            if (_finished)
            {
                _element.Sounds[_currentIndex].Stop();
            }

            return _finished;
        }
    }
}
