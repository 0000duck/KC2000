using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using GameInteractionContracts;

namespace ArtificialIntelligence.EnemyProvider
{
    public class DegreeFilter : IWorldElementProvider
    {
        private IWorldElementProvider _enemyProvider;
        private IWorldElementProvider _viewerProvider;
        private ITargetDegreeCalculator _targetDegreeCalculator;

        public DegreeFilter(IWorldElementProvider enemyProvider, IWorldElementProvider viewerProvider, ITargetDegreeCalculator targetDegreeCalculator)
        {
            _enemyProvider = enemyProvider;
            _viewerProvider = viewerProvider;
            _targetDegreeCalculator = targetDegreeCalculator;
        }

        IWorldElement IWorldElementProvider.GetElement()
        {
            IWorldElement enemy = _enemyProvider.GetElement();

            if (enemy == null)
                return null;

            IWorldElement viewer = _viewerProvider.GetElement();

            Degree targetDegree = _targetDegreeCalculator.CalculateTargetDegree(viewer.Position, enemy.Position);

            IAnimatable animatableElement = (IAnimatable) viewer;

            if (targetDegree == animatableElement.Orientation)
                return enemy;

            if(targetDegree + 1 == animatableElement.Orientation)
                return enemy;

            if (targetDegree - 1 == animatableElement.Orientation)
                return enemy;

            if (targetDegree == Degree.Degree_0 && animatableElement.Orientation == Degree.Degree_315)
                return enemy;

            if (targetDegree == Degree.Degree_315 && animatableElement.Orientation == Degree.Degree_0)
                return enemy;

            return null;
        }
    }
}
