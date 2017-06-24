using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using ArtificialIntelligence.Contracts;
using GameInteractionContracts;
using IOInterface;
using ArtificialIntelligence.Strategies;
using ArtificialIntelligence.Strategies.Spinning;

namespace ThemeMapping.EnemyCreation
{
    public class CollapseStrategyFactory : ICollapseStrategyFactory
    {
        private IExplosionManager _explosionManager;

        public CollapseStrategyFactory(IExplosionManager explosionManager)
        {
            _explosionManager = explosionManager;
        }

        IBehaviourStrategy ICollapseStrategyFactory.BuildCollapseStrategy(ElementTheme elementTheme, IBehaviourStrategy strategyWithLegs, double collapseTime, double collapseTimeWithoutLegs, IDestructionObserver weaponLooser, ICollapseObserver collapseObserver, IEnemyDestructionObserver enemyDestructionObserver)
        {
            if (elementTheme == ElementTheme.FlyingSoldierFlameThrower)
                return new SpinningExplodeStrategy(strategyWithLegs, new SpinningAccelerator(5), 5, new Exploder(_explosionManager, DestructionStrength.GiantSelfExplosion, 2));

            if (elementTheme == ElementTheme.SoldierRobot || elementTheme == ElementTheme.LastRobot)
                return new DeadRobotStrategy(strategyWithLegs);

            return new CollapseStrategy(strategyWithLegs, collapseTime, collapseTimeWithoutLegs, weaponLooser, collapseObserver, enemyDestructionObserver);
        }
    }
}
