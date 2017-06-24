using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs
{
    public class MelodyNoteCollection
    {
        public int MilliSecondsPerSound { set; get; }

        public int MilliSecondsPerBeat { set; get; }

        public List<MelodyNotes> Melody { set; get; }

        public SoundType? SoundType { set; get; }

        public MelodyNoteCollection()
        {
            MilliSecondsPerSound = 120;
            MilliSecondsPerBeat = 180;
        } 
    }
}
