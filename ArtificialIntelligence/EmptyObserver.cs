using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;

namespace ArtificialIntelligence
{
    public class EmptyObserver : IDestructionObserver
    {
        void IDestructionObserver.NotifyFullDestruction(IOInterface.BodyPart bodyPart, BaseTypes.Position3D position)
        {

        }

        void IDestructionObserver.NotifyInnerDestruction()
        {

        }
    }
}
