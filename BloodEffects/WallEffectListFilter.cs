using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseContracts;
using BaseTypes;
using GameInteractionContracts;

namespace BloodEffects
{
    public class WallEffectListFilter : IListFilter<IWorldElement>
    {
        List<IWorldElement> IListFilter<IWorldElement>.Apply(IEnumerable<IWorldElement> list)
        {
            List<IWorldElement> result = new List<IWorldElement>();

            foreach(IWorldElement element in list)
            {
                if (element.Shape == Shape.Circle)
                    continue;

                IVisualAppearance visualAppearane = element as IVisualAppearance;
                if (visualAppearane != null)
                {
                    //if element can move, we can't create a sprite
                    if (visualAppearane.ElementTheme == IOInterface.ElementTheme.GenericElement ||
                        visualAppearane.ElementTheme == IOInterface.ElementTheme.GenericElementWithoutCollision ||
                        visualAppearane.ElementTheme == IOInterface.ElementTheme.ExplosiveBox)
                        continue;
                }

                if (element is IActivatable)
                    continue;

                result.Add(element);
            }

            return result;
        }
    }
}
