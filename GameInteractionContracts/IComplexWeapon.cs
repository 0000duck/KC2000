using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace GameInteractionContracts
{
    public interface IComplexWeapon
    {
        ComplexWeaponResult GetWeaponResult(bool fire, Position3D position, VectorWithDegree directionVector);
    }
}
