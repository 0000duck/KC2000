using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection;
using IOInterface;
using BaseTypes;
using GameInteraction.BaseImplementations;
using InitializationContracts;
using GameInteractionContracts;
using FrameworkContracts;
using IOImplementation;

namespace SaveGames
{
    public class LevelStateGrabber : ILevelStateGrabber
    {
        private IEnumerable<IWorldElement> AllWorldElements { set; get; }

        public LevelStateGrabber(IEnumerable<IWorldElement> allWorldElements)
        {
            AllWorldElements = allWorldElements;
        }

        public List<IElement> GetStateOfAllElements()
        {
            List<IElement> elements = new List<IElement>();

            foreach(IWorldElement worldElement in AllWorldElements)
            {
                elements.Add(GetStateOfOneElement(worldElement));
            }

            return elements;
        }

        private IElement GetStateOfOneElement(IWorldElement worldElement, Degree parentDegree = Degree.Degree_0, Position3D parentPosition = null)
        {
            ElementImplementation element = new ElementImplementation();

            if (worldElement is IVisualAppearance)
            {
                IVisualAppearance visualAppearance = (IVisualAppearance)worldElement;

                element.ElementTheme = visualAppearance.ElementTheme;
                element.StartPosition = worldElement.Position;
                element.Orientation = visualAppearance.Orientation;
            }

            if (worldElement is IStorable)
            {
                IStorable storableElement = (IStorable)worldElement;

                element.InitInformation = storableElement.GetState();
            }

            if (worldElement is IAnimatable)
            {
                ICommunicationElement communicationElement = (worldElement as IAnimatable).CommunicationElement;
                if (communicationElement is IVisualParameterized)
                {
                    IVisualParameters parameters = (communicationElement as IVisualParameterized).GetParameters();
                    element.Parameters = parameters;
                }
            }

            if (worldElement is IElementGroup)
            {
                IElementGroup parent = (IElementGroup)worldElement;

                element.SubElements = new List<IElement>();

                foreach (IWorldElement child in parent.Children)
                {
                    element.SubElements.Add(GetStateOfOneElement(child, element.Orientation, element.StartPosition));
                }
            }

            return element;
        }

        private Position3D GetRelativePosition(Position3D position, Position3D parentPosition, Degree fatherDegree)
        {
            Position3D relativePosition = position.Clone();

            if (parentPosition != null)
            {
                relativePosition.PositionX -= parentPosition.PositionX;
                relativePosition.PositionY -= parentPosition.PositionY;
                relativePosition.PositionZ -= parentPosition.PositionZ;
                
                double oldX = relativePosition.PositionX;

                switch (fatherDegree)
                {
                    case Degree.Degree_90:
                        relativePosition.PositionX = relativePosition.PositionY;
                        relativePosition.PositionY = -oldX;
                        break;
                    case Degree.Degree_180:
                        relativePosition.PositionX = -relativePosition.PositionX;
                        relativePosition.PositionY = -relativePosition.PositionY;
                        break;
                    case Degree.Degree_270:
                        relativePosition.PositionX = -relativePosition.PositionY;
                        relativePosition.PositionY = oldX;
                        break;
                }
            }

            return relativePosition;
        }

        private Degree UndoRotation(Degree degree, Degree parentDegree)
        {
            Degree newDegree = (Degree)((int)degree - parentDegree + 1);
            
            if (newDegree < Degree.Degree_0)
                newDegree += 8;

            return newDegree;
        }
    }
}
