using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using ArtificialIntelligence.Contracts;
using IOInterface;
using GameInteractionContracts;
using BloodEffects;
using BaseTypes;
using ArtificialIntelligence;
using GameInteraction;
using Sound.Contracts;

namespace ThemeMapping.EnemyCreation.CharacterRemovers
{
    public class RobotRemoverBuilder : ICharacterRemoverBuilder
    {
        private IBloodParticleByBodyPartTriggerer _bloodParticleByBodyPartTriggerer;
        private IRandomDirectionThrower _randomDirectionThrower = new RandomDirectionThrower(5);
        private ISound _sound;

        public RobotRemoverBuilder(IBloodParticleByBodyPartTriggerer bloodParticleByBodyPartTriggerer, ISound sound)
        {
            _bloodParticleByBodyPartTriggerer = bloodParticleByBodyPartTriggerer;
            _sound = sound;
        }

        ICharacterRemover ICharacterRemoverBuilder.CreateCharacterRemover(IElementCreator elementCreator, IWorldElementProvider simpleSoldierProvider,
            IDestructibleBodyProvider destructibleBodyProvider, IEnemyDestructionObserver enemyDestructionObserver)
        {
            return new HalfCharacterRemover(simpleSoldierProvider, new SphereTriggererComposition(new SphereBloodTriggerer(elementCreator),
            new GiantBodyPartThrower(elementCreator, destructibleBodyProvider, _randomDirectionThrower, 1.5)),
            destructibleBodyProvider, new ExplosionDamageSharer(3.0), _bloodParticleByBodyPartTriggerer, enemyDestructionObserver, _sound);
        }
    }
}
