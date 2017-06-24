using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using IOInterface;

namespace ArtificialIntelligence.Contracts
{
    public interface IDestructionObserver
    {
        void NotifyFullDestruction(BodyPart bodyPart, Position3D position);

        void NotifyInnerDestruction();
    }
}
