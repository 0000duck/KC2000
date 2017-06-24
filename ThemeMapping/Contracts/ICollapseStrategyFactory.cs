using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using GameInteractionContracts;
using IOInterface;

namespace ThemeMapping.Contracts
{
    public interface ICollapseStrategyFactory
    {
        IBehaviourStrategy BuildCollapseStrategy(ElementTheme elementTheme, IBehaviourStrategy strategyWithLegs, double collapseTime, double collapseTimeWithoutLegs, IDestructionObserver weaponLooser,
            ICollapseObserver collapseObserver, IEnemyDestructionObserver enemyDestructionObserver);
    }
}
