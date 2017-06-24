using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sound.Contracts;
using IOInterface.Events;
using GameInteractionContracts;
using BaseTypes;

namespace GameInteraction
{
    public class HeavyWeaponFireObserver: IFireEventObserver
    {
        private IFireEventObserver _fireEventObserver;
        private IQuakeTriggerer _quakeTriggerer;
        private double _quakeStrength;

        public HeavyWeaponFireObserver(IFireEventObserver fireEventObserver, IQuakeTriggerer quakeTriggerer, double quakeStrength)
        {
            _fireEventObserver = fireEventObserver;
            _quakeTriggerer = quakeTriggerer;
            _quakeStrength = quakeStrength;
        }

        void IFireEventObserver.NotifyShot(Position3D position)
        {
            _fireEventObserver.NotifyShot(position);

            _quakeTriggerer.TriggerAbsoluteQuake(_quakeStrength);
        }
    }
}
