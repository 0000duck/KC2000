using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillCommando.Configuration
{
    public class ConfigurationReader
    {
        public Configuration ReadConfiguration()
        {
            Configuration configuration = new Configuration();

            configuration.LevelEditor = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["LevelEditor"]);
            
            int levelId;
            if (int.TryParse(System.Configuration.ConfigurationManager.AppSettings["LevelToEdit"], out levelId))
                configuration.StartLevelId = levelId;

            configuration.DepthBuffer = int.Parse(System.Configuration.ConfigurationManager.AppSettings["DepthBuffer"]);
            int resolutionX = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ResolutionX"]);
            int resolutionY = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ResolutionY"]);
            configuration.MusicVolume = int.Parse(System.Configuration.ConfigurationManager.AppSettings["MusicVolume"]);
            configuration.SoundVolume = int.Parse(System.Configuration.ConfigurationManager.AppSettings["SoundVolume"]);
            configuration.ScreenShotMaker = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["ScreenShotMaker"]);
            configuration.FrameCounter = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["FrameCounter"]);
            configuration.MouseSensitivity = int.Parse(System.Configuration.ConfigurationManager.AppSettings["MouseSensitivity"]);
            configuration.InvertMouse = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["InvertMouse"]);

            if (resolutionX > 0 && resolutionY > 0)
                configuration.Resolution = new Render.Contracts.Resolution { X = resolutionX, Y = resolutionY };
            if (configuration.MusicVolume > 100)
                configuration.MusicVolume = 100;
            if (configuration.MusicVolume < 0)
                configuration.MusicVolume = 0;
            if (configuration.SoundVolume > 100)
                configuration.SoundVolume = 100;
            if (configuration.SoundVolume < 0)
                configuration.SoundVolume = 0;

            if (configuration.MouseSensitivity < 1)
                configuration.MouseSensitivity = 1;
            if (configuration.MouseSensitivity > 30)
                configuration.MouseSensitivity = 30;

            return configuration;
        }
    }
}
