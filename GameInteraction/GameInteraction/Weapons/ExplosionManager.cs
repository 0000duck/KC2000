using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using GameInteraction.ThemeMapping;
using GameInteraction.BaseImplementations;
using IOInterface;
using GameInteractionContracts;
using ArtificialIntelligence.Contracts;
using BaseContracts;
using IOInterface.Events;

namespace GameInteraction.Weapons
{
    public class ExplosionManager : IExplosionManager
    {
        private IParticleManager _particleManager;
        private IExplosionSizeMapper _explosionSizeMapper;
        private IQuakeTriggerer _quakeTriggerer;
        private IFireEventObserver _eventObserver;
        private IListProviderProvider<IWorldElement> _listProviderProvider;

        public ExplosionManager(IParticleManager particleManager, IExplosionSizeMapper explosionSizeMapper, IQuakeTriggerer quakeTriggerer, IFireEventObserver eventObserver, IListProviderProvider<IWorldElement> listProviderProvider)
        {
            _particleManager = particleManager;
            _explosionSizeMapper = explosionSizeMapper;
            _quakeTriggerer = quakeTriggerer;
            _eventObserver = eventObserver;
            _listProviderProvider = listProviderProvider;
        }

        void IExplosionManager.StartNewExplosion(IWorldElement explodingElement, Position3D position, double destructionStrength, double squareRadius)
        {
            _particleManager.StartNewParticleAnimation(position, _explosionSizeMapper.MapSizeOfExplosion(destructionStrength));
            _quakeTriggerer.TriggerRelativeQuake(position, destructionStrength / 150.0);
            _eventObserver.NotifyShot(position);

            FindDamagedElements(_listProviderProvider.GetProvider().GetList(), explodingElement, position, destructionStrength, squareRadius);
        }

        private void FindDamagedElements(IEnumerable<IWorldElement> elements, IWorldElement explodingElement, Position3D position, double destructionStrength, double squareRadius)
        {
            foreach (IWorldElement element in elements)
            {
                if (element.IsVirtual || explodingElement == element)
                    continue;

                if (!(element is IExplosionVulnerable))
                {
                    if (element is IComposition)
                    {
                        FindDamagedElements(((IComposition)element).Children, explodingElement, position, destructionStrength, squareRadius);
                    }

                    continue;
                }

                Position3D center = element.Position.Clone();
                center.PositionZ += element.Height / 2.0;
                DistanceBetweenTwoPositions distance = new DistanceBetweenTwoPositions(position, center);
                double squareDistance = distance.SquareDistanceXYZ - (element.Radius * element.Radius);

                if (squareDistance < squareRadius)
                {
                    if (squareDistance < 0)
                        squareDistance = 0;

                    ((IExplosionVulnerable)element).YouGotHit(position, destructionStrength * 0.5 + (destructionStrength * 0.5 * (1 - (squareDistance / squareRadius))));
                }
            }
        }
    }
}
