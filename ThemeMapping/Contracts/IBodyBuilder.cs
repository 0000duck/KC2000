using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;

namespace ThemeMapping.Contracts
{
    public interface IBodyBuilder
    {
        IDestructibleBody CreateBody(IDestructionObserver collapseStrategy, IDestructionObserver weaponLooser, IDestructionObserver characterRemover, IDestructionObserver bloodExplosionNotifier, IExitWoundObserver exitWoundObserver, double collapseTime, double collapseTimeWithoutLegs, IDucker ducker);
    }
}
