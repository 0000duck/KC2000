using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace FrameworkImplementations.Mainframe
{
    public class MainRenderer : IDrawable
    {
        private IGameModeProvider _gameModeProvider;
        private IDrawable _menu;
        private ICamera _camera;
        private ILevelRenderLayerProvider _levelRenderLayerProvider;
        private IDrawable _loadingScreen;

        public MainRenderer(IGameModeProvider gameModeProvider, IDrawable menu, IDrawable loadingScreen, ICamera camera, ILevelRenderLayerProvider levelRenderLayerProvider)
        {
            _gameModeProvider = gameModeProvider;
            _menu = menu;
            _camera = camera;
            _levelRenderLayerProvider = levelRenderLayerProvider;
            _loadingScreen = loadingScreen;
        }

        void IDrawable.Draw()
        {
            switch (_gameModeProvider.GetGameMode())
            {
                case GameMode.Menu:
                    _camera.SetDefaultPerspective();
                    _menu.Draw();
                    break;
                case GameMode.LoadingScreen:
                    _camera.SetDefaultPerspective();
                    _loadingScreen.Draw();
                    break;
                case GameMode.Game:
                    _camera.SetInGamePerspective();
                    _levelRenderLayerProvider.Get3DWorld().Draw();
                    _camera.SetDefaultPerspective();
                    _levelRenderLayerProvider.Get2DSurface().Draw();
                    break;
            }
        }
    }
}
