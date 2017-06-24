using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;
using GameInteractionContracts;
using IOImplementation;

namespace BloodEffects
{
    public class BloodParticleByCaliberTriggerer : IBloodParticleByCaliberTriggerer
    {
        private IParticleManager _particleManager;
        private double _minSmallCaliber;
        private double _minBigCaliber;
        private IElementCreatorProvider _elementCreator;
        private List<Vector3D> _flightVectors;
        private double _shiftDistance;
        private double _metersPerSecond;

        public BloodParticleByCaliberTriggerer(IParticleManager particleManager, double minBigCaliber, double minSmallCaliber, IElementCreatorProvider elementCreator, double shiftDistance, double metersPerSecond)
        {
            _particleManager = particleManager;
            _minSmallCaliber = minSmallCaliber;
            _minBigCaliber = minBigCaliber;
            _elementCreator = elementCreator;
            _shiftDistance = shiftDistance;
            _metersPerSecond = metersPerSecond;
            _flightVectors = new List<Vector3D>();
        }

        void IBloodParticleByCaliberTriggerer.TriggerBloodParticle(Position3D bloodPosition, Vector3D directionVector, double caliber)
        {
            if (caliber < _minSmallCaliber)
            {
                _particleManager.StartNewParticleAnimation(bloodPosition, Animation.VerySmallBodyExplosion);
                return;
            }
            if (caliber < _minBigCaliber)
            {
                _particleManager.StartNewParticleAnimation(bloodPosition, Animation.VerySmallBodyExplosion);
                _elementCreator.GetElementCreator().EnqueueNewElement(new ElementImplementation { ElementTheme = ElementTheme.StraightFlyingBloodVerySmall, StartPosition = MovePosition(bloodPosition, directionVector) }, StartBloodFlight);
            }
            else
            {
                _particleManager.StartNewParticleAnimation(bloodPosition, Animation.SmallBodyExplosion);
                _elementCreator.GetElementCreator().EnqueueNewElement(new ElementImplementation { ElementTheme = ElementTheme.StraightFlyingBloodSmall, StartPosition = MovePosition(bloodPosition, directionVector) }, StartBloodFlight);
            }

            _flightVectors.Add(directionVector);
        }

        private Position3D MovePosition(Position3D bloodPosition, Vector3D directionVector)
        {
            Position3D position = bloodPosition.Clone();

            position.PositionX += directionVector.X * _shiftDistance;
            position.PositionY += directionVector.Y * _shiftDistance;
            position.PositionZ += directionVector.Z * _shiftDistance;

            return position;
        }

        private void StartBloodFlight(IWorldElement element)
        {
            Vector3D directionVector = _flightVectors.Last();
            _flightVectors.Remove(directionVector);

            IStraightMovingElement flyingBlood = (IStraightMovingElement)element;

            flyingBlood.StartMovement(directionVector, _metersPerSecond);
        }
    }
}
