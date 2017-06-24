using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface.Events;
using Sound.Contracts;
using BaseTypes;
using ArtificialIntelligence.Contracts;

namespace GameInteraction
{
    public class SoundPlayer : IFireEventObserver
    {
        private ISound _sound;
        private NoiseLevel _noiseLevel;
        private ISoundObserver _soundObserver;

        public SoundPlayer(ISound sound, ISoundObserver soundObserver, NoiseLevel noiseLevel)
        {
            _sound = sound;
            _soundObserver = soundObserver;
            _noiseLevel = noiseLevel;
        }

        void IFireEventObserver.NotifyShot(Position3D position)
        {
            _sound.Play();
            _soundObserver.SetSoundNotfication(_noiseLevel, position);
        }
    }
}
