using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface.Events;
using BaseTypes;
using Sound.Contracts;

namespace GameInteraction
{
    public class PositionUpdatingSoundPlayer : IFireEventObserver
    {
        private ISound _sound;

        public PositionUpdatingSoundPlayer(ISound sound)
        {
            _sound = sound;
        }

        void IFireEventObserver.NotifyShot(Position3D position)
        {
            _sound.SetPosition((float)position.PositionX, (float)position.PositionZ, (float)position.PositionY);
            _sound.Play();
        }
    }
}
