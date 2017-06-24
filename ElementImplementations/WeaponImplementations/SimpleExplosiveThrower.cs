using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using BaseContracts;
using IOInterface;
using ArtificialIntelligence.Contracts;
using GameInteraction;
using IOInterface.Events;

namespace ElementImplementations.WeaponImplementations
{
    public class SimpleExplosiveThrower : ISimpleWeapon
    {
        private IElementCreator _elementCreator;
        private Position3D _position;
        private Vector3D _directionVector;
        private ElementTheme _explosiveTheme;
        private IUpdateTimer _timer;
        private IFireEventObserver _eventObserver;
        private double _metersPerSecond;

        public SimpleExplosiveThrower(IUpdateTimer timer, IElementCreator elementCreator, ElementTheme explosiveTheme, IFireEventObserver eventObserver, double metersPerSecond)
        {
            _timer = timer;
            _elementCreator = elementCreator;
            _explosiveTheme = explosiveTheme;
            _eventObserver = eventObserver;
            _metersPerSecond = metersPerSecond;
        }

        void ISimpleWeapon.Fire(Position3D weaponPosition, Position3D targetPosition, IListProvider<IWorldElement> customicedListProvider)
        {
            if (!_timer.UpdateIsNecessary())
                return;

            _position = weaponPosition.Clone();
            _directionVector = MathHelper.CreateVectorWithXYLengthOne(weaponPosition, targetPosition);

            _elementCreator.EnqueueNewElement(new SimpleElement { ElementTheme = _explosiveTheme, StartPosition = _position }, StartExplosive);
        }

        private void StartExplosive(IWorldElement explosive)
        {
            if (_eventObserver != null)
                _eventObserver.NotifyShot(explosive.Position);

            ((IStraightMovingElement)explosive).StartMovement(_directionVector, _metersPerSecond);
        }
    }
}
