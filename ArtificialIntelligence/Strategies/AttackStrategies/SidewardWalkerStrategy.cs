using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using IOInterface;

namespace ArtificialIntelligence.Strategies.AttackStrategies
{
    public class SidewardWalkerStrategy : IBehaviourStrategy
    {
        private IWorldElementProvider _enemyProvider;
        private IUpdateTimer _updateTimer;
        private DegreeFader _degreeFader;
        private PercentFader _degreePercentFader;
        private PercentFader _stepPercentFader;
        private ITargetDegreeCalculator _targetDegreeCalculator;
        private Degree _walkDirection;
        private double _speed;

        public SidewardWalkerStrategy(IWorldElementProvider enemyProvider, IUpdateTimer updateTimer, double degreeFadeDuration, double stepDuration, ITargetDegreeCalculator targetDegreeCalculator, Degree walkDirection, double speed)
        {
            _enemyProvider = enemyProvider;
            _updateTimer = updateTimer;
            _walkDirection = walkDirection;
            _speed = speed;

            _degreeFader = new DegreeFader();
            _degreePercentFader = new PercentFader(degreeFadeDuration);
            _stepPercentFader = new PercentFader(stepDuration);
            _targetDegreeCalculator = targetDegreeCalculator;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return _stepPercentFader.CanBeStarted();
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            if (_updateTimer.UpdateIsNecessary())
            {
                IWorldElement enemy = _enemyProvider.GetElement();
                if (enemy != null)
                {
                    _degreeFader.StartFading(behaviourParameters.Orientation, _targetDegreeCalculator.CalculateTargetDegree(behaviourParameters.Position, enemy.Position));
                }
                else
                {
                    _degreeFader.StartFading(behaviourParameters.Orientation, behaviourParameters.Orientation);
                }
            }

            if (_stepPercentFader.IsFinished())
            {
                _stepPercentFader.Start();
            }
            BehaviourInstruction behaviourInstruction = new BehaviourInstruction();
            
            behaviourInstruction.ViewDegree = _degreeFader.GetInterpolatedDegree(_degreePercentFader.GetPercent());
            behaviourInstruction.MovementDegree = (int)behaviourInstruction.ViewDegree + _walkDirection;
            
            if (behaviourInstruction.MovementDegree > Degree.Degree_315)
                behaviourInstruction.MovementDegree -= 8;

            behaviourInstruction.Percent = 0.3;
            behaviourInstruction.Speed = _speed;
            behaviourInstruction.Behaviour = MapBehaviour(_stepPercentFader.GetPercent(), _walkDirection);


            return behaviourInstruction;
        }

        private Behaviour MapBehaviour(double percent, Degree walkDirection)
        {
            switch (walkDirection)
            {
                case Degree.Degree_90:
                    if (percent < 0.33)
                        return Behaviour.StepWithRightFoot;
                    if (percent < 0.66)
                        return Behaviour.StepWithLeftFoot;
                    return Behaviour.StandardBehaviour;
                case Degree.Degree_270:
                    if (percent < 0.33)
                        return Behaviour.StepWithLeftFoot;
                    if (percent < 0.66)
                        return Behaviour.StepWithRightFoot;
                    return Behaviour.StandardBehaviour;
            }
            return Behaviour.StandardBehaviour;
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return _enemyProvider.GetElement() != null;
        }
    }
}
