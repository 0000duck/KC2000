using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace GameInteraction.Weapons
{
    public class ExplosionSizeMapper : IExplosionSizeMapper
    {
        private double _strengthForMiddleExplosion;
        private double _strengthForBigExplosion;

        public ExplosionSizeMapper(double strengthForMiddleExplosion, double strengthForBigExplosion)
        {
            _strengthForMiddleExplosion = strengthForMiddleExplosion;
            _strengthForBigExplosion = strengthForBigExplosion;
        }

        Animation IExplosionSizeMapper.MapSizeOfExplosion(double strength)
        {
            if (strength > _strengthForBigExplosion)
                return Animation.Explosion;

            if (strength > _strengthForMiddleExplosion)
                return Animation.ExplosionSmall;

            return Animation.Explosion;
        }
    }
}
