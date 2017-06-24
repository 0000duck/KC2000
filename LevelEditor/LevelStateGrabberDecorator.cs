using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using InitializationContracts;
using IOInterface;
using SaveGames;

namespace LevelEditor
{
    public class LevelStateGrabberDecorator : ILevelStateGrabber
    {
        private ILevelStateGrabber _levelStateGrabber;
        private List<IWorldElement> _worldElements;

        public LevelStateGrabberDecorator(ILevelStateGrabber levelStateGrabber, IEnumerable<IWorldElement> worldElements)
        {
            _levelStateGrabber = levelStateGrabber;
            _worldElements = (List<IWorldElement>)worldElements;
        }

        List<IElement> ILevelStateGrabber.GetStateOfAllElements()
        {
            RemoveDuplicates();
            return _levelStateGrabber.GetStateOfAllElements();
        }

        private void RemoveDuplicates()
        {
            List<IWorldElement> duplicates = new List<IWorldElement>();

            foreach (IWorldElement element in _worldElements)
            {
                foreach (IWorldElement group in _worldElements)
                {
                    if (group is IElementGroup)
                    {
                        if (GroupContainsElement(group as IElementGroup, element))
                            duplicates.Add(element);
                    }
                }
            }

            _worldElements.RemoveAll(x => duplicates.Contains(x));
        }

        private bool GroupContainsElement(IElementGroup elementGroup, IWorldElement element)
        {
            foreach (IWorldElement child in elementGroup.Children)
            {
                if (child is IElementGroup)
                {
                    if(GroupContainsElement(child as IElementGroup, element))
                        return true;
                }
                else 
                {
                    if (child == element)
                        return true;
                }
            }

            return false;
        }
    }
}
