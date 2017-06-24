using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public interface IPositionProvider
    {
        Position3D GetPosition();
    }
}
