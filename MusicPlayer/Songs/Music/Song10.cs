using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class Song10 : Song
    {
        public Song10()
        {
            BassNoteCollection orientBass = new BassNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.Silence,BassNotes.Silence,BassNotes.E1,BassNotes.E4,
                    BassNotes.Silence, BassNotes.E5,BassNotes.Silence,BassNotes.E4,BassNotes.E5,BassNotes.E4,
                    BassNotes.E1,BassNotes.E0,BassNotes.Silence,BassNotes.E1,BassNotes.Silence,
                    BassNotes.E4,BassNotes.E5,BassNotes.E4,
                    BassNotes.E1,BassNotes.E0,BassNotes.Silence,BassNotes.A5,BassNotes.Silence,
                    BassNotes.E0,BassNotes.Silence,BassNotes.Silence,BassNotes.Silence,BassNotes.Silence,
                    BassNotes.Silence,BassNotes.Silence,
                    BassNotes.Silence
                }
            };

            BassNoteCollection orientBassStraight = new BassNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E1,BassNotes.E4,
                    BassNotes.E4, BassNotes.E5,BassNotes.E5,BassNotes.E4,BassNotes.E5,BassNotes.E4,
                    BassNotes.E1,BassNotes.E0,BassNotes.E0,BassNotes.E1,BassNotes.E1,
                    BassNotes.E4,BassNotes.E5,BassNotes.E4,
                    BassNotes.E1,BassNotes.E0,BassNotes.E0,BassNotes.A5,BassNotes.A5,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,
                    BassNotes.E0
                }
            };

            BassNoteCollection orientBassVariant1 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E1,BassNotes.E4,
                    BassNotes.E5,BassNotes.E8,BassNotes.E5,BassNotes.E4,
                    BassNotes.E1,BassNotes.E0,BassNotes.E1,BassNotes.E4,
                    BassNotes.E5,BassNotes.E8,BassNotes.E5,BassNotes.E4,
                    BassNotes.E0,BassNotes.E0,BassNotes.A5,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                }
            };

            BassNoteCollection orientBassBreak = new BassNoteCollection
            {
                MilliSecondsPerBeat = 180 * (32),
                MilliSecondsPerSound = 120 ,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.Silence
                }
            };
            BassLine = new List<BassNoteCollection>();

            //strophe
            BassLine.Add(orientBassBreak);
            BassLine.Add(orientBassBreak);
            BassLine.Add(orientBassStraight);
            BassLine.Add(orientBassStraight);
            //BassLine.Add(orientBassStraight);
            BassLine.Add(orientBassVariant1);
            BassLine.Add(orientBassVariant1);

            //solo
            BassLine.Add(orientBassStraight);
            BassLine.Add(orientBassVariant1);
            //BassLine.Add(orientBassVariant1);
            //BassLine.Add(orientBassStraight);
            //BassLine.Add(orientBassStraight);
            BassLine.Add(orientBassVariant1);

            BassLine.Add(orientBassStraight);
            BassLine.Add(orientBassStraight);
            BassLine.Add(orientBassStraight);

            BassLine.Add(orientBassVariant1);
            BassLine.Add(orientBassVariant1);

            MelodyNoteCollection orient = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 120,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.E1,MelodyNotes.E4,
                    MelodyNotes.Silence, MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.E4,MelodyNotes.E5,MelodyNotes.E4,
                    MelodyNotes.E1,MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.E1,MelodyNotes.Silence,
                    MelodyNotes.E4,MelodyNotes.E5,MelodyNotes.E4,
                    MelodyNotes.E1,MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.H3,MelodyNotes.Silence,
                    MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence
                }
            };

            //MelodyNoteCollection orientLow = new MelodyNoteCollection
            //{
            //    MilliSecondsPerBeat = 180,
            //    MilliSecondsPerSound = 120,
            //    Melody = new List<MelodyNotes> 
            //    {
            //        MelodyNotes.H0,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.H1,MelodyNotes.H4,
            //        MelodyNotes.Silence, MelodyNotes.H5,MelodyNotes.Silence,MelodyNotes.H4,MelodyNotes.H5,MelodyNotes.H4,
            //        MelodyNotes.H1,MelodyNotes.H0,MelodyNotes.Silence,MelodyNotes.H1,MelodyNotes.Silence,
            //        MelodyNotes.H4,MelodyNotes.H5,MelodyNotes.H4,
            //        MelodyNotes.H1,MelodyNotes.H0,MelodyNotes.Silence,MelodyNotes.G2,MelodyNotes.Silence,
            //        MelodyNotes.H0,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
            //        MelodyNotes.Silence,MelodyNotes.Silence,
            //        MelodyNotes.Silence
            //    }
            //};

            MelodyNoteCollection orientLow = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 120,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.H0,MelodyNotes.H0,MelodyNotes.H0,MelodyNotes.H1,MelodyNotes.H4,
                    MelodyNotes.H4, MelodyNotes.H5,MelodyNotes.H5,MelodyNotes.H4,MelodyNotes.H5,MelodyNotes.H4,
                    MelodyNotes.H1,MelodyNotes.H0,MelodyNotes.H0,MelodyNotes.H1,MelodyNotes.H1,
                    MelodyNotes.H4,MelodyNotes.H5,MelodyNotes.H4,
                    MelodyNotes.H1,MelodyNotes.H0,MelodyNotes.H0,MelodyNotes.G2,MelodyNotes.G2,
                    MelodyNotes.H0,MelodyNotes.H0,MelodyNotes.H0,MelodyNotes.H0,MelodyNotes.H0,
                    MelodyNotes.H0,MelodyNotes.H0,
                    MelodyNotes.H0
                }
            };

            MelodyNoteCollection orientVariant1 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 120,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.E1,MelodyNotes.E4,
                    MelodyNotes.E5,MelodyNotes.E8,MelodyNotes.E5,MelodyNotes.E4,
                    MelodyNotes.E1,MelodyNotes.E0,MelodyNotes.E1,MelodyNotes.E4,
                    MelodyNotes.E5,MelodyNotes.E8,MelodyNotes.E5,MelodyNotes.E4,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.H3,MelodyNotes.E0,
                    MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                }
            };

            MelodyNoteCollection orientSolo = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 120,
                MilliSecondsPerSound = 120,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E8,MelodyNotes.E5,MelodyNotes.E4,
                    MelodyNotes.E8,MelodyNotes.E5,MelodyNotes.E4,
                    MelodyNotes.E8,MelodyNotes.E5,MelodyNotes.E4,
                    MelodyNotes.E0,MelodyNotes.E1,MelodyNotes.E4,
                }
            };

            MelodyNoteCollection orientSolo2 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 120,
                MilliSecondsPerSound = 120,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E11,MelodyNotes.E8,MelodyNotes.E7,
                    MelodyNotes.E11,MelodyNotes.E8,MelodyNotes.E7,
                    MelodyNotes.E11,MelodyNotes.E8,MelodyNotes.E7,
                    MelodyNotes.E1,MelodyNotes.E4,MelodyNotes.E5
                }
            };

            MelodyNoteCollection orientSolo3 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 120,
                MilliSecondsPerSound = 120,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E11,MelodyNotes.E8,MelodyNotes.E7,
                    MelodyNotes.E8,MelodyNotes.E5,MelodyNotes.E4,
                    MelodyNotes.E5,MelodyNotes.E4,MelodyNotes.E1,
                    MelodyNotes.E4,MelodyNotes.E1,MelodyNotes.E0
                }
            };

            MelodyNoteCollection orientBreak = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 180 * (32),
                MilliSecondsPerSound = 120,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence
                }
            };

            Guitar = new List<MelodyNoteCollection>();

            Guitar.Add(orient);
            Guitar.Add(orient);
            Guitar.Add(orient);
            Guitar.Add(orient);
            Guitar.Add(orientVariant1);
            Guitar.Add(orientVariant1);

            Guitar.Add(orientSolo);
            Guitar.Add(orientSolo);
            Guitar.Add(orientSolo);
            Guitar.Add(orientSolo);

            Guitar.Add(orientSolo2);
            Guitar.Add(orientSolo2);
            Guitar.Add(orientSolo2);
            Guitar.Add(orientSolo2);


            Guitar.Add(orientSolo2);
            Guitar.Add(orientSolo2);
            Guitar.Add(orientSolo2);
            Guitar.Add(orientSolo2);

            Guitar.Add(orientSolo3);
            Guitar.Add(orientSolo3);
            Guitar.Add(orientSolo3);
            Guitar.Add(orientSolo3);

            Guitar.Add(orientLow);

            Guitar.Add(orientSolo3);
            Guitar.Add(orientSolo3);
            Guitar.Add(orientSolo3);
            Guitar.Add(orientSolo3);

            Guitar.Add(orientVariant1);
            Guitar.Add(orientVariant1);

            SecondGuitar = new List<MelodyNoteCollection>();

            SecondGuitar.Add(orientLow);
            SecondGuitar.Add(orientLow);
            SecondGuitar.Add(orientBreak);
            SecondGuitar.Add(orientBreak);
            SecondGuitar.Add(orientBreak);
            SecondGuitar.Add(orientBreak);
            SecondGuitar.Add(orientBreak);
            SecondGuitar.Add(orientBreak);
        }
    }
}
