using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using FrameworkContracts;
using BaseTypes;

namespace FrameworkImplementations.Player
{
    public class PlayerObserver : IPlayerObserver
    {
        private IPlayerCameraConnection _playerCamera;

        public PlayerObserver(IPlayerCameraConnection playerCamera)
        {
            _playerCamera = playerCamera;
        }

        void IPlayerObserver.InterpretPlayerInformation(IPlayerInformation playerInformation)
        {
            Position3D lookAtPosition = playerInformation.PlayerCameraInformation.CameraPosition.Clone();
            lookAtPosition.PositionX += playerInformation.PlayerCameraInformation.ViewVector.Vector.X;
            lookAtPosition.PositionY += playerInformation.PlayerCameraInformation.ViewVector.Vector.Y;
            lookAtPosition.PositionZ += playerInformation.PlayerCameraInformation.ViewVector.Vector.Z;

            _playerCamera.SetCameraPosition(playerInformation.PlayerCameraInformation.CameraPosition, lookAtPosition,playerInformation.PlayerCameraInformation.ViewVector.Vector,
                playerInformation.PlayerCameraInformation.ViewVector.DegreeXY, playerInformation.PlayerCameraInformation.ViewVector.DegreeZ);
        }
    }
}
