using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicPlayer.Songs;

namespace MusicPlayer
{
    public class Song
    {
        public List<BassNoteCollection> BassLine { set; get; }

        public List<MelodyNoteCollection> Guitar { set; get; }

        public List<MelodyNoteCollection> SecondGuitar { set; get; }

        public List<MelodyNoteCollection> PitchedGuitar { set; get; }

        public List<DrumCollection> Drums { set; get; }
    }
}
