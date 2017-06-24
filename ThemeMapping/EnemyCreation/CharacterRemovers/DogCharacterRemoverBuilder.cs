using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using IOInterface;
using GameInteractionContracts;
using BaseTypes;
using ArtificialIntelligence.Contracts;
using ArtificialIntelligence;
using GameInteraction;
using BloodEffects;

namespace ThemeMapping.EnemyCreation.CharacterRemovers
{
    public class DogCharacterRemoverBuilder : ICharacterRemoverBuilder
    {
        private IBloodParticleByBodyPartTriggerer _bloodParticleByBodyPartTriggerer;
        private IRandomDirectionThrower _randomDirectionThrower = new RandomDirectionThrower(5);

        public DogCharacterRemoverBuilder(IBloodParticleByBodyPartTriggerer bloodParticleByBodyPartTriggerer)
        {
            _bloodParticleByBodyPartTriggerer = bloodParticleByBodyPartTriggerer;
        }

        ICharacterRemover ICharacterRemoverBuilder.CreateCharacterRemover(IElementCreator elementCreator, IWorldElementProvider simpleSoldierProvider,
            IDestructibleBodyProvider destructibleBodyProvider, IEnemyDestructionObserver enemyDestructionObserver)
        {
            CharacterRemover characterRemover = new CharacterRemover(elementCreator, simpleSoldierProvider, new SphereTriggererComposition(new SphereBloodTriggerer(elementCreator),
            new DogBodyPartThrower(elementCreator, destructibleBodyProvider, _randomDirectionThrower, 0.15)),
            destructibleBodyProvider, new ExplosionDamageSharer(), DestructionStrength.DogExplosionResistibility, _bloodParticleByBodyPartTriggerer, enemyDestructionObserver);
            return characterRemover;
        }
    }
}
