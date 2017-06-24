using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence
{
    public class ExplosionDamageSharer : IExplosionDamageSharer
    {
        private double _factor;

        public ExplosionDamageSharer(double factor = 1.0)
        {
            _factor = factor;
        }

        void IExplosionDamageSharer.ShareDamage(Position3D explosionPosition, double destructionStrength, IList<IWorldElement> bodyParts)
        {
            if(!bodyParts.Any())
                return;

            destructionStrength /= bodyParts.Count;
            Vector3D vector = MathHelper.CreateVector3D(explosionPosition, bodyParts.First().Position);

            foreach(IWorldElement element in bodyParts)
            {
                if (element is IVulnerable)
                {
                    ((IVulnerable)element).YouGotHit(element.Position, destructionStrength * _factor, vector);
                }
            } 
        }
    }
}
