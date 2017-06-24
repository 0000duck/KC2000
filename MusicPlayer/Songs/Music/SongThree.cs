using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class SongThree : Song
    {
        public SongThree()
        {
            BassNoteCollection E6Break = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E6,BassNotes.E6,BassNotes.E6,BassNotes.E6,
                    BassNotes.E6,BassNotes.Silence,BassNotes.Silence,BassNotes.Silence
                }
            };

            BassNoteCollection E3Break = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                    BassNotes.E3,BassNotes.Silence,BassNotes.Silence,BassNotes.Silence
                }
            };

            BassNoteCollection A3Break = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A3,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                    BassNotes.A3,BassNotes.Silence,BassNotes.Silence,BassNotes.Silence
                }
            };

            BassNoteCollection E1Break = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E1,BassNotes.E1,BassNotes.E1,BassNotes.E1,
                    BassNotes.E1,BassNotes.Silence,BassNotes.Silence,BassNotes.Silence
                }
            };

            BassNoteCollection E6 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E6,BassNotes.E6,BassNotes.E6,BassNotes.E6
                }
            };

            BassNoteCollection E3 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3
                }
            };

            BassNoteCollection A3 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A3,BassNotes.A3,BassNotes.A3,BassNotes.A3
                }
            };

            BassNoteCollection A6 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A6,BassNotes.A6,BassNotes.A6,BassNotes.A6
                }
            };

            BassNoteCollection E1 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E1,BassNotes.E1,BassNotes.E1,BassNotes.E1
                }
            };

            BassNoteCollection silence = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.Silence,BassNotes.Silence,BassNotes.Silence
                }
            };
            BassLine = new List<BassNoteCollection>();

            BassLine.Add(silence);
            BassLine.Add(E6Break);
            BassLine.Add(E6Break);
            BassLine.Add(E6Break);
            BassLine.Add(E3Break);
            BassLine.Add(A3Break);
            BassLine.Add(A3Break);
            BassLine.Add(A3Break);
            BassLine.Add(E1Break);
            BassLine.Add(E3);
            BassLine.Add(E3);
            BassLine.Add(E6);
            BassLine.Add(E6);
            BassLine.Add(A3);
            BassLine.Add(A3);
            BassLine.Add(A6);
            BassLine.Add(A6);
            BassLine.Add(A6);
            BassLine.Add(A6);

            BassLine.Add(A3);
            BassLine.Add(A3);
            BassLine.Add(A3);
            BassLine.Add(A3);
            BassLine.Add(E3);
            BassLine.Add(E3);
            BassLine.Add(E3);
            BassLine.Add(E3);
            BassLine.Add(E6);
            BassLine.Add(E6);
            BassLine.Add(E6);
            BassLine.Add(E6);
            BassLine.Add(A6);
            BassLine.Add(A6);
            BassLine.Add(A6);
            BassLine.Add(A6);
            BassLine.Add(A3);
            BassLine.Add(A3);
            BassLine.Add(A3);
            BassLine.Add(A3);
            BassLine.Add(E6);
            BassLine.Add(E6);
            BassLine.Add(E6);
            BassLine.Add(E6);
            BassLine.Add(A6);
            BassLine.Add(A6);
            BassLine.Add(A6);
            BassLine.Add(A6);
            BassLine.Add(E1);
            BassLine.Add(E1);
            BassLine.Add(E1);
            BassLine.Add(E1);

            BassLine.Add(E6Break);
            BassLine.Add(E6Break);
            BassLine.Add(E6Break);
            BassLine.Add(E6Break);

            MelodyNoteCollection melodySilence = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                Melody = new List<MelodyNotes> 
                {
                   MelodyNotes.Silence
                }
            };

            MelodyNoteCollection melody1PartOne = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                Melody = new List<MelodyNotes> 
                {
                   MelodyNotes.G7, MelodyNotes.G0, MelodyNotes.G2,MelodyNotes.G3,
                   MelodyNotes.G3,MelodyNotes.G3,MelodyNotes.G3,MelodyNotes.G3
                }
            };
            MelodyNoteCollection melody1PartTwo = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                Melody = new List<MelodyNotes> 
                {
                   MelodyNotes.G7, MelodyNotes.G0, MelodyNotes.G2,MelodyNotes.G3,
                   MelodyNotes.G5,MelodyNotes.G7,MelodyNotes.G8,MelodyNotes.G7,
                   MelodyNotes.G5,MelodyNotes.G3,MelodyNotes.G2,MelodyNotes.G0,
                   MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0
                }
            };


            MelodyNoteCollection melody1PartThree= new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                Melody = new List<MelodyNotes> 
                {
                   MelodyNotes.G0, MelodyNotes.G5, MelodyNotes.G7,MelodyNotes.G8,
                   MelodyNotes.G8,MelodyNotes.G8,MelodyNotes.G8,MelodyNotes.G8
                }
            };

            MelodyNoteCollection melody1PartFour= new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                Melody = new List<MelodyNotes> 
                {
                   MelodyNotes.G0, MelodyNotes.G5, MelodyNotes.G7,MelodyNotes.G8,
                   MelodyNotes.H6,MelodyNotes.H8,MelodyNotes.H9,MelodyNotes.H8,
                   MelodyNotes.H6,MelodyNotes.G8,MelodyNotes.G7,MelodyNotes.G5,
                   MelodyNotes.G5,MelodyNotes.G5,MelodyNotes.G5,MelodyNotes.G5
                }
            };

            MelodyNoteCollection melody1PartFive = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                Melody = new List<MelodyNotes> 
                {
                   MelodyNotes.G7, MelodyNotes.G0, MelodyNotes.G2,MelodyNotes.G3,
                   MelodyNotes.G0, MelodyNotes.G5, MelodyNotes.G7,MelodyNotes.G8,
                }
            };

            MelodyNoteCollection melody1PartSix = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G7, MelodyNotes.G0, MelodyNotes.G2,MelodyNotes.G3,
                   MelodyNotes.G5,MelodyNotes.G7,MelodyNotes.G8,MelodyNotes.G7,
                   MelodyNotes.G5,MelodyNotes.G3,MelodyNotes.G2
                }
            };

            //MelodyNoteCollection melody1PartSeven = new MelodyNoteCollection
            //{
            //    MilliSecondsPerBeat = 240,
            //    Melody = new List<MelodyNotes> 
            //    {
            //        MelodyNotes.G8, MelodyNotes.G8,MelodyNotes.G8,MelodyNotes.G8,
            //        MelodyNotes.G8,MelodyNotes.G8,MelodyNotes.G8,MelodyNotes.G8,
            //        MelodyNotes.G8,MelodyNotes.G8,MelodyNotes.G8,MelodyNotes.G8,
            //        MelodyNotes.G8,MelodyNotes.G8,MelodyNotes.G8,MelodyNotes.G8
            //    }
            //};
            MelodyNoteCollection melody1PartSeven = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G2, MelodyNotes.G8,MelodyNotes.G2,MelodyNotes.G8,
                    MelodyNotes.G2, MelodyNotes.G8,MelodyNotes.G2,MelodyNotes.G8,
                    MelodyNotes.G2, MelodyNotes.G8,MelodyNotes.G2,MelodyNotes.G8,
                    MelodyNotes.G2, MelodyNotes.G8,MelodyNotes.G2,MelodyNotes.G8,
                }
            };

            MelodyNoteCollection melody2H = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 160,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H0,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H8,MelodyNotes.H0,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H0,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H8,MelodyNotes.H0,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H0,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H8,MelodyNotes.H0,MelodyNotes.H7,
                }
            };

            MelodyNoteCollection melody2D1 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 180,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G7, MelodyNotes.G0,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G3,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G0,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G3,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G0,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G3,MelodyNotes.G7,MelodyNotes.G2,
                }
            };

            MelodyNoteCollection melody2D2 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 200,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G7, MelodyNotes.G0,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G3,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G0,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G3,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G0,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G3,MelodyNotes.G7,MelodyNotes.G2,
                }
            };

            MelodyNoteCollection melody2D3 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 220,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G7, MelodyNotes.G0,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G3,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G0,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G3,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G0,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G3,MelodyNotes.G7,MelodyNotes.G2,
                }
            };

            MelodyNoteCollection melody2G = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 160,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G0, MelodyNotes.G5,MelodyNotes.G0,MelodyNotes.G7,
                    MelodyNotes.G0, MelodyNotes.G8,MelodyNotes.G0,MelodyNotes.G7,
                    MelodyNotes.G0, MelodyNotes.G5,MelodyNotes.G0,MelodyNotes.G7,
                    MelodyNotes.G0, MelodyNotes.G8,MelodyNotes.G0,MelodyNotes.G7,
                    MelodyNotes.G0, MelodyNotes.G5,MelodyNotes.G0,MelodyNotes.G7,
                    MelodyNotes.G0, MelodyNotes.G8,MelodyNotes.G0,MelodyNotes.G7,
                }
            };

            MelodyNoteCollection melody2D = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 160,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G7, MelodyNotes.G0,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G3,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G0,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G3,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G0,MelodyNotes.G7,MelodyNotes.G2,
                    MelodyNotes.G7, MelodyNotes.G3,MelodyNotes.G7,MelodyNotes.G2,
                }
            };

            Guitar = new List<MelodyNoteCollection>();

        //    Melody.Add(melodySilence);
            Guitar.Add(melody1PartOne);
            Guitar.Add(melody1PartOne);
            Guitar.Add(melody1PartTwo);
            Guitar.Add(melody1PartThree);
            Guitar.Add(melody1PartThree);
            Guitar.Add(melody1PartFour);
            Guitar.Add(melody1PartFive);
            Guitar.Add(melody1PartFive);
            Guitar.Add(melody1PartSix);
            Guitar.Add(melody1PartSeven);

            
            Guitar.Add(melody2G);
            Guitar.Add(melody2D);
            Guitar.Add(melody2G);
            Guitar.Add(melody2H);
            Guitar.Add(melody2G);
            Guitar.Add(melody2D);
            Guitar.Add(melody2G);
            Guitar.Add(melody2G);
            Guitar.Add(melody2G);
            Guitar.Add(melody2G);
            Guitar.Add(melody2D1);
            Guitar.Add(melody2D2);
            Guitar.Add(melody2D3);
        }

    }
}
