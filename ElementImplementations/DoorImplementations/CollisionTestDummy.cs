using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Elements;
using BaseTypes;
using CollisionDetection.CollisionDetectors;
using CollisionDetection;
using BaseContracts;

namespace ElementImplementations.DoorImplementations
{
    internal class CollisionTestDummy : StandardWorldElement
    {
        private const double ShrinkValue = 0.02;
        private SimpleRecursiveCollisionDetector SimpleCollisionDetector { set; get; }
        private IListProvider<IWorldElement> ListProvider { set; get; }

        public CollisionTestDummy(Position3D position, double lengthX, double lenghtY, double height, IListProvider<IWorldElement> listProvider)
        {
            ListProvider = listProvider;
            SetPhysicalAppearance(Shape.Rectangle, 1, lengthX - ShrinkValue, lenghtY - ShrinkValue, height - (ShrinkValue * 2));

            SetCenterPosition(
                position.PositionX,
                position.PositionY, 
                position.PositionZ + ShrinkValue);

            SimpleCollisionDetector = new SimpleRecursiveCollisionDetector(new DetectorOfOverlappingElements());
        }

        internal bool HasEnoughSpace()
        {
            return SimpleCollisionDetector.SimpleCollisionTakesPlace(this, MyCollisionModel, ListProvider.GetList()) == false;
        }
    }
}
