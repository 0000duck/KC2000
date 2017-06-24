using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sound.Contracts;

namespace MusicPlayer.Songs
{
    public class SongElement
    {
        public IComplexSound[] Sounds { set; get; }

        public int MilliSecondsPerSound { set; get; }

        public int MilliSecondsPerBeat { set; get; }
    }
}
