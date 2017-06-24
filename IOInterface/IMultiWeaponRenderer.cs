using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace IOInterface
{
    public interface IMultiWeaponRenderer
    {
        void Render(ElementTheme weaponTheme, Behaviour behaviour, double percent);
    }
}
