using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.Strategies.PatrolStrategies
{
    public class CircleWalkStrategy : IBehaviourStrategy
    {
        private IFootSwitcher _footSwitcher;
        private PercentFader _stepPercentFader;
        private IDegreeRotater _degreeRotater;
        private IStepFreeSpaceTester _stepFreeSpaceTester;
        private int _numberOfStepsPerDegree;
        private int _currentNumberOfStepsPerDegree;
        private int _counterOfCurrentStepsPerDegree;
        private double _speed;

        public CircleWalkStrategy(IFootSwitcher footSwitcher, IDegreeRotater degreeRotater, double stepDuration, int numberOfStepsPerDegree, IStepFreeSpaceTester stepFreeSpaceTester, double speed)
        {
            _footSwitcher = footSwitcher;
            _degreeRotater = degreeRotater;
            _numberOfStepsPerDegree = numberOfStepsPerDegree;
            _stepPercentFader = new PercentFader(stepDuration);
            _stepFreeSpaceTester = stepFreeSpaceTester;
            _speed = speed;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return _stepPercentFader.CanBeStarted();
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            BehaviourInstruction behaviourInstruction = new BehaviourInstruction();
            behaviourInstruction.ViewDegree = behaviourParameters.Orientation;

            if (_stepPercentFader.IsFinished())
            {
                _counterOfCurrentStepsPerDegree++;

                if (_counterOfCurrentStepsPerDegree > _currentNumberOfStepsPerDegree)
                {
                    _counterOfCurrentStepsPerDegree = 1;
                    behaviourInstruction.ViewDegree = _degreeRotater.GetNextDegree(behaviourInstruction.ViewDegree);
                    _currentNumberOfStepsPerDegree = _stepFreeSpaceTester.GetNumberOfFreeSteps(behaviourInstruction.ViewDegree, _numberOfStepsPerDegree);
                }
                _stepPercentFader.Start();
                _footSwitcher.SwitchFoot();
            }

            behaviourInstruction.MovementDegree = behaviourInstruction.ViewDegree;
            behaviourInstruction.Percent = _stepPercentFader.GetPercent();
            behaviourInstruction.Behaviour = _footSwitcher.GetLeadingFoot(behaviourInstruction.Percent);
            behaviourInstruction.Speed = _speed;

            return behaviourInstruction;
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return true;
        }
    }
}
