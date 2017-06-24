using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using BaseContracts;

namespace ArtificialIntelligence.EnemyProvider
{
    public class VisibleEnemyProvider : IWorldElementProvider
    {
        private IWorldElementProvider _enemyProvider;
        private IWorldElementProvider _viewerProvider;
        private IUpdateTimer _updateTimer;
        private IWorldElement _enemy;
        private IWorldElement _tempEnemy;
        private IListProvider<IWorldElement> _listProvider;
        private IVisibilityTester _visibilityTester;

        public VisibleEnemyProvider(IWorldElementProvider enemyProvider, IWorldElementProvider viewerProvider, IListProvider<IWorldElement> listProvider, IVisibilityTester visibilityTester, IUpdateTimer updateTimer)
        {
            _enemyProvider = enemyProvider;
            _updateTimer = updateTimer;
            _listProvider = listProvider;
            _viewerProvider = viewerProvider;
            _visibilityTester = visibilityTester;
        }

        IWorldElement IWorldElementProvider.GetElement()
        {
            if (_updateTimer.UpdateIsNecessary())
            {
                _tempEnemy = _enemyProvider.GetElement();

                IWorldElement viewer = _viewerProvider.GetElement();

                _visibilityTester.StartVisibilityTest(viewer, _tempEnemy, _listProvider);
            }

            if (!_visibilityTester.Testing())
            {
                _enemy = _visibilityTester.ElementIsVisible() ? _tempEnemy : null;
            }

            return _enemy;
        }
    }
}
