using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using IOInterface;
using BaseTypes;
using BaseContracts;
using FrameworkContracts;
using GameInteraction.BaseImplementations;
using CollisionDetection.Contracts;
using BloodEffects.Contracts;

namespace ElementImplementations.Blood
{
    public class FlyingBloodVisible : ImpulseProcessingAnimatableElement, IFlyingBlood, IExecuteble
    {
        private double _speed;
        private IElementCreator _elementCreator;
        private IBloodEffectCreator _bloodEffectCreator;
        private IParticleManager _particleManager;

        private Animation _animation;
        private double _timeToLiveInSeconds;
        private double _startTime;
        private double _gravitationPerSecond;
        private IStraightFlightSimulator _straightFlightSimulator;

        public FlyingBloodVisible(IListProvider<IWorldElement> listProvider, IElementCreator elementCreator, IBloodEffectCreator bloodEffectCreator,
            IParticleManager particleManager, IStraightFlightSimulator straightFlightSimulator, Animation animation, double gravitationPerSecond, IComplexElementFinder complexElementFinder)
            : base(listProvider, complexElementFinder)
        {
            _elementCreator = elementCreator;
            _bloodEffectCreator = bloodEffectCreator;
            _animation = animation;
            _gravitationPerSecond = gravitationPerSecond;
            _straightFlightSimulator = straightFlightSimulator;
            _particleManager = particleManager;
        }

        void IFlyingBlood.StartFlight(Vector3D directionVector, double speed, double timeToLiveInSeconds)
        {
            _speed = speed;
            _timeToLiveInSeconds = timeToLiveInSeconds;
            _startTime = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
            _straightFlightSimulator.Initialize(directionVector, Weight);
            
        }
        void IExecuteble.ExecuteLogic()
        {
            if (TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - _startTime > _timeToLiveInSeconds)
            {
                _elementCreator.DeleteElement(this);
            }
            else if (CollisionProtocol.IsThereAnyCollision)
            {
                _elementCreator.DeleteElement(this);
                _bloodEffectCreator.CreateBloodEffect(_animation, Position);
                _particleManager.StartNewParticleAnimation(Position, Animation.VerySmallBodyExplosion);
            }
            else
            {
                Fly();
            }
        }

        private void Fly()
        {
            double speedStrength = TimeAndSpeedManager.ConvertSpeedToStrength(_speed);

            double gravitationStrength = (TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - _startTime) * _gravitationPerSecond;
            Impulse gravitation = new Impulse { ImpulseDirection = Direction.FromCeilingToFloor, Strength = gravitationStrength };
            AddImpulse(gravitation);

            IList<Impulse> impulses = _straightFlightSimulator.GetFlightImpulses(speedStrength);

            foreach (Impulse impulse in impulses)
            {
                AddImpulse(impulse);
            }
        }
    }
}
