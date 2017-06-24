using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using GameInteractionContracts;
using BaseTypes;
using BaseContracts;

namespace ArtificialIntelligence
{
    public class SimpleWeaponFirerer : IWeaponFirerer
    {
        private ISimpleWeapon _simpleWeapon;
        private IListProvider<IWorldElement> _customicedListProvider;
        private double _weaponHeight;
        private double _weaponLength;
        private Degree _degree;
        private int _zAndXManipulationCounter;
        private IDestructibleBodyProvider _destructibleBodyProvider;

        public SimpleWeaponFirerer(ISimpleWeapon simpleWeapon, IListProvider<IWorldElement> customicedListProvider, double weaponHeight, double weaponLength, Degree degree, IDestructibleBodyProvider destructibleBodyProvider)
        {
            _simpleWeapon = simpleWeapon;
            _customicedListProvider = customicedListProvider;
            _weaponHeight = weaponHeight;
            _weaponLength = weaponLength;
            _degree = degree;
            _zAndXManipulationCounter = 1;
            _destructibleBodyProvider = destructibleBodyProvider;
        }

        void IWeaponFirerer.Fire(Position3D weaponOwnerPosition, IWorldElement targetElement, Degree weaponOwnerOrientation)
        {
            if (_destructibleBodyProvider.GetDestructibleBody().BodyStatus != MainBodyStatus.FullBody)
                return;

            Position3D weaponPosition = CalculateEndOfWeapon(weaponOwnerPosition, weaponOwnerOrientation);

            Position3D targetPosition = CalculatePlayersHeadPosition(targetElement);

            _simpleWeapon.Fire(weaponPosition, targetPosition, _customicedListProvider);
        }

        private Position3D CalculatePlayersHeadPosition(IWorldElement targetElement)
        {
            Position3D targetPosition = targetElement.Position.Clone();

            //aiming at the middle of the body
            targetPosition.PositionZ += targetElement.Height - 0.3 + (MathHelper.GetRandomValueInARange(0.3, false));

            ChangeXAndY(targetPosition);

            return targetPosition;
        }

        private void ChangeXAndY(Position3D targetPosition)
        {
            switch (_zAndXManipulationCounter)
            {
                case 1:
                    targetPosition.PositionX += 0.2;
                    break;
                case 2:
                    targetPosition.PositionX -= 0.2;
                    break;
                case 3:
                    targetPosition.PositionY += 0.2;
                    break;
                case 4:
                    targetPosition.PositionY -= 0.2;
                    break;
            }
            _zAndXManipulationCounter++;
            if (_zAndXManipulationCounter > 4)
                _zAndXManipulationCounter = 1;
        }

        private Position3D CalculateEndOfWeapon(Position3D weaponOwnerPosition, Degree weaponOwnerOrientation)
        {
            Position3D weaponPosition = weaponOwnerPosition.Clone();
            weaponPosition.PositionZ += _weaponHeight;

            weaponOwnerOrientation += (int)_degree - 1;
            if (weaponOwnerOrientation > Degree.Degree_315)
                weaponOwnerOrientation -= 8;

            Vector2D vector = VectorCreator.CreateVector(_weaponLength, weaponOwnerOrientation);

            weaponPosition.PositionX += vector.X;
            weaponPosition.PositionY += vector.Y;
            return weaponPosition;
        }
    }
}
