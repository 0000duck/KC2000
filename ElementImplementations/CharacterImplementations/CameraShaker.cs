using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using GameInteractionContracts;
using BaseTypes;

namespace ElementImplementations.CharacterImplementations
{
    public class CameraShaker : IPlayerObserver, IQuakeTriggerer
    {
        private IPlayerObserver _playerObserver;
        private List<Quake> _quakes;
        private Position3D _lastPlayerPosition;
        private double _maxQuakeDistance;
        private double _maxShakeAmplitude;
        private double _sinusFactor;
        private double _maxStrength;

        public CameraShaker(IPlayerObserver playerObserver, double maxQuakeDistance, double maxShakeAmplitude, double sinusFactor, double maxStrength)
        {
            _playerObserver = playerObserver;
            _maxQuakeDistance = maxQuakeDistance;
            _maxShakeAmplitude = maxShakeAmplitude;
            _sinusFactor = sinusFactor;
            _maxStrength = maxStrength;
            _quakes = new List<Quake>();
        }

        void IPlayerObserver.InterpretPlayerInformation(IPlayerInformation gameElementMetaInformation)
        {
            _lastPlayerPosition = gameElementMetaInformation.PlayerCameraInformation.CameraPosition.Clone();

            ManipulatePosition(gameElementMetaInformation.PlayerCameraInformation.CameraPosition);

            _playerObserver.InterpretPlayerInformation(gameElementMetaInformation);
        }

        private void ManipulatePosition(Position3D position)
        {
            double sinusWave = Math.Sin(TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds * Math.PI * _sinusFactor) * _maxShakeAmplitude; 

            foreach(Quake quake in _quakes)
            {
                position.PositionX += quake.Strength * sinusWave * 0.5;
                position.PositionY += quake.Strength * sinusWave * 0.5;
                position.PositionZ += quake.Strength * sinusWave;

                quake.Strength -= TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond;
            }

            _quakes.RemoveAll(x => x.Strength <= 0.0);
        }

        void IQuakeTriggerer.TriggerRelativeQuake(Position3D quakePosition, double strengthPercent)
        {
            double strength = RelativateStrength(CutOffStrength(strengthPercent), quakePosition);
            if (strength < 0.0001)
                return;

            _quakes.Add(new Quake { Strength = strength, StartTime = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds });
        }

        private double RelativateStrength(double strengthPercent, Position3D quakePosition)
        {
            if (_lastPlayerPosition == null)
                return strengthPercent;

            DistanceBetweenTwoPositions distance = new DistanceBetweenTwoPositions(quakePosition, _lastPlayerPosition);

            if (distance.DistanceXY >= _maxQuakeDistance)
                return 0.0;

            return strengthPercent * (1 - (distance.DistanceXY / _maxQuakeDistance));
        }

        private double CutOffStrength(double strength)
        {
            if (strength < _maxStrength)
                return strength;
            return _maxStrength;
        }

        void IQuakeTriggerer.TriggerAbsoluteQuake(double strengthPercent)
        {
            _quakes.Add(new Quake { Strength = strengthPercent, StartTime = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds });
        }
    }
}
