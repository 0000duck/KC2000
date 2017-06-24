using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using LevelEditor.Contracts;
using BaseContracts;

namespace LevelEditor.Elements
{
    public class WorldEditor
    {
        private ElementManipulator ElementManipulator { set; get; }
        private ElementPicker ElementPicker { set; get; }
        private ElementCreator ElementCreator { set; get; }
        private IMessageRenderer Header { set; get; }
        private IMessageRenderer Options { set; get; }
        private OptionSelection CreatorOptions { set; get; }
        private List<OptionSelection> ManipulatorOptions { set; get; }
        private OptionSelection CurrentOptions { set; get; }
        private IOptionProvider CurrentOptionProvider { set; get; }

        public WorldEditor(IMessageRenderer header, IMessageRenderer options, ElementCreator elementCreator, ElementManipulator elementManipulator)
        {
            Header = header;
            Options = options;
            ElementCreator = elementCreator;
            ElementManipulator = elementManipulator;
            ElementPicker = new ElementPicker();
            CreatorOptions = ((IOptionProvider)ElementCreator).GetOptions().First();
            CurrentOptions = CreatorOptions;
            CurrentOptionProvider = ElementCreator;
            UpdateMessage();
        }

        public void EditWorld(ILevelEditorInstruction levelEditorPlayerInstruction, Position3D cameraPosition, VectorWithDegree viewDegree, IWorldElement playerToExclude, IListProvider<IWorldElement> listProvider) 
        {
            if (ElementPicker.ItemIsClicked(levelEditorPlayerInstruction))
            {
                IWorldElement element = ElementPicker.FindSelectedElement(cameraPosition, viewDegree, playerToExclude, listProvider);

                ElementManipulator.AddSelectedItem(element);

                if (ElementManipulator.OptionsHaveChanged)
                {
                    ManipulatorOptions = ElementManipulator.GetOptions();

                    if (CurrentOptionProvider == ElementManipulator)
                    {
                        if (ManipulatorOptions != null && ManipulatorOptions.Any())
                        {
                            CurrentOptions = ManipulatorOptions.First();
                        }
                        else
                        {
                            CurrentOptions = CreatorOptions;
                            CurrentOptionProvider = ElementCreator;
                        }

                        UpdateMessage();
                    }
                }
            }

            InterpretOptionSelection(levelEditorPlayerInstruction);

            CurrentOptionProvider.InterpretOption(levelEditorPlayerInstruction, cameraPosition);
            if(CurrentOptionProvider != ElementManipulator)
                ElementManipulator.InterpretOption(levelEditorPlayerInstruction, cameraPosition);
        }

        private void InterpretOptionSelection(ILevelEditorInstruction levelEditorPlayerInstruction)
        {
            if (levelEditorPlayerInstruction.NextOptionSelection)
            {
                if (CurrentOptions == CreatorOptions)
                {
                    if(ManipulatorOptions == null || !ManipulatorOptions.Any())
                        return;

                    CurrentOptions = ManipulatorOptions.First();
                    CurrentOptionProvider = ElementManipulator;
                    UpdateMessage();
                    return;
                }

                int index = ManipulatorOptions.IndexOf(CurrentOptions);

                if (index == ManipulatorOptions.Count - 1)
                {
                    CurrentOptions = CreatorOptions;
                    CurrentOptionProvider = ElementCreator;
                    UpdateMessage();
                    return;
                }

                CurrentOptions = ManipulatorOptions.ElementAt(index + 1);
            }

            if (levelEditorPlayerInstruction.NextOption)
            {
                CurrentOptions.SelectedIndex++;
                if (CurrentOptions.SelectedIndex == CurrentOptions.Options.Count)
                    CurrentOptions.SelectedIndex = 0;
            }

            if (levelEditorPlayerInstruction.PreviousOption)
            {
                CurrentOptions.SelectedIndex--;
                if (CurrentOptions.SelectedIndex < 0)
                    CurrentOptions.SelectedIndex = CurrentOptions.Options.Count - 1;
            }

            CurrentOptionProvider.RegisterSelectionchange(new OptionSelectionChange
                {
                    Header = CurrentOptions.Header,
                    Option = CurrentOptions.Options.ElementAt(CurrentOptions.SelectedIndex)
                });

            UpdateMessage();
        }

        private void UpdateMessage()
        {
            Header.RenderMessage(CurrentOptions.Header);
            Options.RenderMessage(CurrentOptions.Options.ElementAt(CurrentOptions.SelectedIndex));
        }
    }
}
