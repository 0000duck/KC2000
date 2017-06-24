using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;

namespace ElementImplementations.CharacterImplementations.DTOs
{
    public class PlayerInformation : IPlayerInformation
    {
        public ICameraParameters PlayerCameraInformation { get; set; }
    }
}
