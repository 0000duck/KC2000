using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using IOInterface;
using BaseTypes;

namespace ArtificialIntelligence.Strategies.AttackStrategies
{
    public class DuckAttackStrategy : IBehaviourStrategy
    {
        private IWorldElementProvider _enemyProvider;
        private IWeaponFirerer _weaponFirerer;
        private IDucker _ducker;
        private Status _status;
        private IRandomDurationGenerator _randomDurationGenerator;
        private ITargetDegreeCalculator _targetDegreeCalculator;

        private enum Status
        {
            NothingToDo = 0,
            Firering = 1,
            Ducking = 2,
        }

        public DuckAttackStrategy(IWorldElementProvider enemyProvider, IWeaponFirerer weaponFirerer, IDucker ducker, IRandomDurationGenerator randomDurationGenerator, ITargetDegreeCalculator targetDegreeCalculator)
        {
            _enemyProvider = enemyProvider;
            _weaponFirerer = weaponFirerer;
            _ducker = ducker;
            _randomDurationGenerator = randomDurationGenerator;
            _targetDegreeCalculator = targetDegreeCalculator;
            _status = Status.Firering;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            switch(_status)
            {
                case Status.Ducking:
                    return !_ducker.IsDucking();
                case Status.Firering:
                    return _enemyProvider.GetElement() == null;
            }
            return true;
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            switch (_status)
            {
                case Status.Firering:
                    if (_randomDurationGenerator.IsFinished())
                    {
                        _status = Status.Ducking;
                        _ducker.StartDucking();
                    }
                    else
                    {
                        IWorldElement enemy = _enemyProvider.GetElement();
                        if (enemy != null)
                        {
                            if (_targetDegreeCalculator.CalculateTargetDegree(behaviourParameters.Position, enemy.Position) == behaviourParameters.Orientation)
                                 _weaponFirerer.Fire(behaviourParameters.Position, enemy, behaviourParameters.Orientation);
                        }
                    }
                    break;
                case Status.Ducking:
                    if (_ducker.IsDucking())
                    {
                        DuckResult result = _ducker.GetDuckResult();
                        return new BehaviourInstruction
                        {
                            ViewDegree = behaviourParameters.Orientation,
                            Percent= result.Percent,
                            Behaviour = result.Behaviour
                        };
                    }
                    else
                    {
                        _status = Status.Firering;
                        _randomDurationGenerator.StartRandomDuration();
                        IWorldElement enemy = _enemyProvider.GetElement();
                        if (enemy != null)
                        {
                            Vector2D vector = MathHelper.CreateVector2D(behaviourParameters.Position, enemy.Position);
                            Degree targetDegree = VectorToDegreeConverter.Convert(vector);
                            return new BehaviourInstruction
                            {
                                Behaviour = Behaviour.StandardBehaviour,
                                ViewDegree = targetDegree,
                                Percent = 0
                            };
                        }
                    }
                    break;
            }

            return new BehaviourInstruction
            {
                Behaviour = Behaviour.StandardBehaviour,
                ViewDegree = behaviourParameters.Orientation,
                Percent = 0
            };
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return _enemyProvider.GetElement() != null;
        }
    }
}
