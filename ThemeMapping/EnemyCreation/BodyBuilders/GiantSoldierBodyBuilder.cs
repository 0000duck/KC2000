using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using ArtificialIntelligence.Contracts;
using ArtificialIntelligence.BodyPartShapes;
using IOInterface;
using ArtificialIntelligence;
using BaseTypes;

namespace ThemeMapping.EnemyCreation.BodyBuilders
{
    public class GiantSoldierBodyBuilder : IBodyBuilder
    {
        IDestructibleBody IBodyBuilder.CreateBody(IDestructionObserver collapseStrategy, IDestructionObserver weaponLooser, IDestructionObserver characterRemover, IDestructionObserver bloodExplosionNotifier, IExitWoundObserver exitWoundObserver, double collapseTime, double collapseTimeWithoutLegs, IDucker ducker)
        {
            IHipHeightProvider hipHeightProvider = new HipHeightProvider(ducker, 1.5, 0.8);
            List<IDestructibleBodyPart> bodyParts = new List<IDestructibleBodyPart>();

            Dictionary<MainBodyStatus, IDestructibleBodyPart> destroyedBodies = new Dictionary<MainBodyStatus, IDestructibleBodyPart>();
            VulnerableBodyPart vulnerableBodyStandard = new VulnerableBodyPart(BodyPart.Corpse, 90);
            CollapsingBody standardDestroyedBody = new CollapsingBody(3.5, 1.0, 0.75, collapseTime, vulnerableBodyStandard);
            VulnerableBodyPart vulnerableBodyWithoutHead = new VulnerableBodyPart(BodyPart.Corpse, 90);
            CollapsingBody noHead = new CollapsingBody(3.0, 1.0, 0.75, collapseTime, vulnerableBodyWithoutHead);
            VulnerableBodyPart vulnerableBodyWithoutTorso = new VulnerableBodyPart(BodyPart.Corpse, 90);
            CollapsingBody noTorso = new CollapsingBody(1.1, 1.0, 0.75, collapseTime, vulnerableBodyWithoutTorso);
            VulnerableBodyPart vulnerableBodyWithoutLegs = new VulnerableBodyPart(BodyPart.Corpse, 90);
            CollapsingBody noLegs = new CollapsingBody(2.0, 1.0, 0.75, collapseTimeWithoutLegs, vulnerableBodyWithoutLegs);

            destroyedBodies.Add(MainBodyStatus.DeadlyInjured, standardDestroyedBody);
            destroyedBodies.Add(MainBodyStatus.NoHead, noHead);
            destroyedBodies.Add(MainBodyStatus.NoTorso, noTorso);
            destroyedBodies.Add(MainBodyStatus.NoLegs, noLegs);

            //head
            VulnerableBodyPart vulnerableHead = new VulnerableBodyPart(BodyPart.Head, DestructionStrength.GiantHead);
            IDestructibleBodyPart head = new CenteredHipDependentShape(0.6, 0.3, 1.4, hipHeightProvider, vulnerableHead);
            bodyParts.Add(head);
            //torso
            VulnerableBodyPart vulnerableTorso = new VulnerableBodyPart(BodyPart.Torso, DestructionStrength.GiantTorso);
            IDestructibleBodyPart torso = new CenteredHipDependentShape(1.4, 0.7, 0.0, hipHeightProvider, vulnerableTorso);
            bodyParts.Add(torso);
            //legs
            VulnerableBodyPart vulnerableLegs = new VulnerableBodyPart(BodyPart.Legs, DestructionStrength.GiantLegs);
            IDestructibleBodyPart legs = new HipDependentShape(0.5, hipHeightProvider, vulnerableLegs);
            bodyParts.Add(legs);

            IDestructibleBody destructibleBody = new DestructibleBody(bodyParts, destroyedBodies);

            ((IDestructionNotifier)vulnerableHead).AddDestructionObserver((IDestructionObserver)destructibleBody);
            ((IDestructionNotifier)vulnerableTorso).AddDestructionObserver((IDestructionObserver)destructibleBody);
            ((IDestructionNotifier)vulnerableLegs).AddDestructionObserver((IDestructionObserver)destructibleBody);

            ((IDestructionNotifier)vulnerableHead).AddDestructionObserver(bloodExplosionNotifier);
            ((IDestructionNotifier)vulnerableTorso).AddDestructionObserver(bloodExplosionNotifier);
            ((IDestructionNotifier)vulnerableLegs).AddDestructionObserver(bloodExplosionNotifier);

            //exit wound
            ((IDestructionNotifier)vulnerableHead).AddExitWoundObserver(exitWoundObserver);
            ((IDestructionNotifier)vulnerableTorso).AddExitWoundObserver(exitWoundObserver);
            ((IDestructionNotifier)vulnerableLegs).AddExitWoundObserver(exitWoundObserver);

            ((IDestructionNotifier)vulnerableBodyStandard).AddExitWoundObserver(exitWoundObserver);
            ((IDestructionNotifier)vulnerableBodyWithoutHead).AddExitWoundObserver(exitWoundObserver);
            ((IDestructionNotifier)vulnerableBodyWithoutTorso).AddExitWoundObserver(exitWoundObserver);
            ((IDestructionNotifier)vulnerableBodyWithoutLegs).AddExitWoundObserver(exitWoundObserver);
            //

            ((IDestructionNotifier)vulnerableHead).AddDestructionObserver(collapseStrategy);
            ((IDestructionNotifier)vulnerableTorso).AddDestructionObserver(collapseStrategy);
            ((IDestructionNotifier)vulnerableLegs).AddDestructionObserver(collapseStrategy);

            ((IDestructionNotifier)vulnerableBodyStandard).AddDestructionObserver(characterRemover);
            ((IDestructionNotifier)vulnerableBodyWithoutHead).AddDestructionObserver(characterRemover);
            ((IDestructionNotifier)vulnerableBodyWithoutTorso).AddDestructionObserver(characterRemover);
            ((IDestructionNotifier)vulnerableBodyWithoutLegs).AddDestructionObserver(characterRemover);

            ((IDestructionNotifier)vulnerableTorso).AddDestructionObserver(weaponLooser);

            return destructibleBody;
        }
    }
}
