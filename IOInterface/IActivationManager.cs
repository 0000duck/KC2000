using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;

namespace IOInterface
{
    public interface IActivationManager
    {
        void InterpretActivationInstruction(IActivationInstruction activationInstruction, Position3D activatorPosition);
    }
}
