using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using CollisionDetection.Contracts;

namespace DrawableElements.WallEffects.VisibilityTest
{
    public class SimpleTestRay : ISimpleTestRay
    {
        private IWorldElement _testObject; 
        private double _radius;
        private int _maxTestTries;
        private ICollidingElementFinder _collidingElementFinder;

        public SimpleTestRay(IWorldElement testObject, double radius, int maxTestTries, ICollidingElementFinder collidingElementFinder)
        {
            _testObject = testObject;
            _radius = radius;
            _testObject.SetPhysicalAppearance(Shape.Circle, 1, _radius * 2, _radius * 2, _radius * 2, _radius);
            _maxTestTries = maxTestTries;
            _collidingElementFinder = collidingElementFinder;
        }

        bool ISimpleTestRay.FocusedElementIsHitByRay(Position3D startPosition, Position3D endPosition, List<IWorldElement> allElements, IWorldElement focusedElement)
        {
            Vector3D directionVector = MathHelper.CreateVector3D(startPosition, endPosition);
            directionVector.CalculateUnitLength();

            Position3D testObjectPosition = startPosition.Clone();

            int counter = 0;

            while (counter < _maxTestTries)
            {
                _testObject.SetCenterPosition(testObjectPosition.PositionX, testObjectPosition.PositionY, testObjectPosition.PositionZ);

                List<IWorldElement> collidingElements = _collidingElementFinder.FindCollidingElements(_testObject, _testObject.MyCollisionModel, allElements);

                if (collidingElements.Count > 0)
                {
                    return collidingElements.Contains(focusedElement);
                }

                testObjectPosition.PositionX += directionVector.X * _radius * 2;
                testObjectPosition.PositionY += directionVector.Y * _radius * 2;
                testObjectPosition.PositionZ += directionVector.Z * _radius * 2;
                counter++;
            }

            return true;
        }
    }
}
