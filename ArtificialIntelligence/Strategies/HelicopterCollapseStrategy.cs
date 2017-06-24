using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using IOInterface;
using BaseTypes;
using Sound.Contracts;

namespace ArtificialIntelligence.Strategies
{
    public class HelicopterCollapseStrategy : IBehaviourStrategy, IDestructionObserver
    {
        private IBehaviourStrategy _mainStrategy;
        private ISmoker _smoker;
        private bool _collapseHasBegun;
        private IBehaviourStrategy _spinningStrategy;

        public HelicopterCollapseStrategy(ISmoker smoker)
        {
            _smoker = smoker;
        }

        public void SetMainStrategy(IBehaviourStrategy mainStrategy)
        {
            _mainStrategy = mainStrategy;
        }

        public void SetSpinningStrategy(IBehaviourStrategy spinningStrategy)
        {
            _spinningStrategy = spinningStrategy;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            if (_collapseHasBegun)
                return true;

            return _mainStrategy.MovementCanBeBreaked();
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            if (!_collapseHasBegun)
                return _mainStrategy.GetInstruction(behaviourParameters);

            _smoker.Smoke(behaviourParameters.Position);

            return _spinningStrategy.GetInstruction(behaviourParameters);
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return _mainStrategy.ActivityIsNecessary();
        }

        void IDestructionObserver.NotifyFullDestruction(BodyPart bodyPart, Position3D position)
        {
            _collapseHasBegun = true;
        }

        void IDestructionObserver.NotifyInnerDestruction()
        {
            _collapseHasBegun = true;
        }
    }
}
