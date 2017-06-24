using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class SongSix : Song
    {
        public SongSix()
        {
            BassNoteCollection BassOne = new BassNoteCollection
            {
                MilliSecondsPerBeat = 400,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E7,BassNotes.E6,BassNotes.E5,
                    BassNotes.E2,BassNotes.E8,BassNotes.E3,BassNotes.E4,
                    BassNotes.E5,BassNotes.E10,BassNotes.E9,BassNotes.E2,
                    BassNotes.E7,BassNotes.E6,BassNotes.E5,BassNotes.E4,
                    BassNotes.E0,BassNotes.E8,BassNotes.E7,BassNotes.E6,
                }
            };

            BassNoteCollection BassTwo = new BassNoteCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E7,BassNotes.E6,BassNotes.E5,
                    BassNotes.E2,BassNotes.E8,BassNotes.E3,BassNotes.E4,
                    BassNotes.E5,BassNotes.E10,BassNotes.E9,BassNotes.E2,
                    BassNotes.E7,BassNotes.E6,BassNotes.E5,BassNotes.E4,
                    BassNotes.E0,BassNotes.E8,BassNotes.E7,BassNotes.E6,
                }
            };

            BassNoteCollection Slow1 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 320,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A4,BassNotes.A3 
                }
            };

            BassNoteCollection Slow2 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 340,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A2,BassNotes.A1
                }
            };

            BassNoteCollection Slow3 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 360,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E5,BassNotes.E4,
                }
            };

            BassNoteCollection Slow4 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 380,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E3,BassNotes.E2,
                }
            };

            BassLine = new List<BassNoteCollection>();

            //strophe
            BassLine.Add(BassOne);
            BassLine.Add(BassOne);
            BassLine.Add(BassOne);
            BassLine.Add(BassOne);
            BassLine.Add(BassTwo);

            BassLine.Add(Slow1);
            BassLine.Add(Slow2);
            BassLine.Add(Slow3);
            BassLine.Add(Slow4);

            //////////////////////////////////////////////////


            MelodyNoteCollection melodyOne = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E10,MelodyNotes.G4,MelodyNotes.H5,MelodyNotes.E11,
                    MelodyNotes.E6,MelodyNotes.G8,MelodyNotes.H2,MelodyNotes.E0,
                    MelodyNotes.E11,MelodyNotes.G6,MelodyNotes.H9,MelodyNotes.E6,
                    MelodyNotes.E2,MelodyNotes.G2,MelodyNotes.H5,MelodyNotes.E5,
                    MelodyNotes.E10,MelodyNotes.G8,MelodyNotes.E1,MelodyNotes.E11,
                }
            };


            MelodyNoteCollection melodyTwo = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E7,MelodyNotes.G4,MelodyNotes.Silence,MelodyNotes.E12,
                    MelodyNotes.E3,MelodyNotes.G2,MelodyNotes.H2,MelodyNotes.Silence,
                    MelodyNotes.E11,MelodyNotes.G6,MelodyNotes.Silence,MelodyNotes.E6,
                    MelodyNotes.E2,MelodyNotes.Silence,MelodyNotes.H5,MelodyNotes.E5,
                    MelodyNotes.E9,MelodyNotes.G3,MelodyNotes.E1,MelodyNotes.Silence,
                }
            };

            MelodyNoteCollection melodyThree = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E7,MelodyNotes.G4,MelodyNotes.Silence,MelodyNotes.E12,
                    MelodyNotes.E3,MelodyNotes.G2,MelodyNotes.H2,MelodyNotes.Silence,
                    MelodyNotes.E11,MelodyNotes.G6,MelodyNotes.Silence,MelodyNotes.E6,
                    MelodyNotes.E2,MelodyNotes.Silence,MelodyNotes.H5,MelodyNotes.E5,
                    MelodyNotes.E9,MelodyNotes.G3,MelodyNotes.E1,MelodyNotes.Silence,
                }
            };

            MelodyNoteCollection melodyFour = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 80,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E5,MelodyNotes.G7,MelodyNotes.H9,MelodyNotes.G3,
                    MelodyNotes.G4,MelodyNotes.G5,MelodyNotes.H2,MelodyNotes.Silence,
                    MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E9,MelodyNotes.E8,
                    MelodyNotes.E2,MelodyNotes.Silence,MelodyNotes.H5,MelodyNotes.E5,
                    MelodyNotes.E9,MelodyNotes.G3,MelodyNotes.E1,MelodyNotes.Silence,

                    MelodyNotes.G5,MelodyNotes.E7,MelodyNotes.G9,MelodyNotes.G3,
                    MelodyNotes.G4,MelodyNotes.G5,MelodyNotes.H2,MelodyNotes.Silence,
                    MelodyNotes.E11,MelodyNotes.G6,MelodyNotes.Silence,MelodyNotes.E6,
                    MelodyNotes.E2,MelodyNotes.Silence,MelodyNotes.H5,MelodyNotes.E5,
                    MelodyNotes.E9,MelodyNotes.G3,MelodyNotes.E1,MelodyNotes.Silence,
                }
            };

            MelodyNoteCollection melodyFive = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 80,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E5,MelodyNotes.G7,MelodyNotes.H9,MelodyNotes.G3,
                    MelodyNotes.G4,MelodyNotes.G1,MelodyNotes.H2,MelodyNotes.Silence,
                    MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E9,MelodyNotes.E8,
                    MelodyNotes.E2,MelodyNotes.Silence,MelodyNotes.H5,MelodyNotes.E5,
                    MelodyNotes.E9,MelodyNotes.G7,MelodyNotes.E1,MelodyNotes.Silence,

                    MelodyNotes.G5,MelodyNotes.E7,MelodyNotes.G9,MelodyNotes.G3,
                    MelodyNotes.G4,MelodyNotes.G5,MelodyNotes.H5,MelodyNotes.Silence
                }
            };

            Guitar = new List<MelodyNoteCollection>();

            Guitar.Add(melodyOne);
            Guitar.Add(melodyTwo);
            Guitar.Add(melodyThree);
            Guitar.Add(melodyThree);

            Guitar.Add(melodyOne);
            Guitar.Add(melodyTwo);
            Guitar.Add(melodyThree);
            Guitar.Add(melodyThree);

            Guitar.Add(melodyFour);
            Guitar.Add(melodyFour);

            Guitar.Add(melodyThree);
            Guitar.Add(melodyThree);
            Guitar.Add(melodyThree);

            Guitar.Add(melodyFive);
        }
    }
}
