using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface.Events;
using IOInterface;
using BaseTypes;

namespace FrameworkContracts
{
    public interface IFlyingShellFactory
    {
        IFireEventObserver CreateFlyingShell(Animation shellAnimation);
    }
}
