using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TextureConverter.Contracts
{
    public interface IReplacementColor
    {
        Color GetReplacementColor(Color color); 
    }
}
