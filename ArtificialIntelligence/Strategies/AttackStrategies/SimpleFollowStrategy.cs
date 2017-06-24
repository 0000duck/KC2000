using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.Strategies.AttackStrategies
{
    public class SimpleFollowStrategy : IBehaviourStrategy
    {
        private IPositionProvider _positionProvider;
        private IUpdateTimer _updateTimer;
        private IFootSwitcher _footSwitcher;
        private DegreeFader _degreeFader;
        private PercentFader _degreePercentFader;
        private PercentFader _stepPercentFader;
        private ITargetDegreeCalculator _targetDegreeCalculator;
        private double _speed;

        public SimpleFollowStrategy(IPositionProvider positionProvider, IUpdateTimer updateTimer, IFootSwitcher footSwitcher, double degreeFadeDuration, double stepDuration, ITargetDegreeCalculator targetDegreeCalculator, double speed)
        {
            _positionProvider = positionProvider;
            _updateTimer = updateTimer;
            _footSwitcher = footSwitcher;
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
                Position3D enemyPosition = _positionProvider.GetPosition();
                if (enemyPosition != null)
                {
                    _degreeFader.StartFading(behaviourParameters.Orientation, _targetDegreeCalculator.CalculateTargetDegree(behaviourParameters.Position, enemyPosition));   
                }
                else
                {
                    _degreeFader.StartFading(behaviourParameters.Orientation, behaviourParameters.Orientation);
                }
                _degreePercentFader.Start();
            }

            if (_stepPercentFader.IsFinished())
            {
                _stepPercentFader.Start();
                _footSwitcher.SwitchFoot();
            }
            BehaviourInstruction behaviourInstruction = new BehaviourInstruction();
            
            behaviourInstruction.ViewDegree = _degreeFader.GetInterpolatedDegree(_degreePercentFader.GetPercent());
            behaviourInstruction.MovementDegree = behaviourInstruction.ViewDegree;
            behaviourInstruction.Percent = _stepPercentFader.GetPercent();
            behaviourInstruction.Behaviour = _footSwitcher.GetLeadingFoot(behaviourInstruction.Percent);
            behaviourInstruction.Speed = _speed;

            return behaviourInstruction;
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return _positionProvider.GetPosition() != null;
        }
    }
}