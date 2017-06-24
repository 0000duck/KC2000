using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteraction.BaseImplementations;
using BaseTypes;
using GameInteractionContracts;
using BaseContracts;
using IOInterface;

namespace ElementImplementations.DoorImplementations
{
    public class Door : FixAnimatibleElement, IActivatable, IExecuteble
    {
        protected PercentFader PercentFader { set; get; }

        public bool Open { protected set; get; }
        protected bool Moving { set; get; }

        public Position3D ActivationPosition
        {
            get;
            protected set;
        }

        public Door(Position3D position)
            :base(new PositionOnRoomFieldModel())
        {
            PercentFader = new PercentFader(0.5);

            ActivationPosition = position.Clone();
        }

        public override void Render()
        {
            CommunicationElement.ChangePosition(Position.PositionX, Position.PositionY, Position.PositionZ);
            CommunicationElement.RenderAnimation(Behaviour.StandardBehaviour, AnimationPercent, Orientation, IsMarked); 
        }

        public virtual void ExecuteLogic()
        {
            if (Moving)
            {
                AnimationPercent = PercentFader.GetPercent();

                Move();

                if (PercentFader.IsFinished())
                {
                    Moving = false;
                    Open = !Open;
                }
            }
        }

        protected virtual void Move()
        {
            throw new NotImplementedException();
        }

        public void Activate()
        {
             if (Moving)
                return;

            if (DoorCanBeMoved())
            {
                Moving = true;
                PercentFader.Start();
            }
        }

        protected virtual bool DoorCanBeMoved()
        {
            return true;
        }


        public bool IsActivating()
        {
            return Moving;
        }
    }
}
