using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;

namespace GameInteraction.Weapons
{
    public class LoadingWeapon : IComplexWeapon
    {
        private int _ammoCount;

        //TODO: needs to be saved:
        private int _currentFiredAmmoCount;

        private PercentFader _loadingPercentFader;
        private IComplexWeapon _complexWeapon;
        private bool _loading;
        private int? _ammoTotal;

        public LoadingWeapon(IComplexWeapon complexWeapon, int ammoCount, double loadingDuration)
        {
            _ammoCount = ammoCount;
            _loadingPercentFader = new PercentFader(loadingDuration);
            _complexWeapon = complexWeapon;
        }

        ComplexWeaponResult IComplexWeapon.GetWeaponResult(bool fire, Position3D position, VectorWithDegree directionVector)
        {
            ComplexWeaponResult result;

            if (_currentFiredAmmoCount == _ammoCount)
            {
                if (_loading)
                {
                    result = new ComplexWeaponResult 
                    {
                        Behaviour = IOInterface.Behaviour.LoadedInHand,
                        Percent = _loadingPercentFader.GetPercent()
                    };

                    if (result.Percent > 0.98)
                    {
                        _loading = false;
                        _currentFiredAmmoCount = 0;
                    }
                }
                else
                {
                    result = _complexWeapon.GetWeaponResult(false, position, directionVector);
                    _ammoTotal = result.AmmoCount;

                    if ((result.Percent > 0.98 || result.Behaviour == IOInterface.Behaviour.HeldInHand) && _ammoTotal.HasValue && _ammoTotal.Value > 0)
                    {
                        _loading = true;
                        _loadingPercentFader.Start();
                    }
                }
                return result;
            }

            result = _complexWeapon.GetWeaponResult(fire, position, directionVector);
            _ammoTotal = result.AmmoCount;

            if (result.NewShotTriggered)
            {
                _currentFiredAmmoCount++;
            }

            return result;
        }
    }
}
