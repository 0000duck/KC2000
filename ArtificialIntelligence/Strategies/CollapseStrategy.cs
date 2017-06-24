using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using IOInterface;
using GameInteractionContracts;

namespace ArtificialIntelligence.Strategies
{
    public class CollapseStrategy : IBehaviourStrategy, IDestructionObserver
    {
        private double _collapseTime;
        private  double _collapseTimeWithoutLegs;
        private IBehaviourStrategy _strategyWithLegs;
        private PercentFader _collapsePercentFader;
        private bool _collapseHasBegun;
        private bool _characterDied;
        private IDestructionObserver _weaponLooser;
        private bool _weaponLooserNotified;
        private ICollapseObserver _collapseObserver;
        private IEnemyDestructionObserver _enemyDestructionObserver;

        public CollapseStrategy(IBehaviourStrategy strategyWithLegs, double collapseTime, double collapseTimeWithoutLegs, IDestructionObserver weaponLooser,
            ICollapseObserver collapseObserver, IEnemyDestructionObserver enemyDestructionObserver)
        {
            _collapseTime = collapseTime;
            _collapseTimeWithoutLegs = collapseTimeWithoutLegs;
            _strategyWithLegs = strategyWithLegs;
            _weaponLooser = weaponLooser;
            _collapseObserver = collapseObserver;
            _enemyDestructionObserver = enemyDestructionObserver;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return (!_collapseHasBegun) && _strategyWithLegs.MovementCanBeBreaked();
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            if (!_characterDied)
                return _strategyWithLegs.GetInstruction(behaviourParameters);

            if (!_collapseHasBegun)
            {
                BehaviourInstruction behaviourInstruction = _strategyWithLegs.GetInstruction(behaviourParameters);

                if (behaviourInstruction.Behaviour == IOInterface.Behaviour.Ducked)
                {
                    if (behaviourInstruction.Percent < 0.5)
                    {
                        _collapsePercentFader = new PercentFader(_collapseTime);
                        _collapsePercentFader.Start(0.26);
                    }
                    else 
                    {
                        _collapsePercentFader = new PercentFader(_collapseTime);
                        _collapsePercentFader.Start(0.51);
                    }

                    _collapseHasBegun = true;
                }
                else if (behaviourInstruction.Percent <= 0.05 || behaviourInstruction.Percent >= 0.95)
                {
                    _collapseHasBegun = true;
                    _collapsePercentFader = new PercentFader(_collapseTime);
                    _collapsePercentFader.Start();
                }
                else
                {
                    return behaviourInstruction;
                }
            }

            double percent = _collapsePercentFader.GetPercent();

            if (percent > 0.95)
                _collapseObserver.CharacterHasCollapsed();

            if (percent <= 0.5)
            {
                return new BehaviourInstruction
                {
                    ViewDegree = behaviourParameters.Orientation,
                    Behaviour = IOInterface.Behaviour.Collapse,
                    Percent = percent * 2
                };
            }

            if (!_weaponLooserNotified)
            {
                _weaponLooser.NotifyFullDestruction(BodyPart.Arms, null);
                _weaponLooserNotified = true;
            }

            return new BehaviourInstruction
            {
                ViewDegree = behaviourParameters.Orientation,
                Behaviour = IOInterface.Behaviour.LyingOnFloor,
                Percent = (percent - 0.5) * 2
            };
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return _strategyWithLegs.ActivityIsNecessary();
        }

        void IDestructionObserver.NotifyFullDestruction(BodyPart bodyPart, Position3D position)
        {
            if (_characterDied)
                return;

            _characterDied = true;

            if (bodyPart == BodyPart.Legs)
            {
                _collapseHasBegun = true;
                _collapsePercentFader = new PercentFader(_collapseTimeWithoutLegs);
                _collapsePercentFader.Start();
            }

            _enemyDestructionObserver.EnemyDestroyed();
        }

        void IDestructionObserver.NotifyInnerDestruction()
        {
            if (_characterDied)
                return;

            _characterDied = true;

            _enemyDestructionObserver.EnemyDestroyed();
        }
    }
}
