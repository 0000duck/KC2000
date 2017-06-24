using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace FrameworkImplementations.Mainframe
{
    public class LevelFadeInTriggerer : ILevelLoadObserver
    {
        private ILevelLoadObserver _observer;
        private IFader _fader;

        public LevelFadeInTriggerer(ILevelLoadObserver observer, IFader fader)
        {
            _observer = observer;
            _fader = fader;
        }


        void ILevelLoadObserver.LevelBeginsToLoad()
        {
            _observer.LevelBeginsToLoad();
        }

        void ILevelLoadObserver.LevelIsLoaded()
        {
            _observer.LevelIsLoaded();
            _fader.FadeOut();
        }
    }
}
