using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteraction.ThemeMapping;
using CollisionDetection;
using IOInterface;
using GameInteraction.BaseImplementations;
using ThemeMapping;
using BaseTypes;
using LevelEditor.Elements;
using GameInteractionContracts;
using FrameworkContracts;
using LevelEditor.Contracts;
using BaseContracts;
using CollisionDetection.CollisionDetectors;
using CollisionDetection.CollisionDetectors.ComplexElementFinders;

namespace LevelEditor
{
    public class ElementaryLevelEditorFactory : IElementFactory
    {
        private ICommunicationElementFactory CommunicationElementFactory { set; get; }
        private WorldEditor WorldEditor { set; get; }
        private INameListProvider AnimationListProvider { set; get; }
        private INameListProvider ImageListProvider { set; get; }
        private IListProviderProvider<IWorldElement> ListProviderProvider { set; get; }
        private IPlayerInstructionProvider _playerInstructionProvider;

        public ElementaryLevelEditorFactory(ICommunicationElementFactory communicationElementFactory, WorldEditor worldEditor,
            INameListProvider animationListProvider, INameListProvider imageListProvider, IListProviderProvider<IWorldElement> listProviderProvider, IPlayerInstructionProvider playerInstructionProvider)
        {
            WorldEditor = worldEditor;
            CommunicationElementFactory = communicationElementFactory;
            AnimationListProvider = animationListProvider;
            ImageListProvider = imageListProvider;
            ListProviderProvider = listProviderProvider;
            _playerInstructionProvider = playerInstructionProvider;
        }

        public IWorldElement CreateNewElement(IElement element)
        {
            IWorldElement worldElement = null;

            if (element.Parameters == null)
                element.Parameters = AppearanceMapper.GetInstance().GetAppearance(element.ElementTheme);

            IPhysicalParameters parameters = element.Parameters;

            if (parameters != null && element.Orientation > Degree.Degree_0)
            {
                parameters = AppearanceRotater.RotateByDegree(parameters, element.Orientation);
            }

            switch (element.ElementTheme)
            {
                case ElementTheme.PlayerOne:
                    worldElement = new GhostPlayer(WorldEditor, ListProviderProvider.GetProvider(),
                        _playerInstructionProvider, new ComplexElementFinder(new DetectorOfOverlappingElements()), ((int)element.Orientation - 1) * 45);
                    break;
                case ElementTheme.GenericElement:
                case ElementTheme.GenericElementWithoutCollision:
                case ElementTheme.GenericElementWithoutMovement:
                case ElementTheme.SlidingDoor:
                    if (element.Parameters.Shape == Shape.Circle)
                        worldElement = new GenericElementPlaceHolder(AnimationListProvider, ImageListProvider,
                            ((IVisualParameters)element.Parameters).IsAnimation, ((IVisualParameters)element.Parameters).AnimationDurationPerImage,
                            ((IVisualParameters)element.Parameters).TextureFolder, ListProviderProvider.GetProvider(), new ComplexElementFinder(new DetectorOfOverlappingElements()));
                    else
                        worldElement = new BoxElementPlaceHolder(AnimationListProvider, ImageListProvider, ((IVisualParameters)element.Parameters).IsAnimation,
                            ((IVisualParameters)element.Parameters).AnimationDurationPerImage,
                             ((IVisualParameters)element.Parameters).TextureFolder, ListProviderProvider.GetProvider(), new ComplexElementFinder(new DetectorOfOverlappingElements()));
                    break;
                case ElementTheme.Fist:
                case ElementTheme.Pistol:
                case ElementTheme.PistolBullets:
                case ElementTheme.ShotGun:
                case ElementTheme.ShotShells:
                case ElementTheme.MG:
                case ElementTheme.MGChain:
                case ElementTheme.AtomaticMG:
                case ElementTheme.AtomaticMGChain:
                case ElementTheme.RocketThrower:
                case ElementTheme.RocketTriggerer:
                case ElementTheme.GrenadeLauncher:
                case ElementTheme.GrenadeTriggerer:
                case ElementTheme.Uzi:
                case ElementTheme.UziBullets:
                    worldElement = new InvisibleElement(ListProviderProvider.GetProvider(), new ComplexElementFinder(new DetectorOfOverlappingElements()));
                    break;
                default:
                    worldElement = new ElementPlaceHolder(ListProviderProvider.GetProvider(), new ComplexElementFinder(new DetectorOfOverlappingElements()));
                    break;
            }

            IAnimatable animatableElement = (IAnimatable)worldElement;
            animatableElement.ElementTheme = element.ElementTheme;
            animatableElement.Orientation = element.Orientation;

            if (parameters != null)
            {
                ICommunicationElement communicationElement = CommunicationElementFactory.CreateNewElement(element);
                animatableElement.CommunicationElement = communicationElement;

                worldElement.SetCenterPosition(element.StartPosition.PositionX, element.StartPosition.PositionY, element.StartPosition.PositionZ);
                worldElement.SetPhysicalAppearance(parameters.Shape, parameters.Weight, parameters.SideLengthX, parameters.SideLengthY, parameters.Height, parameters.SideLengthX / 2.0);
            }

            if (worldElement is IStorable && element.InitInformation != null && element.InitInformation.InitValues.Count > 0)
            {
                (worldElement as IStorable).SetState(element.InitInformation);
            }
            return worldElement;
        }

        public void DeleteElement(IWorldElement element)
        {
        }
    }
}
