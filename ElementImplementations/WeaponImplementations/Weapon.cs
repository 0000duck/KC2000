using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using BaseContracts;

namespace ElementImplementations.WeaponImplementations
{
    public class Weapon : ISimpleWeapon
    {
        private IUpdateTimer _timer;
        private IDestructionRegistration _bulletRegistration;
        private double _destructionStrength;

        public Weapon(IUpdateTimer timer, double destructionStrength, IDestructionRegistration bulletRegistration)
        {
            _timer = timer;
            _bulletRegistration = bulletRegistration;
            _destructionStrength = destructionStrength;
        }

        void ISimpleWeapon.Fire(Position3D weaponPosition, Position3D targetPosition, IListProvider<IWorldElement> customicedListProvider)
        {
            if (!_timer.UpdateIsNecessary())
                return;

            Position3D positionOfBullet = weaponPosition.Clone();

            Vector3D directionVector = MathHelper.CreateVectorWithXYLengthOne(weaponPosition, targetPosition);

            _bulletRegistration.AddNewDestruction(positionOfBullet, directionVector, _destructionStrength, customicedListProvider, null);
        }
    }
}
