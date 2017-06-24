using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace CollisionDetection.Contracts
{
    public interface ICollisionByCylinderFinder
    {
        IList<IWorldElement> FilterElementsByCylinder(IEnumerable<IWorldElement> allElements, Position3D startPosition, Position3D endPosition, double minHeight);
    }
}
