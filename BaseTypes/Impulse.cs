using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection;
using BaseTypes;

namespace BaseTypes
{
    public class Impulse
    {
        public Direction ImpulseDirection;

        private double strength;
        public double Strength 
        {
            get { return strength; }

            set 
            {
                strength = value;
            }
        }

        public void Compensate(Impulse opposingImpulse)
        {
            if (opposingImpulse.Strength >= this.Strength)
            {
                opposingImpulse.Strength -= this.Strength;
                this.Strength = 0;
            }
            else
            {
                this.Strength -= opposingImpulse.Strength;
                opposingImpulse.Strength = 0;  
            }
        }

        internal double Substract(double strengthToSubstract)
        {
            if (Strength > strengthToSubstract)
            {
                Strength -= strengthToSubstract;
                return strengthToSubstract;
            }

            strengthToSubstract = Strength;
            Strength = 0;
            return strengthToSubstract;
        }
    }
}
