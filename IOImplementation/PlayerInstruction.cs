using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace IOImplementation
{
    public class PlayerInstruction : IPlayerInstruction
    {
        public double ViewXChange { set; get; }

        public double ViewYChange { set; get; }

        public bool WalkForward { set; get; }

        public bool WalkRight { set; get; }

        public bool WalkLeft { set; get; }

        public bool WalkBackward { set; get; }

        public bool FiredPressed { set; get; }

        public bool NextWeapon { set; get; }

        public bool PreviousWeapon { set; get; }

        public bool Duck { set; get; }

        public bool OpenDoor { set; get; }

        public bool Save { set; get; }

        public int? Number { set; get; }
    }
}
