using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace ArtificialIntelligence.Contracts
{
    public interface IRotater
    {
        bool IsRotating();

        RotationResult GetRotationResult();

        void StartRandomRotation(Degree startDegree);

        void StartRotation(Degree startDegree, Degree endDegree);
    }
}
