using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using GameInteractionContracts;

namespace BloodEffects
{
    public class RandomDirectionThrower : IRandomDirectionThrower
    {
        private double _speed;
        private int _degreeAdder;

        public RandomDirectionThrower(double speed)
        {
            _speed = speed;
        }

        private Degree GetRandomDegree()
        {
            _degreeAdder += (int)MathHelper.GetRandomValueInARange(3, false);

            if (_degreeAdder > (int)Degree.Degree_315)
                _degreeAdder = 1;

            return (Degree)_degreeAdder;
        }

        void IRandomDirectionThrower.ThrowElement(IWorldElement worldElement)
        {
            IFlyingBlood flyingBlood = worldElement as IFlyingBlood;

            Vector2D vector = vector = VectorCreator.CreateVector(1, GetRandomDegree());
            Vector3D directionVector = new Vector3D { X = vector.X, Y = vector.Y, Z = 0.3 };

            flyingBlood.StartFlight(directionVector, _speed + worldElement.Weight, 0);
        }
    }
}
