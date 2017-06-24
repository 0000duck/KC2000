using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using CollisionDetection;
using BaseTypes;

namespace LevelEditor.Elements
{
    public interface IElementCopier
    {
        List<IElement> CopyElements(List<IWorldElement> AllSelectedTopLevelElements);
    }
}
