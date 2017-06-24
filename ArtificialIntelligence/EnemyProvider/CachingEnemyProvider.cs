using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.EnemyProvider
{
    public class CachingEnemyProvider : IWorldElementProvider
    {
        private IWorldElementProvider _enemyProvider;
        private double _cacheTimeoutInSeconds;
        private double _lastCacheBegin;
        private bool _usingCachedElement;
        private IWorldElement _cachedEnemy;

        public CachingEnemyProvider(IWorldElementProvider enemyProvider, double cacheTimeoutInSeconds)
        {
            _enemyProvider = enemyProvider;
            _cacheTimeoutInSeconds = cacheTimeoutInSeconds;
            _cachedEnemy = null;
            _usingCachedElement = false;
        }

        IWorldElement IWorldElementProvider.GetElement()
        {
            IWorldElement enemy = _enemyProvider.GetElement();

            if (enemy == null)
            {
                if (_usingCachedElement)
                {
                    if (TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - _lastCacheBegin > _cacheTimeoutInSeconds)
                    {
                        _cachedEnemy = null;
                        _usingCachedElement = false;
                    }
                }
                else
                {
                    if (_cachedEnemy != null)
                    {
                        _usingCachedElement = true;
                        _lastCacheBegin = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
                    }
                }
            }
            else
            {
                _cachedEnemy = enemy;
                _usingCachedElement = false;
            }

            return _cachedEnemy;
        }
    }
}
