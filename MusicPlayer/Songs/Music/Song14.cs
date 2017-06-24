using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class Song14 : Song
    {
        public Song14()
        {

            Guitar = new List<MelodyNoteCollection>();

            BassNoteCollection bassE = new BassNoteCollection
            {
                MilliSecondsPerBeat = 250,
                MilliSecondsPerSound = 200,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                    BassNotes.E0,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                    BassNotes.E0,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                    BassNotes.E0,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                }
            };

            BassNoteCollection bassEdauer = new BassNoteCollection
            {
                MilliSecondsPerBeat = 250,
                MilliSecondsPerSound = 200,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E0, BassNotes.E0,BassNotes.E0, BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0, BassNotes.E0,BassNotes.E0, BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0, BassNotes.E0,BassNotes.E0, BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0, BassNotes.E0,BassNotes.E0, BassNotes.E0,
                }
            };

            BassNoteCollection bassFis = new BassNoteCollection
            {
                MilliSecondsPerBeat = 250,
                MilliSecondsPerSound = 200,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E2,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                    BassNotes.E2,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                    BassNotes.E2,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                    BassNotes.E2,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                }
            };

            BassNoteCollection bassFisDauer = new BassNoteCollection
            {
                MilliSecondsPerBeat = 250,
                MilliSecondsPerSound = 200,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E2,BassNotes.E2,BassNotes.E2, BassNotes.E2,BassNotes.E2, BassNotes.E2,
                    BassNotes.E2,BassNotes.E2,BassNotes.E2, BassNotes.E2,BassNotes.E2, BassNotes.E2,
                    BassNotes.E2,BassNotes.E2,BassNotes.E2, BassNotes.E2,BassNotes.E2, BassNotes.E2,
                    BassNotes.E2,BassNotes.E2,BassNotes.E2, BassNotes.E2,BassNotes.E2, BassNotes.E2,
                }
            };

            BassNoteCollection bassGis = new BassNoteCollection
            {
                MilliSecondsPerBeat = 250,
                MilliSecondsPerSound = 200,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E4,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                    BassNotes.E4,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                    BassNotes.E4,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                    BassNotes.E4,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                }
            };

            BassNoteCollection bassGisDauer = new BassNoteCollection
            {
                MilliSecondsPerBeat = 250,
                MilliSecondsPerSound = 200,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E4,BassNotes.E4,BassNotes.E4, BassNotes.E4,BassNotes.E4,BassNotes.E4,
                    BassNotes.E4,BassNotes.E4,BassNotes.E4, BassNotes.E4,BassNotes.E4,BassNotes.E4,
                    BassNotes.E4,BassNotes.E4,BassNotes.E4, BassNotes.E4,BassNotes.E4,BassNotes.E4,
                    BassNotes.E4,BassNotes.E4,BassNotes.E4, BassNotes.E4,BassNotes.E4,BassNotes.E4,
                }
            };

            BassNoteCollection bassA = new BassNoteCollection
            {
                MilliSecondsPerBeat = 250,
                MilliSecondsPerSound = 200,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A0,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                    BassNotes.A0,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                    BassNotes.A0,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                    BassNotes.A0,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                }
            };

            BassNoteCollection bassADauer = new BassNoteCollection
            {
                MilliSecondsPerBeat = 250,
                MilliSecondsPerSound = 200,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A0,BassNotes.A0,BassNotes.A0, BassNotes.A0,BassNotes.A0, BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0, BassNotes.A0,BassNotes.A0, BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0, BassNotes.A0,BassNotes.A0, BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0, BassNotes.A0,BassNotes.A0, BassNotes.A0,
                }
            };

            BassNoteCollection bassH = new BassNoteCollection
            {
                MilliSecondsPerBeat = 250,
                MilliSecondsPerSound = 200,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A2,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                    BassNotes.A2,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                    BassNotes.A2,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                    BassNotes.A2,BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,BassNotes.Silence, BassNotes.Silence,
                }
            };

            BassNoteCollection bassHDauer = new BassNoteCollection
            {
                MilliSecondsPerBeat = 250,
                MilliSecondsPerSound = 200,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A2,BassNotes.A2,BassNotes.A2, BassNotes.A2,BassNotes.A2, BassNotes.A2,
                    BassNotes.A2,BassNotes.A2,BassNotes.A2, BassNotes.A2,BassNotes.A2, BassNotes.A2,
                    BassNotes.A2,BassNotes.A2,BassNotes.A2, BassNotes.A2,BassNotes.A2, BassNotes.A2,
                    BassNotes.A2,BassNotes.A2,BassNotes.A2, BassNotes.A2,BassNotes.A2, BassNotes.A2,
                }
            };

            BassLine = new List<BassNoteCollection>();


            //strophe
            BassLine.Add(bassE);
            BassLine.Add(bassFis);
            BassLine.Add(bassGis);
            BassLine.Add(bassA);
            BassLine.Add(bassH);
            BassLine.Add(bassE);

            BassLine.Add(bassEdauer);
            BassLine.Add(bassFisDauer);
            BassLine.Add(bassGisDauer);
            BassLine.Add(bassADauer);
            BassLine.Add(bassHDauer);
            BassLine.Add(bassEdauer);

            MelodyNoteCollection E = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 250,
                MilliSecondsPerSound = 200,
                SoundType = SoundType.Faded,

                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence,MelodyNotes.G1,MelodyNotes.H0,MelodyNotes.E0,MelodyNotes.H0, MelodyNotes.G1,
                    MelodyNotes.Silence,MelodyNotes.G1,MelodyNotes.H0,MelodyNotes.E0,MelodyNotes.H0, MelodyNotes.G1,
                    MelodyNotes.Silence,MelodyNotes.G1,MelodyNotes.H0,MelodyNotes.E0,MelodyNotes.H0, MelodyNotes.G1,
                    MelodyNotes.Silence,MelodyNotes.G1,MelodyNotes.H0,MelodyNotes.E0,MelodyNotes.H0, MelodyNotes.G1
                }
            };

            MelodyNoteCollection Epitched = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 250,
                MilliSecondsPerSound = 200,
                SoundType = SoundType.Driller,

                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence,MelodyNotes.G1,MelodyNotes.H0,MelodyNotes.E0,MelodyNotes.H0, MelodyNotes.G1,
                    MelodyNotes.Silence,MelodyNotes.G1,MelodyNotes.H0,MelodyNotes.E0,MelodyNotes.H0, MelodyNotes.G1,
                    MelodyNotes.Silence,MelodyNotes.G1,MelodyNotes.H0,MelodyNotes.E0,MelodyNotes.H0, MelodyNotes.G1,
                    MelodyNotes.Silence,MelodyNotes.G1,MelodyNotes.H0,MelodyNotes.E0,MelodyNotes.H0, MelodyNotes.G1
                }
            };

            MelodyNoteCollection Fismoll = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 250,
                MilliSecondsPerSound = 200,
                SoundType = SoundType.Faded,

                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence,MelodyNotes.G2,MelodyNotes.H2,MelodyNotes.E2,MelodyNotes.H2, MelodyNotes.G2,
                    MelodyNotes.Silence,MelodyNotes.G2,MelodyNotes.H2,MelodyNotes.E2,MelodyNotes.H2, MelodyNotes.G2,
                    MelodyNotes.Silence,MelodyNotes.G2,MelodyNotes.H2,MelodyNotes.E2,MelodyNotes.H2, MelodyNotes.G2,
                    MelodyNotes.Silence,MelodyNotes.G2,MelodyNotes.H2,MelodyNotes.E2,MelodyNotes.H2, MelodyNotes.G2
                }
            };

            MelodyNoteCollection Gismoll = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 250,
                MilliSecondsPerSound = 200,
                SoundType = SoundType.Faded,

                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence,MelodyNotes.G4,MelodyNotes.H4,MelodyNotes.E4,MelodyNotes.H4, MelodyNotes.G4,
                    MelodyNotes.Silence,MelodyNotes.G4,MelodyNotes.H4,MelodyNotes.E4,MelodyNotes.H4, MelodyNotes.G4,
                    MelodyNotes.Silence,MelodyNotes.G4,MelodyNotes.H4,MelodyNotes.E4,MelodyNotes.H4, MelodyNotes.G4,
                    MelodyNotes.Silence,MelodyNotes.G4,MelodyNotes.H4,MelodyNotes.E4,MelodyNotes.H4, MelodyNotes.G4,
                }
            };

            MelodyNoteCollection A = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 250,
                MilliSecondsPerSound = 200,
                SoundType = SoundType.Faded,

                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence,MelodyNotes.G6,MelodyNotes.H5,MelodyNotes.E5,MelodyNotes.H5, MelodyNotes.G6,
                    MelodyNotes.Silence,MelodyNotes.G6,MelodyNotes.H5,MelodyNotes.E5,MelodyNotes.H5, MelodyNotes.G6,
                    MelodyNotes.Silence,MelodyNotes.G6,MelodyNotes.H5,MelodyNotes.E5,MelodyNotes.H5, MelodyNotes.G6,
                    MelodyNotes.Silence,MelodyNotes.G6,MelodyNotes.H5,MelodyNotes.E5,MelodyNotes.H5, MelodyNotes.G6
                }
            };

            MelodyNoteCollection H = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 250,
                MilliSecondsPerSound = 200,
                SoundType = SoundType.Faded,

                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence,MelodyNotes.G8,MelodyNotes.H7,MelodyNotes.E7,MelodyNotes.H7, MelodyNotes.G8,
                    MelodyNotes.Silence,MelodyNotes.G8,MelodyNotes.H7,MelodyNotes.E7,MelodyNotes.H7, MelodyNotes.G8,
                    MelodyNotes.Silence,MelodyNotes.G8,MelodyNotes.H7,MelodyNotes.E7,MelodyNotes.H7, MelodyNotes.G8,
                    MelodyNotes.Silence,MelodyNotes.G8,MelodyNotes.H7,MelodyNotes.E7,MelodyNotes.H7, MelodyNotes.G8
                }
            };

            Guitar.Add(E);
            Guitar.Add(Fismoll);
            Guitar.Add(Gismoll);
            Guitar.Add(A);
            Guitar.Add(H);
            Guitar.Add(E);

            Guitar.Add(E);
            Guitar.Add(Fismoll);
            Guitar.Add(Gismoll);
            Guitar.Add(A);
            Guitar.Add(H);
            Guitar.Add(E);
        }
    }
}
