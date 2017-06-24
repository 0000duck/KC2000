using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Sound.Contracts;
using Render.Contracts;

namespace FrameworkImplementations.Mainframe
{
    public class BackgroundSwitcher : IGameModeObserver
    {
        private ISoundInterrupter _soundInterrupter;
        private IBackgroundColor _menuColor;
        private IBackgroundColor _gameColor;
        private IBackgroundColor _loadColor;
        private IMouseController _mouseController;

        public BackgroundSwitcher(ISoundInterrupter soundInterrupter, IBackgroundColor menuColor, IBackgroundColor gameColor, IBackgroundColor loadColor, IMouseController mouseController)
        {
            _soundInterrupter = soundInterrupter;
            _menuColor = menuColor;
            _gameColor = gameColor;
            _loadColor = loadColor;
            _mouseController = mouseController;
        }

        void IGameModeObserver.NotifyGameModeChange(GameMode nextGameMode)
        {
            switch (nextGameMode)
            {
                case GameMode.Menu:
                    _soundInterrupter.Pause();
                    _menuColor.SetColor();
                    break;
                case GameMode.Game:
                    _soundInterrupter.Continue();
                    _gameColor.SetColor();
                    _mouseController.Reset();
                    break;
                case GameMode.LoadingScreen:
                    _loadColor.SetColor();
                    break;
            }
        }
    }
}
