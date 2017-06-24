using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class Song20 : Song
    {
        public Song20()
        {
            Drums = new List<DrumCollection>();

            DrumCollection drum1 = new DrumCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 100,
                Melody = new List<DrumNotes>
                {
                    DrumNotes.Snare, DrumNotes.Silence, DrumNotes.Silence,
                    DrumNotes.Snare, DrumNotes.Silence, DrumNotes.Snare,
                    DrumNotes.Silence, DrumNotes.Snare, DrumNotes.Silence,
                    DrumNotes.Snare, DrumNotes.Snare, DrumNotes.Silence,
                }
            };


            DrumCollection drum2 = new DrumCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 100,
                Melody = new List<DrumNotes>
                {
                    DrumNotes.Snare, DrumNotes.Silence, DrumNotes.Silence,
                    DrumNotes.Snare, DrumNotes.Silence, DrumNotes.Snare,
                    DrumNotes.Silence, DrumNotes.Silence, DrumNotes.Silence,
                    DrumNotes.Silence, DrumNotes.Snare, DrumNotes.Silence,
                }
            };

            for (int i = 0; i<18; i++)
                Drums.Add(drum1);

            Drums.Add(drum2);
            Drums.Add(drum2);

            Drums.Add(drum1);
            Drums.Add(drum1);
            Drums.Add(drum1);
            Drums.Add(drum1);

            BassLine = new List<BassNoteCollection>();


            BassNoteCollection bassSilence = new BassNoteCollection
            {
                MilliSecondsPerBeat = 12 * 200,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.Silence
                }
            };

            BassNoteCollection bassE = new BassNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.Silence,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.Silence,BassNotes.E0,BassNotes.Silence,
                    BassNotes.Silence,BassNotes.E0,BassNotes.E0,
                }
            };
            BassNoteCollection bassH = new BassNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.Silence,BassNotes.E7,BassNotes.E7,
                    BassNotes.E7,BassNotes.E6,BassNotes.E6,
                    BassNotes.Silence,BassNotes.E5,BassNotes.Silence,
                    BassNotes.Silence,BassNotes.E5,BassNotes.E5,
                }
            };

            BassNoteCollection bassA = new BassNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 120,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A0,BassNotes.Silence,BassNotes.A7,
                    BassNotes.A0,BassNotes.A0,BassNotes.A7,
                    BassNotes.Silence,BassNotes.A0,BassNotes.Silence,
                    BassNotes.Silence,BassNotes.A0,BassNotes.A0,
                }
            };

            BassLine.Add(bassSilence);
            BassLine.Add(bassSilence);

            BassLine.Add(bassE);
            BassLine.Add(bassE);
            BassLine.Add(bassE);
            BassLine.Add(bassH);

            BassLine.Add(bassE);
            BassLine.Add(bassE);
            BassLine.Add(bassE);
            BassLine.Add(bassH);

            BassLine.Add(bassE);
            BassLine.Add(bassE);
            BassLine.Add(bassE);
            BassLine.Add(bassH);

            BassLine.Add(bassE);
            BassLine.Add(bassE);
            BassLine.Add(bassE);
            BassLine.Add(bassH);

            BassLine.Add(bassA);
            BassLine.Add(bassA);

            BassLine.Add(bassE);
            BassLine.Add(bassE);
            BassLine.Add(bassE);
            BassLine.Add(bassH);

            Guitar = new List<MelodyNoteCollection>();

            MelodyNoteCollection mSilence = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 12 * 200,
                MilliSecondsPerSound = 120,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence
                }
            };

            MelodyNoteCollection melody = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 400,
                MilliSecondsPerSound = 140,
                SoundType = SoundType.Faded,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.H0,MelodyNotes.Silence,MelodyNotes.H8,
                    MelodyNotes.H7,MelodyNotes.H0,MelodyNotes.Silence,
                    MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.Silence,
                    MelodyNotes.E3,MelodyNotes.Silence,MelodyNotes.Silence,
                }
            };

            Guitar.Add(mSilence);
            Guitar.Add(mSilence);

            Guitar.Add(mSilence);
            Guitar.Add(mSilence);
            Guitar.Add(mSilence);
            Guitar.Add(mSilence);

            Guitar.Add(mSilence);
            Guitar.Add(mSilence);
            Guitar.Add(mSilence);
            Guitar.Add(mSilence);

            Guitar.Add(melody);
            Guitar.Add(melody);
            Guitar.Add(melody);
            Guitar.Add(melody);

            Guitar.Add(mSilence);
            Guitar.Add(mSilence);

            Guitar.Add(melody);
            Guitar.Add(melody);
        }
    }
}
