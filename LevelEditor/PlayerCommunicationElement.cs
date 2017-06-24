using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using FrameworkContracts;
using BaseTypes;

namespace LevelEditor
{
    public class PlayerCommunicationElement : IDrawable, IPlayerObserver, ICommunicationElement
    {
        private IPlayerCameraConnection PlayerCamera { set; get; }

        public PlayerCommunicationElement(IPlayerCameraConnection playerCamera)
        {
            PlayerCamera = playerCamera;
        }

        public void Draw()
        {
            
        }

        public void InterpretPlayerInformation(IPlayerInformation playerInformation)
        {
            Position3D lookAtPosition = playerInformation.PlayerCameraInformation.CameraPosition.Clone();
            lookAtPosition.PositionX += playerInformation.PlayerCameraInformation.ViewVector.Vector.X;
            lookAtPosition.PositionY += playerInformation.PlayerCameraInformation.ViewVector.Vector.Y;
            lookAtPosition.PositionZ += playerInformation.PlayerCameraInformation.ViewVector.Vector.Z;

            PlayerCamera.SetCameraPosition(playerInformation.PlayerCameraInformation.CameraPosition, lookAtPosition, playerInformation.PlayerCameraInformation.ViewVector.Vector,
                playerInformation.PlayerCameraInformation.ViewVector.DegreeXY, playerInformation.PlayerCameraInformation.ViewVector.DegreeZ);
        }

        public void ChangePosition(double x, double y, double z)
        {
           
        }

        public void RenderAnimation(Behaviour behaviour, double percent, BaseTypes.Degree degree = Degree.Degree_0, bool isMarked = false)
        {
            
        }
    }
}
