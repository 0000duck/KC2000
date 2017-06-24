using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class FinalSpeedMetal : Song
    {
        public FinalSpeedMetal()
        {

            Guitar = new List<MelodyNoteCollection>();

            PitchedGuitar = new List<MelodyNoteCollection>();
            BassLine = new List<BassNoteCollection>();
            SecondGuitar = new List<MelodyNoteCollection>();

            BassNoteCollection Efast = new BassNoteCollection
            {
                MilliSecondsPerBeat = 90,
                MilliSecondsPerSound = 70,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E0, BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0, BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0, BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0, BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0, BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0, BassNotes.E0,BassNotes.E0, BassNotes.E0,
                }
            };

            BassNoteCollection Afast = new BassNoteCollection
            {
                MilliSecondsPerBeat = 90,
                MilliSecondsPerSound = 70,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A0,BassNotes.A0,BassNotes.A0, BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0, BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0, BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0, BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0, BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0, BassNotes.A0,BassNotes.A0, BassNotes.A0,
                }
            };

            BassNoteCollection Hfast = new BassNoteCollection
            {
                MilliSecondsPerBeat = 90,
                MilliSecondsPerSound = 70,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A2,BassNotes.A2,BassNotes.A2, BassNotes.A2,
                    BassNotes.A2,BassNotes.A2,BassNotes.A2, BassNotes.A2,
                    BassNotes.A2,BassNotes.A2,BassNotes.A2, BassNotes.A2,
                    BassNotes.A2,BassNotes.A2,BassNotes.A2, BassNotes.A2,
                    BassNotes.A2,BassNotes.A2,BassNotes.A2, BassNotes.A2,
                    BassNotes.A2,BassNotes.A2,BassNotes.A2, BassNotes.A2,BassNotes.A2, BassNotes.A2,
                }
            };

            BassNoteCollection SlowDownE = new BassNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 140,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A8,BassNotes.A7,BassNotes.A5,
                }
            };
            BassNoteCollection SlowDownA = new BassNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 140,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A8,BassNotes.A7,BassNotes.A3,
                }
            };

            ////strophe
            BassLine.Add(Efast);
            BassLine.Add(SlowDownE);
            BassLine.Add(Efast);
            BassLine.Add(SlowDownE);
            BassLine.Add(Afast);
            BassLine.Add(SlowDownA);
            BassLine.Add(Efast);
            BassLine.Add(SlowDownE);
            BassLine.Add(Hfast);
            BassLine.Add(SlowDownA);
            BassLine.Add(Afast);
            BassLine.Add(SlowDownA);

            BassLine.Add(Efast);
            BassLine.Add(SlowDownE);
            BassLine.Add(Efast);
            BassLine.Add(SlowDownE);
            BassLine.Add(Afast);
            BassLine.Add(SlowDownA);
            BassLine.Add(Efast);
            BassLine.Add(SlowDownE);
            BassLine.Add(Hfast);
            BassLine.Add(SlowDownA);
            BassLine.Add(Afast);
            BassLine.Add(SlowDownA);

            BassLine.Add(Efast);
            BassLine.Add(SlowDownE);
            BassLine.Add(Efast);
            BassLine.Add(SlowDownE);
            BassLine.Add(Afast);
            BassLine.Add(SlowDownA);
            BassLine.Add(Efast);
            BassLine.Add(SlowDownE);
            BassLine.Add(Hfast);
            BassLine.Add(SlowDownA);
            BassLine.Add(Afast);
            BassLine.Add(SlowDownA);

            BassLine.Add(Efast);
            BassLine.Add(SlowDownE);
            BassLine.Add(Efast);
            BassLine.Add(SlowDownE);
            BassLine.Add(Afast);
            BassLine.Add(SlowDownA);
            BassLine.Add(Efast);
            BassLine.Add(SlowDownE);
            BassLine.Add(Hfast);
            BassLine.Add(SlowDownA);
            BassLine.Add(Afast);
            BassLine.Add(SlowDownA);

            MelodyNoteCollection mbreak = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = ((26*90) + (180 * 3)) *6,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence
                }
            };

            MelodyNoteCollection m = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 90,
                MilliSecondsPerSound = 80,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.H8,MelodyNotes.H6,MelodyNotes.H5,MelodyNotes.H0,
                    MelodyNotes.H8,MelodyNotes.H6,MelodyNotes.H5,MelodyNotes.H0,
                    MelodyNotes.H8,MelodyNotes.H6,MelodyNotes.H5,MelodyNotes.H0,
                    MelodyNotes.H8,MelodyNotes.H6,MelodyNotes.H5,MelodyNotes.H0,
                    MelodyNotes.H8,MelodyNotes.H6,MelodyNotes.H5,MelodyNotes.H0,
                    MelodyNotes.H8,MelodyNotes.H6,MelodyNotes.H5,MelodyNotes.H0,MelodyNotes.H6,MelodyNotes.H5,

                    MelodyNotes.H8,MelodyNotes.H6,MelodyNotes.H5,MelodyNotes.H0,
                    MelodyNotes.H8,MelodyNotes.H6,
                }
            };


            Guitar.Add(mbreak);

            Guitar.Add(m);
            Guitar.Add(m);
            Guitar.Add(m);
            Guitar.Add(m);
            Guitar.Add(m);
            Guitar.Add(m);

            Guitar.Add(m);
            Guitar.Add(m);
            Guitar.Add(m);
            Guitar.Add(m);
            Guitar.Add(m);
            Guitar.Add(m);

            Guitar.Add(m);
            Guitar.Add(m);
            Guitar.Add(m);
            Guitar.Add(m);
            Guitar.Add(m);
            Guitar.Add(m);

            MelodyNoteCollection mslow = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 160,
                SoundType = SoundType.Guitar,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E8,MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E0,
                    MelodyNotes.E8,MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E0,
                    MelodyNotes.E8,MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E0,
                    MelodyNotes.E8,MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E0,
                    MelodyNotes.E8,MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E0,
                    MelodyNotes.E8,MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E0,MelodyNotes.E6,MelodyNotes.E5,

                    MelodyNotes.E8,MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E0,
                    MelodyNotes.E8,MelodyNotes.E6,
                }
            };

            SecondGuitar.Add(mbreak);
            SecondGuitar.Add(mbreak);
            SecondGuitar.Add(mslow);
            SecondGuitar.Add(mslow);
            SecondGuitar.Add(mslow);
            //SecondGuitar.Add(mslow);
            //SecondGuitar.Add(mslow);
            //SecondGuitar.Add(mslow);
        }
    }
}
