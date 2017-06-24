using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using BaseContracts;

namespace IOInterface
{
    public interface IExplosionManager
    {
        void StartNewExplosion(IWorldElement explodingElement, Position3D position, double destructionStrength, double squareRadius);
    }
}
