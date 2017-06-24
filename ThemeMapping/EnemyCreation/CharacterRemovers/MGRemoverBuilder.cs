using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using GameInteractionContracts;
using GameInteraction;
using BaseTypes;
using ArtificialIntelligence.Contracts;
using ArtificialIntelligence;
using BloodEffects;
using IOInterface;

namespace ThemeMapping.EnemyCreation.CharacterRemovers
{
    public class MGRemoverBuilder : ICharacterRemoverBuilder
    {
        private IParticleManager _particleManager;

        private IRandomDirectionThrower _randomDirectionThrower = new RandomDirectionThrower(5);

        public MGRemoverBuilder(IParticleManager particleManager)
        {
            _particleManager = particleManager;
        }

        ICharacterRemover ICharacterRemoverBuilder.CreateCharacterRemover(IElementCreator elementCreator, IWorldElementProvider simpleSoldierProvider, IDestructibleBodyProvider destructibleBodyProvider, IEnemyDestructionObserver enemyDestructionObserver)
        {
            ICharacterRemover characterRemover = new MGCharacterRemover(elementCreator, simpleSoldierProvider, new MGPartThrower(
            elementCreator, _randomDirectionThrower, 0.3),
            destructibleBodyProvider, new ExplosionDamageSharer(), DestructionStrength.MGExplosionResistibility, _particleManager);
            return characterRemover;
        }
    }
}
