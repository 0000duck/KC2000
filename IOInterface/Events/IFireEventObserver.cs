using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace IOInterface.Events
{
    public interface IFireEventObserver
    {
        void NotifyShot(Position3D position);
    }
}
