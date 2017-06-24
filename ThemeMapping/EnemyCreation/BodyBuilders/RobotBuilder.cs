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
    public class RobotBuilder : IBodyBuilder
    {
        private IParticleManager _particleManager;

        public RobotBuilder(IParticleManager particleManager)
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
            OnlyInnerDestructionBodyPart vulnerableHead = new OnlyInnerDestructionBodyPart(BodyPart.Head, DestructionStrength.RobotHead);
            IDestructibleBodyPart head = new CenteredHipDependentShape(0.6, 0.3, 1.1, hipHeightProvider, vulnerableHead);
            bodyParts.Add(head);
            //torso
            OnlyInnerDestructionBodyPart vulnerableTorso = new OnlyInnerDestructionBodyPart(BodyPart.Torso, DestructionStrength.RobotTorso);
            IDestructibleBodyPart torso = new CenteredHipDependentShape(1.1, 0.85, 0.0, hipHeightProvider, vulnerableTorso);
            bodyParts.Add(torso);
            //legs
            OnlyInnerDestructionBodyPart vulnerableLegs = new OnlyInnerDestructionBodyPart(BodyPart.Legs, DestructionStrength.RobotLegs);
            DustEmittingBodyPart metalLegs = new DustEmittingBodyPart(vulnerableLegs, _particleManager);
            IDestructibleBodyPart legs = new HipDependentShape(0.75, hipHeightProvider, metalLegs);
            bodyParts.Add(legs);
            //left arm
            OnlyInnerDestructionBodyPart vulnerableLeftArm = new OnlyInnerDestructionBodyPart(BodyPart.Arms, DestructionStrength.RobotArm);
            DustEmittingBodyPart metalLeftArm = new DustEmittingBodyPart(vulnerableLeftArm, _particleManager);
            IDestructibleBodyPart leftArm = new DegreeBasedShape(0.5, 0.5, 0.3,BaseTypes.Degree.Degree_45, 1.2, hipHeightProvider, metalLeftArm);
            bodyParts.Add(leftArm);
            //right arm
            OnlyInnerDestructionBodyPart vulnerableRightArm = new OnlyInnerDestructionBodyPart(BodyPart.Arms, DestructionStrength.RobotArm);
            DustEmittingBodyPart metalRightArm = new DustEmittingBodyPart(vulnerableRightArm, _particleManager);
            IDestructibleBodyPart rightArm = new DegreeBasedShape(0.5, 0.5, 0.3, BaseTypes.Degree.Degree_315, 1.2, hipHeightProvider, metalRightArm);
            bodyParts.Add(rightArm);

            IDestructibleBody destructibleBody = new DestructibleBody(bodyParts, destroyedBodies);

            ((IDestructionNotifier)vulnerableHead).AddDestructionObserver((IDestructionObserver)destructibleBody);
            ((IDestructionNotifier)vulnerableTorso).AddDestructionObserver((IDestructionObserver)destructibleBody);
            ((IDestructionNotifier)vulnerableLegs).AddDestructionObserver((IDestructionObserver)destructibleBody);
            ((IDestructionNotifier)vulnerableLeftArm).AddDestructionObserver((IDestructionObserver)destructibleBody);
            ((IDestructionNotifier)vulnerableRightArm).AddDestructionObserver((IDestructionObserver)destructibleBody);

            //exit wound
            ((IDestructionNotifier)vulnerableHead).AddExitWoundObserver(exitWoundObserver);
            ((IDestructionNotifier)vulnerableTorso).AddExitWoundObserver(exitWoundObserver);
            //

            ((IDestructionNotifier)vulnerableHead).AddDestructionObserver(characterRemover);
            ((IDestructionNotifier)vulnerableTorso).AddDestructionObserver(characterRemover);
            ((IDestructionNotifier)vulnerableLegs).AddDestructionObserver(characterRemover);
            ((IDestructionNotifier)vulnerableLeftArm).AddDestructionObserver(characterRemover);
            ((IDestructionNotifier)vulnerableRightArm).AddDestructionObserver(characterRemover);

            ((IDestructionNotifier)vulnerableHead).AddDestructionObserver(collapseStrategy);
            ((IDestructionNotifier)vulnerableTorso).AddDestructionObserver(collapseStrategy);
            ((IDestructionNotifier)vulnerableLegs).AddDestructionObserver(collapseStrategy);
            ((IDestructionNotifier)vulnerableLeftArm).AddDestructionObserver(collapseStrategy);
            ((IDestructionNotifier)vulnerableRightArm).AddDestructionObserver(collapseStrategy);

            return destructibleBody;
        }
    }
}
