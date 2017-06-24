using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using IOInterface;

namespace BloodEffects.Contracts
{
    public interface IBloodEffectCreator
    {
        void CreateBloodEffect(Animation bloodAnimation, Position3D position);
    }
}
