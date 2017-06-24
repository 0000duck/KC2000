using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.EnemyProvider
{
    public class RandomProviderWithoutHead : IWorldElementProvider
    {
        private IWorldElement _fakeEnemy;
        private IUpdateTimer _timer;

        public RandomProviderWithoutHead(IWorldElement fakeEnemy, IUpdateTimer timer)
        {
            _fakeEnemy = fakeEnemy;
            _timer = timer;
        }

        IWorldElement IWorldElementProvider.GetElement()
        {
            if (_timer.UpdateIsNecessary())
            {
                _fakeEnemy.SetCenterPosition(MathHelper.GetRandomValueInARange(300.0, false), MathHelper.GetRandomValueInARange(300.0, false), 0);
            }

            return _fakeEnemy;
        }
    }
}
