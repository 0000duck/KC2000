using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;

namespace BloodEffects.Contracts
{
    public interface IBloodAnimationSizeMapper
    {
        Animation MapAnimation(double squareFlightDistance);
    }
}
