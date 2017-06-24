using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.ML
{
    public class Guitar2 : Song
    {
        public Guitar2()
        {
            MelodyNoteCollection part1 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 90,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.H3,MelodyNotes.H5,MelodyNotes.H6,
                    MelodyNotes.H3,MelodyNotes.H5,MelodyNotes.H6,
                    MelodyNotes.H3,MelodyNotes.H5,MelodyNotes.H6,
                    MelodyNotes.H3,MelodyNotes.H5,MelodyNotes.H6,
                }
            };

            MelodyNoteCollection part1G = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 120,
                MilliSecondsPerSound = 90,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G0,MelodyNotes.G2,MelodyNotes.G3
                }
            };

            MelodyNoteCollection part1Break = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 180 * (14 + 14 + 2),
                MilliSecondsPerSound = 90,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence
                }
            };

            MelodyNoteCollection part2H = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 90,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.H4,MelodyNotes.Silence,
                    MelodyNotes.H4,MelodyNotes.Silence,
                    MelodyNotes.H4,MelodyNotes.Silence,
                    MelodyNotes.H4,MelodyNotes.H3,
                    MelodyNotes.H1,MelodyNotes.Silence,
                    MelodyNotes.H1,MelodyNotes.Silence,
                    MelodyNotes.H1,MelodyNotes.Silence,
                    MelodyNotes.H1,MelodyNotes.Silence,
                }
            };

            MelodyNoteCollection part2zusatz = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 90,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,
                    MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,
                    MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,
                    MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,
                }
            };

            MelodyNoteCollection part3 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 120,
                MilliSecondsPerSound = 90,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G3,MelodyNotes.G2,MelodyNotes.G0,
                    MelodyNotes.H3,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.G3,MelodyNotes.G2,MelodyNotes.G0,
                    MelodyNotes.G3,MelodyNotes.G2,MelodyNotes.G0,
                    MelodyNotes.H3,MelodyNotes.Silence,MelodyNotes.Silence,
                }
            };

            MelodyNoteCollection part4 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 90,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E7,MelodyNotes.Silence,MelodyNotes.H6,MelodyNotes.Silence,MelodyNotes.H5,MelodyNotes.Silence,
                    MelodyNotes.E6,MelodyNotes.H5,MelodyNotes.Silence,MelodyNotes.H4,MelodyNotes.Silence,
                    MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.E6,
                    MelodyNotes.H4,MelodyNotes.Silence,MelodyNotes.H5,MelodyNotes.Silence,MelodyNotes.H6,MelodyNotes.Silence,
                    MelodyNotes.E4,

                    MelodyNotes.E7,MelodyNotes.Silence,MelodyNotes.H6,MelodyNotes.Silence,MelodyNotes.H5,MelodyNotes.Silence,
                    MelodyNotes.E6,MelodyNotes.H5,MelodyNotes.Silence,MelodyNotes.H4,MelodyNotes.Silence,
                    MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.E6,

                    MelodyNotes.H4, MelodyNotes.H5, MelodyNotes.H6, MelodyNotes.H7,
                    MelodyNotes.E4, MelodyNotes.E5, MelodyNotes.E6, MelodyNotes.E7,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence
                }
            };



            Guitar = new List<MelodyNoteCollection>();
            PitchedGuitar = new List<MelodyNoteCollection>();

            Guitar.Add(part1);
            Guitar.Add(part1G);

            Guitar.Add(part1);
            Guitar.Add(part1G);
            Guitar.Add(part1G);

            Guitar.Add(part2H);

            Guitar.Add(part3);
            Guitar.Add(part3);
            Guitar.Add(part3);
            Guitar.Add(part3);

            Guitar.Add(part4);

            PitchedGuitar.Add(part1Break);

            PitchedGuitar.Add(part2zusatz);


            ///////////////////////////////////////////////////////7

            BassLine = new List<BassNoteCollection>();

            BassNoteCollection raff = new BassNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.Silence,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.Silence,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.Silence,BassNotes.E0,BassNotes.Silence,
                }
            };

            //BassLine.Add(raff);
            //BassLine.Add(raff);
            //BassLine.Add(raff);
            //BassLine.Add(raff);
            //BassLine.Add(raff);
            //BassLine.Add(raff);
            //BassLine.Add(raff);
            //BassLine.Add(raff);
            //BassLine.Add(raff);
            //BassLine.Add(raff);
            //BassLine.Add(raff);
        }
    }
}
