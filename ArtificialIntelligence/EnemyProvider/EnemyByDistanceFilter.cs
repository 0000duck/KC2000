using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.EnemyProvider
{
    public class EnemyByDistanceFilter : IWorldElementProvider
    {
        private IWorldElementProvider _enemyProvider;
        private IWorldElementProvider _providerForDistanceCalculation;
        private double _squareDistance;

        public EnemyByDistanceFilter(IWorldElementProvider enemyProvider, IWorldElementProvider providerForDistanceCalculation, double distance)
        {
            _enemyProvider = enemyProvider;
            _providerForDistanceCalculation = providerForDistanceCalculation;
            _squareDistance = distance * distance;
        }

        IWorldElement IWorldElementProvider.GetElement()
        {
            IWorldElement element = _enemyProvider.GetElement();
            
            if (element == null)
                return null;

            IWorldElement distanceComparisonElement = _providerForDistanceCalculation.GetElement();
            
            DistanceBetweenTwoPositions distanceBetweenTwoPositions = new DistanceBetweenTwoPositions(element.Position, distanceComparisonElement.Position);

            if (distanceBetweenTwoPositions.SquareDistanceXY > _squareDistance)
                return null;

            return element;
        }
    }
}
