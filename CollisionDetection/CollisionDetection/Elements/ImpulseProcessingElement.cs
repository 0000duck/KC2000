using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using BaseContracts;
using CollisionDetection.Contracts;

namespace CollisionDetection.Elements
{
    public class ImpulseProcessingElement : StandardWorldElement, IMovableByImpulse, IComparable
    {
        private const double PushToTheSideOverlappingPercent = 0.1;
        private const double MaxAdditionalSideLengthForMovement = 0.1;

        private IComplexElementFinder ComplexElementFinderForMovement { set; get; } 

        private Position3D TheoreticalPosition { set; get; }
        private PositionOnRoomFieldModel MyTheoreticalCollisionModel { set; get; }

        private CollisionProtocol _collisionProtocol { set; get; }

        public ImpulseCollection ImpulseCollection { private set; get; }

        protected IListProvider<IWorldElement> ListProvider { set; get; }

        public ICollisionProtocol CollisionProtocol
        {
            get
            {
                return _collisionProtocol;
            }
        }

        public ImpulseProcessingElement(IListProvider<IWorldElement> listProvider, IComplexElementFinder complexElementFinder)
        {
            ListProvider = listProvider;
            ImpulseCollection = new ImpulseCollection();
            _collisionProtocol = new CollisionDetection.CollisionProtocol();
            ComplexElementFinderForMovement = complexElementFinder;
        }

        public void ProcessImpulseAndMove(Direction currentDirection)
        {
            Impulse impulse = ImpulseCollection.ExtractImpulse(currentDirection);

            if (impulse == null)
                return;

            //Gewicht abziehen
            ReduceImpulseStrengthByOwnWeight(impulse);

            //wenn Kraft verbraucht
            if (impulse.Strength <= 0)
                return;

            //theoretische Position berechnen
            double desiredDistance = CalculateTheoreticalPosition(impulse);

            List<IWorldElement> collidingElements = ComplexElementFinderForMovement.FindCollidingElements(this, MyTheoreticalCollisionModel, TheoreticalPosition, ListProvider.GetList());

            //bewegen
            if (!collidingElements.Any())
            {
                MoveInCurrentDirection(desiredDistance, currentDirection);
                return;
            }
            else
            {
                _collisionProtocol.SetCollisionInformation(currentDirection);
            }

            MoveInCurrentDirection(0.0, currentDirection);

            //impulse weitergeben
            double strengthRest = impulse.Strength / collidingElements.Count;

            foreach (IWorldElement element in collidingElements)
            {
                IMovableByImpulse movableElement = element as IMovableByImpulse;
                if (movableElement == null)
                    continue;

                movableElement.AddImpulse(new Impulse() { ImpulseDirection = currentDirection, Strength = strengthRest });

                Direction pushToTheSideDirection = GetThePushToTheSideDirection((IWorldElement)movableElement, currentDirection);
                if (pushToTheSideDirection > 0)
                {
                    movableElement.AddImpulse(new Impulse() { ImpulseDirection = pushToTheSideDirection, Strength = strengthRest });
                    AddImpulse(new Impulse() { ImpulseDirection = DirectionHelper.GetOpposingDirection(pushToTheSideDirection), Strength = strengthRest });
                }
            }
        }
        public void MoveByDistance(Direction direction, double desiredDistance)
        {
            TheoreticalPosition.MoveIntoGivenDirection(direction, desiredDistance);
            MyTheoreticalCollisionModel.Update(TheoreticalPosition, LengthX, LengthY);

            List<IWorldElement> collidingElements = ComplexElementFinderForMovement.FindCollidingElements(this, MyTheoreticalCollisionModel, TheoreticalPosition, ListProvider.GetList());

            //bewegen
            if (!collidingElements.Any())
            {
                MoveInCurrentDirection(desiredDistance, direction);
                return;
            }
            else
            {
                _collisionProtocol.SetCollisionInformation(direction);
            }

            MoveInCurrentDirection(0.0, direction); 
        }

        public void AddImpulse(Impulse impulse)
        {
            ImpulseCollection.AddImpulse(impulse);
        }

        public override void SetCenterPosition(double positionX, double positionY, double positionZ)
        {
            base.SetCenterPosition(positionX, positionY, positionZ);

            if (TheoreticalPosition == null)
                TheoreticalPosition = new Position3D();

            TheoreticalPosition.PositionX = positionX;
            TheoreticalPosition.PositionY = positionY;
            TheoreticalPosition.PositionZ = positionZ;

            if (MyTheoreticalCollisionModel == null)
                MyTheoreticalCollisionModel = new PositionOnRoomFieldModel();

            MyTheoreticalCollisionModel.Update(TheoreticalPosition, LengthX, LengthY);
        }

        private void MoveInCurrentDirection(double possibleDistance, Direction currentDirection)
        {
            base.MoveIntoGivenDirection(currentDirection, possibleDistance);

            TheoreticalPosition.PositionX = Position.PositionX;
            TheoreticalPosition.PositionY = Position.PositionY;
            TheoreticalPosition.PositionZ = Position.PositionZ;
        }

        /// <summary>
        /// changes the theoretical position by the impulsestrength
        /// </summary>
        /// <returns>the distance to the new position</returns>
        private double CalculateTheoreticalPosition(Impulse impulse)
        {
            double distance = TimeAndSpeedManager.CalculateDistanceByImpulseStrength(impulse.Strength);
            distance = ReduceDistanceToSideLength(impulse.ImpulseDirection, distance);
            TheoreticalPosition.MoveIntoGivenDirection(impulse.ImpulseDirection, distance);
            MyTheoreticalCollisionModel.Update(TheoreticalPosition, LengthX, LengthY);

            return distance;
        }

        private double ReduceDistanceToSideLength(Direction direction, double distance)
        {
            switch (direction)
            {
                case Direction.FromBottomToTop:
                case Direction.FromTopToBottom:
                    if (distance > MaxAdditionalSideLengthForMovement + LengthY)
                        return MaxAdditionalSideLengthForMovement + LengthY;
                    return distance;
                case Direction.FromLeftToRight:
                case Direction.FromRightToLeft:
                    if (distance > MaxAdditionalSideLengthForMovement + LengthX)
                        return MaxAdditionalSideLengthForMovement + LengthX;
                    return distance;
                case Direction.FromCeilingToFloor:
                case Direction.FromFloorToCeiling:
                    if (distance > MaxAdditionalSideLengthForMovement + Height)
                        return MaxAdditionalSideLengthForMovement + Height;
                    return distance;
                default:
                    return distance;
            }
        }

        private Direction GetThePushToTheSideDirection(IWorldElement otherObject, Direction currentDirection)
        {
            if (currentDirection == Direction.FromLeftToRight || currentDirection == Direction.FromRightToLeft)
            {
                if (otherObject.Position.PositionY > Position.PositionY)
                {
                    double lowestOtherPointY = otherObject.Position.PositionY - (otherObject.LengthY / 2.0);

                    if (lowestOtherPointY > Position.PositionY + (LengthY * (0.5 - PushToTheSideOverlappingPercent)))
                    {
                        return Direction.FromBottomToTop;
                    }
                }
                else
                {
                    double highestOtherPointY = otherObject.Position.PositionY + (otherObject.LengthY / 2.0);

                    if (highestOtherPointY < Position.PositionY - (LengthY * (0.5 - PushToTheSideOverlappingPercent)))
                    {
                        return Direction.FromTopToBottom;
                    }
                }
            }

            if (currentDirection == Direction.FromTopToBottom || currentDirection == Direction.FromBottomToTop)
            {
                if (otherObject.Position.PositionX > Position.PositionX)
                {
                    double lowestOtherPointX = otherObject.Position.PositionX - (otherObject.LengthX / 2.0);

                    if (lowestOtherPointX > Position.PositionX + (LengthX * (0.5 - PushToTheSideOverlappingPercent)))
                    {
                        return Direction.FromLeftToRight;
                    }
                }
                else
                {
                    double highestOtherPointX = otherObject.Position.PositionX + (otherObject.LengthX / 2.0);

                    if (highestOtherPointX < Position.PositionX - (LengthX * (0.5 - PushToTheSideOverlappingPercent)))
                    {
                        return Direction.FromRightToLeft;
                    }
                }
            }

            return Direction.FromNowhereToNowhere;
        }

        private void ReduceImpulseStrengthByOwnWeight(Impulse impulse)
        {
            impulse.Strength -= Weight;
        }

        #region IComparable implementation
        public int CompareTo(object element)
        {
            IWorldElement comparisonObject = (IWorldElement)element;

            switch (ImpulseSortDirection.Direction)
            {
                case Direction.FromLeftToRight:
                    return this.Position.PositionX < comparisonObject.Position.PositionX ? 1 :
                        (this.Position.PositionX > comparisonObject.Position.PositionX ? -1 : 0);
                case Direction.FromRightToLeft:
                    return this.Position.PositionX > comparisonObject.Position.PositionX ? 1 :
                        (this.Position.PositionX < comparisonObject.Position.PositionX ? -1 : 0);
                case Direction.FromBottomToTop:
                    return this.Position.PositionY < comparisonObject.Position.PositionY ? 1 :
                        (this.Position.PositionY > comparisonObject.Position.PositionY ? -1 : 0);
                case Direction.FromTopToBottom:
                    return this.Position.PositionY > comparisonObject.Position.PositionY ? 1 :
                        (this.Position.PositionY < comparisonObject.Position.PositionY ? -1 : 0);
                default:
                    return 0;
            }
        }
        #endregion
    }
}
