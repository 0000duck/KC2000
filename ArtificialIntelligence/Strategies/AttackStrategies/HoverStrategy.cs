using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using IOInterface;
using BaseContracts;
using BaseTypes;

namespace ArtificialIntelligence.Strategies.AttackStrategies
{
    public class HoverStrategy : IBehaviourStrategy
    {
        private IBehaviourStrategy _mainStrategy;
        private IPercentLooper _percentLooperFire;
        private PercentFader _percentFaderHover;
        private IWorldElementProvider _soldierProvider;
        private bool _hoverUp;
        private double _hoverStrength;

        public HoverStrategy(IBehaviourStrategy mainStrategy, IPercentLooper percentLooperFire, double hoverDuration, IWorldElementProvider soldierProvider, double hoverStrength)
        {
            _mainStrategy = mainStrategy;
            _percentLooperFire = percentLooperFire;
            _percentFaderHover = new PercentFader(hoverDuration);
            _percentFaderHover.Start();
            _soldierProvider = soldierProvider;
            _hoverUp = true;
            _hoverStrength = hoverStrength;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return _mainStrategy.MovementCanBeBreaked();
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            BehaviourInstruction instruction = _mainStrategy.GetInstruction(behaviourParameters);

            instruction.Behaviour = Behaviour.StandardBehaviour;
            instruction.Percent = _percentLooperFire.GetPercent();
            
            IWorldElement soldier = _soldierProvider.GetElement();

            IMovableByImpulse movingSoldier = (IMovableByImpulse)soldier;

            movingSoldier.AddImpulse(CalculateImpulse(soldier.Weight));

            return instruction;
        }

        private Impulse CalculateImpulse(double weight)
        {
            Impulse impulse = new Impulse();

            impulse.ImpulseDirection = _hoverUp ? Direction.FromFloorToCeiling : Direction.FromCeilingToFloor;

            double percent = _percentFaderHover.GetPercent();

            impulse.Strength = (_hoverStrength * Math.Cos(percent * Math.PI / 2)) + weight;

            if (_percentFaderHover.IsFinished())
            {
                _hoverUp = !_hoverUp;
                _percentFaderHover.Start();
            }

            return impulse;
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return _mainStrategy.ActivityIsNecessary();
        }
    }
}
