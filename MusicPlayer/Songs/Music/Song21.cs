using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class Song21 : Song
    {
        public Song21()
        {
            Drums = new List<DrumCollection>();

            DrumCollection drum1 = new DrumCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 100,
                Melody = new List<DrumNotes>
                {
                    DrumNotes.Snare, DrumNotes.Silence, DrumNotes.Silence,DrumNotes.Silence,
                    DrumNotes.Snare, DrumNotes.Silence, DrumNotes.Snare,DrumNotes.Silence,
                    DrumNotes.Snare, DrumNotes.Silence, DrumNotes.Silence,DrumNotes.Silence,
                    DrumNotes.Snare, DrumNotes.Silence, DrumNotes.Snare,DrumNotes.Silence,
                }
            };



            for (int i = 0; i<10; i++)
                Drums.Add(drum1);

            BassLine = new List<BassNoteCollection>();

            BassNoteCollection bassE = new BassNoteCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.Silence,BassNotes.Silence,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.Silence,BassNotes.E0,BassNotes.Silence,
                    BassNotes.Silence,BassNotes.E0,BassNotes.Silence,BassNotes.E0,
                    BassNotes.Silence,BassNotes.E0,BassNotes.Silence,BassNotes.E0,
                }
            };
            BassNoteCollection bassEhoch = new BassNoteCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.Silence,BassNotes.Silence,BassNotes.A7,BassNotes.A7,
                    BassNotes.A7,BassNotes.Silence,BassNotes.A7,BassNotes.A7,
                    BassNotes.Silence,BassNotes.A7,BassNotes.Silence,BassNotes.A7,
                    BassNotes.Silence,BassNotes.A7,BassNotes.Silence,BassNotes.A7,
                }
            };
            BassNoteCollection bassA = new BassNoteCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.Silence,BassNotes.Silence,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.Silence,BassNotes.A0,BassNotes.A0,
                    BassNotes.Silence,BassNotes.A0,BassNotes.Silence,BassNotes.A0,
                    BassNotes.Silence,BassNotes.A0,BassNotes.Silence,BassNotes.A0,
                }
            };

            //BassLine.Add(bassE);
            //BassLine.Add(bassE);
            //BassLine.Add(bassEhoch);

            BassLine.Add(bassE);
            BassLine.Add(bassE);
            BassLine.Add(bassEhoch);

            BassLine.Add(bassA);
            BassLine.Add(bassA);

            BassLine.Add(bassE);
            BassLine.Add(bassE);
            BassLine.Add(bassEhoch);

            BassLine.Add(bassA);
            BassLine.Add(bassA);

            Guitar = new List<MelodyNoteCollection>();

            MelodyNoteCollection mSilence = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 16 * 300 * 3,
                MilliSecondsPerSound = 120,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence
                }
            };

            MelodyNoteCollection melodyG = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 150,
                MilliSecondsPerSound = 120,
                SoundType = SoundType.PitchedGuitar,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G0,MelodyNotes.Silence,MelodyNotes.G0,MelodyNotes.Silence,
                    MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.Silence,
                    MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.Silence,MelodyNotes.G0,
                    MelodyNotes.G0,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                }
            };

            MelodyNoteCollection melodyH = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 150,
                MilliSecondsPerSound = 120,
                SoundType = SoundType.PitchedGuitar,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.H0,MelodyNotes.Silence,MelodyNotes.H0,MelodyNotes.Silence,
                    MelodyNotes.H0,MelodyNotes.H0,MelodyNotes.H0,MelodyNotes.Silence,
                    MelodyNotes.H0,MelodyNotes.H0,MelodyNotes.Silence,MelodyNotes.H0,
                    MelodyNotes.H0,MelodyNotes.Silence,MelodyNotes.Silence,MelodyNotes.Silence,
                }
            };

          //  Guitar.Add(mSilence);

            Guitar.Add(melodyG);
            Guitar.Add(melodyG);

            Guitar.Add(melodyG);
            Guitar.Add(melodyG);

            Guitar.Add(melodyH);
            Guitar.Add(melodyH);

            Guitar.Add(melodyG);
            Guitar.Add(melodyG);

            Guitar.Add(melodyG);
            Guitar.Add(melodyG);


            Guitar.Add(melodyG);
            Guitar.Add(melodyG);

            Guitar.Add(melodyG);
            Guitar.Add(melodyG);

            Guitar.Add(melodyH);
            Guitar.Add(melodyH);

            Guitar.Add(melodyG);
            Guitar.Add(melodyG);

            Guitar.Add(melodyG);
            Guitar.Add(melodyG);

        }
    }
}
