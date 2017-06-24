using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace GameInteractionContracts
{
    public interface IDoorOpener
    {
        void SetPlayer(IWorldElement player);

        void AddDoor(IActivatable door);
    }
}
