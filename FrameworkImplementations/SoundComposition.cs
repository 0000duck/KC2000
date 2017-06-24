using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sound.Contracts;

namespace FrameworkImplementations
{
    public class SoundComposition : ISound
    {
        private ISound _soundOne;
        private ISound _soundTwo;

        public SoundComposition(ISound soundOne, ISound soundTwo)
        {
            _soundOne = soundOne;
            _soundTwo = soundTwo;
        }

        void ISound.Play()
        {
            _soundOne.Play();
            _soundTwo.Play();
        }

        void ISound.Stop()
        {
            _soundOne.Stop();
            _soundTwo.Stop();
        }

        void ISound.SetPosition(float x, float y, float z)
        {
            _soundOne.SetPosition(x, y, z);
            _soundTwo.SetPosition(x, y, z);
        }
    }
}
