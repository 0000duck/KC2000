using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOInterface
{
    public interface IPlayerObserver
    {
        void InterpretPlayerInformation(IPlayerInformation gameElementMetaInformation);
    }
}
