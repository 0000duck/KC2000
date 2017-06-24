using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.Strategies.AttackStrategies
{
    public class AirLineFollowStrategy : IBehaviourStrategy
    {
        private IBehaviourStrategy _movementStrategy;
        private IWorldElementProvider _enemyProvider;
        private ITargetDegreeCalculator _targetDegreeCalculator;
        private double _maxSquareDistance;

        public AirLineFollowStrategy(IBehaviourStrategy movementStrategy, IWorldElementProvider enemyProvider, ITargetDegreeCalculator targetDegreeCalculator, double maxDistance)
        {
            _movementStrategy = movementStrategy;
            _enemyProvider = enemyProvider;
            _targetDegreeCalculator = targetDegreeCalculator;
            _maxSquareDistance = maxDistance * maxDistance;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return _movementStrategy.MovementCanBeBreaked();
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            BehaviourInstruction behaviourInstruction = _movementStrategy.GetInstruction(behaviourParameters);
            
            IWorldElement enemy = _enemyProvider.GetElement();
            
            if (enemy != null)
            {
                if (new DistanceBetweenTwoPositions(behaviourParameters.Position, enemy.Position).SquareDistanceXY < _maxSquareDistance)
                {
                    behaviourInstruction.MovementVector = MathHelper.CreateVector2D(behaviourParameters.Position, enemy.Position);
                    behaviourInstruction.MovementVector.CalculateUnitLength();
                    behaviourInstruction.MovementDegree = null;
                    behaviourInstruction.ViewDegree = _targetDegreeCalculator.CalculateTargetDegree(behaviourParameters.Position, enemy.Position);
                }
            }

            return behaviourInstruction;
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return _movementStrategy.ActivityIsNecessary();
        }
    }
}
