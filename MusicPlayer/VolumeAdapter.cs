using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sound.Contracts;

namespace MusicPlayer
{
    public class VolumeAdapter
    {
        public void AdaptVolume<T>(Dictionary<T, IComplexSound> sounds, float volume)
        {
            foreach(IComplexSound sound in sounds.Values)
            {
                sound.SetVolume(volume);
            }
        }
    }
}
