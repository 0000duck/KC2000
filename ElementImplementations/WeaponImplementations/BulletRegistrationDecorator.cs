using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using BaseContracts;
using IOInterface;

namespace ElementImplementations.WeaponImplementations
{
    public class BulletRegistrationDecorator : IDestructionRegistration
    {
        private IDestructionRegistration _destructionRegistration;
        private IParticleManager _particleManager;
        private IRandomBooleanProvider _randomBooleanProvider;
        private Animation _animation;
        private double _shiftDistance;

        public BulletRegistrationDecorator(IDestructionRegistration destructionRegistration, IParticleManager particleManager, IRandomBooleanProvider randomBooleanProvider, Animation animation, double shiftDistance)
        {
            _destructionRegistration = destructionRegistration;
            _particleManager = particleManager;
            _animation = animation;
            _randomBooleanProvider = randomBooleanProvider;
            _shiftDistance = shiftDistance;
        }

        void IDestructionRegistration.AddNewDestruction(Position3D position, Vector3D directionVectorUnitLength, double destructionStrength, IListProvider<IWorldElement> listProvider, double? strengthReduction)
        {
            _particleManager.StartNewParticleAnimation(position, _animation);

            if (!_randomBooleanProvider.GetValue())
                return;

            Position3D shiftedPosition = position.Clone();
            shiftedPosition.PositionX += directionVectorUnitLength.X * _shiftDistance;
            shiftedPosition.PositionY += directionVectorUnitLength.Y * _shiftDistance;
            shiftedPosition.PositionZ += directionVectorUnitLength.Z * _shiftDistance;

            _destructionRegistration.AddNewDestruction(shiftedPosition, directionVectorUnitLength, destructionStrength, listProvider, strengthReduction);
        }
    }
}
