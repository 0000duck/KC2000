using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;
using GameInteraction.ThemeMapping;
using GameInteraction.BaseImplementations;
using ElementImplementations.ComplexElementImplementations;
using ElementImplementations.CharacterImplementations;
using GameInteraction.Weapons;
using CollisionDetection;
using GameInteractionContracts;

namespace ThemeMapping
{
    public class ComplexElementBuilder : IElementFactory
    {
        private IElementFactory Factory { set; get; }

        public ComplexElementBuilder(IElementFactory factory)
        {
            Factory = factory;
        }

        public IWorldElement CreateNewElement(IElement element)
        {
            IWorldElement complexElement = null;
            
            switch (element.ElementTheme)
            {
                case ElementTheme.PlayerOne:
                    complexElement = Factory.CreateNewElement(element);
                    foreach (IElement subElement in element.SubElements)
                    {
                        IWorldElement child = CreateNewElement(subElement);

                        if (child is IGroupElement && complexElement is IElementGroup)
                        {
                            ((IElementGroup)complexElement).AddChild((IGroupElement)child);
                        }
                    }
                    break;
                case ElementTheme.ShotGun:
                case ElementTheme.Pistol:
                case ElementTheme.MG:
                case ElementTheme.AtomaticMG:
                case ElementTheme.RocketThrower:
                case ElementTheme.Uzi:
                case ElementTheme.GrenadeLauncher:
                    complexElement = Factory.CreateNewElement(element);
                    if (element.SubElements != null)
                    {
                        foreach (IElement subElement in element.SubElements)
                        {
                            IWorldElement child = Factory.CreateNewElement(subElement);

                            if (child is IGroupElement && complexElement is IElementGroup)
                            {
                                ((IElementGroup)complexElement).AddChild((IGroupElement)child);
                            }
                        }
                    }
                    break;
                //case alle gruppen
                case ElementTheme.InvisibleGroup:
                    complexElement = new ElementComposition { ElementTheme = element.ElementTheme, Orientation = element.Orientation };
                    complexElement.SetCenterPosition(element.StartPosition.PositionX, element.StartPosition.PositionY, element.StartPosition.PositionZ);
                    foreach(IElement subElement in element.SubElements)
                    {
                        IWorldElement child = Factory.CreateNewElement(subElement);

                        if (child is IGroupElement && complexElement is IElementGroup)
                        {
                            ((IElementGroup)complexElement).AddChild((IGroupElement)child);
                        }
                    }
                break;
                case ElementTheme.CarGroup:
                case ElementTheme.TokyoRail:
                complexElement = Factory.CreateNewElement(element);
                complexElement.SetCenterPosition(element.StartPosition.PositionX, element.StartPosition.PositionY, element.StartPosition.PositionZ);
                foreach (IElement subElement in element.SubElements)
                {
                    IWorldElement child = Factory.CreateNewElement(subElement);

                    if (child is IGroupElement && complexElement is IElementGroup)
                    {
                        ((IElementGroup)complexElement).AddChild((IGroupElement)child);
                    }
                }
                break;
                case ElementTheme.Gondel:
                complexElement = Factory.CreateNewElement(element);
                complexElement.SetCenterPosition(element.StartPosition.PositionX, element.StartPosition.PositionY, element.StartPosition.PositionZ);
                foreach (IElement subElement in element.SubElements)
                {
                    IWorldElement child = this.CreateNewElement(subElement);

                    if (child is IGroupElement && complexElement is IElementGroup)
                    {
                        ((IElementGroup)complexElement).AddChild((IGroupElement)child);
                    }
                }
                break;
                default:
                    return Factory.CreateNewElement(element);
            }

            return complexElement;
        }

        public void DeleteElement(IWorldElement element)
        {
            Factory.DeleteElement(element);
        }
    }
}
