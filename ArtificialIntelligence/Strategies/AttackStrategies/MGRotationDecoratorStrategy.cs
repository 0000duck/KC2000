using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using BaseContracts;

namespace ArtificialIntelligence.Strategies.AttackStrategies
{
    public class MGRotationDecoratorStrategy : IBehaviourStrategy, IWeaponFirerer, IWorldElementProvider
    {
        private IBehaviourStrategy _behaviourStrategy;
        private IWeaponFirerer _weaponFirerer;
        private IWorldElementProvider _worldElementProvider;
        private IAcceleratedSpeedProvider _acceleratedPercentLooper;
        private double _minFireSpeed;
        private double _firePercent;

        public MGRotationDecoratorStrategy(IWorldElementProvider worldElementProvider, IAcceleratedSpeedProvider acceleratedPercentLooper, double minFireSpeed)
        {
            _worldElementProvider = worldElementProvider;
            _acceleratedPercentLooper = acceleratedPercentLooper;
            _minFireSpeed = minFireSpeed;
        }

        public void SetWeaponFirerer(IWeaponFirerer weaponFirerer)
        {
            _weaponFirerer = weaponFirerer;
        }

        public void SetStrategy(IBehaviourStrategy behaviourStrategy)
        {
            _behaviourStrategy = behaviourStrategy;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return _behaviourStrategy.MovementCanBeBreaked();
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            BehaviourInstruction behaviourInstruction = _behaviourStrategy.GetInstruction(behaviourParameters);

            _firePercent += _acceleratedPercentLooper.GetSpeed() * TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond;

            if (_firePercent > 1.0)
            {
                _firePercent -= ((int)_firePercent);
            }
            behaviourInstruction.Percent = _firePercent;

            return behaviourInstruction;
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return _behaviourStrategy.ActivityIsNecessary();
        }

        IWorldElement IWorldElementProvider.GetElement()
        {
            IWorldElement element = _worldElementProvider.GetElement();

            if (element == null)
            {
                _acceleratedPercentLooper.EndAcceleration();
            }
            else
            {
                _acceleratedPercentLooper.StartAcceleration();
            }

            return element;
        }

        void IWeaponFirerer.Fire(Position3D weaponOwnerPosition, IWorldElement targetElement, Degree weaponOwnerOrientation)
        {
            if (_acceleratedPercentLooper.GetSpeed() < _minFireSpeed)
                return;

            _weaponFirerer.Fire(weaponOwnerPosition, targetElement, weaponOwnerOrientation);
        }
    }
}
