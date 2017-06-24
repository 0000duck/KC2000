using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using GameInteraction.BaseImplementations;
using IOInterface;
using GameInteractionContracts;
using BaseContracts;

namespace ElementImplementations.DoorImplementations
{
    public class SlidingDoor : Door, IStorable
    {
        private CollisionTestDummy DoorMovementTestBox { set; get; }
        private IListProvider<IWorldElement> _listProvider;

        public SlidingDoor(Position3D position, IListProvider<IWorldElement> listProvider)
            : base(position)
        {
            _listProvider = listProvider;
        }

        protected override bool DoorCanBeMoved()
        {
            if (!Open)
                return true;

            if(DoorMovementTestBox == null)
                DoorMovementTestBox = new CollisionTestDummy(ActivationPosition, LengthX, LengthY, Height, _listProvider);

            return DoorMovementTestBox.HasEnoughSpace();
        }

        protected override void Move()
        {
            double openingPercent = AnimationPercent;
            if (Open)
            {
                //closing
                switch (Orientation)
                {
                    case Degree.Degree_0:
                        Position.PositionX = ActivationPosition.PositionX - ((1 - openingPercent) * LengthX);
                        break;
                    case Degree.Degree_90:
                        Position.PositionY = ActivationPosition.PositionY - ((1 - openingPercent) * LengthY);
                        break;
                    case Degree.Degree_180:
                        Position.PositionX = ActivationPosition.PositionX + ((1 - openingPercent) * LengthX);
                        break;
                    case Degree.Degree_270:
                        Position.PositionY = ActivationPosition.PositionY + ((1 - openingPercent) * LengthY);
                        break;
                }
            }
            else
            {
                //opening
                switch (Orientation)
                {
                    case Degree.Degree_0:
                        Position.PositionX = ActivationPosition.PositionX - (openingPercent * LengthX);
                        break;
                    case Degree.Degree_90:
                        Position.PositionY = ActivationPosition.PositionY - (openingPercent * LengthY);
                        break;
                    case Degree.Degree_180:
                        Position.PositionX = ActivationPosition.PositionX + (openingPercent * LengthX);
                        break;
                    case Degree.Degree_270:
                        Position.PositionY = ActivationPosition.PositionY + (openingPercent * LengthY);
                        break;
                }
            }
        }

        public void SetState(IInitInformation initInformation)
        {
            SlidingDoorMemento slidingDoorMemento = new SlidingDoorMemento();
            slidingDoorMemento.SetState(initInformation);
            Open = slidingDoorMemento.Open;

            if (Open)
            {
                switch (Orientation)
                {
                    case Degree.Degree_0:
                        ActivationPosition.PositionX += LengthX;
                        break;
                    case Degree.Degree_90:
                        ActivationPosition.PositionY += LengthY;
                        break;
                    case Degree.Degree_180:
                        ActivationPosition.PositionX -= LengthX;
                        break;
                    case Degree.Degree_270:
                        ActivationPosition.PositionY -= LengthY;
                        break;
                }
            } 
        }

        public IInitInformation GetState()
        {
            SlidingDoorMemento slidingDoorMemento = new SlidingDoorMemento();
            slidingDoorMemento.Open = Open;
            return slidingDoorMemento.GetState();
        }
    }
}
