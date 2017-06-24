using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sound.Contracts;
using IOInterface.Events;

namespace FrameworkContracts
{
    public interface IEventToSoundMapper
    {
        ISound GetSound(GameEvent gameEvent);
    }
}
