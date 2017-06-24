using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class Song19 : Song
    {
        public Song19()
        {
            Guitar = new List<MelodyNoteCollection>();

            MelodyNoteCollection melodyE = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 540,
                MilliSecondsPerSound = 120,
                SoundType = SoundType.Guitar,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.H1,MelodyNotes.H3,MelodyNotes.H7,MelodyNotes.H4,MelodyNotes.H8,MelodyNotes.H2,MelodyNotes.H1,
                    MelodyNotes.H7,MelodyNotes.H6,MelodyNotes.H2,MelodyNotes.H5,MelodyNotes.H9,MelodyNotes.H1,MelodyNotes.H3,
                }
            };

            MelodyNoteCollection melodyEF = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 840,
                MilliSecondsPerSound = 120,
                SoundType = SoundType.Guitar,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.H1,MelodyNotes.H3,MelodyNotes.H7,MelodyNotes.H4,MelodyNotes.H8,MelodyNotes.H2,MelodyNotes.H1,
                  
                }
            };

            Guitar.Add(melodyE);
            Guitar.Add(melodyE);
            Guitar.Add(melodyE); 
            Guitar.Add(melodyE);
            Guitar.Add(melodyEF);
            Guitar.Add(melodyEF);
            Guitar.Add(melodyE);
            Guitar.Add(melodyE);

            BassLine = new List<BassNoteCollection>();


            BassNoteCollection bassE = new BassNoteCollection
            {
                MilliSecondsPerBeat = 270,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.Silence,BassNotes.E0,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                    BassNotes.E0,BassNotes.E0,BassNotes.Silence,BassNotes.E0,BassNotes.E6,BassNotes.E6,BassNotes.E6,
                    BassNotes.E0,BassNotes.E0,BassNotes.Silence,BassNotes.E0,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                    BassNotes.E0,BassNotes.E0,BassNotes.Silence,BassNotes.E0,BassNotes.E6,BassNotes.E6,BassNotes.E6,
                }
            };

            BassNoteCollection bassG = new BassNoteCollection
            {
                MilliSecondsPerBeat = 270,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E3,BassNotes.E3,BassNotes.Silence,BassNotes.E3,BassNotes.E6,BassNotes.E6,BassNotes.E6,
                    BassNotes.E3,BassNotes.E3,BassNotes.Silence,BassNotes.E3,BassNotes.E9,BassNotes.E9,BassNotes.E9,
                    BassNotes.E3,BassNotes.E3,BassNotes.Silence,BassNotes.E3,BassNotes.E6,BassNotes.E6,BassNotes.E6,
                    BassNotes.E3,BassNotes.E3,BassNotes.Silence,BassNotes.E3,BassNotes.E9,BassNotes.E9,BassNotes.E9,
                }
            };

            BassNoteCollection bassAF = new BassNoteCollection
            {
                MilliSecondsPerBeat = 210,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A0,BassNotes.A0,BassNotes.Silence,BassNotes.A0,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                    BassNotes.A0,BassNotes.A0,BassNotes.Silence,BassNotes.A0,BassNotes.A6,BassNotes.A6,BassNotes.A6,
                    BassNotes.A0,BassNotes.A0,BassNotes.Silence,BassNotes.A0,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                    BassNotes.A0,BassNotes.A0,BassNotes.Silence,BassNotes.A0,BassNotes.A6,BassNotes.A6,BassNotes.A6,
                }
            };

            BassNoteCollection bassGF = new BassNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E3,BassNotes.E3,BassNotes.Silence,BassNotes.E3,BassNotes.E6,BassNotes.E6,BassNotes.E6,
                    BassNotes.E3,BassNotes.E3,BassNotes.Silence,BassNotes.E3,BassNotes.E9,BassNotes.E9,BassNotes.E9,
                    BassNotes.E3,BassNotes.E3,BassNotes.Silence,BassNotes.E3,BassNotes.E6,BassNotes.E6,BassNotes.E6,
                    BassNotes.E3,BassNotes.E3,BassNotes.Silence,BassNotes.E3,BassNotes.E9,BassNotes.E9,BassNotes.E9,
                    BassNotes.E3,BassNotes.E3,BassNotes.Silence,BassNotes.E3,BassNotes.E9,BassNotes.E9,BassNotes.E9,
                    BassNotes.E3,BassNotes.E3,BassNotes.Silence,BassNotes.E3,BassNotes.E6,BassNotes.E6,BassNotes.E6,
                }
            };

            BassLine.Add(bassE);
            BassLine.Add(bassE);
            BassLine.Add(bassG);
            BassLine.Add(bassG);
            BassLine.Add(bassAF);
            BassLine.Add(bassAF);
            BassLine.Add(bassGF);
            BassLine.Add(bassGF);

            SecondGuitar = new List<MelodyNoteCollection>();

            MelodyNoteCollection melody = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 100,
                SoundType = SoundType.Faded,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E4,MelodyNotes.E3,MelodyNotes.E4,MelodyNotes.E5,
                    MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E4,MelodyNotes.E3,MelodyNotes.E4,MelodyNotes.E5,
                    MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E4,MelodyNotes.E3,MelodyNotes.E4,MelodyNotes.E5,
                    MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E4,MelodyNotes.E3,MelodyNotes.E4,MelodyNotes.E5,
                    MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E4,MelodyNotes.E3,MelodyNotes.E4,MelodyNotes.E5,
                    MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E4,MelodyNotes.E3,MelodyNotes.E4,MelodyNotes.E5,
                    MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E4,MelodyNotes.E3,MelodyNotes.E4,MelodyNotes.E5,
                }
            };

            MelodyNoteCollection melody2 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 180,
                MilliSecondsPerSound = 100,
                SoundType = SoundType.Faded,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E6,MelodyNotes.E7,MelodyNotes.E8,
                    MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E6,MelodyNotes.E7,MelodyNotes.E8,
                    MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E6,MelodyNotes.E7,MelodyNotes.E8,
                    MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E6,MelodyNotes.E7,MelodyNotes.E8,
                    MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E6,MelodyNotes.E7,MelodyNotes.E8,
                    MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E6,MelodyNotes.E7,MelodyNotes.E8,
                    MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E6,MelodyNotes.E7,MelodyNotes.E8,
                }
            };

            MelodyNoteCollection melodyF = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 140,
                MilliSecondsPerSound = 100,
                SoundType = SoundType.Faded,
                Melody = new List<MelodyNotes> 
                {
                   MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E9,MelodyNotes.E10,
                    MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E9,MelodyNotes.E10,
                    MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E9,MelodyNotes.E10,
                    MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E9,MelodyNotes.E10,
                    MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E9,MelodyNotes.E10,
                    MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E9,MelodyNotes.E10,
                    MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E9,MelodyNotes.E10,
                }
            };

            SecondGuitar.Add(melody);
            SecondGuitar.Add(melody);
            SecondGuitar.Add(melody2);
            SecondGuitar.Add(melody2);
            SecondGuitar.Add(melodyF);
            SecondGuitar.Add(melodyF);
            SecondGuitar.Add(melody2);
            SecondGuitar.Add(melody2);
        }
    }
}
