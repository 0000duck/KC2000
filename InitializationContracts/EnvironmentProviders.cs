using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Render.Contracts;

namespace InitializationContracts
{
    public class EnvironmentProviders
    {
        public IFloorProvider FloorProvider { set; get; }

        public ISkylineElementProvider SkylineElementProvider { set; get; }

        public IBackgroundColorProvider BackgroundColorProvider { set; get; }

        public ILightCollectionProvider LightCollectionProvider { set; get; }
    }
}
