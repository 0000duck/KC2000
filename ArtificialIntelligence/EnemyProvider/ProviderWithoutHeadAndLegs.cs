using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using GameInteractionContracts;

namespace ArtificialIntelligence.EnemyProvider
{
    public class ProviderWithoutHeadAndLegs : IWorldElementProvider
    {
        private IWorldElementProvider _characterProvider;
        private IWorldElement _fakeEnemy;
        private IUpdateTimer _timer;

        public ProviderWithoutHeadAndLegs(IWorldElementProvider characterProvider, IWorldElement fakeEnemy, IUpdateTimer timer)
        {
            _characterProvider = characterProvider;
            _fakeEnemy = fakeEnemy;
            _timer = timer;
        }

        IWorldElement IWorldElementProvider.GetElement()
        {
            if (!_timer.UpdateIsNecessary())
                return _fakeEnemy;

            IWorldElement worldElement = _characterProvider.GetElement();

            IAnimatable animatableElement = (IAnimatable)worldElement;

            if (animatableElement == null)
                return null;

            Vector2D vector = VectorCreator.CreateVector(2.0, animatableElement.Orientation);

            _fakeEnemy.SetCenterPosition(worldElement.Position.PositionX + vector.X + MathHelper.GetRandomValueInARange(0.2),
                worldElement.Position.PositionY + vector.Y + MathHelper.GetRandomValueInARange(0.2), 0);

            return _fakeEnemy;
        }
    }
}
