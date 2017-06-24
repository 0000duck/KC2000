using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteraction.BaseImplementations;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using IOInterface;

namespace ElementImplementations
{
    public class BreakableWall : AnimatibleElement, IVulnerable, IExplosionVulnerable
    {
        private double _strength;
        private double _opacityStrength;
        private double _destruction;

        public BreakableWall(double strength, double opacityStrength)
        {
            _strength = strength;
            _opacityStrength = opacityStrength;
        }

        void IVulnerable.YouGotHit(Position3D position, double destructionStrength, Vector3D directionVector)
        {
            InterpretDestruction(destructionStrength);
        }

        void IExplosionVulnerable.YouGotHit(Position3D explosionPosition, double destructionStrength)
        {
            InterpretDestruction(destructionStrength);
        }

        private void InterpretDestruction(double destructionStrength)
        {
            if(_destruction >= _strength)
                return;

            _destruction += destructionStrength;

            if (_destruction >= _opacityStrength)
            {
                Remove();
            }

            AnimationPercent = _destruction / _strength;

            if (AnimationPercent > 1)
                AnimationPercent = 1.0;
        }

        private void Remove()
        {
            SetCenterPosition(Position.PositionX, Position.PositionY, Position.PositionZ - 0.001);
            SetPhysicalAppearance(Shape, 0, 0.0005, 0.0005, 0.0005);
        }
    }
}
