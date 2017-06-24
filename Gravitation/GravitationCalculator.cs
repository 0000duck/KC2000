using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace Gravity
{
    public class GravitationCalculator : IGravitationCalculator
    {
        private double _minimumGravitationHeight;
        private double _gravitationGrowthPerSecond;

        public GravitationCalculator(double minimumGravitationHeight, double gravitationGrowthPerSecond)
        {
            _minimumGravitationHeight = minimumGravitationHeight;
            _gravitationGrowthPerSecond = gravitationGrowthPerSecond;
        }

        void IGravitationCalculator.TriggerGravitation(IWorldElement element, GravitationStatus gravitationStatus)
        {
            IMovableByImpulse movableElement = element as IMovableByImpulse;

            if (movableElement == null)
                return;

            if (gravitationStatus.GravitationIsActive)
            {
                if (movableElement.CollisionProtocol.IsCollisionFloor)
                {
                    gravitationStatus.GravitationIsActive = false;
                    gravitationStatus.Speed = 0.0;
                }
                else 
                {
                    gravitationStatus.Speed += _gravitationGrowthPerSecond * TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond;
                    movableElement.AddImpulse(new Impulse{Strength = gravitationStatus.Speed + element.Weight, ImpulseDirection = Direction.FromCeilingToFloor});
                }
            }
            else
            {
                if (element.Position.PositionZ > _minimumGravitationHeight)
                {
                    gravitationStatus.GravitationIsActive = true;
                }
            }
        }
    }
}
