using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using BaseContracts;
using ArtificialIntelligence.Contracts;
using IOInterface.Events;

namespace ElementImplementations.WeaponImplementations
{
    public class NotifyingWeapon : ISimpleWeapon
    {
        private IUpdateTimer _timer;
        private IDestructionRegistration _bulletRegistration;
        private double _destructionStrength;
        private IFireEventObserver _eventObserver;

        public NotifyingWeapon(IUpdateTimer timer, double destructionStrength, IDestructionRegistration bulletRegistration, IFireEventObserver eventObserver)
        {
            _timer = timer;
            _bulletRegistration = bulletRegistration;
            _destructionStrength = destructionStrength;
            _eventObserver = eventObserver;
        }

        void ISimpleWeapon.Fire(Position3D weaponPosition, Position3D targetPosition, IListProvider<IWorldElement> customicedListProvider)
        {
            if (!_timer.UpdateIsNecessary())
                return;

            Position3D positionOfBullet = weaponPosition.Clone();

            Vector3D directionVector = MathHelper.CreateVectorWithXYLengthOne(weaponPosition, targetPosition);

            _eventObserver.NotifyShot(weaponPosition);

            _bulletRegistration.AddNewDestruction(positionOfBullet, directionVector, _destructionStrength, customicedListProvider, null);
        }
    }
}
