using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Elements
{
    public interface ITranslatable
    {
        void Move(bool up, bool down, bool left, bool right, bool forward, bool backward, bool slow);

        void BindToFloor();
    }
}
