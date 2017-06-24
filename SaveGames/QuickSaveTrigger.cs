using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using GameInteractionContracts;
using ElementImplementations.ActivationManagerImplementations;

namespace SaveGames
{
    public class QuickSaveTrigger : IExecuteble
    {
        private IPlayerInstructionProvider _playerInstructionProvider;
        private IEnumerable<ISaveGameObserver> _observers;

        public QuickSaveTrigger(IPlayerInstructionProvider playerInstructionProvider, IEnumerable<ISaveGameObserver> observers)
        {
            _playerInstructionProvider = playerInstructionProvider;
            _observers = observers;
        }

        void IExecuteble.ExecuteLogic()
        {
            if (!_playerInstructionProvider.GetInput().Save)
                return;

            foreach (ISaveGameObserver saveGameObserver in _observers)
            {
                saveGameObserver.GameContentIsSaved();
            }
        }
    }
}
