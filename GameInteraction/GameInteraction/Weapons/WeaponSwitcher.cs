using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using GameInteractionContracts;
using IOInterface;

namespace GameInteraction.Weapons
{
    public class WeaponSwitcher : IWeaponSwitcher
    {
        private PercentFader _switchPercentFader;
        private ElementTheme _currentWeapon;
        private ElementTheme _desiredWeapon;

        public WeaponSwitcher(double switchduration)
        {
            _switchPercentFader = new PercentFader(switchduration);
        }

        void IWeaponSwitcher.StartSwitching(ElementTheme currentWeapon, ElementTheme desiredWeapon)
        {
            _currentWeapon = currentWeapon;
            _desiredWeapon = desiredWeapon;
            _switchPercentFader.Start();
        }

        bool IWeaponSwitcher.IsSwitching()
        {
            return !_switchPercentFader.IsFinished();
        }

        WeaponSwitchResult IWeaponSwitcher.GetResult()
        {
            double percent = _switchPercentFader.GetPercent();

            return new WeaponSwitchResult 
            {
                Percent = percent < 0.5 ? percent * 2.0 : 1- ((percent - 0.5) * 2.0),
                WeaponTheme = percent < 0.5 ? _currentWeapon : _desiredWeapon
            };
        }
    }
}
