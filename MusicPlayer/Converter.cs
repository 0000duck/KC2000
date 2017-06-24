using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicPlayer.Songs;
using Sound.Contracts;

namespace MusicPlayer
{
    public class Converter
    {
        public Composition Convert(Song song, Dictionary<BassNotes, IComplexSound> bassSounds, Dictionary<MelodyNotes, IComplexSound> guitar,
            Dictionary<MelodyNotes, IComplexSound> pitchedGuitar, Dictionary<DrumNotes, IComplexSound> drumSounds, Dictionary<MelodyNotes, IComplexSound> fadedGuitar,
            Dictionary<MelodyNotes, IComplexSound> drillerGuitar)
        {
            Composition composition = new Composition();

            composition.Instruments = new List<Instrument>();

            if (song.BassLine != null && song.BassLine.Any())
            {
                Instrument bass = new Instrument();

                bass.Elements = new List<SongElement>();

                foreach (BassNoteCollection bassCollection in song.BassLine)
                {
                    SongElement element = new SongElement
                    { 
                        MilliSecondsPerSound = bassCollection.MilliSecondsPerSound,
                        MilliSecondsPerBeat = bassCollection.MilliSecondsPerBeat
                    };

                    element.Sounds = new IComplexSound[bassCollection.BassLine.Count];

                    int index = 0;
                    foreach (BassNotes bassNote in bassCollection.BassLine)
                    {
                        element.Sounds[index] = bassSounds[bassNote];
                        index++;
                    }

                    bass.Elements.Add(element);
                }

                composition.Instruments.Add(bass);
            }

            if (song.Guitar != null && song.Guitar.Any())
            {
                Instrument melody = new Instrument();

                melody.Elements = new List<SongElement>();

                foreach (MelodyNoteCollection melodyCollection in song.Guitar)
                {
                    SongElement element = new SongElement 
                    { 
                        MilliSecondsPerSound = melodyCollection.MilliSecondsPerSound,
                        MilliSecondsPerBeat = melodyCollection.MilliSecondsPerBeat
                    };

                    element.Sounds = new IComplexSound[melodyCollection.Melody.Count];

                    int index = 0;
                    foreach (MelodyNotes melodyNote in melodyCollection.Melody)
                    {
                        if (!melodyCollection.SoundType.HasValue || melodyCollection.SoundType.Value == SoundType.Guitar)
                            element.Sounds[index] = guitar[melodyNote];
                        else 
                        {
                            switch (melodyCollection.SoundType.Value)
                            {
                                case SoundType.PitchedGuitar:
                                    element.Sounds[index] = pitchedGuitar[melodyNote];
                                    break;
                                case SoundType.Faded:
                                    element.Sounds[index] = fadedGuitar[melodyNote];
                                    break;
                                case SoundType.Driller:
                                    element.Sounds[index] = drillerGuitar[melodyNote];
                                    break;
                            }
                        }
                        index++;
                    }

                    melody.Elements.Add(element);
                }

                composition.Instruments.Add(melody);
            }

            if (song.SecondGuitar != null && song.SecondGuitar.Any())
            {
                Instrument melody = new Instrument();

                melody.Elements = new List<SongElement>();

                foreach (MelodyNoteCollection melodyCollection in song.SecondGuitar)
                {
                    SongElement element = new SongElement
                    {
                        MilliSecondsPerSound = melodyCollection.MilliSecondsPerSound,
                        MilliSecondsPerBeat = melodyCollection.MilliSecondsPerBeat
                    };

                    element.Sounds = new IComplexSound[melodyCollection.Melody.Count];

                    int index = 0;
                    foreach (MelodyNotes melodyNote in melodyCollection.Melody)
                    {
                        if (!melodyCollection.SoundType.HasValue || melodyCollection.SoundType.Value == SoundType.Guitar)
                            element.Sounds[index] = guitar[melodyNote];
                        else
                        {
                            switch (melodyCollection.SoundType.Value)
                            {
                                case SoundType.PitchedGuitar:
                                    element.Sounds[index] = pitchedGuitar[melodyNote];
                                    break;
                                case SoundType.Faded:
                                    element.Sounds[index] = fadedGuitar[melodyNote];
                                    break;
                                case SoundType.Driller:
                                    element.Sounds[index] = drillerGuitar[melodyNote];
                                    break;
                            }
                        }

                        index++;
                    }

                    melody.Elements.Add(element);
                }

                composition.Instruments.Add(melody);
            }

            if (song.PitchedGuitar != null && song.PitchedGuitar.Any())
            {
                Instrument melody = new Instrument();

                melody.Elements = new List<SongElement>();

                foreach (MelodyNoteCollection melodyCollection in song.PitchedGuitar)
                {
                    SongElement element = new SongElement
                    {
                        MilliSecondsPerSound = melodyCollection.MilliSecondsPerSound,
                        MilliSecondsPerBeat = melodyCollection.MilliSecondsPerBeat
                    };

                    element.Sounds = new IComplexSound[melodyCollection.Melody.Count];

                    int index = 0;
                    foreach (MelodyNotes melodyNote in melodyCollection.Melody)
                    {
                        element.Sounds[index] = pitchedGuitar[melodyNote];
                        index++;
                    }

                    melody.Elements.Add(element);
                }

                composition.Instruments.Add(melody);
            }

            if (song.Drums != null && song.Drums.Any())
            {
                Instrument drum = new Instrument();

                drum.Elements = new List<SongElement>();

                foreach (DrumCollection drumCollection in song.Drums)
                {
                    SongElement element = new SongElement
                    {
                        MilliSecondsPerSound = drumCollection.MilliSecondsPerSound,
                        MilliSecondsPerBeat = drumCollection.MilliSecondsPerBeat
                    };

                    element.Sounds = new IComplexSound[drumCollection.Melody.Count];

                    int index = 0;
                    foreach (DrumNotes drumNote in drumCollection.Melody)
                    {
                        element.Sounds[index] = drumSounds[drumNote];
                        index++;
                    }

                    drum.Elements.Add(element);
                }

                composition.Instruments.Add(drum);
            }

            return composition;
        }
    }
}
