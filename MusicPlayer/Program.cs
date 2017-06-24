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
                    case "2":
                        song = new SongTwoMelody();
                        break;
                    case "3":
                        song = new SongThree();
                        break;
                    case "4":
                        song = new SongFour();
                        break;
                    case "5":
                        song = new SongFive();
                        break;
                    case "6":
                        song = new SongSix();
                        break;
                    case "7":
                        song = new SongSeven();
                        break;
                    case "8":
                        song = new Song8();
                        break;
                    case "9":
                        song = new Song9();
                        break;
                    case "10":
                        song = new Song10();
                        break;
                    case "11":
                        song = new Song11();
                        break;
                    case "12":
                        song = new Song12();
                        break;
                    case "13":
                        song = new FinalSpeedMetal();
                        break;
                    case "14":
                        song = new Song14();
                        break;
                    case "15":
                        song = new Song15();
                        break;
                    case "16":
                        song = new Song16();
                        break;
                    case "17":
                        song = new Song17();
                        break;
                    case "18":
                        song = new Song18();
                        break;
                    case "19":
                        song = new Song19();
                        break;
                    case "20":
                        song = new Song20();
                        break;
                    case "21":
                        song = new Song21();
                        break;
                    case "30":
                        song = new Guitar2();
                        break;
                    case "31":
                        song = new Bass();
                        break;
                    case "32":
                        song = new Drums();
                        break;
                }

                Composition composition = new Converter().Convert(song, bass, guitar, pitchedGuitar, drumSounds, faded, driller);

                CompositionPlayer player = new CompositionPlayer(composition);

                player.Play();

                player = new CompositionPlayer(composition);
                player.Play();

                player = new CompositionPlayer(composition);
                player.Play();
            }
        }
    }
}
