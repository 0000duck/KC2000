using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace LevelEditor.Elements
{
    public interface IRotateble
    {
        void RotateLeft(bool degree90 = false);

        void RotateRight(bool degree90 = false);
    }
}
