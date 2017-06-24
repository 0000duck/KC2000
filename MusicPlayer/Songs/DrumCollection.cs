using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs
{
    public class DrumCollection
    {
        public int MilliSecondsPerSound { set; get; }

        public int MilliSecondsPerBeat { set; get; }

        public List<DrumNotes> Melody { set; get; }

        public DrumCollection()
        {
            MilliSecondsPerSound = 120;
            MilliSecondsPerBeat = 180;
        } 
    }
}
