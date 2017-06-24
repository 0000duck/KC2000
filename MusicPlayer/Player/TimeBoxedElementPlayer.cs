using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicPlayer.Songs;

namespace MusicPlayer.Player
{
    public class TimeBoxedElementPlayer
    {
        private SongElement _element;
        private int _currentIndex;
        private int _millisecondsOfCurrentSound;

        public TimeBoxedElementPlayer(SongElement element)
        {
            _element = element;

            _currentIndex = 0;
            _millisecondsOfCurrentSound = _element.MilliSecondsPerSound;
        }

        public void Play()
        {
            if (_millisecondsOfCurrentSound == _element.MilliSecondsPerSound)
            {
                if (_currentIndex == _element.Sounds.Count() - 1)
                    return;

                //cancel current sound
                if (_currentIndex > 0)
                {
                    _element.Sounds[_currentIndex - 1].Stop();
                }

                _millisecondsOfCurrentSound = 0;
                _element.Sounds[_currentIndex].Play();
                _currentIndex++;
            }

            _millisecondsOfCurrentSound++;
        }

        public bool IsFinished()
        {
            return _currentIndex == _element.Sounds.Count() - 1 && _millisecondsOfCurrentSound == _element.MilliSecondsPerSound;
        }
    }
}
