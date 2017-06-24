using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.Strategies.PatrolStrategies
{
    public class BackwardMovementStrategy : IBehaviourStrategy
    {
        private IDegreeRotater _degreeRotator;
        private double _speed;

        public BackwardMovementStrategy(IDegreeRotater degreeRotator, double speed)
        {
            _degreeRotator = degreeRotator;
            _speed = speed;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return true;
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            Degree backward = _degreeRotator.GetNextDegree(behaviourParameters.Orientation);
            backward = _degreeRotator.GetNextDegree(backward);
            backward = _degreeRotator.GetNextDegree(backward);
            backward = _degreeRotator.GetNextDegree(backward);

            return new BehaviourInstruction 
            {
                MovementDegree = backward,
                Speed = _speed,
                ViewDegree = behaviourParameters.Orientation
            };
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return true;
        }
    }
}
