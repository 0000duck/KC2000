using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using IOInterface;
using BaseTypes;

namespace ArtificialIntelligence.Strategies
{
    public class DeadRobotStrategy: IBehaviourStrategy, IDestructionObserver
    {
        private IBehaviourStrategy _mainStrategy;
        private bool _robotDied;
        private double _startTime;

        public DeadRobotStrategy(IBehaviourStrategy mainStrategy)
        {
            _mainStrategy = mainStrategy;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return (!_robotDied) && _mainStrategy.MovementCanBeBreaked();
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            if (_robotDied)
            {
                return new BehaviourInstruction
                {
                    Behaviour = Behaviour.LyingOnFloor,
                    ViewDegree = behaviourParameters.Orientation
                };
            }

            return _mainStrategy.GetInstruction(behaviourParameters);
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return _robotDied || _mainStrategy.ActivityIsNecessary();
        }

        void IDestructionObserver.NotifyFullDestruction(BodyPart bodyPart, Position3D position)
        {
            _robotDied = true;
        }

        void IDestructionObserver.NotifyInnerDestruction()
        {
            _robotDied = true;
        }
    }
}
