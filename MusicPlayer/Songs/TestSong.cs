using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs
{
    public class TestSong : Song
    {
        public TestSong()
        {
            BassNoteCollection partOne = new BassNoteCollection 
            {
                MilliSecondsPerBeat = 180,
                BassLine = new List<BassNotes>
                {
                    BassNotes.E0,
                    BassNotes.E0,
                    BassNotes.E0,
                    BassNotes.E0,

                    BassNotes.E1,
                    BassNotes.E2,
                    BassNotes.E3,
                    BassNotes.E4,

                    BassNotes.E5,
                    BassNotes.E6,
                    BassNotes.E7,
                    BassNotes.E8,

                    BassNotes.E9,
                    BassNotes.E10,
                    BassNotes.A6,
                    BassNotes.A7,
                }
            };

            BassNoteCollection partTwo = new BassNoteCollection 
            {
                MilliSecondsPerBeat = 140,
                BassLine = new List<BassNotes>
                {
                    BassNotes.A0,
                    BassNotes.A1,
                    BassNotes.A2,
                    BassNotes.A3,

                    BassNotes.A2,
                    BassNotes.A1,
                    BassNotes.A0,
                    BassNotes.A1,

                    BassNotes.A2,
                    BassNotes.A3,
                    BassNotes.A4,
                    BassNotes.A5,

                    BassNotes.A4,
                    BassNotes.A3,
                    BassNotes.A2,
                    BassNotes.A1,
                }
            };

            BassLine = new List<BassNoteCollection>();

            BassLine.Add(partOne);
            BassLine.Add(partOne);

            BassLine.Add(partTwo);
            BassLine.Add(partTwo);

            MelodyNoteCollection melodyOne = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                Melody = new List<MelodyNotes>
                {
                    MelodyNotes.G0,
                    MelodyNotes.G1,
                    MelodyNotes.G2,
                    MelodyNotes.G3,

                    MelodyNotes.G0,
                    MelodyNotes.G1,
                    MelodyNotes.G2,
                    MelodyNotes.G3,

                    MelodyNotes.H0,
                    MelodyNotes.H1,
                    MelodyNotes.H2,
                    MelodyNotes.H3,

                    MelodyNotes.E0,
                    MelodyNotes.E1,
                    MelodyNotes.E2,
                    MelodyNotes.E3,

                    MelodyNotes.G9,
                    MelodyNotes.G8,
                    MelodyNotes.G9,
                    MelodyNotes.G9,
                }
            };

            Guitar = new List<MelodyNoteCollection>();
            Guitar.Add(melodyOne);
            Guitar.Add(melodyOne);
            Guitar.Add(melodyOne);
            Guitar.Add(melodyOne);
        }
    }
}
