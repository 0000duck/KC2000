using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace FrameworkContracts
{
    public interface IPlayerCameraConnection
    {
        void SetCameraPosition(Position3D cameraPosition, Position3D lookAtPosition, Vector3D viewVector, double degreeXRotation, double degreeYRotation);
    }
}
