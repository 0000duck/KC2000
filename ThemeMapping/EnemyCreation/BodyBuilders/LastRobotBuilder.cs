using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using ArtificialIntelligence.Contracts;
using ArtificialIntelligence;
using ArtificialIntelligence.BodyPartShapes;
using IOInterface;

namespace ThemeMapping.EnemyCreation.BodyBuilders
{
    public class LastRobotBuilder : IBodyBuilder
    {
        private IParticleManager _particleManager;

        public LastRobotBuilder(IParticleManager particleManager)
        {
            _particleManager = particleManager;
        }

        IDestructibleBody IBodyBuilder.CreateBody(IDestructionObserver collapseStrategy, IDestructionObserver weaponLooser, IDestructionObserver characterRemover, IDestructionObserver bloodExplosionNotifier, IExitWoundObserver exitWoundObserver, double collapseTime, double collapseTimeWithoutLegs, IDucker ducker)
        {
            IHipHeightProvider hipHeightProvider = new HipHeightProvider(ducker, 1.9, 1.9);
            List<IDestructibleBodyPart> bodyParts = new List<IDestructibleBodyPart>();

            Dictionary<MainBodyStatus, IDestructibleBodyPart> destroyedBodies = new Dictionary<MainBodyStatus, IDestructibleBodyPart>();

            DustEmittingBodyPart deadLegs = new DustEmittingBodyPart(new OnlyInnerDestructionBodyPart(BodyPart.Corpse, DestructionStrength.RobotLegs), _particleManager);
            CollapsingBody standardDestroyedBody = new CollapsingBody(3.9, 2.2, 0.55, collapseTime, deadLegs);
           
            destroyedBodies.Add(MainBodyStatus.DeadlyInjured, standardDestroyedBody);

            //head
            OnlyInnerDestructionBodyPart vulnerableHead = new OnlyInnerDestructionBodyPart(BodyPart.Head, DestructionStrength.LastRobotHead);
            IDestructibleBodyPart head = new CenteredHipDependentShape(0.6, 0.3, 1.1, hipHeightProvider, vulnerableHead);
            bodyParts.Add(head);
            //torso
            OnlyInnerDestructionBodyPart vulnerableTorso = new OnlyInnerDestructionBodyPart(BodyPart.Torso, DestructionStrength.LastRobotTorso);
            DustEmittingBodyPart dustEmittingTorso = new DustEmittingBodyPart(vulnerableTorso, _particleManager);
            IDestructibleBodyPart torso = new CenteredHipDependentShape(1.1, 1.4, 0.0, hipHeightProvider, dustEmittingTorso);
            bodyParts.Add(torso);
            //legs
            OnlyInnerDestructionBodyPart vulnerableLegs = new OnlyInnerDestructionBodyPart(BodyPart.Legs, DestructionStrength.LastRobotLegs);
            DustEmittingBodyPart metalLegs = new DustEmittingBodyPart(vulnerableLegs, _particleManager);
            IDestructibleBodyPart legs = new HipDependentShape(0.75, hipHeightProvider, metalLegs);
            bodyParts.Add(legs);

            IDestructibleBody destructibleBody = new DestructibleBody(bodyParts, destroyedBodies);

            ((IDestructionNotifier)vulnerableHead).AddDestructionObserver((IDestructionObserver)destructibleBody);
            ((IDestructionNotifier)vulnerableTorso).AddDestructionObserver((IDestructionObserver)destructibleBody);
            ((IDestructionNotifier)vulnerableLegs).AddDestructionObserver((IDestructionObserver)destructibleBody);

            //exit wound
            ((IDestructionNotifier)vulnerableHead).AddExitWoundObserver(exitWoundObserver);
            ((IDestructionNotifier)vulnerableTorso).AddExitWoundObserver(exitWoundObserver);
            //

            ((IDestructionNotifier)vulnerableHead).AddDestructionObserver(characterRemover);
            ((IDestructionNotifier)vulnerableTorso).AddDestructionObserver(characterRemover);
            ((IDestructionNotifier)vulnerableLegs).AddDestructionObserver(characterRemover);

            ((IDestructionNotifier)vulnerableHead).AddDestructionObserver(collapseStrategy);
            ((IDestructionNotifier)vulnerableTorso).AddDestructionObserver(collapseStrategy);
            ((IDestructionNotifier)vulnerableLegs).AddDestructionObserver(collapseStrategy);

            return destructibleBody;
        }
    }
}
