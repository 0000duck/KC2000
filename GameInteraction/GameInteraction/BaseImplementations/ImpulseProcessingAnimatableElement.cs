using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using CollisionDetection;
using BaseTypes;
using GameInteraction.ThemeMapping;
using CollisionDetection.Elements;
using GameInteractionContracts;
using BaseContracts;
using CollisionDetection.Contracts;

namespace GameInteraction.BaseImplementations
{
    public class ImpulseProcessingAnimatableElement : ImpulseProcessingElement, IAnimatable
    {
        public ICommunicationElement CommunicationElement { set; get; }
        public ElementTheme ElementTheme { set; get; }
        public bool IsMarked { set; get; }
        public double AnimationPercent { set; get; }
        public Degree Orientation { set; get; }

        protected Behaviour AnimationBehaviour { set; get; }

        public ImpulseProcessingAnimatableElement(IListProvider<IWorldElement> listProvider, IComplexElementFinder complexElementFinder)
            : base(listProvider, complexElementFinder)
        {}

        public virtual void Render()
        {
            if (!IsVirtual)
            {
                CommunicationElement.ChangePosition(Position.PositionX, Position.PositionY, Position.PositionZ);

                CommunicationElement.RenderAnimation(AnimationBehaviour, AnimationPercent, Orientation, IsMarked);
            }
        }
    }
}
