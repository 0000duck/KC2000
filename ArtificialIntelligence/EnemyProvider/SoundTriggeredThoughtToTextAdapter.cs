using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using Sound.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.EnemyProvider
{
    public class SoundTriggeredThoughtToTextAdapter : ISoundSharer
    {
        private ISoundSharer _soundSharer;
        private bool _couldBeHeard;
        private ISound _visualThought;
        private double _height;
        private double _lastSpottedSoundTimeStamp;
        private double _minTimeIntervall;

        public SoundTriggeredThoughtToTextAdapter(ISoundSharer soundSharer, ISound visualThought, double height, double minTimeIntervall)
        {
            _soundSharer = soundSharer;
            _visualThought = visualThought;
            _height = height;
            _minTimeIntervall = minTimeIntervall;
        }

        bool ISoundSharer.SoundCanBeHeared(Position3D position)
        {
            bool canBeHeard = _soundSharer.SoundCanBeHeared(position);

            if (_couldBeHeard && !canBeHeard)
                _lastSpottedSoundTimeStamp = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;

            if (!_couldBeHeard && canBeHeard)
            {
                if (TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - _lastSpottedSoundTimeStamp > _minTimeIntervall)
                {
                    _visualThought.SetPosition((float)position.PositionX, (float)(position.PositionZ + _height), (float)position.PositionY);
                    _visualThought.Play();

                    _lastSpottedSoundTimeStamp = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
                }
            }
            _couldBeHeard = canBeHeard;

            return canBeHeard;
        }

        bool ISoundSharer.SoundIsNearEnoughToIdentifyPosition(Position3D position)
        {
            bool canBeHeard = _soundSharer.SoundIsNearEnoughToIdentifyPosition(position);

            if (canBeHeard)
                _lastSpottedSoundTimeStamp = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;

            return canBeHeard;
        }
    }
}
