using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using Gravity;

namespace ArtificialIntelligence.Strategies
{
    public class SpinningGravityStrategy : IBehaviourStrategy
    {
        private IWorldElementProvider _elementProvider;
        private ISpinningAccelerator _spinningAccelerator;
        private IGravitationCalculator _gravitationCalculator;
        private GravitationStatus _gravitationStatus;
        private IExploder _exploder;

        public SpinningGravityStrategy(IWorldElementProvider elementProvider, ISpinningAccelerator spinningAccelerator, IGravitationCalculator gravitationCalculator, IExploder exploder)
        {
            _elementProvider = elementProvider;
            _spinningAccelerator = spinningAccelerator;
            _gravitationCalculator = gravitationCalculator;
            _exploder = exploder;
            _gravitationStatus = new GravitationStatus { GravitationIsActive = true };
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return false;
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            IWorldElement element = _elementProvider.GetElement();
            IMovableByImpulse character = (IMovableByImpulse)element;

            if (character.CollisionProtocol.IsCollisionFloor || behaviourParameters.Position.PositionZ < -0.1)
            {
                _exploder.Explode(behaviourParameters.Position);
            }

            _gravitationCalculator.TriggerGravitation(element, _gravitationStatus);

            Degree degree = _spinningAccelerator.GetAcceleratedDegree(behaviourParameters.Orientation);

            return new BehaviourInstruction
            {
                ViewDegree = degree,
                MovementDegree = degree,
                Speed = 500
            };
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return true;
        }
    }
}
