using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using ArtificialIntelligence.Contracts;
using BaseContracts;

namespace ElementImplementations.AmmoImplementations
{
    public class FireBallDestructionTriggerer : ISphereDestructionTriggerer
    {
        private double _squareRadius;
        private double _destructionStrength;
        private IListProvider<IWorldElement> _listProvider;

        public FireBallDestructionTriggerer(double radius, double destructionStrength, IListProvider<IWorldElement> listProvider)
        {
            _squareRadius = radius * radius;
            _destructionStrength = destructionStrength;
            _listProvider = listProvider;
        }

        void ISphereDestructionTriggerer.TriggerSphericalDestruction(Position3D position)
        {
            FindDamagedElements(_listProvider.GetList(), position);
        }

        private void FindDamagedElements(IEnumerable<IWorldElement> elements, Position3D position)
        {
            foreach (IWorldElement element in elements)
            {
                if (element.IsVirtual)
                    continue;

                if (!(element is IExplosionVulnerable))
                {
                    if (element is IComposition)
                    {
                        FindDamagedElements(((IComposition)element).Children, position);
                    }

                    continue;
                }
                DistanceBetweenTwoPositions distance = new DistanceBetweenTwoPositions(position, element.Position);
                if (distance.SquareDistanceXY < _squareRadius)
                {
                    ((IExplosionVulnerable)element).YouGotHit(position, _destructionStrength * (1 - (distance.SquareDistanceXY / _squareRadius)));
                }
            }
        }  
    }
}
