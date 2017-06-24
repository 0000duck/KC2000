using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOInterface
{
    public interface IPlayerInstruction : IWeaponInstructions, IActivationInstruction
    {
        double ViewXChange { set; get; }

        double ViewYChange { set; get; }

        bool WalkForward { set; get; }

        bool WalkRight { set; get; }

        bool WalkLeft { set; get; }

        bool WalkBackward { set; get; }

        bool Duck { set; get; }
    }
}
