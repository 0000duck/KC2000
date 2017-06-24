using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using ArtificialIntelligence.Contracts;
using ArtificialIntelligence.BodyPartShapes;
using ArtificialIntelligence;
using ElementImplementations.CharacterImplementations;
using BaseTypes;
using IOInterface;

namespace ThemeMapping.EnemyCreation.BodyBuilders
{
    public class ShotGunSoldierBodyBuilder : IBodyBuilder
    {
        IDestructibleBody IBodyBuilder.CreateBody(IDestructionObserver collapseStrategy, IDestructionObserver weaponLooser, IDestructionObserver characterRemover, IDestructionObserver bloodExplosionNotifier, IExitWoundObserver exitWoundObserver, double collapseTime, double collapseTimeWithoutLegs, IDucker ducker)
        {
            IHipHeightProvider hipHeightProvider = new HipHeightProvider(ducker, 0.8, 0.4);
            List<IDestructibleBodyPart> bodyParts = new List<IDestructibleBodyPart>();

            Dictionary<MainBodyStatus, IDestructibleBodyPart> destroyedBodies = new Dictionary<MainBodyStatus, IDestructibleBodyPart>();
            VulnerableBodyPart vulnerableBodyStandard = new VulnerableBodyPart(BodyPart.Corpse, 50);
            CollapsingBody standardDestroyedBody = new CollapsingBody(1.8, 0.5, 0.25, collapseTime, vulnerableBodyStandard);
            VulnerableBodyPart vulnerableBodyWithoutHead = new VulnerableBodyPart(BodyPart.Corpse, 50);
            CollapsingBody noHead = new CollapsingBody(1.5, 0.5, 0.25, collapseTime, vulnerableBodyWithoutHead);
            VulnerableBodyPart vulnerableBodyWithoutTorso = new VulnerableBodyPart(BodyPart.Corpse, 50);
            CollapsingBody noTorso = new CollapsingBody(1.1, 0.5, 0.25, collapseTime, vulnerableBodyWithoutTorso);
            VulnerableBodyPart vulnerableBodyWithoutLegs = new VulnerableBodyPart(BodyPart.Corpse, 50);
            CollapsingBody noLegs = new CollapsingBody(1.0, 0.5, 0.25, collapseTimeWithoutLegs, vulnerableBodyWithoutLegs);

            destroyedBodies.Add(MainBodyStatus.DeadlyInjured, standardDestroyedBody);
            destroyedBodies.Add(MainBodyStatus.NoArms, standardDestroyedBody);
            destroyedBodies.Add(MainBodyStatus.NoHead, noHead);
            destroyedBodies.Add(MainBodyStatus.NoTorso, noTorso);
            destroyedBodies.Add(MainBodyStatus.NoLegs, noLegs);

            //head
            VulnerableBodyPart vulnerableHead = new VulnerableBodyPart(BodyPart.Head, DestructionStrength.ShotGunSoldierHead);
            IDestructibleBodyPart head = new CenteredHipDependentShape(0.3, 0.15, 0.7, hipHeightProvider, vulnerableHead);
            bodyParts.Add(head);
            //torso
            VulnerableBodyPart vulnerableTorso = new VulnerableBodyPart(BodyPart.Torso, DestructionStrength.ShotGunSoldierTorso);
            IDestructibleBodyPart torso = new CenteredHipDependentShape(0.6, 0.25, 0.0, hipHeightProvider, vulnerableTorso);
            bodyParts.Add(torso);
            //legs
            VulnerableBodyPart vulnerableLegs = new VulnerableBodyPart(BodyPart.Legs, DestructionStrength.ShotGunSoldierLegs);
            IDestructibleBodyPart legs = new HipDependentShape(0.25, hipHeightProvider, vulnerableLegs);
            bodyParts.Add(legs);
            //arms
            VulnerableBodyPart vulnerableArms = new VulnerableBodyPart(BodyPart.Arms, DestructionStrength.ShotGunSoldierArms);
            IDestructibleBodyPart arms = new DegreeBasedShape(0.3, 0.25, 0.15, Degree.Degree_0, 0.25, hipHeightProvider, vulnerableArms);
            bodyParts.Add(arms);

            IDestructibleBody destructibleBody = new DestructibleBody(bodyParts, destroyedBodies);

            ((IDestructionNotifier)vulnerableHead).AddDestructionObserver((IDestructionObserver)destructibleBody);
            ((IDestructionNotifier)vulnerableTorso).AddDestructionObserver((IDestructionObserver)destructibleBody);
            ((IDestructionNotifier)vulnerableLegs).AddDestructionObserver((IDestructionObserver)destructibleBody);
            ((IDestructionNotifier)vulnerableArms).AddDestructionObserver((IDestructionObserver)destructibleBody);
            
            ((IDestructionNotifier)vulnerableHead).AddDestructionObserver(bloodExplosionNotifier);
            ((IDestructionNotifier)vulnerableTorso).AddDestructionObserver(bloodExplosionNotifier);
            ((IDestructionNotifier)vulnerableLegs).AddDestructionObserver(bloodExplosionNotifier);
            ((IDestructionNotifier)vulnerableArms).AddDestructionObserver(bloodExplosionNotifier);

            //exit wound
            ((IDestructionNotifier)vulnerableHead).AddExitWoundObserver(exitWoundObserver);
            ((IDestructionNotifier)vulnerableTorso).AddExitWoundObserver(exitWoundObserver);
            ((IDestructionNotifier)vulnerableLegs).AddExitWoundObserver(exitWoundObserver);
            ((IDestructionNotifier)vulnerableArms).AddExitWoundObserver(exitWoundObserver);

            ((IDestructionNotifier)vulnerableBodyStandard).AddExitWoundObserver(exitWoundObserver);
            ((IDestructionNotifier)vulnerableBodyWithoutHead).AddExitWoundObserver(exitWoundObserver);
            ((IDestructionNotifier)vulnerableBodyWithoutTorso).AddExitWoundObserver(exitWoundObserver);
            ((IDestructionNotifier)vulnerableBodyWithoutLegs).AddExitWoundObserver(exitWoundObserver);
            //

            ((IDestructionNotifier)vulnerableHead).AddDestructionObserver(collapseStrategy);
            ((IDestructionNotifier)vulnerableTorso).AddDestructionObserver(collapseStrategy);
            ((IDestructionNotifier)vulnerableLegs).AddDestructionObserver(collapseStrategy);
            ((IDestructionNotifier)vulnerableArms).AddDestructionObserver(collapseStrategy);

            ((IDestructionNotifier)vulnerableBodyStandard).AddDestructionObserver(characterRemover);
            ((IDestructionNotifier)vulnerableBodyWithoutHead).AddDestructionObserver(characterRemover);
            ((IDestructionNotifier)vulnerableBodyWithoutTorso).AddDestructionObserver(characterRemover);
            ((IDestructionNotifier)vulnerableBodyWithoutLegs).AddDestructionObserver(characterRemover);

            ((IDestructionNotifier)vulnerableArms).AddDestructionObserver(weaponLooser);
            ((IDestructionNotifier)vulnerableTorso).AddDestructionObserver(weaponLooser);

            return destructibleBody;
        }
    }
}
