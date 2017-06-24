using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LevelEditor.Contracts;
using BaseTypes;
using GameInteraction.ThemeMapping;
using ElementImplementations;
using IOInterface;
using GameInteractionContracts;
using SaveGames;
using GameInteraction;

namespace LevelEditor.Elements
{
    public class DoorWayCreator : IDoorWayCreator
    {
        private IElementGroup _elementGroup;
        private INameListProvider _imageListProvider;
        private ITextureNormalizer _textureNormalizer;
        private IElementCreatorProvider _elementCreatorProvider;

        public DoorWayCreator(INameListProvider imageListProvider, ITextureNormalizer textureNormalizer, IElementCreatorProvider elementCreatorProvider)
        {
            _imageListProvider = imageListProvider;
            _textureNormalizer = textureNormalizer;
            _elementCreatorProvider = elementCreatorProvider;
        }

        void IDoorWayCreator.CreateDoorWay(double totalLength, Position3D position)
        {
            _elementCreatorProvider.GetElementCreator().EnqueueNewElement(new SimpleElement
            {
                ElementTheme = ElementTheme.InvisibleGroup,
                StartPosition = new BaseTypes.Position3D(),
                Orientation = Degree.Degree_0,
                SubElements = new List<IElement>()
            }, CreateGroup);


            CreateInnerDoorWay(position.Clone());

            CreateUpperDoorWay(position.Clone());
            CreateOuterUpperDoorWay(position.Clone());

            CreateInnerSides(position.Clone(), totalLength);
            CreateOuterSides(position.Clone(), totalLength);
        }


        private void CreateOuterSides(Position3D position, double totalLength)
        {
            //left
            Position3D positionLeft = position.Clone();
            VisualParameters visualParameters = new VisualParameters(true);
            positionLeft.PositionY -= ((totalLength) / 4) + 0.5;
            positionLeft.PositionX -= 0.2;
            ReduceToWallPlate(visualParameters);
            visualParameters.SideLengthY = (totalLength) / 2;
            visualParameters.Height = 3;
            visualParameters.SideLengthX = 0.1;
            visualParameters.Shape = Shape.Rectangle;
            visualParameters.TextureFolder = _imageListProvider.GetList().First();

            _elementCreatorProvider.GetElementCreator().EnqueueNewElement(new SimpleElement
            {
                ElementTheme = ElementTheme.GenericElementWithoutMovement,
                StartPosition = positionLeft,
                Parameters = visualParameters,
                Orientation = Degree.Degree_180
            }, AddCreatedElement);

            //right
            Position3D positionRight = position.Clone();
            visualParameters = new VisualParameters(true);
            positionRight.PositionY += ((totalLength) / 4) + 0.5;
            positionRight.PositionX -= 0.2;
            ReduceToWallPlate(visualParameters);
            visualParameters.SideLengthY = (totalLength) / 2;
            visualParameters.Height = 3;
            visualParameters.SideLengthX = 0.1;
            visualParameters.Shape = Shape.Rectangle;
            visualParameters.TextureFolder = _imageListProvider.GetList().First();

            _elementCreatorProvider.GetElementCreator().EnqueueNewElement(new SimpleElement
            {
                ElementTheme = ElementTheme.GenericElementWithoutMovement,
                StartPosition = positionRight,
                Parameters = visualParameters,
                Orientation = Degree.Degree_180
            }, AddCreatedElement);
        }

        private void CreateUpperDoorWay(Position3D position)
        {
            VisualParameters visualParameters = new VisualParameters(true);
            position.PositionZ += 2.0;
            position.PositionX += 0.2;
            ReduceToWallPlate(visualParameters);
            visualParameters.SideLengthY = 1.0;
            visualParameters.Height = 1;
            visualParameters.SideLengthX = 0.1;
            visualParameters.Shape = Shape.Rectangle;
            visualParameters.TextureFolder = _imageListProvider.GetList().First();

            _elementCreatorProvider.GetElementCreator().EnqueueNewElement(new SimpleElement
            {
                ElementTheme = ElementTheme.GenericElementWithoutMovement,
                StartPosition = position,
                Parameters = visualParameters,
                Orientation = Degree.Degree_0
            }, AddCreatedElement);
        }

        private void CreateOuterUpperDoorWay(Position3D position)
        {
            VisualParameters visualParameters = new VisualParameters(true);
            position.PositionZ += 2.0;
            position.PositionX -= 0.2;
            ReduceToWallPlate(visualParameters);
            visualParameters.SideLengthY = 1.0;
            visualParameters.Height = 1;
            visualParameters.SideLengthX = 0.1;
            visualParameters.Shape = Shape.Rectangle;
            visualParameters.TextureFolder = _imageListProvider.GetList().First();

            _elementCreatorProvider.GetElementCreator().EnqueueNewElement(new SimpleElement
            {
                ElementTheme = ElementTheme.GenericElementWithoutMovement,
                StartPosition = position,
                Parameters = visualParameters,
                Orientation = Degree.Degree_180
            }, AddCreatedElement);
        }

        private void CreateInnerSides(Position3D position, double totalLength)
        {
            //left
            Position3D positionLeft = position.Clone();
            VisualParameters visualParameters = new VisualParameters(true);
            positionLeft.PositionY -= ((totalLength - 1) / 4) +0.5;
            positionLeft.PositionX += 0.2;
            ReduceToWallPlate(visualParameters);
            visualParameters.SideLengthY = (totalLength - 1) / 2;
            visualParameters.Height = 3;
            visualParameters.SideLengthX = 0.1;
            visualParameters.Shape = Shape.Rectangle;
            visualParameters.TextureFolder = _imageListProvider.GetList().First();

            _elementCreatorProvider.GetElementCreator().EnqueueNewElement(new SimpleElement
            {
                ElementTheme = ElementTheme.GenericElementWithoutMovement,
                StartPosition = positionLeft,
                Parameters = visualParameters,
                Orientation = Degree.Degree_0
            }, AddCreatedElement);
            
            //right
            Position3D positionRight = position.Clone();
            visualParameters = new VisualParameters(true);
            positionRight.PositionY += ((totalLength - 1) / 4) + 0.5;
            positionRight.PositionX += 0.2;
            ReduceToWallPlate(visualParameters);
            visualParameters.SideLengthY = (totalLength - 1) / 2;
            visualParameters.Height = 3;
            visualParameters.SideLengthX = 0.1;
            visualParameters.Shape = Shape.Rectangle;
            visualParameters.TextureFolder = _imageListProvider.GetList().First();

            _elementCreatorProvider.GetElementCreator().EnqueueNewElement(new SimpleElement
            {
                ElementTheme = ElementTheme.GenericElementWithoutMovement,
                StartPosition = positionRight,
                Parameters = visualParameters,
                Orientation = Degree.Degree_0
            }, AddCreatedElement);
        }

        private void CreateInnerDoorWay(Position3D position)
        {
            //left
            Position3D positionLeft = position.Clone();
            VisualParameters visualParameters = new VisualParameters(true);
            positionLeft.PositionY -= 0.55;
            ReduceToWallPlate(visualParameters);
            visualParameters.SideLengthY = 0.5;
            visualParameters.Height = 2;
            visualParameters.SideLengthX = 0.1;
            visualParameters.Shape = Shape.Rectangle;
            visualParameters.TextureFolder = _imageListProvider.GetList().First();

            _elementCreatorProvider.GetElementCreator().EnqueueNewElement(new SimpleElement
            {
                ElementTheme = ElementTheme.GenericElementWithoutMovement,
                StartPosition = positionLeft,
                Parameters = visualParameters,
                Orientation = Degree.Degree_270
            }, AddCreatedElement);

            //right
            Position3D positionRight = position.Clone();
            visualParameters = new VisualParameters(true);
            positionRight.PositionY += 0.55;
            ReduceToWallPlate(visualParameters);
            visualParameters.SideLengthY = 0.5;
            visualParameters.Height = 2;
            visualParameters.SideLengthX = 0.1;
            visualParameters.Shape = Shape.Rectangle;
            visualParameters.TextureFolder = _imageListProvider.GetList().First();

            _elementCreatorProvider.GetElementCreator().EnqueueNewElement(new SimpleElement
            {
                ElementTheme = ElementTheme.GenericElementWithoutMovement,
                StartPosition = positionRight,
                Parameters = visualParameters,
                Orientation = Degree.Degree_90
            }, AddCreatedElement);

            //ceiling
            Position3D positionCeiling = position.Clone();
            visualParameters = new VisualParameters(true);
            positionCeiling.PositionZ += 2;
            ReduceToCeilingPlate(visualParameters);
            visualParameters.SideLengthY = 0.5;
            visualParameters.Height = 0.1;
            visualParameters.SideLengthX = 1;
            visualParameters.Shape = Shape.Rectangle;
            visualParameters.TextureFolder = _imageListProvider.GetList().First();

            _elementCreatorProvider.GetElementCreator().EnqueueNewElement(new SimpleElement
            {
                ElementTheme = ElementTheme.GenericElementWithoutMovement,
                StartPosition = positionCeiling,
                Parameters = visualParameters,
                Orientation = Degree.Degree_90
            }, AddCreatedElement);
        }

        private void AddCreatedElement(IWorldElement element)
        {
            _elementGroup.AddChild((IGroupElement)element);
        }

        private void CreateGroup(IWorldElement element)
        {
            _elementGroup = (IElementGroup)element;
        }

        private void ReduceToCeilingPlate(VisualParameters visualParameters)
        {
            visualParameters.NegativeX = null;
            visualParameters.NegativeZ = null;
            visualParameters.PositiveX = null;
            visualParameters.PositiveZ = null;
            visualParameters.Top = null;
        }

        private void ReduceToWallPlate(VisualParameters visualParameters)
        {
            visualParameters.Bottom = null;
            visualParameters.NegativeZ = null;
            visualParameters.NegativeX = null;
            visualParameters.PositiveZ = null;
            visualParameters.Top = null;
        }
    }
}
