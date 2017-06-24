using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;

namespace ArtificialIntelligence.Strategies
{
    public class PriorizedStrategy : IBehaviourStrategy
    {
        private Dictionary<int, IBehaviourStrategy> _byPrioOrderedStrategies;
        private int _strategyKey;

        public PriorizedStrategy(Dictionary<int, IBehaviourStrategy> byPrioOrderedStrategies)
        {
            _byPrioOrderedStrategies = byPrioOrderedStrategies;
            _strategyKey = byPrioOrderedStrategies.Keys.Count;
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return _byPrioOrderedStrategies[_strategyKey].MovementCanBeBreaked();
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            SwitchStrategyByPrio();

            return _byPrioOrderedStrategies[_strategyKey].GetInstruction(behaviourParameters);
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return _byPrioOrderedStrategies[_strategyKey].ActivityIsNecessary();
        }

        private void SwitchStrategyByPrio()
        {
            int highestNecessaryPrio = 1000;

            foreach (int key in _byPrioOrderedStrategies.Keys)
            {
                if (_byPrioOrderedStrategies[key].ActivityIsNecessary())
                {
                    if (key < highestNecessaryPrio)
                    {
                        highestNecessaryPrio = key;
                    }
                }
            }

            if (highestNecessaryPrio == _strategyKey)
                return;

            if (_byPrioOrderedStrategies[_strategyKey].MovementCanBeBreaked())
            {
                _strategyKey = highestNecessaryPrio;
            }

            if(_strategyKey == 1000)
                _strategyKey = _byPrioOrderedStrategies.Keys.Count;
        }
    }
}
