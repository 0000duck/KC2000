using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using CollisionDetection.Contracts;
using BaseContracts;

namespace ArtificialIntelligence.PathTesting
{
    public class FreeSpaceTester : IFreeSpaceTester
    {
        private ICollisionByCylinderFinder _collisionByCylinderFinder;
        private IListProvider<IWorldElement> _elementListProvider;
        private IWorldElement _testElement;
        private ICollisionDetector _collisionDetector;

        public FreeSpaceTester(ICollisionByCylinderFinder collisionByCylinderFinder, IListProvider<IWorldElement> elementListProvider, IWorldElement testElement, ICollisionDetector collisionDetector)
        {
            _collisionByCylinderFinder = collisionByCylinderFinder;
            _elementListProvider = elementListProvider;
            _testElement = testElement;
            _collisionDetector = collisionDetector;
        }

        int IFreeSpaceTester.GetNumberOfFreeUnits(Position3D excludedStartPosition, Vector3D directionVector, double radius, double minHeight, int desiredUnits)
        {
            Position3D endPosition = excludedStartPosition.Clone();

            endPosition.PositionX += directionVector.X * radius * 2 * desiredUnits;
            endPosition.PositionY += directionVector.Y * radius * 2 * desiredUnits;
            endPosition.PositionZ += directionVector.Z * radius * 2 * desiredUnits;

            IList<IWorldElement> list = _collisionByCylinderFinder.FilterElementsByCylinder(_elementListProvider.GetList(), excludedStartPosition, endPosition, minHeight);

            return GetNumberOfUnitsWithoutCollision(list, excludedStartPosition, directionVector, radius, minHeight, desiredUnits);
        }

        private int GetNumberOfUnitsWithoutCollision(IList<IWorldElement> list, Position3D excludedStartPosition, Vector3D directionVector, double radius, double minHeight, int desiredUnits)
        {
            double height = directionVector.Z * radius * 2;

            if (height < 0)
                height *= -1;

            if (height < minHeight)
                height = minHeight;

            _testElement.SetPhysicalAppearance(Shape.Circle, 1, radius * 2, radius * 2, height, radius);

            int counter = 0;

            while (counter < desiredUnits)
            {
                Position3D position = excludedStartPosition.Clone();
                position.PositionX += directionVector.X * radius * 2 * (counter + 1);
                position.PositionY += directionVector.Y * radius * 2 * (counter + 1);
                position.PositionZ += directionVector.Z * radius * 2 * (counter + 1);
                _testElement.SetCenterPosition(position.PositionX, position.PositionY, position.PositionZ);

                if(_collisionDetector.SimpleCollisionTakesPlace(_testElement, _testElement.MyCollisionModel, list))
                {
                    return counter;
                }
                counter++;
            }

            return counter;
        }
    }
}
