using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;

namespace FrameworkContracts
{
    public interface IParticle : IDrawable
    {
        bool IsFinished();

        void Start(Position3D position);
    }
}
