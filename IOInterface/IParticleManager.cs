using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace IOInterface
{
    public interface IParticleManager
    {
        void StartNewParticleAnimation(Position3D position, Animation animation);
    }
}
