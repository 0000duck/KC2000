using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs
{
    public class BassNoteCollection
    {
        public int MilliSecondsPerSound { set; get; }

        public int MilliSecondsPerBeat { set; get; }

        public List<BassNotes> BassLine { set; get; }

        public BassNoteCollection()
        {
            MilliSecondsPerSound = 120;
            MilliSecondsPerBeat = 180;
        } 
    }
}
