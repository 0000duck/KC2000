using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using Sound.Contracts;

namespace ArtificialIntelligence
{
    public class SoundPlayingWeaponFirerer : IWeaponFirerer
    {
        private ISound _sound;
        private IUpdateTimer _updateTimer;
        private IWeaponFirerer _firerer;

        public SoundPlayingWeaponFirerer(IWeaponFirerer firerer, ISound sound, IUpdateTimer updateTimer)
        {
            _firerer = firerer;
            _sound = sound;
            _updateTimer = updateTimer;
        }

        void IWeaponFirerer.Fire(Position3D weaponOwnerPosition, IWorldElement targetElement, Degree weaponOwnerOrientation)
        {
            _firerer.Fire(weaponOwnerPosition, targetElement, weaponOwnerOrientation);

            if (_updateTimer.UpdateIsNecessary())
            {
                _sound.SetPosition((float)weaponOwnerPosition.PositionX, (float)weaponOwnerPosition.PositionZ, (float)weaponOwnerPosition.PositionY);
                _sound.Play();
            }
        }
    }
}
