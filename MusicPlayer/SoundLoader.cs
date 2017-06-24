using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sound.Contracts;

namespace MusicPlayer
{
    public class SoundLoader
    {
        private ISoundFactory _soundFactory;

        public SoundLoader(ISoundFactory soundFactory)
        {
            _soundFactory = soundFactory;
        }

        public Dictionary<BassNotes, IComplexSound> LoadBassSounds()
        {
            Dictionary<BassNotes, IComplexSound> dictionary = new Dictionary<BassNotes, IComplexSound>();

            BassMapper bassMapper = new BassMapper();

            foreach (BassNotes bassnote in Enum.GetValues(typeof(BassNotes)))
            {
                dictionary.Add(bassnote, GetSound("Sound\\bass\\" + bassMapper.Map(bassnote).ToString() + ".wav"));
            }

            return dictionary;
        }

        public Dictionary<MelodyNotes, IComplexSound> LoadMelodySounds()
        {
            Dictionary<MelodyNotes, IComplexSound> dictionary = new Dictionary<MelodyNotes, IComplexSound>();

            MelodyMapper melodyMapper = new MelodyMapper();

            foreach (MelodyNotes melodynote in Enum.GetValues(typeof(MelodyNotes)))
            {
                dictionary.Add(melodynote, GetSound("Sound\\melody\\" + melodyMapper.Map(melodynote).ToString() + ".wav"));
            }

            return dictionary;
        }

        private IComplexSound GetSound(string soundFile)
        {
            if (soundFile.Contains("Silence"))
                return new Silence();

            return (IComplexSound)_soundFactory.LoadSound(soundFile, false);
        }
    }

    public class Silence : IComplexSound
    {

        void ISound.SetPosition(float x, float y, float z)
        {
        }

        void ISound.Play()
        {
        }

        void IComplexSound.Pause()
        {
        }

        void IComplexSound.Continue()
        {
        }

        void IComplexSound.Delete()
        {
        }

        void ISound.Stop()
        {
        }


        void IComplexSound.SetVolume(float volume)
        {
        }

        void IComplexSound.SetSpeed(float speedFactor)
        {
        }
    }
}
