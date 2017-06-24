using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using GameInteractionContracts;

namespace FrameworkImplementations.Player
{
    public class PlayerInstructionCache : IPlayerInstructionProvider, IExecuteble
    {
        private IPlayerInstructionProvider _playerInstructionProvider;
        private IPlayerInstruction _instructions;

        public PlayerInstructionCache(IPlayerInstructionProvider playerInstructionProvider)
        {
            _playerInstructionProvider = playerInstructionProvider;
        }

        IPlayerInstruction IPlayerInstructionProvider.GetInput()
        {
            return _instructions;
        }

        void IExecuteble.ExecuteLogic()
        {
            _instructions = _playerInstructionProvider.GetInput();
        }
    }
}
