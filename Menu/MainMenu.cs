using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InitializationContracts;
using FrameworkContracts;
using Render.Contracts;
using GameInteractionContracts;
using Profile.Contracts;

namespace Menu
{
    public class MainMenu : MenuPage, IExecuteble, IGameModeObserver
    {
        private Action ClickedExit { set; get; }
        private IMouseController _mouseController;
        private IPressedKeyDetector _pressedKeyDetector;
        private IProfileLoader _profileLoader;

        private bool _addedRestartText;
        private IMenuElement _continue;
        private ITextFactory _textFactory;
        private Action _continueGame;

        public MainMenu(IRectangle mouse, ITextFactory textFactory, IScreen screen, Action clickedExit,
            IMouseController mouseController, IPressedKeyDetector pressedKeyDetector, IProfileLoader profileLoader, IGameStartInitializer gameStartInitializer, Action continueGame)
            : base(mouse)
        {
            ClickedExit = clickedExit;
            _profileLoader = profileLoader;
            _textFactory = textFactory;
            _continueGame = continueGame;

            MenuElements.Add(new MenuElement(textFactory.CreateText(0, 0.7, "EDIT")), () =>
            {
                gameStartInitializer.SetSkillLevel(SkillLevel.Easy);
                gameStartInitializer.Start();

            });
            MenuElements.Add(new MenuElement(textFactory.CreateText(0, 0.4, "QUIT")), ClickedOKQuit);



            _mouseController = mouseController;
            _pressedKeyDetector = pressedKeyDetector;

            SubPages.Add(new EpisodeSelection(mouse, textFactory, gameStartInitializer, SubPageIsFinished));
        }

        private void ClickedOKQuit()
        {
            ClickedExit();
            PlayClickSound();
        }

        void IExecuteble.ExecuteLogic()
        {
            SetMouseState(_mouseController.GetMouseEvents(), _pressedKeyDetector);
        }

        void IGameModeObserver.NotifyGameModeChange(GameMode nextGameMode)
        {
            switch (nextGameMode)
            {
                case GameMode.Game:
                    if (!_addedRestartText && _profileLoader.LoadProfile().NextLevel.HasValue)
                    {
                        if (_continue != null && MenuElements.ContainsKey(_continue))
                            MenuElements.Remove(_continue);
                        MenuElements.Add(new MenuElement(_textFactory.CreateText(0, 0.55, "RESTART")), _continueGame);
                        _addedRestartText = true;
                    }
                    break;
            }
        }
    }
}
