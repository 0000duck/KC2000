using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using BaseContracts;
using CollisionDetection.Contracts;
using IOInterface;
using BloodEffects.Contracts;

namespace BloodEffects
{
    public class BloodEffectCreator : IBloodEffectCreator
    {     
        private double _lengthOfFieldUnit;
        private IListProviderProvider<IWorldElement> _listProviderProvider;
        private ICollidingElementFinder _collidingElementFinder;
        private IList<IBloodSpriteParameterCalculator> _spriteCreators;
        private IListFilter<IWorldElement> _listFilter;
        private IWallEffectQueue _wallEffectQueue;
        private Dictionary<Animation, double> _radiusPerAnimation;

        public BloodEffectCreator(double lengthOfFieldUnit, IListProviderProvider<IWorldElement> listProvider, IWallEffectQueue wallEffectQueue,
            ICollidingElementFinder collidingElementFinder, IList<IBloodSpriteParameterCalculator> spriteCreators, IListFilter<IWorldElement> listFilter, Dictionary<Animation, double> radiusPerAnimation)
        {
            _lengthOfFieldUnit = lengthOfFieldUnit;
            _listProviderProvider = listProvider;
            _collidingElementFinder = collidingElementFinder;
            _spriteCreators = spriteCreators;
            _listFilter = listFilter;
            _wallEffectQueue = wallEffectQueue;
            _radiusPerAnimation = radiusPerAnimation;
        }

        void IBloodEffectCreator.CreateBloodEffect(Animation bloodAnimation, Position3D position)
        {
            double radius = _radiusPerAnimation[bloodAnimation];

            IWorldElement _testElement;
            if (radius * 2 >= _lengthOfFieldUnit)  
                _testElement = new StandardWorldElement(new LargePositionOnRoomFieldModel());
            else
                _testElement = new StandardWorldElement();

            _testElement.SetCenterPosition(position.PositionX, position.PositionY, position.PositionZ - radius);
            _testElement.SetPhysicalAppearance(Shape.Circle, 1, radius * 2, radius * 2, radius * 2, radius);

            List<IWorldElement> collidingWorldElements = _collidingElementFinder.FindCollidingElements(_testElement, _testElement.MyCollisionModel, _listProviderProvider.GetProvider().GetList());

            List<IWorldElement> filteredList = _listFilter.Apply(collidingWorldElements);

            foreach (IWorldElement element in filteredList)
            {
                foreach (IBloodSpriteParameterCalculator spriteCreator in _spriteCreators)
                {
                    WallSpriteAnimationParameters parameters = spriteCreator.TryToCreateSprite(element, position, radius);

                    if (parameters == null)
                        continue;

                    parameters.AnimationPercent = MathHelper.GetRandomValueInARange(1.0, false);

                    parameters.Animation = bloodAnimation;

                    _wallEffectQueue.QueueWallEffect(parameters, element, filteredList, position);
                }
            }
        }
    }
}
