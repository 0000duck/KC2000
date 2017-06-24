using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;
using CollisionDetection;

namespace GameInteractionContracts
{
    public interface IAnimatable : IWorldElement, IVisualAppearance
    {
        ICommunicationElement CommunicationElement { set; get; }      

        void Render();
    }
}
