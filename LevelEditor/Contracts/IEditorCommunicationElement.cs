using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;

namespace LevelEditor.Contracts
{
    public interface IEditorCommunicationElement
    {
        void Update(IVisualParameters parameters, Degree degree);
    }
}
