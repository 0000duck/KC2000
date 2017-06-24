using System;
using System.Drawing;
using OpenTK;
using Sound;
using OpenTK.Audio;
using System.Threading;
using FrameworkImplementations.Mainframe;
using System.Collections.Generic;
using KillCommando.Implementations.Providers;
using Render;
using BaseTypes;
using OpenTKPortation.Implementations;
using GameInteractionContracts;
using OpenTKPortation;
using System.Linq;

namespace KillCommando
{
    class Program
    {
        private static bool run = true;

        [STAThread]
        public static void Main()
        {
            AudioContext context = null;

            Configuration.Configuration config = new Configuration.ConfigurationReader().ReadConfiguration();
            if (config.Resolution == null)
            {
                config.Resolution = new ResolutionProvider().GetMaxResolution();
            }

            using (GameWindowInitializer game = new GameWindowInitializer(config))
            {
                if (!config.LevelEditor)
                {   
                    context = new AudioContext(AudioContext.DefaultDevice);
                }

                Screen screen = new Screen(game, new ResolutionProvider());
                game.Init(screen);
                new Render.Initializer().Initialize();

                FrameTimeProvider timeProvider = new FrameTimeProvider();
                ScreenClearer screenClearer = new ScreenClearer();
                MouseController mouseControllerMenu = new MouseController(game.Mouse, screen, config.InvertMouse);
                PressedKeyDetector pressedKeyDetector = new PressedKeyDetector(game.Keyboard);

                IExecuteble workflow = new WorkFlowInitializer().InitWorkFlow(
                    mouseControllerMenu,
                    pressedKeyDetector, 
                    config,
                    () => { run = false; }, 
                    MusicDictionaryProvider.FullVersionSongs, 
                    LevelIdListProvider.ListFullVersion, 
                    screen,
                    () => { game.SwapBuffers(); screenClearer.CleanScreen(); });

                while (run)
                {
                    game.ProcessEvents();
                    TimeAndSpeedManager.AddGameTimeInSeconds(timeProvider.GetTimeInSecondsSinceLastFrame() * 1.3);
                    screenClearer.CleanScreen();
                    workflow.ExecuteLogic();
                    game.SwapBuffers();
                }

                if (context != null)
                    context.Dispose();

                game.Exit();
            }
        }
    }
}