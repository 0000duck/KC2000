using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace SaveGames
{
    public interface ILevelStateGrabber
    {
        List<IElement> GetStateOfAllElements();
    }
}

