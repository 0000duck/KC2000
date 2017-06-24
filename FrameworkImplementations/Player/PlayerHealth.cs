using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using FrameworkContracts;

namespace FrameworkImplementations.Player
{
    public class PlayerHealth : IFullVulnerable
    {
        private IPlayerHealthObserver _playerHealthObserver;
        private IFullVulnerable _bloodRenderer;
        private int _health;
        private IPlayerDeathObserver _playerDeathObserver;
        private bool _playerDied;
        private double _divisionFactor;

        public PlayerHealth(IPlayerHealthObserver playerHealthObserver, IFullVulnerable bloodRenderer, IPlayerDeathObserver playerDeathObserver, double divisionFactor)
        {
            _playerHealthObserver = playerHealthObserver;
            _bloodRenderer = bloodRenderer;
            _playerDeathObserver = playerDeathObserver;
            _health = 100;
            _divisionFactor = divisionFactor;
            _playerHealthObserver.HealthHasChanged(_health);
        }

        void IVulnerable.YouGotHit(Position3D position, double destructionStrength, Vector3D directionVector)
        {
            destructionStrength /= _divisionFactor;
            SubstractDamage(destructionStrength);

            _playerHealthObserver.HealthHasChanged(_health);
            _bloodRenderer.YouGotHit(position, destructionStrength, directionVector);
        }

        void IExplosionVulnerable.YouGotHit(Position3D explosionPosition, double destructionStrength)
        {
            destructionStrength /= _divisionFactor;
            SubstractDamage(destructionStrength);

            _playerHealthObserver.HealthHasChanged(_health);
            _bloodRenderer.YouGotHit(explosionPosition, destructionStrength);
        }

        private void SubstractDamage(double destructionStrength)
        {
            _health -= (int)destructionStrength;
            if (_health < 0)
            {
                _health = 0;
            }

            if (_playerDied)
                return;

            if (_health == 0)
            {
                _playerDeathObserver.PlayerGotKilled();
                _playerDied = true;
            }
        }
    }
}
