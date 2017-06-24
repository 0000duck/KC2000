using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Render.Contracts;

namespace KillCommando.Configuration
{
    public class Configuration
    {
        public Resolution Resolution { set; get; }
        public int DepthBuffer { set;get; }
        public bool LevelEditor { set;get; }
        public int? StartLevelId { set; get; }
        public int MusicVolume { set; get; }
        public int SoundVolume { set; get; }
        public bool ScreenShotMaker { set; get; }
        public bool FrameCounter { set; get; }
        public int MouseSensitivity { set; get; }
        public bool InvertMouse { get; set; }
    }
}
