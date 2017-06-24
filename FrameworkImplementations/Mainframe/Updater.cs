using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using GameInteractionContracts;

namespace FrameworkImplementations.Mainframe
{
    public class Updater : IExecuteble
    {
        private IGameModeProvider _gameModeProvider;
        private IExecuteble _gameLogic;
        private IExecuteble _menuLogic;

        public Updater(IGameModeProvider gameModeProvider, IExecuteble gameLogic, IExecuteble menuLogic)
        {
            _gameModeProvider = gameModeProvider;
            _gameLogic = gameLogic;
            _menuLogic = menuLogic;
        }

        void IExecuteble.ExecuteLogic()
        {
            _gameModeProvider.UpdateGameMode();

            switch (_gameModeProvider.GetGameMode())
            {
                case GameMode.Menu:
                    _menuLogic.ExecuteLogic();
                    break;
                case GameMode.Game:
                    _gameLogic.ExecuteLogic();
                    break;
            }
        }
    }
}
