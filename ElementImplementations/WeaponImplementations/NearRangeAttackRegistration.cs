using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using BaseContracts;
using CollisionDetection.Contracts;
using ArtificialIntelligence.Contracts;
using CollisionDetection.Elements;

namespace ElementImplementations.WeaponImplementations
{
    public class NearRangeAttackRegistration : IDestructionRegistration
    {
        private ICollidingElementFinder _collidingElementFinder;
        private double _testObjectRadius;
        private INearRangeAttackSharer _nearRangeAttackSharer;
        private IWorldElement _testObject;

        public NearRangeAttackRegistration(ICollidingElementFinder collidingElementFinder, INearRangeAttackSharer nearRangeAttackSharer, double testObjectRadius)
        {
            _collidingElementFinder = collidingElementFinder;
            _testObjectRadius = testObjectRadius;
            _nearRangeAttackSharer = nearRangeAttackSharer;
            _testObject = new StandardWorldElement();
            _testObject.SetPhysicalAppearance(Shape.Circle, 1, _testObjectRadius * 2, _testObjectRadius * 2, _testObjectRadius, _testObjectRadius);
        }

        void IDestructionRegistration.AddNewDestruction(Position3D position, Vector3D directionVectorUnitLength, double destructionStrength, IListProvider<IWorldElement> listProvider, double? strengthReduction)
        {
            _testObject.SetCenterPosition(position.PositionX + (directionVectorUnitLength.X * (_testObjectRadius + 0.05)),
                position.PositionY + (directionVectorUnitLength.Y * (_testObjectRadius + 0.05)),
                position.PositionZ);

            List<IWorldElement> allCollidingElements = _collidingElementFinder.FindCollidingElements(_testObject, _testObject.MyCollisionModel, listProvider.GetList());

            _nearRangeAttackSharer.ShareAttackDamage(allCollidingElements, _testObject.Position, directionVectorUnitLength, destructionStrength);
        }
    }
}
