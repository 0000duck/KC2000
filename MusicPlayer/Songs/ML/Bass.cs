using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.ML
{
    public class Bass : Song
   {
        public Bass()
        {
            BassLine = new List<BassNoteCollection>();

            BassNoteCollection raff = new BassNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.Silence,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.Silence,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.Silence,BassNotes.E0,BassNotes.Silence,
                }
            };

            BassLine.Add(raff);
            BassLine.Add(raff);
        }
    }
}
