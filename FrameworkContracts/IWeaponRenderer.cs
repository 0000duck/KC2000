using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace FrameworkContracts
{
    public interface IWeaponRenderer
    {
        void Draw(Behaviour behaviour, double percent);
    }
}
