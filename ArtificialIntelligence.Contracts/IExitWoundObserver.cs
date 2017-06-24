using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;

namespace ArtificialIntelligence.Contracts
{
    public interface IExitWoundObserver
    {
        void NotifyExitWound(BodyPart bodyPart, Position3D position, Vector3D directionVector, double destructionStrength);
    }
}
