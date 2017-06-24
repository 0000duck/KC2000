using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace FrameworkImplementations.Mainframe
{
    public class GameModeProvider : IGameModeProvider, ILevelLoadObserver
    {
        private IKeyPressedOnceDetector _pressedEscapeDetector;
        private IList<IGameModeObserver> _observers;
        private GameMode _status;
        private bool _gamePaused;

        public GameModeProvider(IKeyPressedOnceDetector pressedEscapeDetector)
        {
            _pressedEscapeDetector = pressedEscapeDetector;
            _observers = new List<IGameModeObserver>();
        }

        public void AddObserver(IGameModeObserver observer)
        {
            _observers.Add(observer);
        }

        GameMode IGameModeProvider.GetGameMode()
        {
            return _status;
        }

        void IGameModeProvider.UpdateGameMode()
        {
            switch (_status)
            {
                case GameMode.Undefined:
                    _status = GameMode.Menu;
                    NotifyMode();
                    return;
                case GameMode.Menu:
                    if (_gamePaused)
                    {
                        if (_pressedEscapeDetector.KeyWasPressedOnce())
                        {
                            _gamePaused = false;
                            _status = GameMode.Game;
                            NotifyMode();
                        }
                    }
                    return;
                case GameMode.LoadingScreen:

                    return;
                case GameMode.Game:
                    if (_pressedEscapeDetector.KeyWasPressedOnce())
                    {
                        _gamePaused = true;
                        _status = GameMode.Menu;
                        NotifyMode();
                    }
                    return;
            }
        }

        private void NotifyMode()
        {
            foreach (IGameModeObserver observer in _observers)
                observer.NotifyGameModeChange(_status);
        }

        void ILevelLoadObserver.LevelBeginsToLoad()
        {
            _status = GameMode.LoadingScreen;
            NotifyMode();
        }

        void ILevelLoadObserver.LevelIsLoaded()
        {
            _status = GameMode.Game;
            NotifyMode();
        }

        public void Reset()
        {
            _gamePaused = false;
            _status = GameMode.Menu;
            NotifyMode();
        }
    }
}
