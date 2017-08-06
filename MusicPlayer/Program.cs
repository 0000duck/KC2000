using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Audio;
using Sound.Contracts;
using Sound;
using MusicPlayer.Songs;
using MusicPlayer.Player;
using MusicPlayer.Songs.Music;
using System.Threading;
using MusicPlayer.Provider;
using MusicPlayer.Songs.ML;

namespace MusicPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AudioContext context = new AudioContext())
            {
                Thread.Sleep(1000);
                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                Thread.Sleep(3000);
                //Dictionary<BassNotes, IComplexSound> bassSounds = new SoundLoader(new SoundFactory(new BufferLoader(new WavFileReader()), 120, 1.0f)).LoadBassSounds();
                Dictionary<BassNotes, IComplexSound> bass = new BassCreator().CreateBassNotes(new SoundFactory(new BufferLoader(new WavFileReader()), 120, 1.0f), "Sound\\bass\\Eroh.wav");
                Dictionary<MelodyNotes, IComplexSound> guitar = new MelodyCreator().CreateBassNotes(new SoundFactory(new BufferLoader(new WavFileReader()), 120, 1.0f), "Sound\\bass\\Eroh.wav", 15.0);
                Dictionary<MelodyNotes, IComplexSound> pitchedGuitar = new MelodyCreator().CreateBassNotes(new SoundFactory(new BufferLoader(new WavFileReader()), 120, 1.0f), "Sound\\bass\\Eroh pitch.wav", 15.0);
                Dictionary<DrumNotes, IComplexSound> drumSounds = new DrumCreator().CreateBassNotes(new SoundFactory(new BufferLoader(new WavFileReader()), 120, 1.0f), "Sound\\melody\\snare.wav");
                Dictionary<MelodyNotes, IComplexSound> driller = new MelodyCreator().CreateBassNotes(new SoundFactory(new BufferLoader(new WavFileReader()), 120, 1.0f), "Sound\\bass\\Eroh echo2.wav", 15.0);
                Dictionary<MelodyNotes, IComplexSound> faded = new MelodyCreator().CreateBassNotes(new SoundFactory(new BufferLoader(new WavFileReader()), 120, 1.0f), "Sound\\bass\\Eroh fade.wav", 15.0);

                VolumeAdapter volumeAdapter = new MusicPlayer.VolumeAdapter();
                
                volumeAdapter.AdaptVolume(bass, 0.9f);
                volumeAdapter.AdaptVolume(drumSounds, 0.7f);
                volumeAdapter.AdaptVolume(pitchedGuitar, 0.8f);

                string songNumber = System.Configuration.ConfigurationManager.AppSettings["Song"];

                Song song = null;
                switch (songNumber)
                {
                    case "1":
                        song = new SongOne();
                        break;
                }

                ISoundFactory factory = new SoundFactory(new BufferLoader(new WavFileReader()), 120, 1.0f);
                IPlayer endlessTonePlayer = new EndlessTonePlayer(new PitchFactorProvider().CreateBassNotes(),
                  (IComplexSound) factory.LoadSound("Sound\\bass\\Eroh.wav", false, true),
                   250, new[] { MelodyNotes.E1, MelodyNotes.E3, MelodyNotes.E9, MelodyNotes.G10, MelodyNotes.G12 });

                Composition composition = new Converter().Convert(song, bass, guitar, pitchedGuitar, drumSounds, faded, driller);

                CompositionPlayer player = new CompositionPlayer(composition, endlessTonePlayer);

                player.Play();

                player = new CompositionPlayer(composition, endlessTonePlayer);
                player.Play();

                player = new CompositionPlayer(composition, endlessTonePlayer);
                player.Play();
            }
        }
    }
}
