using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace ArtificialIntelligence.EnemyProvider
{
    public class DiffusePositionProvider : IPositionProvider
    {
        private IWorldElementProvider _elementProvider;
        private IWorldElementProvider _enemyProvider;
        private double _minSquareDistance;
        private double _mediumSquareDistance;
        private double _maxSquareDistance;
        private double _diffusionNear;
        private double _diffusionFar;
        private int _diffusionCounter;

        public DiffusePositionProvider(IWorldElementProvider elementProvider, IWorldElementProvider enemyProvider, double minDistance, double mediumDistance, double maxDistance, double diffusionNear, double diffusionFar)
        {
            _elementProvider = elementProvider;
            _enemyProvider = enemyProvider;
            _minSquareDistance = minDistance * minDistance;
            _maxSquareDistance = maxDistance * maxDistance;
            _mediumSquareDistance = mediumDistance * mediumDistance;
            _diffusionNear = diffusionNear;
            _diffusionFar = diffusionFar;
        }

        Position3D IPositionProvider.GetPosition()
        {
            IWorldElement element = _elementProvider.GetElement();

            if (element == null)
                return null;

            IWorldElement enemy = _enemyProvider.GetElement();

            if (enemy == null)
                return null;

            DistanceBetweenTwoPositions distance = new DistanceBetweenTwoPositions(enemy.Position, element.Position);

            if (distance.SquareDistanceXY < _maxSquareDistance && distance.SquareDistanceXY > _minSquareDistance)
            {
                Position3D position = enemy.Position.Clone();

                if(distance.SquareDistanceXY < _mediumSquareDistance)
                    AddDiffusion(position, _diffusionNear);
                else
                    AddDiffusion(position, _diffusionFar);

                _diffusionCounter++;
                if (_diffusionCounter > 3)
                    _diffusionCounter = 0;

                return position;
            }

            return enemy.Position;
        }

        private void AddDiffusion(Position3D position, double _diffusion)
        {
            switch (_diffusionCounter)
            {
                case 0:
                    position.PositionX += _diffusion;
                    position.PositionY -= _diffusion;
                    break;
                case 1:
                    position.PositionX -= _diffusion;
                    position.PositionY += _diffusion;
                    break;
                case 2:
                    position.PositionX += _diffusion;
                    position.PositionY += _diffusion;
                    break;
                case 3:
                    position.PositionX -= _diffusion;
                    position.PositionY -= _diffusion;
                    break;
            }
        }
    }
}
