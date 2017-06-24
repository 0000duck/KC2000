using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class SongTwo : Song
    {
        public SongTwo()
        {
            #region bassnotes
            BassNoteCollection bassPartOne = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E3,BassNotes.E3,BassNotes.E5,BassNotes.E5,
                    BassNotes.E8,BassNotes.E7,BassNotes.E6,

                    BassNotes.E5,BassNotes.E5,BassNotes.E5,BassNotes.E5,
                    BassNotes.E5,BassNotes.E5,BassNotes.E5,BassNotes.E5,
                    BassNotes.E7,BassNotes.E7,BassNotes.E8,BassNotes.E8,
                    BassNotes.E7,BassNotes.E5,BassNotes.E3,
                }
            };
            BassNoteCollection bassPartTwo = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E8,BassNotes.E7,BassNotes.E5,
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                    BassNotes.E7,BassNotes.E5,BassNotes.E3,
                }
            };
            BassNoteCollection bassPartThree = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E3,BassNotes.E3,
                    BassNotes.E5,BassNotes.E5,BassNotes.E7,
                    BassNotes.E0,BassNotes.E0,BassNotes.E3,BassNotes.E3,
                    BassNotes.E5,BassNotes.E5,BassNotes.E8
                }
            };

            BassLine = new List<BassNoteCollection>();

            //BassLine.Add(bassPartOne);
            BassLine.Add(bassPartOne);
            BassLine.Add(bassPartTwo);
            BassLine.Add(bassPartTwo);
            BassLine.Add(bassPartThree);
            BassLine.Add(bassPartThree);
            BassLine.Add(bassPartOne);
            BassLine.Add(bassPartOne);
            BassLine.Add(bassPartTwo);
            BassLine.Add(bassPartTwo);
            BassLine.Add(bassPartThree);
            BassLine.Add(bassPartThree);
            #endregion

        }
    }
}
