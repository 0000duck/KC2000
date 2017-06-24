using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using CollisionDetection.Elements;
using CollisionDetection.Contracts;
using BaseContracts;
using BaseTypes;
using GameInteraction.BaseImplementations;

namespace GameInteraction
{
    public class GravityTransportationElement : ImpulseProcessingAnimatableElement, IStraightMovingElement, IExecuteble
    {
        private ICollisionDetector _collisionDetector;
        private IListProvider<IWorldElement> _listProvider;
        private IElementCreator _elementCreator;
        private IAnimationInstructionProvider _animationInstructionProvider;
        private Vector3D _directionVector;
        private double _metersPerSecond;
        private bool _collision;
        private bool _centered;

        public GravityTransportationElement(ICollisionDetector collisionDetector, IListProvider<IWorldElement> listProvider, IElementCreator elementCreator,
            IAnimationInstructionProvider animationInstructionProvider, bool centered, IComplexElementFinder complexElementFinder)
        :base(listProvider, complexElementFinder)
        {
            _collisionDetector = collisionDetector;
            _listProvider = listProvider;
            _elementCreator = elementCreator;
            _animationInstructionProvider = animationInstructionProvider;
            _centered = centered;
        }

        void IStraightMovingElement.StartMovement(Vector3D directionVector, double metersPerSecond)
        {
            if (_centered)
                Position.PositionZ -= Height / 2.0;
            _directionVector = directionVector;
            _metersPerSecond = metersPerSecond;
            Orientation = VectorToDegreeConverter.Convert(directionVector);
        }

        void IExecuteble.ExecuteLogic()
        {
            if (CollisionProtocol.IsThereAnyCollision)
                _collision = true;

            if (_directionVector != null && !_collision)
            {
                double movementDistance = TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond * _metersPerSecond;

                while (movementDistance > Radius * 0.9 && !_collision)
                {
                    TestCollision(Radius * 0.9);
                    movementDistance -= Radius * 0.9;
                }

                if(movementDistance > 0 && !_collision)
                    TestCollision(movementDistance);
            }

            AnimationInstruction instruction = _animationInstructionProvider.GetInstructions(_collision, Position);

            AnimationBehaviour = instruction.Behaviour;
            AnimationPercent = instruction.Percent;

            if (instruction.ElementIsFinished)
            {
                _elementCreator.DeleteElement(this);
            }
        }

        private void TestCollision(double distance)
        {
            SetCenterPosition(Position.PositionX + _directionVector.X * distance,
                Position.PositionY + _directionVector.Y * distance,
                Position.PositionZ + _directionVector.Z * distance);

            if (_collisionDetector.SimpleCollisionTakesPlace(this, MyCollisionModel, _listProvider.GetList()))
                _collision = true;
        }
    }
}
