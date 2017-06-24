using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class Song11: Song
    {
        public Song11()
        {
            BassNoteCollection bass1 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 370,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,
                    BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E5,BassNotes.E5,BassNotes.E5,BassNotes.E5,BassNotes.E5,BassNotes.E5,BassNotes.E5,BassNotes.E5,BassNotes.E5,BassNotes.E5,BassNotes.E5,BassNotes.E5,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                }
            };

            BassNoteCollection bass2 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 370,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,
                    BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,
                    BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,
                    BassNotes.E5,BassNotes.E5,BassNotes.E5,BassNotes.E5,BassNotes.E5,BassNotes.E5,
                    BassNotes.E5,BassNotes.E5,BassNotes.E5,BassNotes.E5,BassNotes.E5,BassNotes.E5,
                    BassNotes.E5,BassNotes.E5,BassNotes.E5,BassNotes.E5,
                    BassNotes.E8,BassNotes.E8,BassNotes.E8,BassNotes.E8,BassNotes.E8,BassNotes.E8,
                    BassNotes.E8,BassNotes.E8,BassNotes.E8,BassNotes.E8,BassNotes.E8,BassNotes.E8,
                    BassNotes.E8,BassNotes.E8,BassNotes.E8,BassNotes.E8,
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                }
            };
         

            BassNoteCollection bassBreak = new BassNoteCollection
            {
                MilliSecondsPerBeat = 740 * (32),
                MilliSecondsPerSound = 120 ,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.Silence
                }
            };


            MelodyNoteCollection part1 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 740,
                MilliSecondsPerSound = 120,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E9,MelodyNotes.E9,MelodyNotes.E9,MelodyNotes.E9,MelodyNotes.E9,MelodyNotes.E9,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E10,MelodyNotes.E10,MelodyNotes.E10,MelodyNotes.E10,MelodyNotes.E10,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E12,MelodyNotes.E12,MelodyNotes.E12,MelodyNotes.E12,MelodyNotes.E12,MelodyNotes.E12,
                    MelodyNotes.E7,MelodyNotes.E7,MelodyNotes.E7,MelodyNotes.E9,MelodyNotes.E9,MelodyNotes.E9,MelodyNotes.E9,MelodyNotes.E9,
                }
            };

            MelodyNoteCollection part2 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 740,
                MilliSecondsPerSound = 120,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.H3,MelodyNotes.H3,MelodyNotes.H3,MelodyNotes.H3,MelodyNotes.H3,MelodyNotes.H3,
                    MelodyNotes.H0,MelodyNotes.H0,
                    MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,
                    MelodyNotes.H0,MelodyNotes.H0,
                    MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,
                     MelodyNotes.E0,MelodyNotes.E0, 
                     MelodyNotes.E0,MelodyNotes.E0, MelodyNotes.E0,MelodyNotes.E0, MelodyNotes.E0,MelodyNotes.E0,
                     MelodyNotes.E0,MelodyNotes.E0,//MelodyNotes.E0,MelodyNotes.E0, MelodyNotes.E0,MelodyNotes.E0,
                     MelodyNotes.E0,MelodyNotes.E0, MelodyNotes.E0,MelodyNotes.E0, MelodyNotes.E0,MelodyNotes.E0,
                }
            };

            Guitar = new List<MelodyNoteCollection>();

            Guitar.Add(part1);
            Guitar.Add(part1);
            Guitar.Add(part1);

            Guitar.Add(part2);


            BassLine = new List<BassNoteCollection>();

            //strophe
            BassLine.Add(bassBreak);
            BassLine.Add(bass1);
            BassLine.Add(bass1);

            BassLine.Add(bass2);
        }
    }
}
