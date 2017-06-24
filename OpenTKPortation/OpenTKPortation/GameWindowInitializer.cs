using OpenTK;
using Render.Contracts;
using OpenTK.Graphics;

namespace KillCommando
{
    public class GameWindowInitializer : GameWindow
    {
        private IScreen _screen;

        public GameWindowInitializer(Configuration.Configuration configuration)
            : base(configuration.Resolution.X, configuration.Resolution.Y,
            new GraphicsMode(new ColorFormat(8, 8, 8, 8), configuration.DepthBuffer), "...KILL COMMANDO", GameWindowFlags.Fullscreen)
        {
            CursorVisible = false;
            WindowBorder = OpenTK.WindowBorder.Hidden;
            VSync = VSyncMode.Off;
        }

        public void Init(IScreen screen)
        {
            _screen = screen;

            Resize += (sender, e) =>
            {
                ResizeScreen();
            };

            ResizeScreen();
        }

        private void ResizeScreen()
        {
            _screen.ChangeResolution(new Resolution { X = Size.Width, Y = Size.Height });
        }
    }
}
