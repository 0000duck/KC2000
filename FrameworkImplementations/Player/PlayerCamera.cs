using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using Sound.Contracts;

namespace FrameworkImplementations.Player
{
    public class PlayerCamera : IPlayerCameraConnection, IPlayerCamera
    {
        private double DegreeYRotation { set; get; }

        public Position3D LookAtPosition { set; get; }
        public Position3D CameraPosition { private set; get; }
        public Degree CameraPerspective { private set; get; }
        public double DegreeXRotation { private set; get; }

        private IEar _ear;
 
        public PlayerCamera(IEar ear)
        {
            _ear = ear;
            CameraPosition = new Position3D();
            LookAtPosition = new Position3D();
        }

        void IPlayerCameraConnection.SetCameraPosition(Position3D cameraPosition, Position3D lookAtPosition, Vector3D viewVector, double degreeXRotation, double degreeYRotation)
        {
            _ear.SetPosition((float)cameraPosition.PositionX, (float)cameraPosition.PositionZ, (float)cameraPosition.PositionY);

            CameraPosition.PositionX = cameraPosition.PositionX;
            CameraPosition.PositionY = cameraPosition.PositionZ;
            CameraPosition.PositionZ = cameraPosition.PositionY;
            LookAtPosition.PositionX = lookAtPosition.PositionX;
            LookAtPosition.PositionY = lookAtPosition.PositionZ;
            LookAtPosition.PositionZ = lookAtPosition.PositionY;
            DegreeXRotation = degreeXRotation;
            DegreeYRotation = degreeYRotation;
            CameraPerspective = VectorToDegreeConverter.Convert(BaseTypes.MathHelper.ConvertDegreeToVector(DegreeXRotation));
        }
    }
}
