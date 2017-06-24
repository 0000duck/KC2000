using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using ArtificialIntelligence.Contracts;
using IOInterface;
using IOInterface.Events;

namespace GameInteraction.Weapons
{
    public class DelayedFireringWeapon : IComplexWeapon
    {
        private PercentFader _percentFaderShot;
        private IComplexAmmo _ammo;
        private double _percentDelay;
        private bool _delayedFireTriggered;
        private IFireEventObserver _eventObserver;

        public DelayedFireringWeapon(double durationOfShot, IComplexAmmo ammo, double percentDelay, IFireEventObserver fireEventObserver)
        {
            _ammo = ammo;
            _percentFaderShot = new PercentFader(durationOfShot);
            _percentDelay = percentDelay;
            _eventObserver = fireEventObserver;
        }

        ComplexWeaponResult IComplexWeapon.GetWeaponResult(bool fire, Position3D position, VectorWithDegree directionVector)
        {
            if (!_percentFaderShot.IsFinished())
            {
                double percent = _percentFaderShot.GetPercent();

                if (percent > _percentDelay && !_delayedFireTriggered)
                {
                    _ammo.Fire(position, directionVector);
                    _delayedFireTriggered = true;
                }
                return new ComplexWeaponResult 
                {
                    Behaviour = Behaviour.FiredInHand,
                    Percent = percent,
                    AmmoCount = _ammo.Count
                };
            }
            else
            {
                if(fire)
                {
                    _percentFaderShot.Start();
                    _eventObserver.NotifyShot(position);
                    _delayedFireTriggered = false;
                    return new ComplexWeaponResult
                    {
                        Behaviour = Behaviour.FiredInHand,
                        Percent = _percentFaderShot.GetPercent(),
                        AmmoCount = _ammo.Count,
                        NewShotTriggered = true
                    };
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
