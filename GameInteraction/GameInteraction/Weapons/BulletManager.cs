using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvironmentAnalysis.RayTest.Rays;
using CollisionDetection.Elements;
using GameInteraction.BaseImplementations;
using BaseTypes;
using CollisionDetection;
using IOInterface;
using GameInteractionContracts;
using BaseContracts;
using ArtificialIntelligence.Contracts;

namespace GameInteraction.Weapons
{
    public class BulletManager : IBulletManager, IExecuteble
    {
        internal class FlyingBullet
        {
            public CollisionRay Bullet { set; get; }

            public double DestructionStrength { set; get; }

            public bool IsFinished { get; set; }

            public VectorWithDegree DirectionVector { get; set; }
        }

        private List<FlyingBullet> FlyingBullets { set; get; } 
        private IParticleManager ParticleManager { set; get; }

        public BulletManager(IParticleManager particleManager)
        {
            ParticleManager = particleManager;
            FlyingBullets = new List<FlyingBullet>();
        }

        public void AddNewBullet(Position3D position, IWorldElement excludebleSource, VectorWithDegree directionVector, bool upsplittingAmmo, double destructionStrength, TestQuality testQuality, IListProvider<IWorldElement> listProvider)
        {
            TestingPurpose purpose;
            if (upsplittingAmmo)
                purpose = TestingPurpose.UpsplittingRay;
            else
                purpose = TestingPurpose.SingleRay;

            CollisionRay bullet = CollisionRayFactory.GenerateRay(position, directionVector, purpose, testQuality, listProvider, excludebleSource);
            FlyingBullets.Add(new FlyingBullet { Bullet = bullet, DestructionStrength = destructionStrength, DirectionVector = directionVector });
        }

        private void InterpretResults(List<CollisionCacheTestResult> resultList, FlyingBullet flyingBullet)
        {
            List<CollisionCacheTestResult> filteredList = FilterDuplicates(resultList);

            foreach (CollisionCacheTestResult collisionResult in filteredList)
            {
                if (collisionResult.CollidedElement != null)
                {
                    if (collisionResult.CollidedElement is IVulnerable)
                        ((IVulnerable)collisionResult.CollidedElement).YouGotHit(
                        collisionResult.OuterPositionOfCollision, flyingBullet.DestructionStrength / filteredList.Count, 
                        flyingBullet.DirectionVector.Vector);
                    else
                        ParticleManager.StartNewParticleAnimation(collisionResult.OuterPositionOfCollision, Animation.Dust);
                }
            }
        }

        private List<CollisionCacheTestResult> FilterDuplicates(List<CollisionCacheTestResult> resultList)
        {
            if (resultList.Count < 2)
                return resultList;

            List<CollisionCacheTestResult> filteredList = new List<CollisionCacheTestResult>();

            foreach (CollisionCacheTestResult collisionResult in resultList)
            {
                if (filteredList.Any(x => x.CollidedElement == collisionResult.CollidedElement))
                {
                    if (collisionResult.CollidedElement.Shape == Shape.Circle)   
                        continue;
                }
                    
                filteredList.Add(collisionResult);
            }
            return filteredList;
        }

        void IExecuteble.ExecuteLogic()
        {
            TestCollisionOfAllBullets();
            TestCollisionOfAllBullets();
        }

        private void TestCollisionOfAllBullets()
        {
            foreach (FlyingBullet flyingBullet in FlyingBullets)
            {
                flyingBullet.Bullet.CalculateNextSegment();
                if (flyingBullet.Bullet.TestIsFinished())
                {
                    InterpretResults(flyingBullet.Bullet.GetCollisionResults(), flyingBullet);
                    flyingBullet.IsFinished = true;
                }
            }
            FlyingBullets.RemoveAll(x => x.IsFinished);
        }
    }
}
