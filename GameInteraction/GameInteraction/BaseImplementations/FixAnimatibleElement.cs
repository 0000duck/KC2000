using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Elements;
using GameInteractionContracts;
using BaseTypes;
using IOInterface;
using CollisionDetection;

namespace GameInteraction.BaseImplementations
{
    public class FixAnimatibleElement : StandardWorldElement, IAnimatable
    {
        public ICommunicationElement CommunicationElement { set; get; }

        public double AnimationPercent { set; get; }

        public FixAnimatibleElement(ISimpleCollisionModel collisionModel)
            : base(collisionModel)
        {
        }

        public virtual void Render()
        {
            CommunicationElement.RenderAnimation(Behaviour.StandardBehaviour, AnimationPercent, Orientation, IsMarked);
        }

        public ElementTheme ElementTheme { set; get; }

        public Degree Orientation { set; get; }

        public bool IsMarked { set; get; }
    }
}
