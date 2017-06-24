using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sound.Contracts;
using ArtificialIntelligence.Contracts;

namespace ArtificialIntelligence.Strategies
{
    public class LoopedSoundUpdater : IBehaviourStrategy
    {
        private ISound _helicopterRotor;
        private IBehaviourStrategy _mainStrategy;
        private bool _soundStarted;

        public LoopedSoundUpdater(ISound helicopterRotor, IBehaviourStrategy mainStrategy)
        {
            _helicopterRotor = helicopterRotor;
            _mainStrategy = mainStrategy;
        }

        bool IBehaviourStrategy.ActivityIsNecessary()
        {
            return _mainStrategy.ActivityIsNecessary();
        }

        bool IBehaviourStrategy.MovementCanBeBreaked()
        {
            return _mainStrategy.MovementCanBeBreaked();
        }

        BehaviourInstruction IBehaviourStrategy.GetInstruction(BehaviourParameters behaviourParameters)
        {
            if (!_soundStarted)
            {
                _helicopterRotor.Play();
                _soundStarted = true;
            }

            _helicopterRotor.SetPosition((float)behaviourParameters.Position.PositionX, (float)behaviourParameters.Position.PositionZ, (float)behaviourParameters.Position.PositionY);

            return _mainStrategy.GetInstruction(behaviourParameters);
        }
    }
}
