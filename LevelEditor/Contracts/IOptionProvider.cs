using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace LevelEditor.Contracts
{
    interface IOptionProvider
    {
        List<OptionSelection> GetOptions();

        void InterpretOption(ILevelEditorInstruction levelEditorInstruction, Position3D editorPosition);

        void RegisterSelectionchange(OptionSelectionChange selectionChange);
    }
}
