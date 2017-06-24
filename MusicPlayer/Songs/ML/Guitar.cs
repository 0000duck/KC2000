using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.ML
{
    public class Guitar : Song
    {
        public Guitar()
        {
            MelodyNoteCollection part1 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 150,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.E6,MelodyNotes.E6,MelodyNotes.Silence
                }
            };

            MelodyNoteCollection part1H = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 150,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.H7,MelodyNotes.Silence,MelodyNotes.H7,MelodyNotes.Silence,MelodyNotes.H7,MelodyNotes.Silence,MelodyNotes.H8,MelodyNotes.H8,MelodyNotes.Silence
                }
            };
            MelodyNoteCollection part2 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 150,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E8,MelodyNotes.Silence,MelodyNotes.E8,MelodyNotes.Silence,MelodyNotes.E7,MelodyNotes.Silence,MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.Silence
                }
            };

            MelodyNoteCollection part2H = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 150,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.H10,MelodyNotes.Silence,MelodyNotes.H10,MelodyNotes.Silence,MelodyNotes.H9,MelodyNotes.Silence,MelodyNotes.H8,MelodyNotes.H7,MelodyNotes.Silence
                }
            };

            MelodyNoteCollection part3 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 150,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E6,MelodyNotes.E6,MelodyNotes.E4,MelodyNotes.E4,MelodyNotes.E4,
                    MelodyNotes.E6,MelodyNotes.E6,MelodyNotes.E4,MelodyNotes.E4,MelodyNotes.E4,MelodyNotes.E4,MelodyNotes.E4,MelodyNotes.E4,
                    MelodyNotes.E6,MelodyNotes.E6,MelodyNotes.E4,MelodyNotes.E4,MelodyNotes.E4,
                    MelodyNotes.E6,MelodyNotes.E6,MelodyNotes.E4,MelodyNotes.E4,MelodyNotes.E4,MelodyNotes.E4,MelodyNotes.E4,MelodyNotes.E4,
                }
            };

            MelodyNoteCollection part3H = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 150,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.H8,MelodyNotes.H8,MelodyNotes.H6,MelodyNotes.H6,MelodyNotes.H6,
                    MelodyNotes.H8,MelodyNotes.H8,MelodyNotes.H6,MelodyNotes.H6,MelodyNotes.H6,MelodyNotes.H6,MelodyNotes.H6,MelodyNotes.H6,
                    MelodyNotes.H8,MelodyNotes.H8,MelodyNotes.H6,MelodyNotes.H6,MelodyNotes.H6,
                    MelodyNotes.H8,MelodyNotes.H8,MelodyNotes.H6,MelodyNotes.H6,MelodyNotes.H6,MelodyNotes.H6,MelodyNotes.H6,MelodyNotes.H6,
                }
            };

            MelodyNoteCollection part4 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 120,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E2,MelodyNotes.E7,MelodyNotes.Silence,MelodyNotes.H6,MelodyNotes.Silence,MelodyNotes.G5,MelodyNotes.E2,
                    MelodyNotes.H8,MelodyNotes.E10,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.G8,MelodyNotes.E3,MelodyNotes.Silence,MelodyNotes.E8,MelodyNotes.Silence,MelodyNotes.E9,MelodyNotes.E10,MelodyNotes.E11,
                    MelodyNotes.E2,MelodyNotes.E9,MelodyNotes.Silence,MelodyNotes.H2,MelodyNotes.E2,MelodyNotes.E7,MelodyNotes.Silence,MelodyNotes.H6,MelodyNotes.Silence,MelodyNotes.G5,MelodyNotes.E2,MelodyNotes.Silence,MelodyNotes.G5,MelodyNotes.E2,
                }
            };
            //MelodyNoteCollection part4 = new MelodyNoteCollection
            //{
            //    MilliSecondsPerBeat = 120,
            //    MilliSecondsPerSound = 100,
            //    Melody = new List<MelodyNotes> 
            //    {
            //        MelodyNotes.E2,MelodyNotes.E7,MelodyNotes.Silence,MelodyNotes.H6,MelodyNotes.Silence,MelodyNotes.G5,MelodyNotes.E2,
            //        MelodyNotes.H8,MelodyNotes.E10,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.G8,MelodyNotes.E3,MelodyNotes.Silence,MelodyNotes.E8,MelodyNotes.Silence,MelodyNotes.E9,MelodyNotes.E10,MelodyNotes.E11,
            //        MelodyNotes.E2,MelodyNotes.E9,MelodyNotes.Silence,MelodyNotes.H2,MelodyNotes.E2,MelodyNotes.E7,MelodyNotes.Silence,MelodyNotes.H6,MelodyNotes.Silence,MelodyNotes.G5,MelodyNotes.E2,MelodyNotes.Silence,MelodyNotes.G5,MelodyNotes.E2,
            //    }
            //};
            Guitar = new List<MelodyNoteCollection>();
            PitchedGuitar = new List<MelodyNoteCollection>();

            Guitar.Add(part1);
            Guitar.Add(part1);
            Guitar.Add(part2);

            Guitar.Add(part1);
            Guitar.Add(part1);
            Guitar.Add(part2);

            Guitar.Add(part3);
            Guitar.Add(part4);

            PitchedGuitar.Add(part1H);
            PitchedGuitar.Add(part1H);
            PitchedGuitar.Add(part2H);

            PitchedGuitar.Add(part1H);
            PitchedGuitar.Add(part1H);
            PitchedGuitar.Add(part2H);

            PitchedGuitar.Add(part3H);
        }
    }
}
