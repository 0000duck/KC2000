using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.EnemyProvider
{
    public class SoundConnector : ISoundSharer, ISoundObserver
    {
        private double _squareDistanceForLowLevelHearable;
        private double _squareDistanceForMediumLevelHearable;
        private double _squareDistanceForHighLevelHearable;
        private double _squareDistanceForLowLevelIdentifyable;
        private double _squareDistanceForMediumLevelIdentifyable;
        private double _squareDistanceForHighLevelIdentifyable;
        private double _timeToLiveInSeconds;
        private SoundEvent _soundEvent;

        public SoundConnector(double distanceForLowLevelHearable, double distanceForMediumLevelHearable, double distanceForHighLevelHearable,
            double distanceForLowLevelIdentifyable, double distanceForMediumLevelIdentifyable, double distanceForHighLevelIdentifyable, double timeToLiveInSeconds)
        {
            _squareDistanceForLowLevelHearable = distanceForLowLevelHearable * distanceForLowLevelHearable;
            _squareDistanceForMediumLevelHearable = distanceForMediumLevelHearable * distanceForMediumLevelHearable;
            _squareDistanceForHighLevelHearable = distanceForHighLevelHearable * distanceForHighLevelHearable;
            _squareDistanceForLowLevelIdentifyable = distanceForLowLevelIdentifyable * distanceForLowLevelIdentifyable;
            _squareDistanceForMediumLevelIdentifyable = distanceForMediumLevelIdentifyable * distanceForMediumLevelIdentifyable;
            _squareDistanceForHighLevelIdentifyable = distanceForHighLevelIdentifyable * distanceForHighLevelIdentifyable;
            _timeToLiveInSeconds = timeToLiveInSeconds;
            _soundEvent = null;
        }

        bool ISoundSharer.SoundCanBeHeared(Position3D position)
        {
            return SoundIsNearEnuogh(position, _squareDistanceForLowLevelHearable, _squareDistanceForMediumLevelHearable, _squareDistanceForHighLevelHearable);
        }

        bool ISoundSharer.SoundIsNearEnoughToIdentifyPosition(Position3D position)
        {
            return SoundIsNearEnuogh(position, _squareDistanceForLowLevelIdentifyable, _squareDistanceForMediumLevelIdentifyable, _squareDistanceForHighLevelIdentifyable);
        }

        private bool SoundIsNearEnuogh(Position3D position, double lowDistance, double mediumDistance, double highDistance)
        {
            if (_soundEvent == null)
                return false;

            double ageOfSound = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - _soundEvent.TimeStamp;

            if (ageOfSound > _timeToLiveInSeconds)
            {
                _soundEvent = null;
                return false;
            }

            DistanceBetweenTwoPositions distanceBetweenTwoPositions = new DistanceBetweenTwoPositions(position, _soundEvent.Position);

            switch (_soundEvent.NoiseLevel)
            {
                case NoiseLevel.Low:
                    return distanceBetweenTwoPositions.SquareDistanceXY < lowDistance;
                case NoiseLevel.Medium:
                    return distanceBetweenTwoPositions.SquareDistanceXY < mediumDistance;
                case NoiseLevel.High:
                    return distanceBetweenTwoPositions.SquareDistanceXY < highDistance;
            }
            return false;
        }

        void ISoundObserver.SetSoundNotfication(NoiseLevel noiseLevel, Position3D position)
        {
            if (_soundEvent != null && noiseLevel < _soundEvent.NoiseLevel)
            {
                double ageOfSound = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - _soundEvent.TimeStamp;

                if (ageOfSound < _timeToLiveInSeconds)
                    return;
            }

            _soundEvent = new SoundEvent
            {
                NoiseLevel = noiseLevel, 
                Position = position, 
                TimeStamp = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds
            };
        }
    }
}
