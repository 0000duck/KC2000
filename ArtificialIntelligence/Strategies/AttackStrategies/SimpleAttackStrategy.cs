using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.Strategies.AttackStrategies
{
    public class SimpleAttackStrategy : IBehaviourStrategy
    {
        private IWorldElementProvider _enemyProvider;
        private IBehaviourStrategy _movementStrategy;
        private ITargetDegreeCalculator _targetDegreeCalculator;
        private IWeaponFirerer _weaponFirerer;

        public SimpleAttackStrategy(IWorldElementProvider enemyProvider, IBehaviourStrategy movementStrategy, ITargetDegreeCalculator targetDegreeCalculator, IWeaponFirerer weaponFirerer)
        {
            _enemyProvider = enemyProvider;
            _movementStrategy = movementStrategy;
            _targetDegreeCalculator = targetDegreeCalculator;
            _weaponFirerer = weaponFirerer;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return _movementStrategy.MovementCanBeBreaked();
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            FireIfEnemyIsFocused(behaviourParameters);

            return _movementStrategy.GetInstruction(behaviourParameters);
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return _movementStrategy.ActivityIsNecessary();
        }

        private void FireIfEnemyIsFocused(BehaviourParameters behaviourParameters)
        {
            IWorldElement enemy = _enemyProvider.GetElement();

            if (enemy != null)
            {
                if (_targetDegreeCalculator.CalculateTargetDegree(behaviourParameters.Position, enemy.Position) == behaviourParameters.Orientation)
                {
                    _weaponFirerer.Fire(behaviourParameters.Position, enemy, behaviourParameters.Orientation);
                }
            }
        }
    }
}
