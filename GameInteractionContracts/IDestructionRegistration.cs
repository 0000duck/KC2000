using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseContracts;
using BaseTypes;

namespace GameInteractionContracts
{
    public interface IDestructionRegistration
    {
        void AddNewDestruction(Position3D position, Vector3D directionVectorUnitLength, double destructionStrength, IListProvider<IWorldElement> listProvider, double? strengthReduction);
    }
}
