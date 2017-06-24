using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace GameInteractionContracts
{
    public interface IActivatable
    {
        void Activate();

        bool IsActivating();

        Position3D ActivationPosition { get; } 
    }
}
