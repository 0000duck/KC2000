using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;

namespace ElementImplementations.CharacterImplementations.DTOs
{
    public class CameraParameters : ICameraParameters
    {
        public Position3D CameraPosition { set; get; }

        public VectorWithDegree ViewVector { set; get; }
    }
}
