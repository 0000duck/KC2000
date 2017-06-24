using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using CollisionDetection;
using ElementImplementations.ActivationManagerImplementations;
using BaseTypes;
using SaveGames;
using InitializationContracts;

namespace LevelEditor.Elements
{
    public class ElementCopier : IElementCopier
    {
        List<IElement> IElementCopier.CopyElements(List<IWorldElement> elements)
        {
            ILevelStateGrabber grabber = new LevelStateGrabber(elements);
            return grabber.GetStateOfAllElements();
        }
    }
}
