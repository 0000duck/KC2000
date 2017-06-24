using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class Song15 : Song
    {
        public Song15()
        {
            Guitar = new List<MelodyNoteCollection>();

            MelodyNoteCollection melodyBeat = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 240,
                SoundType = SoundType.Driller,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                    MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                    MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                    MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                }
            };

            MelodyNoteCollection melodyBreak = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240 * 16,
                MilliSecondsPerSound = 240,
                SoundType = SoundType.Driller,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence
                }
            };

            Guitar.Add(melodyBeat);
           // Guitar.Add(melodyBeat);

            Guitar.Add(melodyBeat);
            Guitar.Add(melodyBeat);
            Guitar.Add(melodyBeat);
            Guitar.Add(melodyBeat);

            Guitar.Add(melodyBeat);
            Guitar.Add(melodyBeat);
            Guitar.Add(melodyBeat);
            Guitar.Add(melodyBeat);

            Guitar.Add(melodyBeat);
            Guitar.Add(melodyBeat);
            Guitar.Add(melodyBeat);
            Guitar.Add(melodyBeat);

            Guitar.Add(melodyBeat);
            Guitar.Add(melodyBeat);
            Guitar.Add(melodyBeat);
            Guitar.Add(melodyBeat);

            //Guitar.Add(melodyBeat);
            //Guitar.Add(melodyBeat);
            //Guitar.Add(melodyBeat);
            //Guitar.Add(melodyBeat);

            //Guitar.Add(melodyBeat);
            //Guitar.Add(melodyBeat);
            //Guitar.Add(melodyBeat);
            //Guitar.Add(melodyBeat);

            BassLine = new List<BassNoteCollection>();

            BassNoteCollection bassBreak = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240 * 16,
                MilliSecondsPerSound = 200,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.Silence
                }
            };

            BassNoteCollection bassA7 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 200,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A7,BassNotes.A7,BassNotes.A7,BassNotes.A7,
                    BassNotes.A7,BassNotes.A7,BassNotes.A7,BassNotes.A7,
                    BassNotes.A7,BassNotes.A7,BassNotes.A7,BassNotes.A7,
                    BassNotes.A7,BassNotes.A7,BassNotes.A7,BassNotes.A7,
                }
            };

            BassNoteCollection bassA3 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 200,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A3,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                    BassNotes.A3,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                    BassNotes.A3,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                    BassNotes.A3,BassNotes.A3,BassNotes.A3,BassNotes.A3,
                }
            };

            BassNoteCollection bassA0 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 200,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,BassNotes.A0,
                }
            };

            BassNoteCollection bassA8 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 200,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A8,BassNotes.A8,BassNotes.A8,BassNotes.A8,
                    BassNotes.A8,BassNotes.A8,BassNotes.A8,BassNotes.A8,
                    BassNotes.A8,BassNotes.A8,BassNotes.A8,BassNotes.A8,
                    BassNotes.A8,BassNotes.A8,BassNotes.A8,BassNotes.A8,
                }
            };

            BassNoteCollection bassA5 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 200,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A5,BassNotes.A5,BassNotes.A5,BassNotes.A5,
                    BassNotes.A5,BassNotes.A5,BassNotes.A5,BassNotes.A5,
                    BassNotes.A5,BassNotes.A5,BassNotes.A5,BassNotes.A5,
                    BassNotes.A5,BassNotes.A5,BassNotes.A5,BassNotes.A5,
                }
            };
            BassNoteCollection bassE0 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 200,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                }
            };

            BassLine.Add(bassBreak);
          //  BassLine.Add(bassBreak);

            BassLine.Add(bassA7);
            BassLine.Add(bassA7);
            BassLine.Add(bassA3);
            BassLine.Add(bassA0);

            BassLine.Add(bassA7);
            BassLine.Add(bassA7);
            BassLine.Add(bassA3);
            BassLine.Add(bassA0);

            BassLine.Add(bassA7);
            BassLine.Add(bassA7);
            BassLine.Add(bassA3);
            BassLine.Add(bassA0);

            BassLine.Add(bassA7);
            BassLine.Add(bassA7);
            BassLine.Add(bassA3);
            BassLine.Add(bassA0);

            BassLine.Add(bassA0);
            BassLine.Add(bassA3);
            BassLine.Add(bassE0);
            BassLine.Add(bassE0);

            BassLine.Add(bassA0);
            BassLine.Add(bassA3);
            BassLine.Add(bassE0);
            BassLine.Add(bassE0);

            BassLine.Add(bassA0);
            BassLine.Add(bassA3);
            //BassLine.Add(bassE0);
            //BassLine.Add(bassE0);

            PitchedGuitar = new List<MelodyNoteCollection>();

            MelodyNoteCollection intro = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 120,
                MilliSecondsPerSound = 120,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                    MelodyNotes.H0,MelodyNotes.H1,MelodyNotes.H2,MelodyNotes.H3,
                    MelodyNotes.H4,MelodyNotes.H5,MelodyNotes.H6,MelodyNotes.H7,
                    MelodyNotes.H8,MelodyNotes.H9,MelodyNotes.H10,MelodyNotes.H11,
                    MelodyNotes.E7,MelodyNotes.E8,MelodyNotes.E9,MelodyNotes.E10,
                }
            };

            MelodyNoteCollection pitchedE3 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 240,
                SoundType = SoundType.Driller,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                    MelodyNotes.E3,MelodyNotes.E3,MelodyNotes.E3, MelodyNotes.E3,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                    MelodyNotes.E3,MelodyNotes.E3,MelodyNotes.E3, MelodyNotes.E3,
                }
            };
            MelodyNoteCollection pitchedH4 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 240,
                SoundType = SoundType.Driller,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                    MelodyNotes.H4,MelodyNotes.H4,MelodyNotes.H4, MelodyNotes.H4,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                    MelodyNotes.H4,MelodyNotes.H4,MelodyNotes.H4, MelodyNotes.H4,
                }
            };

            MelodyNoteCollection pitchedH0 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 240,
                SoundType = SoundType.Driller,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                    MelodyNotes.H0,MelodyNotes.H0,MelodyNotes.H0, MelodyNotes.H0,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                    MelodyNotes.H0,MelodyNotes.H0,MelodyNotes.H0, MelodyNotes.H0,
                }
            };

            MelodyNoteCollection pitchedH1 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 240,
                MilliSecondsPerSound = 240,
                SoundType = SoundType.Driller,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                    MelodyNotes.H1,MelodyNotes.H1,MelodyNotes.H1, MelodyNotes.H1,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                    MelodyNotes.H1,MelodyNotes.H1,MelodyNotes.H1, MelodyNotes.H1,
                }
            };

            MelodyNoteCollection sg1doppel = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 120,
                MilliSecondsPerSound = 120,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E12,MelodyNotes.E7,MelodyNotes.E3, MelodyNotes.E0,
                    MelodyNotes.E7,MelodyNotes.E3,MelodyNotes.E0, MelodyNotes.H4,
                    MelodyNotes.E12,MelodyNotes.E7,MelodyNotes.E3, MelodyNotes.E0,
                    MelodyNotes.E7,MelodyNotes.E3,MelodyNotes.E0, MelodyNotes.H4,
                    MelodyNotes.E12,MelodyNotes.E7,MelodyNotes.E3, MelodyNotes.E0,
                    MelodyNotes.E7,MelodyNotes.E3,MelodyNotes.E0, MelodyNotes.H4,
                    MelodyNotes.E12,MelodyNotes.E7,MelodyNotes.E3, MelodyNotes.E0,
                    MelodyNotes.E7,MelodyNotes.E3,MelodyNotes.E0, MelodyNotes.H4,
                }
            };

            PitchedGuitar.Add(melodyBreak);
          //  PitchedGuitar.Add(melodyBreak);

            PitchedGuitar.Add(melodyBreak);
            PitchedGuitar.Add(melodyBreak);
            PitchedGuitar.Add(melodyBreak);
            PitchedGuitar.Add(melodyBreak);

            PitchedGuitar.Add(pitchedE3);
            PitchedGuitar.Add(pitchedE3);
            PitchedGuitar.Add(pitchedH4);
            PitchedGuitar.Add(pitchedH1);

            PitchedGuitar.Add(pitchedE3);
            PitchedGuitar.Add(pitchedE3);
            PitchedGuitar.Add(pitchedH4);
            PitchedGuitar.Add(pitchedH0);

            PitchedGuitar.Add(pitchedE3);
            PitchedGuitar.Add(pitchedE3);
            PitchedGuitar.Add(pitchedH4);
            PitchedGuitar.Add(pitchedH1);

            SecondGuitar = new List<MelodyNoteCollection>();

            MelodyNoteCollection sg1 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 120,
                MilliSecondsPerSound = 120,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E12,MelodyNotes.E7,MelodyNotes.E3, MelodyNotes.E0,
                    MelodyNotes.E7,MelodyNotes.E3,MelodyNotes.E0, MelodyNotes.H4,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                    MelodyNotes.E12,MelodyNotes.E7,MelodyNotes.E3, MelodyNotes.E0,
                    MelodyNotes.E7,MelodyNotes.E3,MelodyNotes.E0, MelodyNotes.H4,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                    MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence, MelodyNotes.Silence,
                }
            };

            SecondGuitar.Add(melodyBreak);
        //    SecondGuitar.Add(melodyBreak);

            SecondGuitar.Add(melodyBreak);
            SecondGuitar.Add(melodyBreak);
            SecondGuitar.Add(melodyBreak);
            SecondGuitar.Add(melodyBreak);

            SecondGuitar.Add(melodyBreak);
            SecondGuitar.Add(melodyBreak);
            SecondGuitar.Add(melodyBreak);
            SecondGuitar.Add(melodyBreak);

            SecondGuitar.Add(sg1);
            SecondGuitar.Add(sg1);
            SecondGuitar.Add(sg1);
            SecondGuitar.Add(sg1);

            SecondGuitar.Add(sg1);
            SecondGuitar.Add(sg1);
            SecondGuitar.Add(sg1);
            SecondGuitar.Add(sg1);

            SecondGuitar.Add(sg1doppel);
            SecondGuitar.Add(sg1doppel);
            SecondGuitar.Add(sg1doppel);
            SecondGuitar.Add(sg1doppel);

            SecondGuitar.Add(sg1doppel);
            SecondGuitar.Add(sg1doppel);
            SecondGuitar.Add(sg1doppel);
            SecondGuitar.Add(sg1doppel);

            SecondGuitar.Add(sg1doppel);
            SecondGuitar.Add(sg1doppel);
            //SecondGuitar.Add(sg1doppel);
            //SecondGuitar.Add(sg1doppel);
        }
    }
}
