using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sound.Contracts;
using FrameworkContracts;

namespace WindowsSound
{
    public class MediaPlayerFactory : ISoundFactory
    {
        ISound ISoundFactory.LoadSound(string fileName, bool listenerDependent, bool looped)
        {
            return new WindowsMediaPlayer(fileName);
        }

        void ISoundFactory.DeleteSound(ISound sound)
        {
            ((IComplexSound)sound).Delete();
        }
    }
}
