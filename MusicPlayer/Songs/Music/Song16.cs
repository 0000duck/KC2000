using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MusicPlayer.Songs.Music
{
    public class Song16 : Song
    {
        public Song16()
        {
            Guitar = new List<MelodyNoteCollection>();

            MelodyNoteCollection melody3 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 130,
                MilliSecondsPerSound = 120,
                SoundType = SoundType.Guitar,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.G0,MelodyNotes.H0, MelodyNotes.E0,
                    MelodyNotes.G2,MelodyNotes.G5,MelodyNotes.E0, MelodyNotes.E5,
                    MelodyNotes.E0,MelodyNotes.G0,MelodyNotes.H0, MelodyNotes.E0,
                    MelodyNotes.G2,MelodyNotes.G5,MelodyNotes.E0, MelodyNotes.E5,
                }
            };

            MelodyNoteCollection melody1 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 130,
                MilliSecondsPerSound = 120,
                SoundType = SoundType.Guitar,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G0,MelodyNotes.H0, MelodyNotes.E0,
                    MelodyNotes.G2,MelodyNotes.G5,MelodyNotes.E0, MelodyNotes.E5,
                    MelodyNotes.E0,MelodyNotes.G0,MelodyNotes.H0, MelodyNotes.E0,
                    MelodyNotes.G2,MelodyNotes.G5,MelodyNotes.E0, MelodyNotes.E5,
                    MelodyNotes.E8,
                }
            };

            Guitar.Add(melody3);
            Guitar.Add(melody3);
            Guitar.Add(melody3);
            Guitar.Add(melody3);
            Guitar.Add(melody3);
            Guitar.Add(melody3);
            Guitar.Add(melody3);
            Guitar.Add(melody3);

            Guitar.Add(melody3);
            Guitar.Add(melody3);
            Guitar.Add(melody3);
            Guitar.Add(melody3);
            Guitar.Add(melody3);
            Guitar.Add(melody3);
            Guitar.Add(melody3);
            Guitar.Add(melody3);

            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);
            Guitar.Add(melody1);

            BassLine = new List<BassNoteCollection>();

            BassNoteCollection bassE0 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 130,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                }
            };

            BassNoteCollection bassE2 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 130,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E2,BassNotes.E2,BassNotes.E2,BassNotes.E2,
                    BassNotes.E2,BassNotes.E2,BassNotes.E2,BassNotes.E2,
                    BassNotes.E2,BassNotes.E2,BassNotes.E2,BassNotes.E2,
                    BassNotes.E2,BassNotes.E2,BassNotes.E2,BassNotes.E2,
                }
            };


            BassNoteCollection bassE3 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 130,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                    BassNotes.E3,BassNotes.E3,BassNotes.E3,BassNotes.E3,
                }
            };

            BassNoteCollection bassE6 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 130,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E6,BassNotes.E6,BassNotes.E6,BassNotes.E6,
                    BassNotes.E6,BassNotes.E6,BassNotes.E6,BassNotes.E6,
                    BassNotes.E6,BassNotes.E6,BassNotes.E6,BassNotes.E6,
                    BassNotes.E6,BassNotes.E6,BassNotes.E6,BassNotes.E6,
                }
            };

            BassNoteCollection bassE7 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 130,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,
                    BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,
                    BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,
                    BassNotes.E7,BassNotes.E7,BassNotes.E7,BassNotes.E7,
                }
            };

            BassNoteCollection bassA0 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 130,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                }
            };

            BassNoteCollection bassA3 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 130,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A3,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                    BassNotes.A3,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                    BassNotes.A3,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                    BassNotes.A3,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                }
            };

            BassNoteCollection bassA5 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 130,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A5,BassNotes.A5,BassNotes.A5,BassNotes.A5,
                    BassNotes.A5,BassNotes.A5,BassNotes.A5,BassNotes.A5,
                    BassNotes.A5,BassNotes.A5,BassNotes.A5,BassNotes.A5,
                    BassNotes.A5,BassNotes.A5,BassNotes.A5,BassNotes.A5,
                }
            };

            BassNoteCollection bassA7 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 130,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A7,BassNotes.A7,BassNotes.A7,BassNotes.A7,
                    BassNotes.A7,BassNotes.A7,BassNotes.A7,BassNotes.A7,
                    BassNotes.A7,BassNotes.A7,BassNotes.A7,BassNotes.A7,
                    BassNotes.A7,BassNotes.A7,BassNotes.A7,BassNotes.A7,
                }
            };

            BassNoteCollection bassA10 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 130,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A10,BassNotes.A10,BassNotes.A10,BassNotes.A10,
                    BassNotes.A10,BassNotes.A10,BassNotes.A10,BassNotes.A10,
                    BassNotes.A10,BassNotes.A10,BassNotes.A10,BassNotes.A10,
                    BassNotes.A10,BassNotes.A10,BassNotes.A10,BassNotes.A10,
                }
            };

            BassLine.Add(bassE6);
            BassLine.Add(bassE6);
            BassLine.Add(bassA0);
            BassLine.Add(bassA0);
            BassLine.Add(bassE3);
            BassLine.Add(bassE3);
            BassLine.Add(bassE2);
            BassLine.Add(bassE2);

            BassLine.Add(bassE6);
            BassLine.Add(bassE6);
            BassLine.Add(bassA0);
            BassLine.Add(bassA0);
            BassLine.Add(bassE3);
            BassLine.Add(bassE3);
            BassLine.Add(bassE2);
            BassLine.Add(bassE2);

            BassLine.Add(bassE0);
            BassLine.Add(bassE0);
            BassLine.Add(bassE7);
            BassLine.Add(bassE7);
            BassLine.Add(bassE3);
            BassLine.Add(bassE3);
            BassLine.Add(bassA5);
            BassLine.Add(bassA5);
            BassLine.Add(bassA0);
            BassLine.Add(bassA0);
            BassLine.Add(bassA7);
            BassLine.Add(bassA7);
            BassLine.Add(bassA3);
            BassLine.Add(bassA3);
            BassLine.Add(bassA10);
            BassLine.Add(bassA10);
            BassLine.Add(bassA5);
            BassLine.Add(bassA5);
            BassLine.Add(bassA0);
            BassLine.Add(bassA0);
            BassLine.Add(bassA3);
            BassLine.Add(bassA3);
            BassLine.Add(bassE0);
            BassLine.Add(bassE0);

            PitchedGuitar = new List<MelodyNoteCollection>();

         
        
        }
    }
}

