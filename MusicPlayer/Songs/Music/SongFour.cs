using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class SongFour : Song
    {
        public SongFour()
        {
            BassNoteCollection A = new BassNoteCollection
            {
                MilliSecondsPerBeat = 300,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                }
            };
            BassNoteCollection C = new BassNoteCollection
            {
                MilliSecondsPerBeat = 300,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A3,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                    BassNotes.A3,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                    BassNotes.A3,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                    BassNotes.A3,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                }
            };
            BassNoteCollection G = new BassNoteCollection
            {
                MilliSecondsPerBeat = 300,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                }
            };
            BassNoteCollection F = new BassNoteCollection
            {
                MilliSecondsPerBeat = 300,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E1,BassNotes.E1,BassNotes.E1,BassNotes.E1,
                    BassNotes.E1,BassNotes.E1,BassNotes.E1,BassNotes.E1,
                    BassNotes.E1,BassNotes.E1,BassNotes.E1,BassNotes.E1,
                    BassNotes.E1,BassNotes.E1,BassNotes.E1,BassNotes.E1,
                }
            };

            BassLine = new List<BassNoteCollection>();

            //strophe
            BassLine.Add(A);
            BassLine.Add(A);
            BassLine.Add(A);
            BassLine.Add(G);
            BassLine.Add(A);
            BassLine.Add(A);
            BassLine.Add(A);
            BassLine.Add(G);
            //refraine
            BassLine.Add(A);
            BassLine.Add(C);
            BassLine.Add(G);
            BassLine.Add(F);
            BassLine.Add(C);
            ///////////////////////////////

            MelodyNoteCollection stropheTriole = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 200,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2
                }
            };
            MelodyNoteCollection strophe = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 300,
                Melody = new List<MelodyNotes> 
                {
                    //MelodyNotes.G0,MelodyNotes.G2,
                    MelodyNotes.G2,MelodyNotes.G2,
                    MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,
                    MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,
                    MelodyNotes.G4,MelodyNotes.G4, MelodyNotes.G5,MelodyNotes.G5
                }
            };
            MelodyNoteCollection stropheG = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 300,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,
                    MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,
                    MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,
                    MelodyNotes.G4,MelodyNotes.G4, MelodyNotes.G4,MelodyNotes.G4
                }
            };

            MelodyNoteCollection refrain = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 300,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,
                    MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,
                    MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,
                    MelodyNotes.G4,MelodyNotes.G4, MelodyNotes.G5,MelodyNotes.G5,

                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.H3,MelodyNotes.H3,MelodyNotes.H1,MelodyNotes.H1,

                    MelodyNotes.H3,MelodyNotes.H3,MelodyNotes.H3,MelodyNotes.H3,
                    MelodyNotes.H3,MelodyNotes.H3,MelodyNotes.H3,MelodyNotes.H3,
                    MelodyNotes.H3,MelodyNotes.H3,MelodyNotes.H3,MelodyNotes.H3,
                    MelodyNotes.H1,MelodyNotes.H1,MelodyNotes.H0,MelodyNotes.H0,

                    MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,
                    MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,
                    MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,MelodyNotes.G2,
                    MelodyNotes.G4,MelodyNotes.G4, MelodyNotes.G5,MelodyNotes.G5,

                    MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,
                    MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                }
            };

            Guitar = new List<MelodyNoteCollection>();

            Guitar.Add(stropheTriole);
            Guitar.Add(strophe);
            Guitar.Add(stropheTriole);
            Guitar.Add(strophe);
            Guitar.Add(stropheTriole);
            Guitar.Add(strophe);
            Guitar.Add(stropheG);
            Guitar.Add(stropheTriole);
            Guitar.Add(strophe);
            Guitar.Add(stropheTriole);
            Guitar.Add(strophe);
            Guitar.Add(stropheTriole);
            Guitar.Add(strophe);
            Guitar.Add(stropheG);
            Guitar.Add(refrain);

        }
    }
}
