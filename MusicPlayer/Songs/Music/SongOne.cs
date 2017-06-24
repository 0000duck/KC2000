using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class SongOne : Song
    {
        public SongOne()
        {
            int bassMilliSecondsPerSound = 120;
            int bassMilliSecondsPerBeat = 180;

            int melodyMilliSecondsPerSound = 120;
            int melodyMilliSecondsPerBeat = 180;

            int melodyFastMilliSecondsPerSound = 120;
            int melodyFastMilliSecondsPerBeat = 120;

            #region bassnotes
            BassNoteCollection E = new BassNoteCollection
            {
                MilliSecondsPerBeat = bassMilliSecondsPerBeat,
                MilliSecondsPerSound = bassMilliSecondsPerSound,

                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                }
            };
            BassNoteCollection D = new BassNoteCollection
            {
                MilliSecondsPerBeat = bassMilliSecondsPerBeat,
                MilliSecondsPerSound = bassMilliSecondsPerSound,

                BassLine = new List<BassNotes> 
                {
                    BassNotes.A5,BassNotes.A5,BassNotes.A5,BassNotes.A5,
                    BassNotes.A5,BassNotes.A5,BassNotes.A5,BassNotes.A5,
                    BassNotes.A5,BassNotes.A5,BassNotes.A5,BassNotes.A5,
                    BassNotes.A5,BassNotes.A5,BassNotes.A5,BassNotes.A5,
                }
            };
            BassNoteCollection C = new BassNoteCollection
            {
                MilliSecondsPerBeat = bassMilliSecondsPerBeat,
                MilliSecondsPerSound = bassMilliSecondsPerSound,

                BassLine = new List<BassNotes> 
                {
                    BassNotes.A3,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                    BassNotes.A3,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                    BassNotes.A3,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                    BassNotes.A3,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                }
            };
            BassNoteCollection H = new BassNoteCollection
            {
                MilliSecondsPerBeat = bassMilliSecondsPerBeat,
                MilliSecondsPerSound = bassMilliSecondsPerSound,

                BassLine = new List<BassNotes> 
                {
                    BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,
                    BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,
                    BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,
                    BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,
                }
            };
            BassNoteCollection G = new BassNoteCollection
            {
                MilliSecondsPerBeat = bassMilliSecondsPerBeat,
                MilliSecondsPerSound = bassMilliSecondsPerSound,

                BassLine = new List<BassNotes> 
                {
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                }
            };
            BassNoteCollection E2 = new BassNoteCollection
            {
                MilliSecondsPerBeat = bassMilliSecondsPerBeat,
                MilliSecondsPerSound = bassMilliSecondsPerSound,

                BassLine = new List<BassNotes> 
                {
                    BassNotes.A7,BassNotes.A7,BassNotes.A7,BassNotes.A7,
                    BassNotes.A7,BassNotes.A7,BassNotes.A7,BassNotes.A7,
                    BassNotes.A7,BassNotes.A7,BassNotes.A7,BassNotes.A7,
                    BassNotes.A7,BassNotes.A7,BassNotes.A7,BassNotes.A7,
                }
            };
            BassNoteCollection A = new BassNoteCollection
            {
                MilliSecondsPerBeat = bassMilliSecondsPerBeat,
                MilliSecondsPerSound = bassMilliSecondsPerSound,

                BassLine = new List<BassNotes> 
                {
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                }
            };
            #endregion

            BassLine = new List<BassNoteCollection>();

            BassLine.Add(D);
            BassLine.Add(D);
            BassLine.Add(C);
            BassLine.Add(C);

            BassLine.Add(D);
            BassLine.Add(D);
            BassLine.Add(C);
            BassLine.Add(C);

            BassLine.Add(E);
            BassLine.Add(H);
            BassLine.Add(G);
            BassLine.Add(E);

            BassLine.Add(E2);
            BassLine.Add(G);
            BassLine.Add(H);
            BassLine.Add(E);

            BassLine.Add(C);
            BassLine.Add(A);
            BassLine.Add(H);
            BassLine.Add(G);

            BassLine.Add(C);
            BassLine.Add(A);
            BassLine.Add(H);
            BassLine.Add(E);
            ///////////////////////////////////////7

            MelodyNoteCollection partOne = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = melodyMilliSecondsPerBeat,
                MilliSecondsPerSound = melodyMilliSecondsPerSound,

                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G7, MelodyNotes.G1,MelodyNotes.G4,
                    MelodyNotes.G0, MelodyNotes.G7,MelodyNotes.G10,MelodyNotes.G8,MelodyNotes.G11
                }
            };
            MelodyNoteCollection partTwo = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = melodyMilliSecondsPerBeat,
                MilliSecondsPerSound = melodyMilliSecondsPerSound,

                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G0, MelodyNotes.G6,MelodyNotes.G9,
                    MelodyNotes.H0, MelodyNotes.H6,MelodyNotes.H9,MelodyNotes.H7,MelodyNotes.H10
                }
            };

            MelodyNoteCollection mainpartOne = new MelodyNoteCollection
            {
                MilliSecondsPerSound = melodyFastMilliSecondsPerSound,
                MilliSecondsPerBeat = melodyFastMilliSecondsPerBeat,

                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,

                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H8,
                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H8,
                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H8,
                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H8,
                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H8,
                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H8,
                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H8,
                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H8,

                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,

                    MelodyNotes.E0, MelodyNotes.E4,MelodyNotes.E7,
                    MelodyNotes.E0, MelodyNotes.E4,MelodyNotes.E7,
                    MelodyNotes.E0, MelodyNotes.E4,MelodyNotes.E7,
                    MelodyNotes.E0, MelodyNotes.E4,MelodyNotes.E7,
                    MelodyNotes.E0, MelodyNotes.E4,MelodyNotes.E7,
                    MelodyNotes.E0, MelodyNotes.E4,MelodyNotes.E7,
                    MelodyNotes.E0, MelodyNotes.E4,MelodyNotes.E7,
                    MelodyNotes.E0, MelodyNotes.E4,MelodyNotes.E7,
                }
            };

            MelodyNoteCollection mainpartTwo = new MelodyNoteCollection
            {
                MilliSecondsPerSound = melodyFastMilliSecondsPerSound,
                MilliSecondsPerBeat = melodyFastMilliSecondsPerBeat,

                Melody = new List<MelodyNotes>
                {
                    MelodyNotes.E0, MelodyNotes.E6,MelodyNotes.E9,
                    MelodyNotes.E0, MelodyNotes.E6,MelodyNotes.E9,
                    MelodyNotes.E0, MelodyNotes.E6,MelodyNotes.E9,
                    MelodyNotes.E0, MelodyNotes.E6,MelodyNotes.E9,
                    MelodyNotes.E0, MelodyNotes.E6,MelodyNotes.E9,
                    MelodyNotes.E0, MelodyNotes.E6,MelodyNotes.E9,
                    MelodyNotes.E0, MelodyNotes.E6,MelodyNotes.E9,
                    MelodyNotes.E0, MelodyNotes.E6,MelodyNotes.E9,

                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,

                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H8,
                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H8,
                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H8,
                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H8,
                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H8,
                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H8,
                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H8,
                    MelodyNotes.H0, MelodyNotes.H5,MelodyNotes.H8,

                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                }
            };

            MelodyNoteCollection mainpartThree = new MelodyNoteCollection
            {
                MilliSecondsPerSound = melodyFastMilliSecondsPerSound,
                MilliSecondsPerBeat = melodyFastMilliSecondsPerBeat,

                Melody = new List<MelodyNotes>
                {
                    MelodyNotes.E0, MelodyNotes.E6,MelodyNotes.E9,
                    MelodyNotes.E0, MelodyNotes.E6,MelodyNotes.E9,
                    MelodyNotes.E0, MelodyNotes.E6,MelodyNotes.E9,
                    MelodyNotes.E0, MelodyNotes.E6,MelodyNotes.E9,
                    MelodyNotes.E0, MelodyNotes.E6,MelodyNotes.E9,
                    MelodyNotes.E0, MelodyNotes.E6,MelodyNotes.E9,
                    MelodyNotes.E0, MelodyNotes.E6,MelodyNotes.E9,
                    MelodyNotes.E0, MelodyNotes.E6,MelodyNotes.E9,

                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E0, MelodyNotes.E5,MelodyNotes.E8,

                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,
                    MelodyNotes.H0, MelodyNotes.H4,MelodyNotes.H7,

                    MelodyNotes.E0, MelodyNotes.E4,MelodyNotes.E7,
                    MelodyNotes.E0, MelodyNotes.E4,MelodyNotes.E7,
                    MelodyNotes.E0, MelodyNotes.E4,MelodyNotes.E7,
                    MelodyNotes.E0, MelodyNotes.E4,MelodyNotes.E7,
                    MelodyNotes.E0, MelodyNotes.E4,MelodyNotes.E7,
                    MelodyNotes.E0, MelodyNotes.E4,MelodyNotes.E7,
                    MelodyNotes.E0, MelodyNotes.E4,MelodyNotes.E7,
                    MelodyNotes.E0, MelodyNotes.E4,MelodyNotes.E7,
                }
            };
            Guitar = new List<MelodyNoteCollection>();
            Guitar.Add(partOne);
            Guitar.Add(partOne);
            Guitar.Add(partOne);
            Guitar.Add(partOne);
            Guitar.Add(partTwo);
            Guitar.Add(partTwo);
            Guitar.Add(partTwo);
            Guitar.Add(partTwo);
            Guitar.Add(partOne);
            Guitar.Add(partOne);
            Guitar.Add(partOne);
            Guitar.Add(partOne);
            Guitar.Add(partTwo);
            Guitar.Add(partTwo);
            Guitar.Add(partTwo);
            Guitar.Add(partTwo);

            Guitar.Add(mainpartOne);
            Guitar.Add(mainpartOne);
            Guitar.Add(mainpartTwo);
            Guitar.Add(mainpartThree);
        }
    }
}
