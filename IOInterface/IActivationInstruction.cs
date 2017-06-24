using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOInterface
{
    public interface IActivationInstruction
    {
        bool OpenDoor { set; get; }

        bool Save { set; get; }
    }
}
