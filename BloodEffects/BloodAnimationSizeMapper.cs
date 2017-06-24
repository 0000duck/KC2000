using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BloodEffects.Contracts;
using IOInterface;
using BaseTypes;

namespace BloodEffects
{
    public class BloodAnimationSizeMapper : IBloodAnimationSizeMapper
    {
        List<Tuple<double, Animation>> _descendingSortedAnimationPerSquareDistance;

        public BloodAnimationSizeMapper(List<Tuple<double, Animation>>  descendingSortedAnimationPerSquareDistance)
        {
            _descendingSortedAnimationPerSquareDistance = descendingSortedAnimationPerSquareDistance;
        }

        Animation IBloodAnimationSizeMapper.MapAnimation(double squareFlightDistance)
        {
 	        foreach(Tuple<double, Animation> squareDistance in _descendingSortedAnimationPerSquareDistance)
            {
                if(squareDistance.Item1 < squareFlightDistance)
                    return squareDistance.Item2;
            }

            return Animation.BloodSmall1;
        }
    }
}
