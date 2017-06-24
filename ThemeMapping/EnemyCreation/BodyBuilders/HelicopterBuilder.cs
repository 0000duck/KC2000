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
    public class HelicopterBuilder : IBodyBuilder
    {
        private IDestructionObserver _deathStrategy;
        private IParticleManager _particleManager;

        public HelicopterBuilder(IDestructionObserver deathStrategy, IParticleManager particleManager)
        {
            _deathStrategy = deathStrategy;
            _particleManager = particleManager;
        }

        IDestructibleBody IBodyBuilder.CreateBody(IDestructionObserver collapseStrategy, IDestructionObserver weaponLooser, IDestructionObserver characterRemover, IDestructionObserver bloodExplosionNotifier, IExitWoundObserver exitWoundObserver, double collapseTime, double collapseTimeWithoutLegs, IDucker ducker)
        {
            IHipHeightProvider hipHeightProvider = new HipHeightProvider(ducker, 0.2, 0.2);
            List<IDestructibleBodyPart> bodyParts = new List<IDestructibleBodyPart>();

            Dictionary<MainBodyStatus, IDestructibleBodyPart> destroyedBodies = new Dictionary<MainBodyStatus, IDestructibleBodyPart>();

            //inner main part
            OnlyInnerDestructionBodyPart innerDestructionPart = new OnlyInnerDestructionBodyPart(BodyPart.Torso, DestructionStrength.HeliTorso);
            DustEmittingBodyPart innerPart = new DustEmittingBodyPart(innerDestructionPart, _particleManager);
            IDestructibleBodyPart mainPart = new DegreeBasedShape(3.2, 1.8, 0.0, Degree.Degree_0, 1, hipHeightProvider, innerPart);
            bodyParts.Add(mainPart);

            //rotor
            OnlyInnerDestructionBodyPart rotorDestructionPart = new OnlyInnerDestructionBodyPart(BodyPart.Head, DestructionStrength.HeliHead);
            DustEmittingBodyPart rotor = new DustEmittingBodyPart(rotorDestructionPart, _particleManager);
            IDestructibleBodyPart rotorPart = new DegreeBasedShape(0.5, 2.5, 3.3, Degree.Degree_0, 1, hipHeightProvider, rotor);
            bodyParts.Add(rotorPart);

            //backrotor
            OnlyInnerDestructionBodyPart backrotorDestructionPart = new OnlyInnerDestructionBodyPart(BodyPart.Arms, DestructionStrength.HeliArms);
            DustEmittingBodyPart backrotor = new DustEmittingBodyPart(backrotorDestructionPart, _particleManager);
            IDestructibleBodyPart backrotorPart = new DegreeBasedShape(2, 1, 1.5, Degree.Degree_180, 1.75, hipHeightProvider, backrotor);
            bodyParts.Add(backrotorPart);


            IDestructibleBody destructibleBody = new DestructibleBody(bodyParts, destroyedBodies);

            ((IDestructionNotifier)innerDestructionPart).AddDestructionObserver(_deathStrategy);
            ((IDestructionNotifier)rotorDestructionPart).AddDestructionObserver(_deathStrategy);
            ((IDestructionNotifier)backrotorDestructionPart).AddDestructionObserver(_deathStrategy);

            return destructibleBody;
        }
    }
}
