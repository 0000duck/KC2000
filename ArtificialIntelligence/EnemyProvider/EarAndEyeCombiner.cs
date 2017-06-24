using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace ArtificialIntelligence.EnemyProvider
{
    public class EarAndEyeCombiner : IWorldElementProvider
    {
        private IWorldElementProvider _visibleEnemyProvider;
        private IWorldElementProvider _hearableEnemyProvider;

        public EarAndEyeCombiner(IWorldElementProvider visibleEnemyProvider, IWorldElementProvider hearableEnemyProvider)
        {
            _visibleEnemyProvider = visibleEnemyProvider;
            _hearableEnemyProvider = hearableEnemyProvider;
        }

        IWorldElement IWorldElementProvider.GetElement()
        {
            IWorldElement element = _hearableEnemyProvider.GetElement();

            if (element == null)
                element = _visibleEnemyProvider.GetElement();

            return element;
        }
    }
}
