using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using IOInterface;
using Render.Contracts;
using GameInteractionContracts;

namespace InitializationContracts
{
    public class LevelUnit
    {
        public int Id { set; get; }

        public IBackgroundColor Background { set; get; }

        public IDrawable World3D { get; set; }

        public IDrawable InfoSurface2D { get; set; }

        public IExecuteble GameContent { get; set; }

        public List<IElement> Elements { get; set; }

        public IElementCreator ElementCreator { get; set; }
    }
}
