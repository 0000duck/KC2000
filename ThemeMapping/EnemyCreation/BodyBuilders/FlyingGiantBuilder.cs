using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using ArtificialIntelligence.Contracts;
using ArtificialIntelligence;
using ArtificialIntelligence.BodyPartShapes;
using IOInterface;
using BaseTypes;

namespace ThemeMapping.EnemyCreation.BodyBuilders
{
    public class FlyingGiantBuilder : IBodyBuilder
    {
        private IExplosionManager _explosionManager;
        private IParticleManager _particleManager;

        public FlyingGiantBuilder(IExplosionManager explosionManager, IParticleManager particleManager)
        {
            _explosionManager = explosionManager;
            _particleManager = particleManager;
        }

        IDestructibleBody IBodyBuilder.CreateBody(IDestructionObserver collapseStrategy, IDestructionObserver weaponLooser, IDestructionObserver characterRemover, IDestructionObserver bloodExplosionNotifier, IExitWoundObserver exitWoundObserver, double collapseTime, double collapseTimeWithoutLegs, IDucker ducker)
        {
            IHipHeightProvider hipHeightProvider = new HipHeightProvider(ducker, 1.2, 1.2);
            List<IDestructibleBodyPart> bodyParts = new List<IDestructibleBodyPart>();

            Dictionary<MainBodyStatus, IDestructibleBodyPart> destroyedBodies = new Dictionary<MainBodyStatus, IDestructibleBodyPart>();
            VulnerableBodyPart vulnerableBodyStandard = new VulnerableBodyPart(BodyPart.Corpse, 90);
            CollapsingBody standardDestroyedBody = new CollapsingBody(3.5, 3.5, 0.75, collapseTime, vulnerableBodyStandard);
            //VulnerableBodyPart vulnerableBodyWithoutHead = new VulnerableBodyPart(BodyPart.Corpse, 90);
            //CollapsingBody noHead = new CollapsingBody(3.0, 3.0, 0.75, collapseTime, vulnerableBodyWithoutHead);

            destroyedBodies.Add(MainBodyStatus.DeadlyInjured, standardDestroyedBody);
            //destroyedBodies.Add(MainBodyStatus.NoHead, noHead);

            //torso
            DustEmittingBodyPart vulnerableTorso = new DustEmittingBodyPart(new ExplosiveBodyPart(_explosionManager, DestructionStrength.FlyGiantHead, DestructionStrength.GiantSelfExplosion, 3), _particleManager, Animation.SmallBodyExplosion);
            IDestructibleBodyPart torso = new CenteredHipDependentShape(1.4, 1.3, 1, hipHeightProvider, vulnerableTorso);
            bodyParts.Add(torso);
            //legs
            DustEmittingBodyPart vulnerableTank = new DustEmittingBodyPart(new ExplosiveBodyPart(_explosionManager, DestructionStrength.FlyGiantBoard, DestructionStrength.GiantSelfExplosion, 3), _particleManager);
            IDestructibleBodyPart tank = new CenteredHipDependentShape(1, 0.7, 0, hipHeightProvider, vulnerableTank);
            bodyParts.Add(tank);

            ////head
            //OnlyInnerDestructionBodyPart vulnerableHead = new OnlyInnerDestructionBodyPart(BodyPart.Head, DestructionStrength.FlyGiantHead);
            //IDestructibleBodyPart head = new CenteredHipDependentShape(0.6, 0.3, 1.9, hipHeightProvider, vulnerableHead);
            //bodyParts.Add(head);
            ////torso
            //OnlyInnerDestructionBodyPart vulnerableTorso = new OnlyInnerDestructionBodyPart(BodyPart.Torso, DestructionStrength.FlyGiantTorso);
            //IDestructibleBodyPart torso = new CenteredHipDependentShape(1.4, 0.65, 0.6, hipHeightProvider, vulnerableTorso);
            //bodyParts.Add(torso);
            ////legs
            //DustEmittingBodyPart vulnerableBoard = new DustEmittingBodyPart(new ExplosiveBodyPart(_explosionManager, DestructionStrength.FlyGiantBoard, DestructionStrength.GiantSelfExplosion, 2), _particleManager);
            //IDestructibleBodyPart board = new CenteredHipDependentShape(0.6, 0.7, 0.0, hipHeightProvider, vulnerableBoard);
            //bodyParts.Add(board);
            ////gas
            //DustEmittingBodyPart vulnerableGas1 = new DustEmittingBodyPart(new ExplosiveBodyPart(_explosionManager, DestructionStrength.FlyGiantGas, DestructionStrength.GiantSelfExplosion, 2), _particleManager);
            //IDestructibleBodyPart gas1 = new DegreeBasedShape(1.4, 0.5, 0.7, Degree.Degree_135, 0.5, hipHeightProvider, vulnerableGas1);
            //bodyParts.Add(gas1);
            //DustEmittingBodyPart vulnerableGas2 = new DustEmittingBodyPart(new ExplosiveBodyPart(_explosionManager, DestructionStrength.FlyGiantGas, DestructionStrength.GiantSelfExplosion, 2), _particleManager);
            //IDestructibleBodyPart gas2 = new DegreeBasedShape(1.4, 0.5, 0.7, Degree.Degree_225, 0.5, hipHeightProvider, vulnerableGas2);
            //bodyParts.Add(gas2);

            IDestructibleBody destructibleBody = new DestructibleBody(bodyParts, destroyedBodies);

            //((IDestructionNotifier)vulnerableHead).AddDestructionObserver((IDestructionObserver)destructibleBody);
            //((IDestructionNotifier)vulnerableTorso).AddDestructionObserver((IDestructionObserver)destructibleBody);

            //((IDestructionNotifier)vulnerableHead).AddDestructionObserver(bloodExplosionNotifier);
            //((IDestructionNotifier)vulnerableTorso).AddDestructionObserver(bloodExplosionNotifier);

            ////exit wound
            //((IDestructionNotifier)vulnerableHead).AddExitWoundObserver(exitWoundObserver);
            //((IDestructionNotifier)vulnerableTorso).AddExitWoundObserver(exitWoundObserver);

            //((IDestructionNotifier)vulnerableBodyStandard).AddExitWoundObserver(exitWoundObserver);
            //((IDestructionNotifier)vulnerableBodyWithoutHead).AddExitWoundObserver(exitWoundObserver);
            ////

            //((IDestructionNotifier)vulnerableHead).AddDestructionObserver(collapseStrategy);
            //((IDestructionNotifier)vulnerableTorso).AddDestructionObserver(collapseStrategy);

            //((IDestructionNotifier)vulnerableBodyStandard).AddDestructionObserver(characterRemover);
            //((IDestructionNotifier)vulnerableBodyWithoutHead).AddDestructionObserver(characterRemover);

            return destructibleBody;
        }
    
        //IDestructibleBody IBodyBuilder.CreateBody(IDestructionObserver collapseStrategy, IDestructionObserver weaponLooser, IDestructionObserver characterRemover, IDestructionObserver bloodExplosionNotifier, IExitWoundObserver exitWoundObserver, double collapseTime, double collapseTimeWithoutLegs, IDucker ducker)
        //{
        //    IHipHeightProvider hipHeightProvider = new HipHeightProvider(ducker, 1.18, 0.8);
        //    List<IDestructibleBodyPart> bodyParts = new List<IDestructibleBodyPart>();

        //    Dictionary<MainBodyStatus, IDestructibleBodyPart> destroyedBodies = new Dictionary<MainBodyStatus, IDestructibleBodyPart>();
        //    VulnerableBodyPart vulnerableBodyStandard = new VulnerableBodyPart(BodyPart.Corpse, 90);
        //    CollapsingBody standardDestroyedBody = new CollapsingBody(3.5, 3.5, 0.75, collapseTime, vulnerableBodyStandard);
        //    VulnerableBodyPart vulnerableBodyWithoutHead = new VulnerableBodyPart(BodyPart.Corpse, 90);
        //    CollapsingBody noHead = new CollapsingBody(3.0, 3.0, 0.75, collapseTime, vulnerableBodyWithoutHead);

        //    destroyedBodies.Add(MainBodyStatus.DeadlyInjured, standardDestroyedBody);
        //    destroyedBodies.Add(MainBodyStatus.NoHead, noHead);

        //    //head
        //    OnlyInnerDestructionBodyPart vulnerableHead = new OnlyInnerDestructionBodyPart(BodyPart.Head, DestructionStrength.FlyGiantHead);
        //    IDestructibleBodyPart head = new CenteredHipDependentShape(0.6, 0.3, 1.9, hipHeightProvider, vulnerableHead);
        //    bodyParts.Add(head);
        //    //torso
        //    OnlyInnerDestructionBodyPart vulnerableTorso = new OnlyInnerDestructionBodyPart(BodyPart.Torso, DestructionStrength.FlyGiantTorso);
        //    IDestructibleBodyPart torso = new CenteredHipDependentShape(1.4, 0.65, 0.6, hipHeightProvider, vulnerableTorso);
        //    bodyParts.Add(torso);
        //    //legs
        //    DustEmittingBodyPart vulnerableBoard = new DustEmittingBodyPart(new ExplosiveBodyPart(_explosionManager, DestructionStrength.FlyGiantBoard, DestructionStrength.GiantSelfExplosion, 2), _particleManager);
        //    IDestructibleBodyPart board = new CenteredHipDependentShape(0.6, 0.7, 0.0, hipHeightProvider, vulnerableBoard);
        //    bodyParts.Add(board);
        //    //gas
        //    DustEmittingBodyPart vulnerableGas1 = new DustEmittingBodyPart(new ExplosiveBodyPart(_explosionManager, DestructionStrength.FlyGiantGas, DestructionStrength.GiantSelfExplosion, 2), _particleManager);
        //    IDestructibleBodyPart gas1 = new DegreeBasedShape(1.4, 0.5, 0.7, Degree.Degree_135, 0.5, hipHeightProvider, vulnerableGas1);
        //    bodyParts.Add(gas1);
        //    DustEmittingBodyPart vulnerableGas2 = new DustEmittingBodyPart(new ExplosiveBodyPart(_explosionManager, DestructionStrength.FlyGiantGas, DestructionStrength.GiantSelfExplosion, 2), _particleManager);
        //    IDestructibleBodyPart gas2 = new DegreeBasedShape(1.4, 0.5, 0.7, Degree.Degree_225, 0.5, hipHeightProvider, vulnerableGas2);
        //    bodyParts.Add(gas2);

        //    IDestructibleBody destructibleBody = new DestructibleBody(bodyParts, destroyedBodies);

        //    ((IDestructionNotifier)vulnerableHead).AddDestructionObserver((IDestructionObserver)destructibleBody);
        //    ((IDestructionNotifier)vulnerableTorso).AddDestructionObserver((IDestructionObserver)destructibleBody);

        //    ((IDestructionNotifier)vulnerableHead).AddDestructionObserver(bloodExplosionNotifier);
        //    ((IDestructionNotifier)vulnerableTorso).AddDestructionObserver(bloodExplosionNotifier);

        //    //exit wound
        //    ((IDestructionNotifier)vulnerableHead).AddExitWoundObserver(exitWoundObserver);
        //    ((IDestructionNotifier)vulnerableTorso).AddExitWoundObserver(exitWoundObserver);

        //    ((IDestructionNotifier)vulnerableBodyStandard).AddExitWoundObserver(exitWoundObserver);
        //    ((IDestructionNotifier)vulnerableBodyWithoutHead).AddExitWoundObserver(exitWoundObserver);
        //    //

        //    ((IDestructionNotifier)vulnerableHead).AddDestructionObserver(collapseStrategy);
        //    ((IDestructionNotifier)vulnerableTorso).AddDestructionObserver(collapseStrategy);

        //    ((IDestructionNotifier)vulnerableBodyStandard).AddDestructionObserver(characterRemover);
        //    ((IDestructionNotifier)vulnerableBodyWithoutHead).AddDestructionObserver(characterRemover);

        //    return destructibleBody;
        //}
    }
}
