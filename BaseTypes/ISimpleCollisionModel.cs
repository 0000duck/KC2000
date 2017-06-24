using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace BaseTypes
{
    public interface ISimpleCollisionModel
    {
        int X { get; }
        int Y { get; }

        void Update(Position3D position, double sideLengthX, double sideLengthY);

        bool EventuallyCollidesWith(ISimpleCollisionModel otherCollisionModel);
    }
}
