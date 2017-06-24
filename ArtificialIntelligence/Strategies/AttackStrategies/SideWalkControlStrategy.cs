using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using IOInterface;

namespace ArtificialIntelligence.Strategies.AttackStrategies
{
    public class SideWalkControlStrategy : IBehaviourStrategy
    {
        private IBehaviourStrategy _followStrategy;
        private IBehaviourStrategy _walk90DegreeStrategy;
        private IBehaviourStrategy _walk270DegreeStrategy;
        private IBehaviourStrategy _rotateStrategy;
        private IDirectionDecider _directionDecider;
        private IRandomDurationGenerator _randomDurationGenerator;

        private Degree? _currentDirection;
        private int _numberOfSteps;

        public SideWalkControlStrategy(IBehaviourStrategy followStrategy, IBehaviourStrategy walk90DegreeStrategy, IBehaviourStrategy walk270DegreeStrategy, IBehaviourStrategy rotateStrategy, IDirectionDecider directionDecider, IRandomDurationGenerator randomDurationGenerator, int numberOfSteps)
        {
            _followStrategy = followStrategy;
            _walk270DegreeStrategy = walk270DegreeStrategy;
            _walk90DegreeStrategy = walk90DegreeStrategy;
            _rotateStrategy = rotateStrategy;
            _directionDecider = directionDecider;
            _randomDurationGenerator = randomDurationGenerator;
            _numberOfSteps = numberOfSteps;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            if (!_currentDirection.HasValue)
                return _rotateStrategy.MovementCanBeBreaked();

            switch (_currentDirection.Value)
            {
                case Degree.Degree_0:
                    return _followStrategy.MovementCanBeBreaked();
                case Degree.Degree_90:
                    return _walk90DegreeStrategy.MovementCanBeBreaked();
                case Degree.Degree_270:
                    return _walk270DegreeStrategy.MovementCanBeBreaked();
            }

            return true;
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            if (_randomDurationGenerator.IsFinished())
            {
                if (((IBehaviourStrategy)this).MovementCanBeBreaked())
                {
                    _randomDurationGenerator.StartRandomDuration();
                    _currentDirection = _directionDecider.GetMovementDirection(_numberOfSteps, behaviourParameters.Orientation);
                }
            }
            return GetBehaviour(behaviourParameters);
        }

        private BehaviourInstruction GetBehaviour(BehaviourParameters behaviourParameters)
        {
            if (!_currentDirection.HasValue)
                return _rotateStrategy.GetInstruction(behaviourParameters);

            switch (_currentDirection.Value)
            {
                case Degree.Degree_0:
                    return _followStrategy.GetInstruction(behaviourParameters);
                case Degree.Degree_90:
                    return _walk90DegreeStrategy.GetInstruction(behaviourParameters);
                case Degree.Degree_270:
                    return _walk270DegreeStrategy.GetInstruction(behaviourParameters);
            }

            return new BehaviourInstruction 
            {
                Behaviour = Behaviour.StandardBehaviour,
                ViewDegree = behaviourParameters.Orientation
            };
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            if (!_currentDirection.HasValue)
                return _rotateStrategy.ActivityIsNecessary();

            switch (_currentDirection.Value)
            {
                case Degree.Degree_0:
                    return _followStrategy.ActivityIsNecessary();
                case Degree.Degree_90:
                    return _walk90DegreeStrategy.ActivityIsNecessary();
                case Degree.Degree_270:
                    return _walk270DegreeStrategy.ActivityIsNecessary();
            }

            return false;
        }
    }
}
