using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using IOInterface;
using BaseTypes;

namespace ArtificialIntelligence.Strategies.AttackStrategies
{
    public class FollowOrRotateStrategy : IBehaviourStrategy
    {
        private enum Strategy
        {
            Follow = 1,

            Rotate = 2
        }

        private IBehaviourStrategy _followStrategy;
        private IBehaviourStrategy _rotateStrategy;
        private IFollowDecider _followDecider;
        private Strategy _currentStrategy;

        public FollowOrRotateStrategy(IBehaviourStrategy followStrategy, IBehaviourStrategy rotateStrategy, IFollowDecider followDecider)
        {
            _followStrategy = followStrategy;
            _rotateStrategy = rotateStrategy;
            _followDecider = followDecider;
            _currentStrategy = Strategy.Rotate;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            switch (_currentStrategy)
            {
                case Strategy.Rotate:
                    return _rotateStrategy.MovementCanBeBreaked();
                case Strategy.Follow:
                    return _followStrategy.MovementCanBeBreaked();
            }
            return true;
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            switch (_currentStrategy)
            {
                case Strategy.Rotate:
                    if (_rotateStrategy.MovementCanBeBreaked() && _followDecider.GotToFollow())
                    {
                        _currentStrategy = Strategy.Follow;
                    }
                    return _rotateStrategy.GetInstruction(behaviourParameters);
                case Strategy.Follow:
                    if (_followStrategy.MovementCanBeBreaked() && !_followDecider.GotToFollow())
                    {
                        _currentStrategy = Strategy.Rotate;
                    }
                    return _followStrategy.GetInstruction(behaviourParameters);
            }

            return new BehaviourInstruction
            {
                ViewDegree = behaviourParameters.Orientation,
                Behaviour = Behaviour.StandardBehaviour
            };
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            switch (_currentStrategy)
            {
                case Strategy.Rotate:
                    return _rotateStrategy.ActivityIsNecessary();
                case Strategy.Follow:
                    return _followStrategy.ActivityIsNecessary();
            }
            return false;
        }
    }
}
