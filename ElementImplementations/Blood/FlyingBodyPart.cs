using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using BaseContracts;
using GameInteraction.BaseImplementations;
using ArtificialIntelligence.Contracts;
using IOInterface;
using FrameworkContracts;
using CollisionDetection.Contracts;

namespace ElementImplementations.Blood
{
    public class FlyingBodyPart : ImpulseProcessingAnimatableElement, IFlyingBlood, IExecuteble, IVulnerable, IExplosionVulnerable
    {
        private double _speed;
        private double _startTime;
        private double _gravitationPerSecond;
        private bool _movementStopped;
        private double _maxSecondsWithoutVerticalMovement;
        private double _measurementStartTime;
        private bool _justFalling;
        private IStraightFlightSimulator _straightFlightSimulator;
        private PercentFader _perecentFader;
        private DegreeFader _degreeFader;
        private IBloodParticleByBodyPartTriggerer _bloodParticleByBodyPartTriggerer;
        private int _lastPositionZ;
        private Action<IWorldElement, Position3D> _destructionAction;
        private Behaviour _stoppedBehaviour;

        public FlyingBodyPart(IListProvider<IWorldElement> listProvider, IStraightFlightSimulator straightFlightSimulator,
            double gravitationPerSecond, double rotationDuration, double maxSecondsWithoutVerticalMovement,
            IComplexElementFinder complexElementFinder, Action<IWorldElement, Position3D> destructionAction, Behaviour stoppedBehaviour)
            : base(listProvider, complexElementFinder)
        {
            _gravitationPerSecond = gravitationPerSecond;
            _straightFlightSimulator = straightFlightSimulator;
            _perecentFader = new PercentFader(rotationDuration);
            _degreeFader = new DegreeFader();
            _maxSecondsWithoutVerticalMovement = maxSecondsWithoutVerticalMovement;
            _destructionAction = destructionAction;
            _stoppedBehaviour = stoppedBehaviour;
        }

        void IFlyingBlood.StartFlight(Vector3D directionVector, double speed, double timeToLiveInSeconds)
        {
            _straightFlightSimulator.Initialize(directionVector, Weight);
            _degreeFader.StartFadingByDelta(Degree.Degree_0, 4 + (int)MathHelper.GetRandomValueInARange(3));
            _speed = speed;
            _startTime = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
            _perecentFader.Start();
            _measurementStartTime = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
        }

        void IExecuteble.ExecuteLogic()
        {
            if (_movementStopped)
            {
                AnimationBehaviour = _stoppedBehaviour;
                AnimationPercent = 1.0;
                return;
            }

            if (CollisionProtocol.IsThereAnyCollision)
            {
                if (CollisionProtocol.IsCollisionBottom || CollisionProtocol.IsCollisionTop || CollisionProtocol.IsCollisionLeft || CollisionProtocol.IsCollisionRight)
                    _justFalling = true;
            }

             Fly();

             Orientation = _degreeFader.GetInterpolatedDegree(_perecentFader.GetPercent());
             AnimationBehaviour = Behaviour.StandardBehaviour;
        }

        private void Fly()
        {
            double gravitationStrength = (TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - _startTime) * _gravitationPerSecond;
            Impulse gravitation = new Impulse { ImpulseDirection = Direction.FromCeilingToFloor, Strength = gravitationStrength };
            AddImpulse(gravitation);
         
            double speedStrength = TimeAndSpeedManager.ConvertSpeedToStrength(_speed);

            //slow down 
            speedStrength -= gravitationStrength / 3.5;
            if (speedStrength < 0)
            {
                speedStrength = 0;
            }

            CheckPositionZ();

            if (_justFalling)
                return;

            IList<Impulse> impulses = _straightFlightSimulator.GetFlightImpulses(speedStrength);

            foreach (Impulse impulse in impulses)
            {
                AddImpulse(impulse);
            }
        }

        private void CheckPositionZ()
        {
            int tempPositionZ = (int)(Position.PositionZ * 1000);
            if (tempPositionZ == _lastPositionZ)
            {
                if(TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - _measurementStartTime > _maxSecondsWithoutVerticalMovement)
                    _movementStopped = true;
            }
            else
            {
                _measurementStartTime = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
            }
            _lastPositionZ = tempPositionZ;
        }

        void IVulnerable.YouGotHit(Position3D position, double destructionStrength, Vector3D directionVector)
        {
            _destructionAction(this, position);
        }

        void IExplosionVulnerable.YouGotHit(Position3D explosionPosition, double destructionStrength)
        {
            _destructionAction(this, Position);
        }
    }
}
