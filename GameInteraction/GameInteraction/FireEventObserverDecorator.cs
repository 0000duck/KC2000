using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface.Events;
using BaseTypes;

namespace GameInteraction
{
    public class FireEventObserverComposition : IFireEventObserver
    {
        private IFireEventObserver _eventObserverOne;
        private IFireEventObserver _eventObserverTwo;

        public FireEventObserverComposition(IFireEventObserver eventObserverOne, IFireEventObserver eventObserverTwo)
        {
            _eventObserverOne = eventObserverOne;
            _eventObserverTwo = eventObserverTwo;
        }

        void IFireEventObserver.NotifyShot(Position3D position)
        {
            _eventObserverOne.NotifyShot(position);
            _eventObserverTwo.NotifyShot(position);
        }
    }
}
