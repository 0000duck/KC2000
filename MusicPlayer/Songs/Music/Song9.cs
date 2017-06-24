using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class Song9 : Song
    {
        public Song9()
        {

            BassNoteCollection Ebasic = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.Silence,BassNotes.Silence,BassNotes.E0,
                    BassNotes.Silence,BassNotes.E0,BassNotes.E0,BassNotes.Silence,
                    BassNotes.Silence,BassNotes.Silence,BassNotes.Silence,BassNotes.Silence,
                    BassNotes.Silence,BassNotes.Silence
                }
            };

            BassNoteCollection Easia = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E1,BassNotes.E6,BassNotes.E5,BassNotes.E1
                }
            };
            BassLine = new List<BassNoteCollection>();

            //strophe
            BassLine.Add(Ebasic);
            BassLine.Add(Ebasic);
            BassLine.Add(Ebasic);
            BassLine.Add(Ebasic);
            BassLine.Add(Easia);
            BassLine.Add(Ebasic);
            BassLine.Add(Ebasic);
            BassLine.Add(Ebasic);
            BassLine.Add(Ebasic);
            BassLine.Add(Easia);

            BassLine.Add(Ebasic);
            BassLine.Add(Ebasic);
            BassLine.Add(Easia);

            MelodyNoteCollection melodybreakbasic = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240 * 14,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence
                }
            };
            MelodyNoteCollection melodybreakasia = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240 * 5,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence
                }
            };

            MelodyNoteCollection melodyasia = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 90,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.E1,MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E1,MelodyNotes.E0,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence
                }
            };

            MelodyNoteCollection melodyasiashort = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 90,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.E1,MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E1
                }
            };

            MelodyNoteCollection melodyasia2 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 90,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.H12,MelodyNotes.H6,MelodyNotes.H5,MelodyNotes.H6,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence
                }
            };

            MelodyNoteCollection melodyasia3 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 90,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E10,MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence
                }
            };

            MelodyNoteCollection melodyasia4 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 90,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E10,MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E1,MelodyNotes.E5,MelodyNotes.E6,
                    MelodyNotes.E1,MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence
                }
            };

            MelodyNoteCollection melodyasia5 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 90,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E1,MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E10,MelodyNotes.E6,MelodyNotes.E5,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence
                }
            };

            Guitar = new List<MelodyNoteCollection>();

            Guitar.Add(melodybreakbasic);
            Guitar.Add(melodybreakbasic);
            Guitar.Add(melodybreakbasic);
            Guitar.Add(melodybreakbasic);
            Guitar.Add(melodybreakasia);
            Guitar.Add(melodyasia);
            Guitar.Add(melodyasia2);
            Guitar.Add(melodyasia3);
            Guitar.Add(melodyasia4);
            Guitar.Add(melodybreakasia);

            Guitar.Add(melodyasia3);
            Guitar.Add(melodyasia5);
            Guitar.Add(melodyasiashort);

            Drums = new List<DrumCollection>();

            DrumCollection beat = new DrumCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 20,
                Melody = new List<DrumNotes> 
                {
                    
                    DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,
                    DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,
                    DrumNotes.Snare,DrumNotes.Snare,

                    DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,
                    DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,
                    DrumNotes.Snare,DrumNotes.Snare,

                    DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,
                    DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,
                    DrumNotes.Snare,DrumNotes.Snare,

                    DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,
                    DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,
                    DrumNotes.Snare,DrumNotes.Snare,

                    DrumNotes.Snare,DrumNotes.Snare,DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare
                }
            };

            DrumCollection beatbridgge = new DrumCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 20,
                Melody = new List<DrumNotes> 
                {
                    
                    DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,
                    DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,
                    DrumNotes.Snare,DrumNotes.Snare,

                    DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,
                    DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare,
                    DrumNotes.Snare,DrumNotes.Snare,


                    DrumNotes.Snare,DrumNotes.Snare,DrumNotes.Silence,DrumNotes.Snare,DrumNotes.Snare
                }
            };

            Drums.Add(beat);
            Drums.Add(beat);
            Drums.Add(beatbridgge);
        }
    }
}
