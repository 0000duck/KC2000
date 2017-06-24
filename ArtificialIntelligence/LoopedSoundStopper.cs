using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using IOInterface;
using Sound.Contracts;

namespace ArtificialIntelligence
{
    public class LoopedSoundStopper : IElementCreator
    {
        private IElementCreator _creator;
        private ISound _sound;

        public LoopedSoundStopper(IElementCreator creator, ISound sound)
        {
            _creator = creator;
            _sound = sound;
        }

        IWorldElement IElementCreator.GetNewElement(IElement element)
        {
            return _creator.GetNewElement(element);
        }

        void IElementCreator.EnqueueNewElement(IElement element, Action<IWorldElement> returnCreatedElement)
        {
            _creator.EnqueueNewElement(element, returnCreatedElement);
        }

        void IElementCreator.DeleteElement(IWorldElement element)
        {
            _sound.Stop();
            _creator.DeleteElement(element);
        }
    }
}
