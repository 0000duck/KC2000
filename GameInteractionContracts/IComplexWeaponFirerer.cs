using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using IOInterface;

namespace GameInteractionContracts
{
    public interface IComplexWeaponFirerer
    {
        void SetInstructions(IWeaponInstructions instructions, Position3D position, VectorWithDegree vector);
    }
}
