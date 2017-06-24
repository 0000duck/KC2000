using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteraction.BaseImplementations;
using GameInteractionContracts;

namespace ElementImplementations.ActivationManagerImplementations
{
    public interface IActivationObserver
    {
        void ElementIsActivated(IActivatable element);
        void ElementCanBeActivated(IActivatable element);
    }
}
