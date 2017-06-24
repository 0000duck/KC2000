using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sound.Contracts;

namespace MusicPlayer.Provider
{
    public class DrumCreator
    {
        public Dictionary<DrumNotes, IComplexSound> CreateBassNotes(ISoundFactory soundFactory, string snareSound)
        {
            Dictionary<DrumNotes, IComplexSound> dictionary = new Dictionary<DrumNotes, IComplexSound>();

            dictionary.Add(DrumNotes.Silence, new Silence());

            dictionary.Add(DrumNotes.Snare, (IComplexSound)soundFactory.LoadSound(snareSound, false));

            return dictionary;
        }
    }
}
