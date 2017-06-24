using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection;
using EnvironmentAnalysis.RayTest.Rays;
using GameInteraction.BaseImplementations;
using GameInteraction.ThemeMapping;
using ElementImplementations;
using IOInterface;
using BaseTypes;
using GameInteractionContracts;
using LevelEditor.Contracts;
using FrameworkContracts;
using GameInteraction;

namespace LevelEditor.Elements
{
    public class ElementManipulator : IOptionProvider
    {
        private List<IWorldElement> AllSelectedBasicElements { set; get; }
        private List<IWorldElement> AllSelectedTopLevelElements { set; get; }
        private List<IElement> AllCopiedTopLevelElements { set; get; }
        private IWorldElement SingleSelectedElement { set; get; }
        private IElementCopier ElementCopier { set; get; }
        private OptionSelection OptionSelection { set; get; }
        private bool MultiSelect { set; get; }
        private List<OptionSelection> OptionsSelections { set; get; }
        private OptionSelectionChange LastOptionSelectionChange { set; get; }
        private IElementCreatorProvider _elementCreatorProvider;

        public bool OptionsHaveChanged { get; private set; }

        public ElementManipulator(IElementCreatorProvider elementCreator)
        {
            _elementCreatorProvider = elementCreator;
            AllSelectedBasicElements = new List<IWorldElement>();
            AllSelectedTopLevelElements = new List<IWorldElement>();
            ElementCopier = new ElementCopier();
            OptionSelection = new OptionSelection
            {
                Header = "Auswahl",
                Options = new List<string> { "Position" }
            };
            UseOwnOption();
        }

        private void UseOwnOption()
        {
            OptionsSelections = new List<OptionSelection> { OptionSelection };
            OptionsHaveChanged = true;
        }

        private void UseOptionOfSingleElement()
        {
            OptionsSelections = (AllSelectedTopLevelElements.First() as IOptionProvider).GetOptions();
            OptionsHaveChanged = true;
        }

        private void SetInstruction(ILevelEditorInstruction currentInstructions)
        {
            MultiSelect = currentInstructions.MultiSelect;
            InterpretMovementCommands(currentInstructions);
            InterpretGroupCommands(currentInstructions);
            InterpretCopyPasteCommands(currentInstructions);
            InterpretDeleteCommands(currentInstructions);
        }

        public void AddSelectedItem(IWorldElement element)
        {
            if (element == null)
            {
                UnselectAllElements();
                SingleSelectedElement = null;
                UseOwnOption();
                return;
            }

            if (!MultiSelect)
            {
                UnselectAllElements();
            }

            AddElementToLists(element);

            if (AllSelectedTopLevelElements.Count == 1 && AllSelectedTopLevelElements.First() is IOptionProvider)
            {
                UseOptionOfSingleElement();
            }
            else
            {
                UseOwnOption();
            }
        }

        private void InterpretDeleteCommands(ILevelEditorInstruction currentInstructions)
        {
            if (currentInstructions.Delete)
            {
                foreach (IWorldElement element in AllSelectedTopLevelElements)
                {
                    _elementCreatorProvider.GetElementCreator().DeleteElement(element);
                }
            }
        }

        private void InterpretCopyPasteCommands(ILevelEditorInstruction currentInstructions)
        {
            if (currentInstructions.Copy)
            {
                AllCopiedTopLevelElements = ElementCopier.CopyElements(AllSelectedTopLevelElements);
            }

            if (currentInstructions.Paste)
            {
                if (AllCopiedTopLevelElements == null || AllCopiedTopLevelElements.Count == 0)
                    return;

                foreach (IElement element in AllCopiedTopLevelElements)
                {
                    _elementCreatorProvider.GetElementCreator().EnqueueNewElement(element, AddPastedElement);
                }
                UnselectAllElements();
            }
        }

        private void AddPastedElement(IWorldElement worldElement)
        {
            AddElementToLists(worldElement);
        }

        private void AddElementsToNewGroup(IWorldElement newGroup)
        {
            if (AllSelectedTopLevelElements.Count(x => !(x is IElementGroup)) < 2)
                return;

            List<IWorldElement> newTopLevelElements = new List<IWorldElement>();

            foreach (IWorldElement element in AllSelectedTopLevelElements)
            {
                if (element is IElementGroup)
                {
                    newTopLevelElements.Add(element);
                    continue;
                }

                (newGroup as IElementGroup).AddChild((IGroupElement)element);
            
            }
            AllSelectedTopLevelElements.Clear();
            AllSelectedTopLevelElements = newTopLevelElements;
            AllSelectedTopLevelElements.Add(newGroup);
        }

        private void InterpretGroupCommands(ILevelEditorInstruction currentInstructions)
        {
            if (currentInstructions.Group)
            {
                _elementCreatorProvider.GetElementCreator().EnqueueNewElement(new SimpleElement
                {
                    ElementTheme = ElementTheme.InvisibleGroup,
                    StartPosition = new BaseTypes.Position3D(),
                    Orientation = Degree.Degree_0,
                    SubElements = new List<IElement>()
                }, AddElementsToNewGroup);
                return;
            }
            if (currentInstructions.Ungroup)
            {
                if (AllSelectedTopLevelElements.Count != 1 || AllSelectedTopLevelElements[0] is IElementGroup == false)
                    return;

                foreach (IWorldElement element in AllSelectedBasicElements)
                {
                    RemoveElementFromGroup(element);
                }

                _elementCreatorProvider.GetElementCreator().DeleteElement(AllSelectedTopLevelElements[0]);
                
                AllSelectedTopLevelElements.Clear();
                return;
            }
            if (currentInstructions.SingleUngroup)
            {
                if (SingleSelectedElement == null)
                    return;

                RemoveElementFromGroup(SingleSelectedElement);
                SingleSelectedElement = null;
            }
        }

        private void RemoveElementFromGroup(IWorldElement element)
        {
            (element as IGroupElement).Parent.RemoveChild(element as IGroupElement);

            _elementCreatorProvider.GetElementCreator().DeleteElement(element);
            _elementCreatorProvider.GetElementCreator().EnqueueNewElement(new SimpleElement
            {
                ElementTheme = (element as IVisualAppearance).ElementTheme,
                StartPosition = element.Position,
                Orientation = (element as IVisualAppearance).Orientation,
                Parameters = (((element as IAnimatable).CommunicationElement) as IVisualParameterized).GetParameters()
            }); 
        }

        private void AddElementToLists(IWorldElement element)
        {
            SingleSelectedElement = null;

            if (element is IGroupElement && ((IGroupElement)element).Parent != null)
            {
                SingleSelectedElement = element;
                IGroupElement highestParent = FindHighestParent((IGroupElement)element);
                AllSelectedTopLevelElements.Add((IWorldElement)highestParent);
                AddAllChildrenToBasicList((IElementGroup)highestParent);
            }
            else if (element is IElementGroup)
            {
                AllSelectedTopLevelElements.Add((IWorldElement)element);
                AddAllChildrenToBasicList((IElementGroup)element);
            }
            else
            {
                AllSelectedTopLevelElements.Add(element);
                AllSelectedBasicElements.Add(element);
            }

            MarkAllSelectedElements();
        }

        private void AddAllChildrenToBasicList(IElementGroup elementGroup)
        {
            if (elementGroup.Children == null || elementGroup.Children.Count == 0)
                return;
            
            foreach (IWorldElement child in elementGroup.Children)
            {
                if (child is IElementGroup)
                {
                    AddAllChildrenToBasicList(child as IElementGroup);
                }
                else
                {
                    AllSelectedBasicElements.Add(child);
                }
            }    
        }

        private IGroupElement FindHighestParent(IGroupElement groupElement)
        {
            if (groupElement.Parent != null)
            {
                if (groupElement.Parent is IGroupElement)
                    return FindHighestParent((IGroupElement)groupElement.Parent);
            }
            
            return groupElement;
        }

        private void InterpretMovementCommands(ILevelEditorInstruction currentInstructions)
        {
            foreach (IWorldElement element in AllSelectedBasicElements)
            {
                if (element is ITranslatable)
                {
                    (element as ITranslatable).Move(currentInstructions.MoveUp, currentInstructions.MoveDown, 
                        currentInstructions.MoveLeft, currentInstructions.MoveRight,
                        currentInstructions.MoveForward, currentInstructions.MoveBackward, currentInstructions.SlowMotion);
                }
            }

            foreach (IWorldElement element in AllSelectedTopLevelElements)
            {
                if (element is IRotateble)
                {
                    if(currentInstructions.RotateLeft)
                        (element as IRotateble).RotateLeft();

                    if (currentInstructions.RotateRight)
                        (element as IRotateble).RotateRight();
                }
            }
        }

        private void MarkAllSelectedElements()
        {
            foreach (IWorldElement element in AllSelectedBasicElements)
            {
                if (element is IVisualAppearance)
                {
                    (element as IVisualAppearance).IsMarked = true;
                }
            }
        }

        private void UnselectAllElements()
        {
            foreach (IWorldElement element in AllSelectedBasicElements)
            {
                if (element is IVisualAppearance)
                {
                    (element as IVisualAppearance).IsMarked = false;
                }
            }
            AllSelectedBasicElements.Clear();
            AllSelectedTopLevelElements.Clear();
        }

        public List<OptionSelection> GetOptions()
        {
            OptionsHaveChanged = false;
            return OptionsSelections;
        }

        public void InterpretOption(ILevelEditorInstruction levelEditorInstruction, Position3D editorPosition)
        {
            if (!(AllSelectedTopLevelElements.Count == 1 && (AllSelectedTopLevelElements.First() is IOptionProvider)) || 
                (LastOptionSelectionChange!= null && LastOptionSelectionChange.Option == "Position"))
            {
                SetInstruction(levelEditorInstruction);
                return;
            }

            (AllSelectedTopLevelElements.First() as IOptionProvider).InterpretOption(levelEditorInstruction, editorPosition);
        }

        public void RegisterSelectionchange(OptionSelectionChange selectionChange)
        {
            LastOptionSelectionChange = selectionChange;

            if (AllSelectedTopLevelElements.Count == 0)
                return;

            if (!(AllSelectedTopLevelElements.First() is IOptionProvider))
                return;

            (AllSelectedTopLevelElements.First() as IOptionProvider).RegisterSelectionchange(selectionChange);
        }
    }
}
