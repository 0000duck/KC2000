using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;

namespace GameInteraction.Weapons
{
    public class FirePositionCalculator : IComplexAmmo
    {
        private double _weaponHeight;
        private double _weaponLength;
        private IComplexAmmo _ammoFirerer;

        public FirePositionCalculator(double weaponHeight, double weaponLength, IComplexAmmo ammoFirerer)
        {
            _weaponHeight = weaponHeight;
            _weaponLength = weaponLength;
            _ammoFirerer = ammoFirerer;
        }

        AmmoFireResult IComplexAmmo.Fire(Position3D position, VectorWithDegree directionVector)
        {
            Position3D firePosition = position.Clone();

            firePosition.PositionZ += _weaponHeight;

            firePosition.PositionX += directionVector.Vector.X * _weaponLength;
            firePosition.PositionY += directionVector.Vector.Y * _weaponLength;
            firePosition.PositionZ += directionVector.Vector.Z * _weaponLength;

            return _ammoFirerer.Fire(firePosition, directionVector);
        }

        int IComplexAmmo.Count
        {
            get { return _ammoFirerer.Count; }
        }
    }
}
