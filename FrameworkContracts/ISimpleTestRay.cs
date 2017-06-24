using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace FrameworkContracts
{
    public interface ISimpleTestRay
    {
        bool FocusedElementIsHitByRay(Position3D startPosition, Position3D endPosition, List<IWorldElement> allElements, IWorldElement focusedElement);
    }
}
