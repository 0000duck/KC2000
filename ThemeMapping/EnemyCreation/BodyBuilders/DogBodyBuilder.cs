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
    public class DogBodyBuilder : IBodyBuilder
    {
        IDestructibleBody IBodyBuilder.CreateBody(IDestructionObserver collapseStrategy, IDestructionObserver weaponLooser, IDestructionObserver characterRemover, IDestructionObserver bloodExplosionNotifier, IExitWoundObserver exitWoundObserver, double collapseTime, double collapseTimeWithoutLegs, IDucker ducker)
        {
            List<IDestructibleBodyPart> bodyParts = new List<IDestructibleBodyPart>();
            IHipHeightProvider hipHeightProvider = new HipHeightProvider(ducker, 0.6, 0.6);
            Dictionary<MainBodyStatus, IDestructibleBodyPart> destroyedBodies = new Dictionary<MainBodyStatus, IDestructibleBodyPart>();
            VulnerableBodyPart vulnerableBodyStandard = new VulnerableBodyPart(BodyPart.Corpse, 50);
            CollapsingBody standardDestroyedBody = new CollapsingBody(0.6, 0.4, 0.25, collapseTime, vulnerableBodyStandard);
            VulnerableBodyPart vulnerableBodyWithoutHead = new VulnerableBodyPart(BodyPart.Corpse, 50);
            CollapsingBody noHead = new CollapsingBody(0.4, 0.3, 0.25, collapseTime, vulnerableBodyWithoutHead);

            destroyedBodies.Add(MainBodyStatus.DeadlyInjured, standardDestroyedBody);
            destroyedBodies.Add(MainBodyStatus.NoHead, noHead);

            //head
            VulnerableBodyPart vulnerableHead = new VulnerableBodyPart(BodyPart.Head, DestructionStrength.DogHead);
            IDestructibleBodyPart head = new DegreeBasedShape(0.2, 0.1, -0.15,Degree.Degree_0,0.4, hipHeightProvider, vulnerableHead);
            bodyParts.Add(head);

            //legs
            OnlyInnerDestructionBodyPart vulnerableLegs = new OnlyInnerDestructionBodyPart(BodyPart.Legs, DestructionStrength.DogLegs);
            IDestructibleBodyPart legs = new HipDependentShape(0.4, hipHeightProvider, vulnerableLegs);
            bodyParts.Add(legs);

            IDestructibleBody destructibleBody = new DestructibleBody(bodyParts, destroyedBodies);

            ((IDestructionNotifier)vulnerableHead).AddDestructionObserver((IDestructionObserver)destructibleBody);
            ((IDestructionNotifier)vulnerableLegs).AddDestructionObserver((IDestructionObserver)destructibleBody);


            ((IDestructionNotifier)vulnerableHead).AddDestructionObserver(bloodExplosionNotifier);
            ((IDestructionNotifier)vulnerableLegs).AddDestructionObserver(bloodExplosionNotifier);

            ((IDestructionNotifier)vulnerableHead).AddExitWoundObserver(exitWoundObserver);
            ((IDestructionNotifier)vulnerableLegs).AddExitWoundObserver(exitWoundObserver);

            ((IDestructionNotifier)vulnerableBodyStandard).AddExitWoundObserver(exitWoundObserver);
            ((IDestructionNotifier)vulnerableBodyWithoutHead).AddExitWoundObserver(exitWoundObserver);

            ((IDestructionNotifier)vulnerableHead).AddDestructionObserver(collapseStrategy);
            ((IDestructionNotifier)vulnerableLegs).AddDestructionObserver(collapseStrategy);

            ((IDestructionNotifier)vulnerableBodyStandard).AddDestructionObserver(characterRemover);
            ((IDestructionNotifier)vulnerableBodyWithoutHead).AddDestructionObserver(characterRemover);

            return destructibleBody;
        }
    }
}
