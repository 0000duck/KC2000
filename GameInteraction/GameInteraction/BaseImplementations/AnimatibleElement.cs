using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Elements;
using GameInteractionContracts;
using BaseTypes;
using IOInterface;

namespace GameInteraction.BaseImplementations
{
    public class AnimatibleElement : StandardWorldElement, IAnimatable
    {
        public ICommunicationElement CommunicationElement { set; get; }

        public double AnimationPercent { set; get; }

        public Behaviour AnimationBehaviour { set; get; }

        public virtual void Render()
        {
            if (!IsVirtual)
            {
                CommunicationElement.ChangePosition(Position.PositionX, Position.PositionY, Position.PositionZ);

                CommunicationElement.RenderAnimation(AnimationBehaviour, AnimationPercent, Orientation, IsMarked);
            }
        }

        public ElementTheme ElementTheme { set; get; }

        public Degree Orientation { set; get; }

        public bool IsMarked { set; get; }
    }
}
