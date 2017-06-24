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
    public class GenericElementPlaceHolder : ElementPlaceHolder, IOptionProvider
    {
        protected List<OptionSelection> Options { set; get; }
        protected INameListProvider AnimationListProvider { set; get; }
        protected INameListProvider ImageListProvider { set; get; }
        protected OptionSelectionChange LastOptionSelectionChange { set; get; }

        public GenericElementPlaceHolder(INameListProvider animationListProvider, INameListProvider imageListProvider, bool isAnimation, double animationDuration,
            string textureFolder, IListProvider<IWorldElement> listProvider, IComplexElementFinder complexElementFinder)
            : base(listProvider, complexElementFinder)
        {
            AnimationListProvider = animationListProvider;
            ImageListProvider = imageListProvider;

            FillOptions(isAnimation, animationDuration, textureFolder);
        }

        private void FillOptions(bool isAnimation, double animationDuration, string textureFolder)
        {
            Options = new List<OptionSelection>
            {
                new OptionSelection
                {
                    Header = "Move and scale",
                    Options = new List<string> {"Position", "Texture", "Size"}
                }
            };

            if(isAnimation)
            {
                OptionSelection optionSelection = new OptionSelection
                {
                    Header = "Animation",
                    Options = AnimationListProvider.GetList()
                };

                optionSelection.SelectedIndex = optionSelection.Options.IndexOf(textureFolder);

                Options.Add(optionSelection);
            }
            else
            {
                OptionSelection optionSelection = new OptionSelection
                {
                    Header = "Image",
                    Options = ImageListProvider.GetList()
                };

                optionSelection.SelectedIndex = optionSelection.Options.IndexOf(textureFolder);

                Options.Add(optionSelection);
            }

            if (isAnimation)
            {
                OptionSelection optionSelection = new OptionSelection
                {
                    Header = "AnimationDuration",
                    Options = new List<string> {"0", "5", "10", "15", "25", "50", "75", "100", "200"}
                };

                string duration = ((int)(animationDuration * 100)).ToString();
                optionSelection.SelectedIndex = optionSelection.Options.IndexOf(duration);

                Options.Add(optionSelection);
            }
        }

        public List<OptionSelection> GetOptions()
        {
            return Options;
        }

        public virtual void InterpretOption(ILevelEditorInstruction levelEditorInstruction, BaseTypes.Position3D editorPosition)
        {
            if (LastOptionSelectionChange == null)
                return;

            IVisualParameters parameters = ((IVisualParameterized)CommunicationElement).GetParameters();

            if (LastOptionSelectionChange.Header.Equals("Animation") ||
                LastOptionSelectionChange.Header.Equals("Image"))
            {
                if (parameters.TextureFolder == LastOptionSelectionChange.Option)
                    return;

                parameters = parameters.Clone();
                parameters.TextureFolder = LastOptionSelectionChange.Option;
                ((IEditorCommunicationElement)CommunicationElement).Update(parameters, Orientation);
            }
            else if (LastOptionSelectionChange.Header.Equals("AnimationDuration"))
            {
                parameters = parameters.Clone();
                int duration = int.Parse(LastOptionSelectionChange.Option);
                parameters.AnimationDurationPerImage = ((double)duration) / 100.0;
                ((IEditorCommunicationElement)CommunicationElement).Update(parameters, Orientation);
            }
            else if (LastOptionSelectionChange.Option.Equals("Size"))
            {
                double distance = levelEditorInstruction.SlowMotion ? Constants.SizeChangeSmall : Constants.SizeChange;

                parameters = parameters.Clone();
                if (levelEditorInstruction.MoveUp)
                {
                    parameters.Height += distance;
                }
                else if (levelEditorInstruction.MoveDown)
                {
                    parameters.Height -= distance;
                }
                else if (levelEditorInstruction.MoveLeft)
                {
                    parameters.SideLengthX += distance;
                }
                else if (levelEditorInstruction.MoveRight)
                {
                    parameters.SideLengthX -= distance;
                }
                else if (levelEditorInstruction.MoveForward)
                {
                    parameters.SideLengthY += distance;
                }
                else if (levelEditorInstruction.MoveBackward)
                {
                    parameters.SideLengthY -= distance;
                }
                else if (levelEditorInstruction.RotateLeft)
                {
                    parameters.SideLengthX += distance;
                    parameters.SideLengthY += distance;
                    parameters.Height += distance;
                }
                else if (levelEditorInstruction.RotateRight)
                {
                    parameters.SideLengthX -= distance;
                    parameters.SideLengthY -= distance;
                    parameters.Height -= distance;
                }
                else if(levelEditorInstruction.Number.HasValue)
                {
                    ChangeParametersByNumber(parameters, levelEditorInstruction.Number.Value);
                }
                else
                    return;

                if (ElementTheme == IOInterface.ElementTheme.GenericElement)
                {
                    parameters.Weight = 50 * parameters.SideLengthX * parameters.SideLengthY * parameters.Height;
                }

                ((IEditorCommunicationElement)CommunicationElement).Update(parameters, Orientation);
            }   
        }

        private void ChangeParametersByNumber(IVisualParameters parameters, int number)
        {
            parameters.SideLengthX = number;
            parameters.SideLengthY = number;

            if (number == 0)
            {
                parameters.SideLengthX = 10;
                parameters.SideLengthY = 10;
            }
        }

        public virtual void RegisterSelectionchange(OptionSelectionChange selectionChange)
        {
            LastOptionSelectionChange = selectionChange;
        }
    }
}
