using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace FrameworkContracts
{
    public interface IPlayerCamera
    {
        Position3D CameraPosition { get; }
        Position3D LookAtPosition { get; }
        double DegreeXRotation { get; }
        Degree CameraPerspective { get; }
    }
}
