using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using IOInterface;
using BaseTypes;

namespace ElementImplementations.ActivationManagerImplementations
{
    public class DoorActivator : IExecuteble, IDoorOpener
    {
        private IPlayerInstructionProvider _playerInstructionProvider;
        private IWorldElement _player;
        private List<IActivatable> _doors;
        private double _squareActivationRadius;

        public DoorActivator(IPlayerInstructionProvider playerInstructionProvider, double activationRadius)
        {
            _playerInstructionProvider = playerInstructionProvider;
            _squareActivationRadius = activationRadius * activationRadius;
            _doors = new List<IActivatable>();
        }

        void IExecuteble.ExecuteLogic()
        {
            if (!_playerInstructionProvider.GetInput().OpenDoor)
                return;

            foreach(IActivatable door in _doors)           
            {
                DistanceBetweenTwoPositions distance = new DistanceBetweenTwoPositions(door.ActivationPosition, _player.Position);

                if (distance.SquareDistanceXY > _squareActivationRadius)
                    continue;

                door.Activate();
            }
        }

        void IDoorOpener.SetPlayer(IWorldElement player)
        {
            _player = player;
        }

        void IDoorOpener.AddDoor(IActivatable door)
        {
            _doors.Add(door);
        }
    }
}
