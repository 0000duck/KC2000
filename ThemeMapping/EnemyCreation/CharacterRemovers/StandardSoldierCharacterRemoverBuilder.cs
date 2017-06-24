using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using GameInteraction;
using GameInteractionContracts;
using BaseTypes;
using ArtificialIntelligence.Contracts;
using BloodEffects;
using ArtificialIntelligence;
using IOInterface;

namespace ThemeMapping.EnemyCreation.CharacterRemovers
{
    public class StandardSoldierCharacterRemoverBuilder : ICharacterRemoverBuilder
    {
        private IBloodParticleByBodyPartTriggerer _bloodParticleByBodyPartTriggerer;
        private IRandomDirectionThrower _randomDirectionThrower = new RandomDirectionThrower(5);

        public StandardSoldierCharacterRemoverBuilder(IBloodParticleByBodyPartTriggerer bloodParticleByBodyPartTriggerer)
        {
            _bloodParticleByBodyPartTriggerer = bloodParticleByBodyPartTriggerer;
        }

        ICharacterRemover ICharacterRemoverBuilder.CreateCharacterRemover(IElementCreator elementCreator, IWorldElementProvider simpleSoldierProvider,
            IDestructibleBodyProvider destructibleBodyProvider, IEnemyDestructionObserver enemyDestructionObserver)
        {
            CharacterRemover characterRemover = new CharacterRemover(elementCreator, simpleSoldierProvider,new SphereTriggererComposition(new SphereBloodTriggerer(elementCreator),
            new SphereBodyPartByBodyStatusTriggerer(elementCreator, destructibleBodyProvider, _randomDirectionThrower, 0.15)),
            destructibleBodyProvider, new ExplosionDamageSharer(), DestructionStrength.StandardSoldierExplosionResistibility, _bloodParticleByBodyPartTriggerer, enemyDestructionObserver);
            return characterRemover;
        }
    }
}
