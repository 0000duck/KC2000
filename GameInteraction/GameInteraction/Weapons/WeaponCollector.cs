using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using ArtificialIntelligence.Contracts;
using IOInterface;

namespace GameInteraction.Weapons
{
    public class WeaponCollector : IWeaponCollector, IExecuteble
    {
        private IElementCreatorProvider _elementCreatorProvider;
        private IElementGroup _weaponOwner;
        private List<IWeaponPlaceHolder> _weaponPlaceHolders;
        private List<IWeaponPlaceHolder> _collectedWeaponPlaceHolders;
        private IUpdateTimer _updateTimer;
        private double _maxSquareDistance;

        public WeaponCollector(IElementCreatorProvider elementCreatorProvider, IUpdateTimer updateTimer, double maxCollectorDistance)
        {
            _elementCreatorProvider = elementCreatorProvider;
            _updateTimer = updateTimer;
            _maxSquareDistance = maxCollectorDistance;
            _weaponPlaceHolders = new List<IWeaponPlaceHolder>();
            _collectedWeaponPlaceHolders = new List<IWeaponPlaceHolder>();
        }

        void IWeaponCollector.AddWeaponOwner(IElementGroup weaponOwner)
        {
            _weaponOwner = weaponOwner;
        }

        void IWeaponCollector.AddWeaponPlaceHolder(IWeaponPlaceHolder weaponPlaceHolder)
        {
            _weaponPlaceHolders.Add(weaponPlaceHolder);
        }

        void IExecuteble.ExecuteLogic()
        {
            if (!_updateTimer.UpdateIsNecessary())
                return;

            List<IWeaponPlaceHolder> collectablePlaceHolders = FindCollectablePlaceHolder();

            if (!collectablePlaceHolders.Any())
                return;

            foreach (IWeaponPlaceHolder placeHolder in collectablePlaceHolders)
            {
                TriggerWeaponCreation(placeHolder);
            }
        }

        private void TriggerWeaponCreation(IWeaponPlaceHolder placeHolder)
        {
            IGroupElement compatibleWeapon = FindCompatibleWeapon(placeHolder, _weaponOwner.Children);

            IElementCreator elementCreator = _elementCreatorProvider.GetElementCreator();

            if (compatibleWeapon == null)
            {
                if (placeHolder.WeaponCount == 0)
                    return;

                elementCreator.EnqueueNewElement(new SimpleElement
                {
                    ElementTheme = placeHolder.WeaponTheme,
                    StartPosition = new Position3D()
                }, AddWeapon);
                _collectedWeaponPlaceHolders.Add(placeHolder);
                _weaponPlaceHolders.Remove(placeHolder);
                return;
            }

            elementCreator.EnqueueNewElement(new SimpleElement
            {
                ElementTheme = placeHolder.AmmoTheme,
                StartPosition = new Position3D()
            }, (IWorldElement ammo) => 
                {   
                    ((IElementGroup)compatibleWeapon).AddChild((IGroupElement)ammo); 
                }
            );

            _weaponPlaceHolders.Remove(placeHolder);
            elementCreator.DeleteElement((IWorldElement)placeHolder);
        }

        private IGroupElement FindCompatibleWeapon(IWeaponPlaceHolder collectablePlaceHolder, IList<IGroupElement> weapons)
        {
            foreach (IGroupElement weapon in weapons)
            {
                IVisualAppearance visualWeapon = (IVisualAppearance)weapon;

                if (visualWeapon.ElementTheme == collectablePlaceHolder.WeaponTheme)
                {
                    return weapon;
                }
            }
            return null;
        }

        private List<IWeaponPlaceHolder> FindCollectablePlaceHolder()
        {
            List<IWeaponPlaceHolder> list = new List<IWeaponPlaceHolder>();

            IWorldElement weaponOwnerAsWorldElement = (IWorldElement)_weaponOwner;
            foreach (IWeaponPlaceHolder weaponPlaceHolder in _weaponPlaceHolders)
            {
                IWorldElement placeHolder = (IWorldElement)weaponPlaceHolder;

                DistanceBetweenTwoPositions distance = new DistanceBetweenTwoPositions(weaponOwnerAsWorldElement.Position, placeHolder.Position);

                if (distance.SquareDistanceXY > _maxSquareDistance)
                    continue;

                list.Add(weaponPlaceHolder);
            }
            return list;
        }

        private void AddWeapon(IWorldElement weapon)
        {
            _weaponOwner.AddChild((IGroupElement)weapon);

            IWeaponPlaceHolder placeHolder = _collectedWeaponPlaceHolders.Find(x => x.WeaponTheme == ((IVisualAppearance)weapon).ElementTheme);

            if (placeHolder != null)
            {
                _collectedWeaponPlaceHolders.Remove(placeHolder);

                IElementCreator elementCreator = _elementCreatorProvider.GetElementCreator();
                
                elementCreator.EnqueueNewElement(new SimpleElement
                {
                    ElementTheme = placeHolder.AmmoTheme,
                    StartPosition = new Position3D()
                }, (IWorldElement ammo) =>
                {
                    ((IElementGroup)weapon).AddChild((IGroupElement)ammo);
                }
                );
                
                elementCreator.DeleteElement((IWorldElement)placeHolder);
            }
        }
    }
}
