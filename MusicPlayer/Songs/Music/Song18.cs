using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class Song18 : Song
    {
        public Song18()
        {
            Guitar = new List<MelodyNoteCollection>();

            MelodyNoteCollection melodyE = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                SoundType = SoundType.Guitar,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                }
            };
            MelodyNoteCollection melodyA = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                SoundType = SoundType.Guitar,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,
                    MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,
                }
            };
            MelodyNoteCollection melodyH = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                SoundType = SoundType.Guitar,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.H0,MelodyNotes.H0,MelodyNotes.H0,MelodyNotes.H0,
                    MelodyNotes.H0,MelodyNotes.H0,MelodyNotes.H0,MelodyNotes.H0,
                }
            };

            //full melody
            MelodyNoteCollection highE = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 120,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E4,MelodyNotes.E4,
                    MelodyNotes.E7,MelodyNotes.E7,MelodyNotes.E9,MelodyNotes.E9,
                    MelodyNotes.E10,MelodyNotes.E10,MelodyNotes.E9,MelodyNotes.E9,
                    MelodyNotes.E7,MelodyNotes.E7,MelodyNotes.E4,MelodyNotes.E4
                }
            };
            MelodyNoteCollection highA = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 120,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G6,MelodyNotes.G6,
                    MelodyNotes.G9,MelodyNotes.G9,MelodyNotes.G11,MelodyNotes.G11,
                    MelodyNotes.G12,MelodyNotes.G12,MelodyNotes.G11,MelodyNotes.G11,
                    MelodyNotes.G9,MelodyNotes.G9,MelodyNotes.G6,MelodyNotes.G6
                }
            };

            MelodyNoteCollection highHA = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 120,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G4,MelodyNotes.G4,MelodyNotes.G8,MelodyNotes.G8,
                    MelodyNotes.G11,MelodyNotes.G11,MelodyNotes.G8,MelodyNotes.G8,
                    MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G6,MelodyNotes.G6,
                    MelodyNotes.G9,MelodyNotes.G9,MelodyNotes.G6,MelodyNotes.G6
                }
            };

            MelodyNoteCollection highEFinale = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 120,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.E0,MelodyNotes.G2,MelodyNotes.G3,MelodyNotes.G4,
                    MelodyNotes.G4,MelodyNotes.G4,MelodyNotes.G4,MelodyNotes.G4
                }
            };

            Guitar.Add(melodyE);
            Guitar.Add(melodyE);
            Guitar.Add(melodyA);
            Guitar.Add(melodyA);
            Guitar.Add(melodyA);
            Guitar.Add(melodyA);
            Guitar.Add(melodyE);
            Guitar.Add(melodyH);
            Guitar.Add(melodyH);
            Guitar.Add(melodyA);
            Guitar.Add(melodyA);
            Guitar.Add(melodyE);

            Guitar.Add(highE);
            Guitar.Add(highE);
            Guitar.Add(highA);
            Guitar.Add(highE);
            Guitar.Add(highHA);
            Guitar.Add(highEFinale);

            BassLine = new List<BassNoteCollection>();


            BassNoteCollection bassE = new BassNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E4,BassNotes.E4,
                    BassNotes.E7,BassNotes.E7,BassNotes.A4,BassNotes.A4,
                    BassNotes.A5,BassNotes.A5,BassNotes.A4,BassNotes.A4,
                    BassNotes.E7,BassNotes.E7,BassNotes.E4,BassNotes.E4
                }
            };
            BassNoteCollection bassA = new BassNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A0,BassNotes.A0,BassNotes.A4,BassNotes.A4,
                    BassNotes.A7,BassNotes.A7,BassNotes.A9,BassNotes.A9,
                    BassNotes.A10,BassNotes.A10,BassNotes.A9,BassNotes.A9,
                    BassNotes.A7,BassNotes.A7,BassNotes.A4,BassNotes.A4
                }
            };

            BassNoteCollection bassHA = new BassNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A2,BassNotes.A2,BassNotes.A6,BassNotes.A6,
                    BassNotes.A9,BassNotes.A9,BassNotes.A6,BassNotes.A6,
                    BassNotes.A0,BassNotes.A0,BassNotes.A4,BassNotes.A4,
                    BassNotes.A7,BassNotes.A7,BassNotes.A4,BassNotes.A4
                }
            };

            BassNoteCollection bassEFinale = new BassNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.A0,BassNotes.A1,BassNotes.A2,
                    BassNotes.A2,BassNotes.A2,BassNotes.A2,BassNotes.A2
                }
            };

            //one note
            BassNoteCollection bassEOnly = new BassNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                }
            };
            BassNoteCollection bassAOnly = new BassNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                }
            };

            BassNoteCollection bassHAOnly = new BassNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A2,BassNotes.A2,BassNotes.A2,BassNotes.A2,
                    BassNotes.A2,BassNotes.A2,BassNotes.A2,BassNotes.A2,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                }
            };

            BassLine.Add(bassE);
            BassLine.Add(bassE);
            BassLine.Add(bassA);
            BassLine.Add(bassE);
            BassLine.Add(bassHA);
            BassLine.Add(bassEFinale);

            BassLine.Add(bassEOnly);
            BassLine.Add(bassEOnly);
            BassLine.Add(bassAOnly);
            BassLine.Add(bassEOnly);
            BassLine.Add(bassHAOnly);
            BassLine.Add(bassEFinale);

            PitchedGuitar = new List<MelodyNoteCollection>();



        }
    }
}
