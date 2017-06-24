using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using IOInterface;
using BaseContracts;

namespace ElementImplementations.AmmoImplementations
{
    public class Rocket : IAnimationInstructionProvider
    {
        private IExplosionManager _explosionManager;
        private IParticleManager _particleManager;
        private double _destructionStrength;
        private double _destructionSquareRadius;
        private double _lastSmokeCloudInSeconds;
        private double _secondsBetweenSmokeClouds;
        private double _timeToLiveInSeconds;
        private double? _startTime;

        public Rocket(IExplosionManager explosionManager, IParticleManager particleManager, double destructionStrength, double destructionRadius, double secondsBetweenSmokeClouds, double timeToLiveInSeconds)
        {
            _explosionManager = explosionManager;
            _particleManager = particleManager;
            _destructionStrength = destructionStrength;
            _destructionSquareRadius = destructionRadius * destructionRadius;
            _secondsBetweenSmokeClouds = secondsBetweenSmokeClouds;
            _timeToLiveInSeconds = timeToLiveInSeconds;
        }

        AnimationInstruction IAnimationInstructionProvider.GetInstructions(bool collisionWithWorld, Position3D position)
        {
            if (collisionWithWorld)
            {
                _explosionManager.StartNewExplosion(null, position, _destructionStrength, _destructionSquareRadius);
            }

            StartNewSmokeCloudIfNecessary(position);

            if (!_startTime.HasValue)
                _startTime = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;

            if (TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - _startTime > _timeToLiveInSeconds)
            {
                _explosionManager.StartNewExplosion(null, position, _destructionStrength, _destructionSquareRadius);
                return new AnimationInstruction
                {
                    Behaviour = Behaviour.StandardBehaviour,
                    Percent = 0,
                    ElementIsFinished = true
                };
            }

            return new AnimationInstruction
            {
                Behaviour = Behaviour.StandardBehaviour,
                Percent = 0,
                ElementIsFinished = collisionWithWorld
            };
        }

        private void StartNewSmokeCloudIfNecessary(Position3D position)
        {
            double secondsSinceLastCloud = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - _lastSmokeCloudInSeconds;

            if (secondsSinceLastCloud > _secondsBetweenSmokeClouds)
            {
                _particleManager.StartNewParticleAnimation(position.Clone(), Animation.Smoke);
                _lastSmokeCloudInSeconds = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
            }
        }
    }
}
