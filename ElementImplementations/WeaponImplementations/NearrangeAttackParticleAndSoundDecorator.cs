using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using Sound.Contracts;
using IOInterface;
using ArtificialIntelligence.Contracts;

namespace ElementImplementations.WeaponImplementations
{
    public class NearrangeAttackParticleAndSoundDecorator : INearRangeAttackSharer
    {
        private INearRangeAttackSharer _nearRangeAttackSharer;
        private ISound _hitSound;
        private IParticleManager _particleManager;

        public NearrangeAttackParticleAndSoundDecorator(INearRangeAttackSharer nearRangeAttackSharer, ISound hitSound, IParticleManager particleManager)
        {
            _nearRangeAttackSharer = nearRangeAttackSharer;
            _hitSound = hitSound;
            _particleManager = particleManager;
        }

        void INearRangeAttackSharer.ShareAttackDamage(IList<IWorldElement> allAttackedElements, Position3D position, Vector3D directionVectorUnitLength, double destructionStrength)
        {
            if (allAttackedElements.Count > 0)
            {
                _hitSound.Play();

                Position3D dustPosition = position.Clone();
                dustPosition.PositionX -= directionVectorUnitLength.X * 0.1;
                dustPosition.PositionY -= directionVectorUnitLength.Y * 0.1;
                dustPosition.PositionZ -= directionVectorUnitLength.Z * 0.1;

                _particleManager.StartNewParticleAnimation(dustPosition, Animation.FistDust);

            }
            _nearRangeAttackSharer.ShareAttackDamage(allAttackedElements, position, directionVectorUnitLength, destructionStrength);
        }
    }
}
