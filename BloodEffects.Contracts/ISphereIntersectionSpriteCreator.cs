using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using FrameworkContracts;

namespace BloodEffects.Contracts
{
    public interface ISphereIntersectionSpriteCreator
    {
        List<IDrawable> CreateSprite(IWorldElement intersectedElement, Position3D centerOfSphere, double radius);
    }
}
