using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseContracts
{
    public interface ICollisionProtocol
    {
        bool IsCollisionLeft { get; }

        bool IsCollisionRight { get; }

        bool IsCollisionTop { get; }

        bool IsCollisionBottom { get; }

        bool IsCollisionFloor { get; }

        bool IsCollisionCeiling { get; }

        bool IsCollisionWithMoreThanTwoSides{ get; }

        bool IsCollisionInCorner{ get; }

        bool IsThereAnyHorizontalCollision{ get; }

        bool IsThereAnyCollision { get; }

        void Reset();
    }
}
