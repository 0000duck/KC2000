using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using BaseContracts;

namespace BaseTypes
{
    public interface IMovableByImpulse
    {
        ImpulseCollection ImpulseCollection { get; }

        ICollisionProtocol CollisionProtocol { get; }

        void AddImpulse(Impulse impulse);

        void ProcessImpulseAndMove(Direction currentDirection);

        void MoveByDistance(Direction direction, double desiredDistance);
    }
}
