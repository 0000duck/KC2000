using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using IOInterface;
using IOInterface.Events;

namespace GameInteraction.Weapons
{
    public class PermanentFireringWeapon : IComplexWeapon
    {
        private PercentFader _percentFaderShot;
        private IComplexAmmo _ammo;
        private IFireEventObserver _eventObserver;

        public PermanentFireringWeapon(double durationOfShot, IComplexAmmo ammo, IFireEventObserver fireEventObserver)
        {
            _ammo = ammo;
            _percentFaderShot = new PercentFader(durationOfShot);
            _eventObserver = fireEventObserver;
        }

        ComplexWeaponResult IComplexWeapon.GetWeaponResult(bool fire, Position3D position, VectorWithDegree directionVector)
        {
            if (!_percentFaderShot.IsFinished())
            {
                return new ComplexWeaponResult 
                {
                    Behaviour = Behaviour.FiredInHand,
                    Percent = _percentFaderShot.GetPercent(),
                    AmmoCount = _ammo.Count
                };
            }
            else
            {
                if(fire)
                {
                    AmmoFireResult result = _ammo.Fire(position, directionVector);
                    if (result == AmmoFireResult.SuccessfullyFired)
                    {
                        _eventObserver.NotifyShot(position);
                        _percentFaderShot.Start();
                        return new ComplexWeaponResult
                        {
                            Behaviour = Behaviour.FiredInHand,
                            Percent = _percentFaderShot.GetPercent(),
                            AmmoCount = _ammo.Count,
                            NewShotTriggered = true
                        };
                    }
                }
            }

            return new ComplexWeaponResult
            {
                Behaviour = Behaviour.HeldInHand,
                Percent = 0,
                AmmoCount = _ammo.Count
            };
        }
    }
}
