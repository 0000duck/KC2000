using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class Song17 : Song
    {
        public Song17()
        {
            Guitar = new List<MelodyNoteCollection>();

            MelodyNoteCollection melodyIntro = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 125,
                MilliSecondsPerSound = 120,
                SoundType = SoundType.Guitar,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.E9, MelodyNotes.Silence,MelodyNotes.E12,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.E12,MelodyNotes.Silence,MelodyNotes.E12,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.E12,
                    MelodyNotes.E10,MelodyNotes.Silence,MelodyNotes.E9,MelodyNotes.Silence,MelodyNotes.E10,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.E7,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,

                    MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.E4,MelodyNotes.Silence,MelodyNotes.E7, MelodyNotes.Silence,MelodyNotes.E10,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.E10,MelodyNotes.Silence,MelodyNotes.E10,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.E10,
                    MelodyNotes.E9,MelodyNotes.Silence,MelodyNotes.E7,MelodyNotes.Silence,
                    MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,

                    MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.E9, MelodyNotes.Silence,MelodyNotes.E12,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.E12,MelodyNotes.Silence,MelodyNotes.E12,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.E12,
                    MelodyNotes.E10,MelodyNotes.Silence,MelodyNotes.E9,MelodyNotes.Silence,MelodyNotes.E10,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.E7,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,

                     MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.E4,MelodyNotes.Silence,MelodyNotes.E5, MelodyNotes.Silence,MelodyNotes.E7,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.E10,MelodyNotes.Silence,MelodyNotes.E10,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.E10,
                    MelodyNotes.E9,MelodyNotes.Silence,MelodyNotes.E7,MelodyNotes.Silence,
                    MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                }
            };

            MelodyNoteCollection melodybreak = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 125,
                MilliSecondsPerSound = 120,
                SoundType = SoundType.Guitar,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,
                }
            };

            MelodyNoteCollection melodyMain = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 125,
                MilliSecondsPerSound = 120,
                SoundType = SoundType.Guitar,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.H5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H7,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H2,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H2,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H2,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                     MelodyNotes.H5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H7,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H0,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H0,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H0,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,

                    MelodyNotes.H5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H7,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H9,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,

                    MelodyNotes.H7,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.H5,MelodyNotes.Silence,
                    
                    MelodyNotes.H7,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,

                    MelodyNotes.H2,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H2,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H2,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                }
            };

            MelodyNoteCollection melodyFinale = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 125,
                MilliSecondsPerSound = 120,
                SoundType = SoundType.Guitar,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.H5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H2,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.H5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.E9,MelodyNotes.Silence,
                    MelodyNotes.E9,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.E9,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.E7,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.E4,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.E10,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.E5,MelodyNotes.Silence,
                    MelodyNotes.E10,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.E7,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.E7,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.E9,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,

                    MelodyNotes.H5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.E4,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.E7,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.E4,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                }
            };

            Guitar.Add(melodyIntro);

            Guitar.Add(melodybreak);
            Guitar.Add(melodyMain);
            Guitar.Add(melodyMain);
            Guitar.Add(melodyFinale);
            Guitar.Add(melodybreak);
            Guitar.Add(melodybreak);

            BassLine = new List<BassNoteCollection>();

            BassNoteCollection bassBreak = new BassNoteCollection
            {
                MilliSecondsPerBeat = (125 * 32 * 3) + (125 * 22),
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.Silence
                }
            };

            BassNoteCollection bassE0 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 500,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A0,BassNotes.E0,BassNotes.A0,BassNotes.E0,
                    BassNotes.A0,BassNotes.E0,BassNotes.A0,BassNotes.E0,
                    BassNotes.A0,BassNotes.E0,BassNotes.A0,BassNotes.E0,
                    BassNotes.A0,BassNotes.E0,BassNotes.A0,BassNotes.E0,
                }
            };

            BassNoteCollection bassE0slow = new BassNoteCollection
            {
                MilliSecondsPerBeat = 1000,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A0,BassNotes.E0,BassNotes.A0,BassNotes.E0,
                    BassNotes.A0,BassNotes.E0,BassNotes.A0,BassNotes.E0,BassNotes.Silence,BassNotes.Silence
                }
            };
            BassLine.Add(bassBreak);
            BassLine.Add(bassE0);
            BassLine.Add(bassE0);

            BassLine.Add(bassE0);
            BassLine.Add(bassE0);
            BassLine.Add(bassE0);
            BassLine.Add(bassE0);
            BassLine.Add(bassE0slow);


            PitchedGuitar = new List<MelodyNoteCollection>();

         
     
        }
    }
}
