using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteraction.BaseImplementations;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using GameInteractionContracts;
using IOInterface;
using BaseContracts;
using GameInteraction;
using CollisionDetection.Contracts;

namespace ElementImplementations.BoxImplementations
{
    public class AmmoBox : ImpulseProcessingAnimatableElement, IExplosionVulnerable, IVulnerable
    {
        private double _strength;
        private IElementCreator _elementCreator;
        private List<ElementTheme> _innerItems;
        private IParticleManager _particleManager;

        public AmmoBox(double strength, IElementCreator elementCreator, List<ElementTheme> innerItems, IParticleManager particleManager, IListProvider<IWorldElement> listProvider, 
            IComplexElementFinder complexElementFinder)
            : base(listProvider, complexElementFinder)
        {
            _strength = strength;
            _elementCreator = elementCreator;
            _innerItems = innerItems;
            _particleManager = particleManager;
        }

        public void YouGotHit(Position3D position, double destructionStrength, Vector3D directionVector)
        {
            _strength -= destructionStrength;
            if (_strength <= 0)
                RemoveBoxAndCreateItem();
            else
                _particleManager.StartNewParticleAnimation(position, Animation.WoodExplosionSmall);
        }

        public void YouGotHit(Position3D explosionPosition, double destructionStrength)
        {
            _strength -= destructionStrength;
            if (_strength <= 0)
                RemoveBoxAndCreateItem();
            else
                _particleManager.StartNewParticleAnimation(explosionPosition, Animation.WoodExplosionSmall);
        }

        private void RemoveBoxAndCreateItem()
        {
            _elementCreator.DeleteElement(this);

            int counter = 1;

            foreach(ElementTheme item in _innerItems)
            {
                Degree degree = (Degree)counter;
                if (degree > Degree.Degree_315)
                    degree = Degree.Degree_0;

                Position3D position = Position.Clone();
                Vector2D vector = VectorCreator.CreateVector(0.4, degree);

                position.PositionX += vector.X;
                position.PositionY += vector.Y;

                _elementCreator.EnqueueNewElement(new SimpleElement { ElementTheme = item, StartPosition = position });
                counter+=2;
            }
            
            _particleManager.StartNewParticleAnimation(Position, Animation.WoodExplosionBig);
        }
    }
}
