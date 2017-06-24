using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using ArtificialIntelligence.Contracts;
using GameInteractionContracts;
using IOInterface;
using IOImplementation;

namespace ArtificialIntelligence
{
    public class WeaponLooser : IDestructionObserver
    {
        private IWorldElementProvider _characterProvider;
        private IElementCreator _elementCreator;
        private ElementTheme _weaponPlaceholder;
        private bool _weaponIsLost;

        public WeaponLooser(IWorldElementProvider characterProvider, IElementCreator elementCreator, ElementTheme weaponPlaceholder)
        {
            _characterProvider = characterProvider;
            _elementCreator = elementCreator;
            _weaponPlaceholder = weaponPlaceholder;
        }

        void IDestructionObserver.NotifyFullDestruction(BodyPart bodyPart, Position3D position)
        {
            if (_weaponIsLost)
                return;

            if (bodyPart != BodyPart.Arms && bodyPart != BodyPart.Torso)
                return;

            ThrowWeapon();
            _weaponIsLost = true;
        }

        private void ThrowWeapon()
        {
            IWorldElement character = _characterProvider.GetElement();
       
            if (character == null)
                return;

            Position3D position = character.Position.Clone();

            Vector2D vector = VectorCreator.CreateVector(1, ((IVisualAppearance)character).Orientation);

            position.PositionX += vector.X;
            position.PositionY += vector.Y;
            position.PositionZ = 0;

            _elementCreator.EnqueueNewElement(new ElementImplementation
            {
                StartPosition = position,
                ElementTheme = _weaponPlaceholder
            });
        }

        void IDestructionObserver.NotifyInnerDestruction()
        {}
    }
}
