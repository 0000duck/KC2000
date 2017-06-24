using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using IOInterface;
using BaseTypes;

namespace ArtificialIntelligence.Strategies.AttackStrategies
{
    public class JumpDecorator : IBehaviourStrategy
    {
        private IBehaviourStrategy _movementStrategy;
        private IWorldElementProvider _simpleSoldierProvider;
        private bool _jumping;
        private double _speed;
        private Direction _currentDirection;
        private double _lastJumpEnding;
        private double _jumpBreak;

        public JumpDecorator(IBehaviourStrategy movementStrategy, IWorldElementProvider simpleSoldierProvider, double speed, double jumpBreak)
        {
            _movementStrategy = movementStrategy;
            _simpleSoldierProvider = simpleSoldierProvider;
            _speed = speed;
            _currentDirection = Direction.FromBottomToTop;
            _jumpBreak = jumpBreak;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return (!_jumping) && _movementStrategy.MovementCanBeBreaked();
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            BehaviourInstruction behaviourInstruction = _movementStrategy.GetInstruction(behaviourParameters);

            
            if (_jumping)
            {
                IWorldElement element = _simpleSoldierProvider.GetElement();
                IMovableByImpulse character = (IMovableByImpulse)element;

                behaviourInstruction.Behaviour = Behaviour.Jump;

                if (character.CollisionProtocol.IsCollisionFloor)
                {
                    _jumping = false;
                    _lastJumpEnding = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
                    behaviourInstruction.Percent = 1;
                }
                else
                {
                    character.AddImpulse(new Impulse { ImpulseDirection = Direction.FromFloorToCeiling, Strength = _speed + element.Weight });
                    character.AddImpulse(new Impulse { ImpulseDirection = _currentDirection, Strength = (_speed / 4.0) + element.Weight });
                    behaviourInstruction.Percent = 0.5;
                }
            }
            else
            {
                if (_lastJumpEnding + _jumpBreak < TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds)
                {
                    _jumping = true;
                    SwitchDirection();
                }
            }

            return behaviourInstruction;
        }

        private void SwitchDirection()
        {
            switch (_currentDirection)
            {
                case Direction.FromBottomToTop:
                    _currentDirection = Direction.FromLeftToRight;
                    return;
                case Direction.FromLeftToRight:
                    _currentDirection = Direction.FromTopToBottom;
                    return;
                case Direction.FromRightToLeft:
                    _currentDirection = Direction.FromBottomToTop;
                    return;
                case Direction.FromTopToBottom:
                    _currentDirection = Direction.FromRightToLeft;
                    return;
            }
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return _movementStrategy.ActivityIsNecessary();
        }
    }
}
