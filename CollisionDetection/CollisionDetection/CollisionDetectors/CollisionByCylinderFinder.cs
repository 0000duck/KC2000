using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Contracts;
using BaseTypes;

namespace CollisionDetection.CollisionDetectors
{
    public class CollisionByCylinderFinder : ICollisionByCylinderFinder
    {
        private ICollidingElementFinder _collidingElementFinder;
        private IWorldElement _testElement;

        public CollisionByCylinderFinder(ICollidingElementFinder collidingElementFinder, IWorldElement testElement)
        {
            _collidingElementFinder = collidingElementFinder;
            _testElement = testElement;
        }

        IList<IWorldElement> ICollisionByCylinderFinder.FilterElementsByCylinder(IEnumerable<IWorldElement> allElements, Position3D startPosition, Position3D endPosition, double minHeight)
        {
            double distanceZ = startPosition.PositionZ - endPosition.PositionZ;
            distanceZ = distanceZ > 0 ? distanceZ : -distanceZ;
            distanceZ = distanceZ > minHeight ? distanceZ : minHeight;

            double distance = new DistanceBetweenTwoPositions(startPosition, endPosition).DistanceXY;

            _testElement.SetPhysicalAppearance(Shape.Circle, 1, distance, distance, distanceZ, distance / 2.0);

            Position3D centerPosition = startPosition.Clone();
            centerPosition.PositionX += endPosition.PositionX;
            centerPosition.PositionY += endPosition.PositionY;

            centerPosition.PositionX /= 2.0;
            centerPosition.PositionY /= 2.0;

            _testElement.SetCenterPosition(centerPosition.PositionX, centerPosition.PositionY, startPosition.PositionZ < endPosition.PositionZ ? startPosition.PositionZ : endPosition.PositionZ);

            return _collidingElementFinder.FindCollidingElements(_testElement, _testElement.MyCollisionModel, allElements);
        }
    }
}
