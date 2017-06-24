using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using GameInteractionContracts;


namespace ArtificialIntelligence.Strategies
{
    public class StepQuakeStrategy : IBehaviourStrategy
    {
        private IBehaviourStrategy _strategy;
        private bool _above90Percent;
        private IQuakeTriggerer _quakeTriggerer;
        private double _strength;

        public StepQuakeStrategy(IBehaviourStrategy strategy, IQuakeTriggerer quakeTriggerer, double strength)
        {
            _strategy = strategy;
            _quakeTriggerer = quakeTriggerer;
            _strength = strength;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return _strategy.MovementCanBeBreaked();
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            BehaviourInstruction behaviourInstruction = _strategy.GetInstruction(behaviourParameters);

            if (behaviourInstruction.Percent > 0.9)
            {
                if (!_above90Percent)
                    _quakeTriggerer.TriggerRelativeQuake(behaviourParameters.Position, _strength);

                _above90Percent = true;
            }
            else 
            {
                _above90Percent = false;
            }

            return behaviourInstruction;
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return _strategy.ActivityIsNecessary();
        }
    }
}
