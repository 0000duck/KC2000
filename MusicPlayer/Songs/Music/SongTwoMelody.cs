using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class SongTwoMelody : SongTwo
    {
        public SongTwoMelody()
        {
            Guitar = new List<MelodyNoteCollection>();

            MelodyNoteCollection melodyMainFast = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 120,
                MilliSecondsPerSound = 60,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.E3,MelodyNotes.E3,MelodyNotes.E3,MelodyNotes.E3,MelodyNotes.E5,MelodyNotes.E5,MelodyNotes.E5,MelodyNotes.E5,
                    MelodyNotes.E8,MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E7,MelodyNotes.E6,MelodyNotes.E6,

                    MelodyNotes.E5,MelodyNotes.E5,MelodyNotes.E5,MelodyNotes.E5,MelodyNotes.E5,MelodyNotes.E5,MelodyNotes.E5,MelodyNotes.E5,
                    MelodyNotes.E5,MelodyNotes.E5,MelodyNotes.E5,MelodyNotes.E5,MelodyNotes.E5,MelodyNotes.E5,MelodyNotes.E5,MelodyNotes.E5,
                    MelodyNotes.E7,MelodyNotes.E7,MelodyNotes.E7,MelodyNotes.E7,MelodyNotes.E8,MelodyNotes.E8,MelodyNotes.E8,MelodyNotes.E8,
                    MelodyNotes.E7,MelodyNotes.E7,MelodyNotes.E5,MelodyNotes.E5,MelodyNotes.E3,MelodyNotes.E3,
                }
            };

            MelodyNoteCollection melodyMain = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.E0,
                    MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E5,
                    MelodyNotes.E3,MelodyNotes.Silence,MelodyNotes.E3,MelodyNotes.Silence,MelodyNotes.E3,
                    MelodyNotes.E5,MelodyNotes.E7,
                    
                    //MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.E0,
                    //MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E3,
                    //MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.E5,MelodyNotes.Silence,MelodyNotes.E3,
                    //MelodyNotes.E5,MelodyNotes.E7,
                }
            };

            MelodyNoteCollection melodyOne = new MelodyNoteCollection
            {
                MilliSecondsPerSound = 120,
                MilliSecondsPerBeat = 120,

                Melody = new List<MelodyNotes>
                { 
                    MelodyNotes.E0, MelodyNotes.E1, MelodyNotes.E2,MelodyNotes.E3,MelodyNotes.E4,
                    MelodyNotes.E5, MelodyNotes.E6, MelodyNotes.E7,MelodyNotes.E8,MelodyNotes.E8,
                    MelodyNotes.E7,MelodyNotes.E7,MelodyNotes.E5,MelodyNotes.E5,
                    MelodyNotes.E0, MelodyNotes.E1, MelodyNotes.E2,MelodyNotes.E3,MelodyNotes.E4,
                    MelodyNotes.E5, MelodyNotes.E6, MelodyNotes.E7,MelodyNotes.E7,MelodyNotes.E7,
                    MelodyNotes.E5,MelodyNotes.E5,MelodyNotes.E3,MelodyNotes.E3,
                }
            };

            MelodyNoteCollection melodyThree = new MelodyNoteCollection
            {
                MilliSecondsPerSound = 120,
                MilliSecondsPerBeat = 120,

                Melody = new List<MelodyNotes>
                { 
                    MelodyNotes.E0, MelodyNotes.E7, MelodyNotes.E0,MelodyNotes.E7,MelodyNotes.E0,
                    MelodyNotes.E7, MelodyNotes.E0, MelodyNotes.E7,MelodyNotes.E3,MelodyNotes.E3,
                    MelodyNotes.E5,MelodyNotes.E5,MelodyNotes.E7,MelodyNotes.E7,
                    MelodyNotes.E0, MelodyNotes.E8, MelodyNotes.E0,MelodyNotes.E8,MelodyNotes.E0,
                    MelodyNotes.E8, MelodyNotes.E0, MelodyNotes.E8,MelodyNotes.E3,MelodyNotes.E3,
                    MelodyNotes.E5,MelodyNotes.E5,MelodyNotes.E8,MelodyNotes.E8,
                }
            };

            //bisher am Anfang zweimal mainmelody

            Guitar.Add(melodyMain);
            Guitar.Add(melodyMain);
            //Melody.Add(melodyMain);
            //Melody.Add(melodyMain);

            Guitar.Add(melodyOne);
            Guitar.Add(melodyOne);
            Guitar.Add(melodyThree);
            Guitar.Add(melodyThree);

            Guitar.Add(melodyMainFast);
            Guitar.Add(melodyMainFast);
            //Melody.Add(melodyMain);
            //Melody.Add(melodyMain);

            Guitar.Add(melodyOne);
            Guitar.Add(melodyOne);
            Guitar.Add(melodyThree);
            Guitar.Add(melodyThree);
        }
    }
}
