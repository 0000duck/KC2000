using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace IOInterface
{
    public interface ICameraParameters
    {
        Position3D CameraPosition { set; get; }

        VectorWithDegree ViewVector { set; get; }
    }
}
