using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkContracts
{
    public interface IMessageRendererFactory
    {
        IMessageRenderer CreateMessageRenderer(double cornerX, double cornerY);
    }
}
