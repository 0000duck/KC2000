using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using CollisionDetection.Contracts;
using BaseTypes;
using BaseContracts;

namespace ElementImplementations.WeaponImplementations
{
    public class HighDetailNearRangeAttackRegistration : IDestructionRegistration
    {
        private ICollidingElementFinder _collidingElementFinder;
        private double _testObjectRadius;
        private INearRangeAttackSharer _nearRangeAttackSharer;
        private IWorldElement _testObject;

        public HighDetailNearRangeAttackRegistration(ICollidingElementFinder collidingElementFinder, INearRangeAttackSharer nearRangeAttackSharer, double testObjectRadius)
        {
            _collidingElementFinder = collidingElementFinder;
            _testObjectRadius = testObjectRadius;
            _nearRangeAttackSharer = nearRangeAttackSharer;
            _testObject = new StandardWorldElement();
            _testObject.SetPhysicalAppearance(Shape.Circle, 1, _testObjectRadius * 2, _testObjectRadius * 2, _testObjectRadius, _testObjectRadius);
        }

        void IDestructionRegistration.AddNewDestruction(Position3D position, Vector3D directionVectorUnitLength, double destructionStrength, IListProvider<IWorldElement> listProvider, double? strengthReduction)
        {
            Position3D testPosition = position.Clone();
            testPosition.PositionX += directionVectorUnitLength.X * _testObjectRadius;
            testPosition.PositionY += directionVectorUnitLength.Y * _testObjectRadius;
            testPosition.PositionZ += directionVectorUnitLength.Z * _testObjectRadius / 2.0;
            _testObject.SetCenterPosition(testPosition.PositionX, testPosition.PositionY, testPosition.PositionZ);

            List<IWorldElement> allCollidingElements = _collidingElementFinder.FindCollidingElements(_testObject, _testObject.MyCollisionModel, listProvider.GetList());

            int counter = 0;
            while (allCollidingElements.Count == 0 && counter < 3)
            {
                testPosition.PositionX += directionVectorUnitLength.X * _testObjectRadius * 2;
                testPosition.PositionY += directionVectorUnitLength.Y * _testObjectRadius * 2;
                testPosition.PositionZ += directionVectorUnitLength.Z * _testObjectRadius;
                _testObject.SetCenterPosition(testPosition.PositionX, testPosition.PositionY, testPosition.PositionZ);

                allCollidingElements = _collidingElementFinder.FindCollidingElements(_testObject, _testObject.MyCollisionModel, listProvider.GetList());
                counter++;
            }

            _nearRangeAttackSharer.ShareAttackDamage(allCollidingElements, _testObject.Position, directionVectorUnitLength, destructionStrength);
        }
    }
}
