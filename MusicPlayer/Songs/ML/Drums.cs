using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.ML
{
    public class Drums : Song
   {
        public Drums()
        {
            BassLine = new List<BassNoteCollection>();

            BassNoteCollection drum = new BassNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 60,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A10,BassNotes.Silence,BassNotes.Silence,BassNotes.A10,BassNotes.Silence,BassNotes.Silence,BassNotes.A10,BassNotes.Silence,
                    BassNotes.A10,BassNotes.Silence,BassNotes.Silence,BassNotes.A10,BassNotes.Silence,BassNotes.Silence,BassNotes.A10,
                    BassNotes.A10,BassNotes.Silence,BassNotes.A10,BassNotes.Silence,BassNotes.Silence,BassNotes.Silence,BassNotes.A10,
                }
            };

            BassLine.Add(drum);
            BassLine.Add(drum);
            //BassLine.Add(drum);
            //BassLine.Add(drum);
            //BassLine.Add(drum);
        }
    }
}
