using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteraction.ThemeMapping;
using CollisionDetection;
using IOInterface;
using GameInteraction.BaseImplementations;
using BaseTypes;
using GameInteractionContracts;
using ElementImplementations.ComplexElementImplementations;

namespace ThemeMapping
{
    public class GroupBuildingFactory :  ListFillingFactory<IWorldElement>, IElementFactory
    {
        private List<ElementTheme> ThemesToExcludeCompletely { set; get; }
        private List<ElementTheme> ThemesToExcludeFromGroups { set; get; }
        private IComposition [,] Compositions {set; get;}
        private double _maxLevelLength;
        private int _groupDimensions;

        public GroupBuildingFactory(IElementFactory factory, List<ElementTheme> themesToExcludeCompletely, List<ElementTheme> themesToExcludeFromGroups,
            double maxLevelLength, int groupDimensions, List<IWorldElement> floorElements)
            : base(factory)
        {
            ThemesToExcludeCompletely = themesToExcludeCompletely;
            ThemesToExcludeFromGroups = themesToExcludeFromGroups;
            _maxLevelLength = maxLevelLength;
            _groupDimensions = groupDimensions;

            Compositions = new IComposition[groupDimensions, groupDimensions];

            for (int x = 0; x < groupDimensions; x++)
            {
                for (int y = 0; y < groupDimensions; y++)
                {
                    Compositions[x, y] = new ElementComposition();
                }
            }

            List.AddRange(floorElements);
        }

        public override IWorldElement CreateNewElement(IElement element)
        {
            IWorldElement worldelement = Factory.CreateNewElement(element);

            if (ThemesToExcludeCompletely.Contains(element.ElementTheme))
                return worldelement;

            if (worldelement is IGroupElement && !ThemesToExcludeFromGroups.Contains(element.ElementTheme))
            {
                int x = (int)(element.StartPosition.PositionX / (_maxLevelLength / _groupDimensions));
                int y = (int)(element.StartPosition.PositionY / (_maxLevelLength / _groupDimensions));

                x = x < 0 ? 0 : x;
                y = y < 0 ? 0 : y;

                x = x >= _groupDimensions ? _groupDimensions - 1 : x;
                y = y >= _groupDimensions ? _groupDimensions - 1 : y;

                Compositions[x, y].AddChild((IGroupElement)worldelement);

                if (!List.Contains((IWorldElement)Compositions[x, y]))
                    List.Add((IWorldElement)Compositions[x, y]);
            }
            else
            {
                List.Add(worldelement);
            }
            
            return worldelement;
        }

        public override void DeleteElement(IWorldElement element)
        {
            if (List.Contains(element))
                List.Remove(element);
            else if (element is IGroupElement)
            {
                IElementGroup parent = ((IGroupElement)element).Parent;
                if (parent != null && List.Contains((IWorldElement)parent))
                {
                    parent.RemoveChild((IGroupElement)element);
                    ((IGroupElement)element).Parent = null;

                    if(parent.Children.Count == 0)
                        List.Remove((IWorldElement)parent);
                }
            }
            
            Factory.DeleteElement(element);
        }
    }
}
