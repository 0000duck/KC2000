using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using Sound.Contracts;

namespace ArtificialIntelligence.EnemyProvider
{
    public class LostVisibilityTriggeredThoughtToTextAdapter : IWorldElementProvider
    {
        private IWorldElementProvider _enemyProvider;
        private IWorldElementProvider _viewerProvider;
        private bool _seenSomething;
        private double _lastSpottedEnemyTimeStamp;
        private double _minTimeIntervall;
        private ISound _visualThought;

        public LostVisibilityTriggeredThoughtToTextAdapter(IWorldElementProvider enemyProvider, IWorldElementProvider viewerProvider, double minTimeIntervall, ISound visualThought)
        {
            _enemyProvider = enemyProvider;
            _viewerProvider = viewerProvider;
            _minTimeIntervall = minTimeIntervall;
            _visualThought = visualThought;
            _lastSpottedEnemyTimeStamp = -_minTimeIntervall;
        }

        IWorldElement IWorldElementProvider.GetElement()
        {
            IWorldElement enemy = _enemyProvider.GetElement();

            if (enemy != null)
            {
                _lastSpottedEnemyTimeStamp = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
                _seenSomething = true;
            }
            if (_seenSomething && enemy == null)
            {
                if (TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - _lastSpottedEnemyTimeStamp > _minTimeIntervall)
                {
                    IWorldElement viewer = _viewerProvider.GetElement();
                    
                    if (viewer != null)
                    {
                        _visualThought.SetPosition((float)viewer.Position.PositionX, (float)(viewer.Position.PositionZ + viewer.Height), (float)viewer.Position.PositionY);
                        _visualThought.Play();
                    }
                    _lastSpottedEnemyTimeStamp = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
                    _seenSomething = false;
                }
            }

            return enemy;
        }
    }
}
