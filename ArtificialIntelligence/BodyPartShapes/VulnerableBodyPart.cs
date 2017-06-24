using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using IOInterface;

namespace ArtificialIntelligence.BodyPartShapes
{
    public class VulnerableBodyPart : IVulnerable, IDestructionNotifier
    {
        private double _strength;
        private double _currentInjury;
        private List<IDestructionObserver> _destructionObserverList;
        private List<IExitWoundObserver> _exitWoundObservers;
        private BodyPart _bodyPart;

        public VulnerableBodyPart(BodyPart bodyPart, double strength)
        {
            _bodyPart = bodyPart;
            _strength = strength;
            _destructionObserverList = new List<IDestructionObserver>();
            _exitWoundObservers = new List<IExitWoundObserver>();
        }

        void IVulnerable.YouGotHit(Position3D position, double destructionStrength, Vector3D directionVector)
        {
            _currentInjury += destructionStrength;

            foreach (IExitWoundObserver observer in _exitWoundObservers)
            {
                observer.NotifyExitWound(_bodyPart, position, directionVector, destructionStrength);
            }

            if (destructionStrength >= _strength)
            {
                foreach (IDestructionObserver observer in _destructionObserverList)
                {
                    observer.NotifyFullDestruction(_bodyPart, position);
                }
            }
            else 
            {
                if (_currentInjury >= _strength)
                {
                    foreach (IDestructionObserver observer in _destructionObserverList)
                    {
                        observer.NotifyInnerDestruction();
                    }
                }
            }
        }

        void IDestructionNotifier.AddDestructionObserver(IDestructionObserver destructionObserver)
        {
            _destructionObserverList.Add(destructionObserver);
        }

        void IDestructionNotifier.AddExitWoundObserver(IExitWoundObserver exitWoundObserver)
        {
            _exitWoundObservers.Add(exitWoundObserver);
        }
    }
}
