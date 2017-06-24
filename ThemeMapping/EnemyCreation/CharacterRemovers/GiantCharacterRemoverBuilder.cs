using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using IOInterface;
using GameInteractionContracts;
using BloodEffects;
using GameInteraction;
using BaseTypes;
using ArtificialIntelligence.Contracts;
using ArtificialIntelligence;

namespace ThemeMapping.EnemyCreation.CharacterRemovers
{
    public class GiantCharacterRemoverBuilder : ICharacterRemoverBuilder
    {
        private IBloodParticleByBodyPartTriggerer _bloodParticleByBodyPartTriggerer;
        private IRandomDirectionThrower _randomDirectionThrower = new RandomDirectionThrower(5);

        public GiantCharacterRemoverBuilder(IBloodParticleByBodyPartTriggerer bloodParticleByBodyPartTriggerer)
        {
            _bloodParticleByBodyPartTriggerer = bloodParticleByBodyPartTriggerer;
        }

        ICharacterRemover ICharacterRemoverBuilder.CreateCharacterRemover(IElementCreator elementCreator, IWorldElementProvider simpleSoldierProvider,
            IDestructibleBodyProvider destructibleBodyProvider, IEnemyDestructionObserver enemyDestructionObserver)
        {
            CharacterRemover characterRemover = new CharacterRemover(elementCreator, simpleSoldierProvider, new SphereTriggererComposition(new SphereBloodTriggerer(elementCreator),
            new GiantBodyPartThrower(elementCreator, destructibleBodyProvider, _randomDirectionThrower, 0.15)),
            destructibleBodyProvider, new ExplosionDamageSharer(2.0), DestructionStrength.GiantExplosionResistibility, _bloodParticleByBodyPartTriggerer, enemyDestructionObserver);
            return characterRemover;
        }
    }
}
