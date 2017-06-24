using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sound.Contracts;
using System.Media;

namespace WindowsSound
{
    public class WindowsMediaPlayer : IComplexSound
    {
        private SoundPlayer _player;
        private string _soundFile;

        public WindowsMediaPlayer(string soundFile)
        {
            _soundFile = soundFile;
        }

        void ISound.Play()
        {
            _player = new SoundPlayer(_soundFile);
            _player.Load();
            _player.PlayLooping();
        }

        void ISound.Stop()
        {
            _player.Stop();
            _player.Dispose();
        }

        void ISound.SetPosition(float x, float y, float z)
        {
        }

        void IComplexSound.Pause()
        {
            _player.Stop();
            _player.Dispose();
        }

        void IComplexSound.Continue()
        {
            ((ISound)this).Play();
        }

        void IComplexSound.Delete()
        {
            _player.Dispose();
        }

        void IComplexSound.SetVolume(float volume)
        {
        }

        void IComplexSound.SetSpeed(float speedFactor)
        {
        }
    }
}
