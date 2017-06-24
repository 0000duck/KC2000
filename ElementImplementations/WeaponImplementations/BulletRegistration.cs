using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using BaseContracts;
using IOInterface;
using EnvironmentAnalysis.RayTest.Rays;
using CollisionDetection.Elements;
using ArtificialIntelligence.Contracts;

namespace ElementImplementations.WeaponImplementations
{
    public class BulletRegistration : IDestructionRegistration, IExecuteble
    {
        class FlyingBullet
        {
            public CollisionRay Bullet { set; get; }

            public double DestructionStrength { set; get; }

            public bool IsFinished { get; set; }

            public Vector3D DirectionVector { get; set; }

            public double? ReductionStrength { get; set; }

            public double LastCalculationTimeStamp { get; set; }
        }

        private List<FlyingBullet> _flyingBullets;
        private double _calculationBreak;


        public BulletRegistration(double calculationBreak)
        {
            _flyingBullets = new List<FlyingBullet>();
            _calculationBreak = calculationBreak;
        }

        void IDestructionRegistration.AddNewDestruction(Position3D position, Vector3D directionVectorUnitLength, double destructionStrength, IListProvider<IWorldElement> listProvider, double? strengthReduction)
        {
            if (VectorIsVertical(directionVectorUnitLength))
                return;

            CollisionRay bullet = CollisionRayFactory.GenerateRay(position, directionVectorUnitLength, TestingPurpose.SingleRay, TestQuality.Low, listProvider, maxRayDistance: 60);
            _flyingBullets.Add(new FlyingBullet 
            { 
                Bullet = bullet, 
                DestructionStrength = destructionStrength, 
                DirectionVector = directionVectorUnitLength, 
                ReductionStrength = strengthReduction
            });    
        }

        private bool VectorIsVertical(Vector3D directionVectorUnitLength)
        {
            double x = Math.Abs(directionVectorUnitLength.X);
            double y = Math.Abs(directionVectorUnitLength.Y);
            double z = Math.Abs(directionVectorUnitLength.Z);

            return z > x * 2 && z > y * 2;
        }

        void IExecuteble.ExecuteLogic()
        {
            foreach (FlyingBullet flyingBullet in _flyingBullets)
            {
                if (TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - flyingBullet.LastCalculationTimeStamp < _calculationBreak)
                    continue;

                flyingBullet.LastCalculationTimeStamp = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;

                flyingBullet.Bullet.CalculateNextSegment();

                if (flyingBullet.ReductionStrength.HasValue)
                {
                    flyingBullet.DestructionStrength -= flyingBullet.ReductionStrength.Value;
                    if (flyingBullet.DestructionStrength < 0)
                    {
                        flyingBullet.IsFinished = true;
                        continue;
                    }
                }
                if (flyingBullet.Bullet.TestIsFinished())
                {
                    InterpretResults(flyingBullet.Bullet.GetCollisionResults(), flyingBullet);
                    flyingBullet.IsFinished = true;
                }
            }
            _flyingBullets.RemoveAll(x => x.IsFinished);
        }

        private void InterpretResults(List<CollisionCacheTestResult> resultList, FlyingBullet flyingBullet)
        {
            foreach (CollisionCacheTestResult collisionResult in resultList)
            {
                if (collisionResult.CollidedElement != null)
                {
                    if (collisionResult.CollidedElement is IVulnerable)
                        ((IVulnerable)collisionResult.CollidedElement).YouGotHit(
                        collisionResult.OuterPositionOfCollision, flyingBullet.DestructionStrength / resultList.Count,
                        flyingBullet.DirectionVector);
                }
            }
        }
    }
}
