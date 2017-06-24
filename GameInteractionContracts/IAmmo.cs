using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameInteractionContracts
{
    public interface IAmmo
    {
        BaseTypes.Position3D Position { get; }

        IOInterface.ElementTheme ElementTheme { get; }

        int Count { get; }

        void SetCollected();

        FireResult Fire(FireInstructions fireInstructions);

        bool HasEnoughSpace(BaseTypes.Position3D position);

        bool Collectable { get; }
    }
}
