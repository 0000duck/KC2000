using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InitializationContracts;
using IOInterface;
using GameInteraction.ThemeMapping;
using ElementImplementations;
using FrameworkContracts;
using BaseTypes;
using SaveGames;
using LevelEditor.Contracts;
using GameInteractionContracts;
using GameInteraction;

namespace LevelEditor.Elements
{
    public class ElementCreator : IOptionProvider
    {
        private OptionSelectionChange LastOptionSelectionChange { set; get; }
        private INameListProvider AnimationListProvider { set; get; }
        private INameListProvider ImageListProvider { set; get; }
        private ITextureNormalizer _textureNormalizer;
        private IDoorWayCreator _doorWayCreator;
        private IElementCreatorProvider _elementCreatorProvider;

        public ElementCreator(INameListProvider animationListProvider, INameListProvider imageListProvider, ITextureNormalizer textureNormalizer, IDoorWayCreator doorWayCreator, IElementCreatorProvider elementCreatorProvider)
        {
            _elementCreatorProvider = elementCreatorProvider;
            AnimationListProvider = animationListProvider;
            ImageListProvider = imageListProvider;
            _textureNormalizer = textureNormalizer;
            _doorWayCreator = doorWayCreator;
        }

        public List<OptionSelection> GetOptions()
        {
            OptionSelection selection = new OptionSelection
            {
                Header = "ElementTyp",
                Options = new List<string>()
            };

            selection.Options.Add("GenericSpriteWithoutCollisionImage05");
            selection.Options.Add("GenericSpriteWithoutCollisionImage1");
            selection.Options.Add("GenericSpriteWithoutCollisionImage2");

            selection.Options.Add("GenericBoxImage");

            selection.Options.Add("GenericSpriteImage05");
            selection.Options.Add("GenericSpriteImage1");
                       
            selection.Options.Add("GenericSpriteWithoutMovementImage05");
            selection.Options.Add("GenericSpriteWithoutMovementImage1");
            selection.Options.Add("GenericSpriteWithoutMovementImage2");

            selection.Options.Add("GenericBoxWithoutMovementImage");

            foreach (ElementTheme theme in Enum.GetValues(typeof(ElementTheme)))
            {
                if (theme == ElementTheme.GenericElement ||
                    theme == ElementTheme.GenericElementWithoutCollision ||
                    theme == ElementTheme.GenericElementWithoutMovement)
                    continue;

                selection.Options.Add(theme.ToString());
            }
        
            selection.Options.Add("GenericSpriteAnimation");
            selection.Options.Add("GenericBoxAnimation");
            selection.Options.Add("GenericSpriteWithoutCollisionAnimation");
            selection.Options.Add("GenericBoxWithoutCollisionAnimation");
            selection.Options.Add("GenericSpriteWithoutMovementAnimation");
            selection.Options.Add("GenericBoxWithoutMovementAnimation");

            selection.Options.Add("GenericBoxWithoutCollisionImage");

            selection.Options.Add("FloorPlate1x1");
            selection.Options.Add("FloorPlate2x2Animation");
            selection.Options.Add("WallPlate3x3");
            selection.Options.Add("WallPlate3x4");
            selection.Options.Add("WallPlate3x5");
            selection.Options.Add("WallPlate3x6");
            selection.Options.Add("WallPlate3x9");
            selection.Options.Add("WallPlate3x10");
            selection.Options.Add("WallPlate3x20");
            selection.Options.Add("WallPlate3x40");
            selection.Options.Add("WallPlate3x80");
            selection.Options.Add("CeilingPlate1x1");
            selection.Options.Add("InnerDoorWay3");

            return new List<OptionSelection> { selection };
        }

        public void InterpretOption(ILevelEditorInstruction levelEditorInstruction, Position3D editorPosition)
        {
            if (!levelEditorInstruction.CreateElement)
                return;

            if (LastOptionSelectionChange == null)
                return;

            //discrete values: 0.2
            editorPosition.PositionX = ((int)(editorPosition.PositionX * 10)) / 10;
            editorPosition.PositionY = ((int)(editorPosition.PositionY * 10)) / 10;

            if (OptionIsGenericElement(editorPosition))
            {
                return;
            }

            ElementTheme theme;
            if (!Enum.TryParse(LastOptionSelectionChange.Option, out theme))
            {
                return;
            }

            if (theme == ElementTheme.Undefined)
                return;

            if (theme == ElementTheme.SlidingDoor)
            {
                CreateSlidingDoor(editorPosition);
                return;
            }

            _elementCreatorProvider.GetElementCreator().EnqueueNewElement(new SimpleElement { ElementTheme = theme, StartPosition = editorPosition, Orientation = Degree.Degree_0 });
        }

        private void CreateSlidingDoor(Position3D editorPosition)
        {
            VisualParameters visualParameters = new VisualParameters(true);
            editorPosition.PositionZ = 0.0;
            ReduceToDoorPlate(visualParameters);
            visualParameters.SideLengthY = 0.1;
            visualParameters.Height = 2;
            visualParameters.SideLengthX = 1.0;
            visualParameters.Shape = Shape.Rectangle;
            visualParameters.IsAnimation = false;
            visualParameters.TextureFolder = ImageListProvider.GetList().First();

            _elementCreatorProvider.GetElementCreator().EnqueueNewElement(new SimpleElement
            {
                ElementTheme = ElementTheme.SlidingDoor,
                StartPosition = editorPosition,
                Parameters = visualParameters,
                Orientation = Degree.Degree_0
            });
        }

        private bool OptionIsGenericElement(Position3D editorPosition)
        {
            ElementTheme theme = ElementTheme.Undefined;
            Shape shape = Shape.Circle;
            bool isAnimation = false;
            double animationDuration = 0.5;
            VisualParameters visualParameters = new VisualParameters(true);
            editorPosition.PositionZ = 0.0;

            switch (LastOptionSelectionChange.Option)
            {
                case "GenericSpriteImage05":
                    theme = ElementTheme.GenericElement;
                    shape = Shape.Circle;
                    visualParameters.Height = 0.5;
                    visualParameters.SideLengthX = 0.5;
                    visualParameters.SideLengthY = 0.5;
                    break;
                case "GenericSpriteImage1":
                    theme = ElementTheme.GenericElement;
                    shape = Shape.Circle;
                    visualParameters.Height = 1;
                    visualParameters.SideLengthX = 1;
                    visualParameters.SideLengthY = 1;
                    break;
                case "GenericBoxImage":
                    theme = ElementTheme.GenericElement;
                    shape = Shape.Rectangle;
                    break;
                case "GenericSpriteWithoutCollisionImage05":
                    theme = ElementTheme.GenericElementWithoutCollision;
                    shape = Shape.Circle;
                    visualParameters.Height = 0.5;
                    visualParameters.SideLengthX = 0.5;
                    visualParameters.SideLengthY = 0.5;
                    break;
                case "GenericSpriteWithoutCollisionImage1":
                    theme = ElementTheme.GenericElementWithoutCollision;
                    shape = Shape.Circle;
                    visualParameters.Height = 1;
                    visualParameters.SideLengthX = 1;
                    visualParameters.SideLengthY = 1;
                    break;
                case "GenericSpriteWithoutCollisionImage2":
                    theme = ElementTheme.GenericElementWithoutCollision;
                    shape = Shape.Circle;
                    visualParameters.Height = 2;
                    visualParameters.SideLengthX = 2;
                    visualParameters.SideLengthY = 2;
                    break;
                case "GenericBoxWithoutCollisionImage":
                    theme = ElementTheme.GenericElementWithoutCollision;
                    shape = Shape.Rectangle;
                    break;
                case "GenericSpriteWithoutMovementImage05":
                    theme = ElementTheme.GenericElementWithoutMovement;
                    shape = Shape.Circle;
                    visualParameters.Height = 0.5;
                    visualParameters.SideLengthX = 0.5;
                    visualParameters.SideLengthY = 0.5;
                    break;
                case "GenericSpriteWithoutMovementImage1":
                    theme = ElementTheme.GenericElementWithoutMovement;
                    shape = Shape.Circle;
                    visualParameters.Height = 1;
                    visualParameters.SideLengthX = 1;
                    visualParameters.SideLengthY = 1;
                    break;
                case "GenericSpriteWithoutMovementImage2":
                    theme = ElementTheme.GenericElementWithoutMovement;
                    shape = Shape.Circle;
                    visualParameters.Height = 2;
                    visualParameters.SideLengthX = 2;
                    visualParameters.SideLengthY = 2;
                    break;
                case "GenericBoxWithoutMovementImage":
                    theme = ElementTheme.GenericElementWithoutMovement;
                    shape = Shape.Rectangle;
                    break;
                case "GenericSpriteAnimation":
                    theme = ElementTheme.GenericElement;
                    shape = Shape.Circle;
                    isAnimation = true;
                    break;
                case "GenericBoxAnimation":
                    theme = ElementTheme.GenericElement;
                    shape = Shape.Rectangle;
                    isAnimation = true;
                    break;
                case "GenericSpriteWithoutCollisionAnimation":
                    theme = ElementTheme.GenericElementWithoutCollision;
                    shape = Shape.Circle;
                    isAnimation = true;
                    break;
                case "GenericBoxWithoutCollisionAnimation":
                    theme = ElementTheme.GenericElementWithoutCollision;
                    shape = Shape.Rectangle;
                    isAnimation = true;
                    break;
                case "GenericSpriteWithoutMovementAnimation":
                    theme = ElementTheme.GenericElementWithoutMovement;
                    isAnimation = true;
                    shape = Shape.Circle;
                    break;
                case "GenericBoxWithoutMovementAnimation":
                    theme = ElementTheme.GenericElementWithoutMovement;
                    shape = Shape.Rectangle;
                    isAnimation = true;
                    break;
                case "FloorPlate1x1":
                    theme = ElementTheme.GenericElementWithoutCollision;
                    shape = Shape.Rectangle;
                    isAnimation = false;
                    ReduceToFloorPlate(visualParameters);
                    visualParameters.Height = 0.1;
                    editorPosition.PositionZ = -0.1;
                    break;
                case "FloorPlate2x2Animation":
                    theme = ElementTheme.GenericElementWithoutCollision;
                    shape = Shape.Rectangle;
                    isAnimation = true;
                    ReduceToFloorPlate(visualParameters);
                    visualParameters.Height = 0.1;
                    editorPosition.PositionZ = -0.1;
                    visualParameters.SideLengthX = 2;
                    visualParameters.SideLengthY = 2;
                    break;
                case "CeilingPlate1x1":
                    theme = ElementTheme.GenericElementWithoutMovement;
                    shape = Shape.Rectangle;
                    isAnimation = false;
                    ReduceToCeilingPlate(visualParameters);
                    visualParameters.Height = 0.1;
                    editorPosition.PositionZ = 2;
                    break;
                case "WallPlate3x3":
                case "WallPlate3x4":
                case "WallPlate3x5":
                case "WallPlate3x6":
                case "WallPlate3x9":
                case "WallPlate3x10":
                case "WallPlate3x20":
                case "WallPlate3x40":
                case "WallPlate3x80":
                    theme = ElementTheme.GenericElementWithoutMovement;
                    shape = Shape.Rectangle;
                    isAnimation = false;
                    ReduceToWallPlate(visualParameters);
                    visualParameters.SideLengthY = int.Parse(LastOptionSelectionChange.Option.Split('x')[1]);
                    visualParameters.Height = 3;
                    visualParameters.SideLengthX = 0.1;
                    break;
                case "InnerDoorWay3":
                    _doorWayCreator.CreateDoorWay(3, editorPosition);
                    return true;
                default:
                    return false;
            }
         
            visualParameters.Shape = shape;
            visualParameters.IsAnimation = isAnimation;

            if (shape == Shape.Circle)
            {
                ReduceToFloorPlate(visualParameters);
                visualParameters.Top = null;
            }
            else
            {
                _textureNormalizer.NormalizeTextures(visualParameters, 2);
            }

            if (isAnimation)
            {
                visualParameters.TextureFolder = AnimationListProvider.GetList().First();
                visualParameters.AnimationDurationPerImage = animationDuration;
            }
            else
                visualParameters.TextureFolder = ImageListProvider.GetList().First();

            _elementCreatorProvider.GetElementCreator().EnqueueNewElement(new SimpleElement
            {
                ElementTheme = theme,
                StartPosition = editorPosition,
                Parameters = visualParameters,
                Orientation = Degree.Degree_0
            });

            return true;
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

        private void ReduceToDoorPlate(VisualParameters visualParameters)
        {
            visualParameters.Bottom = null;
            visualParameters.NegativeX = null;
            visualParameters.PositiveX = null;
            visualParameters.Top = null;
        }

        private void ReduceToFloorPlate(VisualParameters visualParameters)
        {
            visualParameters.NegativeX = null;
            visualParameters.NegativeZ = null;
            visualParameters.PositiveX = null;
            visualParameters.PositiveZ = null;
            visualParameters.Bottom = null;
        }

        public void RegisterSelectionchange(OptionSelectionChange selectionChange)
        {
            LastOptionSelectionChange = selectionChange;
        }
    }
}
