using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class Song12 : Song
    {
        public Song12()
        {

            Guitar = new List<MelodyNoteCollection>();

            BassNoteCollection bassEeinzel = new BassNoteCollection
            {
                MilliSecondsPerBeat = 280,
                MilliSecondsPerSound = 110,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.Silence,BassNotes.Silence, 
                    BassNotes.E0,BassNotes.Silence,BassNotes.Silence, 
                    BassNotes.E0,BassNotes.Silence,BassNotes.Silence, 
                    BassNotes.E0,BassNotes.E3,BassNotes.E7,BassNotes.A8,BassNotes.A10 
                }
            };

            BassNoteCollection bassEdoppel = new BassNoteCollection
            {
                MilliSecondsPerBeat = 280,
                MilliSecondsPerSound = 110,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.Silence, 
                    BassNotes.E0,BassNotes.E0,BassNotes.Silence, 
                    BassNotes.E0,BassNotes.E0,BassNotes.Silence, 
                    BassNotes.E0,BassNotes.E3,BassNotes.E7,BassNotes.A8,BassNotes.A10 
                }
            };

            BassNoteCollection bassGeinzel = new BassNoteCollection
            {
                MilliSecondsPerBeat = 280,
                MilliSecondsPerSound = 110,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E3,BassNotes.Silence,BassNotes.Silence, 
                    BassNotes.E3,BassNotes.Silence,BassNotes.Silence, 
                    BassNotes.E3,BassNotes.Silence,BassNotes.Silence, 
                    BassNotes.E4,BassNotes.A5,BassNotes.A4,BassNotes.E5,BassNotes.E4 
                }
            };

            BassNoteCollection bassGdoppel = new BassNoteCollection
            {
                MilliSecondsPerBeat = 280,
                MilliSecondsPerSound = 110,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E3,BassNotes.E3,BassNotes.Silence, 
                    BassNotes.E3,BassNotes.E3,BassNotes.Silence, 
                    BassNotes.E3,BassNotes.E3,BassNotes.Silence, 
                    BassNotes.E4,BassNotes.A5,BassNotes.A4,BassNotes.E5,BassNotes.E4 
                }
            };

            BassNoteCollection bassFisdoppel = new BassNoteCollection
            {
                MilliSecondsPerBeat = 280,
                MilliSecondsPerSound = 110,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E2,BassNotes.E2,BassNotes.Silence, 
                    BassNotes.E2,BassNotes.E2,BassNotes.Silence, 
                    BassNotes.E2,BassNotes.E2,BassNotes.Silence, 
                    BassNotes.E2,BassNotes.A4, BassNotes.A5
                }
            };

            BassLine = new List<BassNoteCollection>();


            //strophe
            BassLine.Add(bassEeinzel);
            BassLine.Add(bassEeinzel);
            BassLine.Add(bassEeinzel);
            BassLine.Add(bassGeinzel);
            BassLine.Add(bassEdoppel);
            BassLine.Add(bassEdoppel);
            BassLine.Add(bassEdoppel);
            BassLine.Add(bassGdoppel);
            BassLine.Add(bassFisdoppel);
            BassLine.Add(bassFisdoppel);
            BassLine.Add(bassFisdoppel);
            BassLine.Add(bassFisdoppel);

            BassLine.Add(bassEdoppel);
            BassLine.Add(bassEdoppel);
            BassLine.Add(bassEdoppel);
            BassLine.Add(bassGdoppel);
            BassLine.Add(bassFisdoppel);
            BassLine.Add(bassFisdoppel);
            BassLine.Add(bassFisdoppel);
            BassLine.Add(bassFisdoppel);

            MelodyNoteCollection silence = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = (280 * 14) * 4,
                MilliSecondsPerSound = 400,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence
                }
            };

            

            MelodyNoteCollection part1 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 280,
                MilliSecondsPerSound = 280,
                SoundType = SoundType.Driller,

                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.Silence, 
                    MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.Silence, 
                    MelodyNotes.E0,MelodyNotes.Silence,MelodyNotes.Silence, 
                    MelodyNotes.E0,MelodyNotes.E3,MelodyNotes.E7,MelodyNotes.Silence,MelodyNotes.Silence 
                }
            };

            MelodyNoteCollection part2 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 280,
                MilliSecondsPerSound = 280,
                SoundType = SoundType.Driller,

                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E3,MelodyNotes.Silence,MelodyNotes.Silence, 
                    MelodyNotes.E3,MelodyNotes.Silence,MelodyNotes.Silence, 
                    MelodyNotes.E3,MelodyNotes.Silence,MelodyNotes.Silence, 
                    MelodyNotes.E4,MelodyNotes.E10,MelodyNotes.E9,MelodyNotes.E5,MelodyNotes.E4 
                }
            };

            MelodyNoteCollection part3 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 280,
                MilliSecondsPerSound = 280,
                SoundType = SoundType.Driller,

                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E2,MelodyNotes.E2,MelodyNotes.Silence, 
                    MelodyNotes.E2,MelodyNotes.E2,MelodyNotes.Silence, 
                    MelodyNotes.E2,MelodyNotes.E2,MelodyNotes.Silence, 
                    MelodyNotes.E2,MelodyNotes.E9, MelodyNotes.E10 
                }
            };

            Guitar.Add(silence);

            Guitar.Add(part1);
            Guitar.Add(part1);
            Guitar.Add(part1);
            Guitar.Add(part2);

            Guitar.Add(part3);
            Guitar.Add(part3);
            Guitar.Add(part3);
            Guitar.Add(part3);

            Guitar.Add(part1);
            Guitar.Add(part1);
            Guitar.Add(part1);
            Guitar.Add(part2);

            Guitar.Add(part3);
            Guitar.Add(part3);
            Guitar.Add(part3);
            Guitar.Add(part3);
        }
    }
}
