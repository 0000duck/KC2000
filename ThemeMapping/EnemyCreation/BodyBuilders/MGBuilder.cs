using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using ArtificialIntelligence.Contracts;
using ArtificialIntelligence.BodyPartShapes;
using ArtificialIntelligence;
using IOInterface;
using BaseTypes;

namespace ThemeMapping.EnemyCreation.BodyBuilders
{
    public class MGBuilder : IBodyBuilder
    {
        private IParticleManager _particleManager;

        public MGBuilder(IParticleManager particleManager)
        {
            _particleManager = particleManager;
        }

        IDestructibleBody IBodyBuilder.CreateBody(IDestructionObserver collapseStrategy, IDestructionObserver weaponLooser, IDestructionObserver characterRemover, IDestructionObserver bloodExplosionNotifier, IExitWoundObserver exitWoundObserver, double collapseTime, double collapseTimeWithoutLegs, IDucker ducker)
        {
            List<IDestructibleBodyPart> bodyParts = new List<IDestructibleBodyPart>();
            IHipHeightProvider hipHeightProvider = new HipHeightProvider(ducker, 0.25, 0.25);
            Dictionary<MainBodyStatus, IDestructibleBodyPart> destroyedBodies = new Dictionary<MainBodyStatus, IDestructibleBodyPart>();

            //round foot at the ceiling
            OnlyInnerDestructionBodyPart innerFoot = new OnlyInnerDestructionBodyPart(BodyPart.Head, DestructionStrength.MGPart);
            DustEmittingBodyPart vulnerableFoot = new DustEmittingBodyPart(innerFoot, _particleManager);
            IDestructibleBodyPart foot = new CenteredHipDependentShape(0.25, 0.5, 0.5, hipHeightProvider, vulnerableFoot);
            bodyParts.Add(foot);

            //connection to the mg
            OnlyInnerDestructionBodyPart innerTorso = new OnlyInnerDestructionBodyPart(BodyPart.Head, DestructionStrength.MGPart);
            DustEmittingBodyPart vulnerableConnection = new DustEmittingBodyPart(innerTorso, _particleManager);
            IDestructibleBodyPart connection = new CenteredHipDependentShape(0.25, 0.25, 0.25, hipHeightProvider, vulnerableConnection);
            bodyParts.Add(connection);

            //mg
            OnlyInnerDestructionBodyPart innerLegs = new OnlyInnerDestructionBodyPart(BodyPart.Head, DestructionStrength.MGPart);
            DustEmittingBodyPart vulnerableMg = new DustEmittingBodyPart(innerLegs, _particleManager);
            IDestructibleBodyPart mg = new DegreeBasedShape(0.35, 0.25, 0.0, Degree.Degree_0, 0.3, hipHeightProvider, vulnerableMg);
            bodyParts.Add(mg);

            IDestructibleBody destructibleBody = new DestructibleBody(bodyParts, destroyedBodies);

            ((IDestructionNotifier)innerFoot).AddDestructionObserver(characterRemover);
            ((IDestructionNotifier)innerTorso).AddDestructionObserver(characterRemover);
            ((IDestructionNotifier)innerLegs).AddDestructionObserver(characterRemover);

            return destructibleBody;
        }
    }
}
