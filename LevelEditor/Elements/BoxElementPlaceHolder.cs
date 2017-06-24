using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LevelEditor.Contracts;
using FrameworkContracts;
using BaseContracts;
using BaseTypes;
using CollisionDetection.Contracts;

namespace LevelEditor.Elements
{
    public class BoxElementPlaceHolder : GenericElementPlaceHolder
    {
        private string SelectedSide { set; get; }
        private BoxSideManipulator BoxSideManipulator { set; get; }

        public BoxElementPlaceHolder(INameListProvider animationListProvider, INameListProvider imageListProvider,
            bool isAnimation, double animationDuration, string textureFolder, IListProvider<IWorldElement> listProvider, IComplexElementFinder complexElementFinder)
            : base(animationListProvider, imageListProvider, isAnimation, animationDuration, textureFolder, listProvider, complexElementFinder)
        {
            Options.Add(
                new OptionSelection
                {
                    Header = "Side",
                    Options = new List<string> {"All", "Top", "Bottom", "Front", "Back", "Left", "Right"}
                }
            );
            SelectedSide = "All";
            BoxSideManipulator = new BoxSideManipulator(new TextureNormalizer());
        }

        public override void InterpretOption(ILevelEditorInstruction levelEditorInstruction, BaseTypes.Position3D editorPosition)
        {
            if (LastOptionSelectionChange == null)
                return;

            if (LastOptionSelectionChange.Header.Equals("Animation") || 
                LastOptionSelectionChange.Header.Equals("Image") ||
                LastOptionSelectionChange.Option.Equals("Size"))
            {
                base.InterpretOption(levelEditorInstruction, editorPosition);
                return;
            }

            if (LastOptionSelectionChange.Header.Equals("Side") ||
                LastOptionSelectionChange.Option.Equals("Texture"))
            {
                IVisualParameters parameters = ((IVisualParameterized)CommunicationElement).GetParameters();
                
                BoxSideManipulator.InterPretTextureCommands(SelectedSide, levelEditorInstruction, parameters);

                ((IEditorCommunicationElement)CommunicationElement).Update(parameters, Orientation);
            }
        }

        public override void RegisterSelectionchange(OptionSelectionChange selectionChange)
        {
            LastOptionSelectionChange = selectionChange;

            if (LastOptionSelectionChange.Header.Equals("Side"))
            {
                SelectedSide = LastOptionSelectionChange.Option;
                ((ISideMarker)CommunicationElement).MarkSide(SelectedSide);
            }
        }
    }
}
