using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using IOInterface;
using ArtificialIntelligence.Contracts;
using ArtificialIntelligence;
using ArtificialIntelligence.BodyPartShapes;
using BaseTypes;

namespace ThemeMapping.EnemyCreation.BodyBuilders
{
    public class TankBuilder : IBodyBuilder
    {
        private IExplosionManager _explosionManager;
        private IParticleManager _particleManager;

        public TankBuilder(IExplosionManager explosionManager, IParticleManager particleManager)
        {
            _explosionManager = explosionManager;
            _particleManager = particleManager;
        }

        IDestructibleBody IBodyBuilder.CreateBody(IDestructionObserver collapseStrategy, IDestructionObserver weaponLooser, IDestructionObserver characterRemover, IDestructionObserver bloodExplosionNotifier, IExitWoundObserver exitWoundObserver, double collapseTime, double collapseTimeWithoutLegs, IDucker ducker)
        {
            IHipHeightProvider hipHeightProvider = new HipHeightProvider(ducker, 1.4, 1.4);
            List<IDestructibleBodyPart> bodyParts = new List<IDestructibleBodyPart>();

            Dictionary<MainBodyStatus, IDestructibleBodyPart> destroyedBodies = new Dictionary<MainBodyStatus, IDestructibleBodyPart>();

            //head
            DustEmittingBodyPart vulnerableHead = new DustEmittingBodyPart(new ExplosiveBodyPart(_explosionManager, DestructionStrength.TankHead, DestructionStrength.GiantSelfExplosion, 3), _particleManager, Animation.SmallBodyExplosion);
            IDestructibleBodyPart head = new CenteredHipDependentShape(0.7, 0.4, 1.2, hipHeightProvider, vulnerableHead);
            bodyParts.Add(head);
            //torso
            DustEmittingBodyPart vulnerableTorso = new DustEmittingBodyPart(new ExplosiveBodyPart(_explosionManager, DestructionStrength.TankTorso, DestructionStrength.GiantSelfExplosion, 3), _particleManager);
            IDestructibleBodyPart torso = new CenteredHipDependentShape(1.2, 1.3, 0, hipHeightProvider, vulnerableTorso);
            bodyParts.Add(torso);
            //legs
            DustEmittingBodyPart vulnerableTank = new DustEmittingBodyPart(new ExplosiveBodyPart(_explosionManager, DestructionStrength.TankLegs, DestructionStrength.GiantSelfExplosion, 3), _particleManager);
            IDestructibleBodyPart tank = new HipDependentShape(1.4, hipHeightProvider, vulnerableTank);
            bodyParts.Add(tank);

            IDestructibleBody destructibleBody = new DestructibleBody(bodyParts, destroyedBodies);

            return destructibleBody;
        }
    }
}
