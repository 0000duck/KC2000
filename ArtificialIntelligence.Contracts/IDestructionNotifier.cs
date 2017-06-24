using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArtificialIntelligence.Contracts
{
    public interface IDestructionNotifier
    {
        void AddDestructionObserver(IDestructionObserver destructionObserver);

        void AddExitWoundObserver(IExitWoundObserver exitWoundObserver);
    }
}
