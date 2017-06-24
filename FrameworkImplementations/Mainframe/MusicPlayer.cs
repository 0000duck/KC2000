using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sound.Contracts;
using FrameworkContracts;

namespace FrameworkImplementations.Mainframe
{
    public class MusicPlayer : IGameModeObserver
    {
        private ISoundFactory _soundFactory;
        private ILevelIdProvider _levelIdProvider;
        private ISongProvider _songProvider;
        private ISound _menuSound;
        private ISound _gameMusic;
        private int? lastLoadedLevelId;
        private bool _levelLoaded;

        public MusicPlayer(ISoundFactory soundFactory, ILevelIdProvider levelIdProvider, ISongProvider songProvider, ISound menuSound)
        {
            _soundFactory = soundFactory;
            _levelIdProvider = levelIdProvider;
            _menuSound = menuSound;
            _songProvider = songProvider;
        }

        void IGameModeObserver.NotifyGameModeChange(GameMode nextGameMode)
        {
            switch (nextGameMode)
            { 
                case GameMode.Menu:
                    if (_gameMusic != null)
                        _gameMusic.Stop();
                    _menuSound.Play(); 
                    break;
                case GameMode.Game:
                    _menuSound.Stop();
                    if (lastLoadedLevelId != _levelIdProvider.GetLevelId() || _levelLoaded)
                    {
                        if (_gameMusic != null)
                            _soundFactory.DeleteSound(_gameMusic);

                        _gameMusic = _soundFactory.LoadSound(_songProvider.GetSongFileName(_levelIdProvider.GetLevelId()), false, true);

                        lastLoadedLevelId = _levelIdProvider.GetLevelId();
                        _levelLoaded = false;
                    }
                    if (_gameMusic != null)
                        _gameMusic.Play();
                    break;
                case GameMode.LoadingScreen:
                    _levelLoaded = true;
                    break;
            }
        }
    }
}
