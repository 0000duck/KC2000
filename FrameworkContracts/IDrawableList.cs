using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkContracts
{
    public interface IDrawableList : IDrawable
    {
        void Add(IDrawable drawable);
        void Remove(IDrawable drawable);
    }
}
