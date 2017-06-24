using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using IOInterface;
using GameInteractionContracts;
using BloodEffects;
using ArtificialIntelligence.Contracts;
using GameInteraction;
using ArtificialIntelligence;
using BaseTypes;
using Sound.Contracts;

namespace ThemeMapping.EnemyCreation.CharacterRemovers
{
    class HelicopterRemoverBuilder: ICharacterRemoverBuilder
    {
        private IBloodParticleByBodyPartTriggerer _bloodParticleByBodyPartTriggerer;
        private IRandomDirectionThrower _randomDirectionThrower = new RandomDirectionThrower(5);
        private ISound _helicopterSound;
        private bool _noblood;

        public HelicopterRemoverBuilder(IBloodParticleByBodyPartTriggerer bloodParticleByBodyPartTriggerer, ISound helicopterSound, bool noblood)
        {
            _bloodParticleByBodyPartTriggerer = bloodParticleByBodyPartTriggerer;
            _helicopterSound = helicopterSound;
            _noblood = noblood;
        }

        ICharacterRemover ICharacterRemoverBuilder.CreateCharacterRemover(IElementCreator elementCreator, IWorldElementProvider simpleSoldierProvider,
            IDestructibleBodyProvider destructibleBodyProvider, IEnemyDestructionObserver enemyDestructionObserver)
        {
            if (_noblood)
            {
                return new CharacterRemover(new LoopedSoundStopper(elementCreator, _helicopterSound), simpleSoldierProvider,
                  new NoBlood(), destructibleBodyProvider, new ExplosionDamageSharer(2.0), DestructionStrength.HelicopterExplosionResistibility, new NoBlood(), enemyDestructionObserver);
            }

            return new CharacterRemover(new LoopedSoundStopper(elementCreator, _helicopterSound), simpleSoldierProvider, 
                new SphereTriggererComposition(new SphereBloodTriggerer(elementCreator),
            new GiantBodyPartThrower(elementCreator, destructibleBodyProvider, _randomDirectionThrower, 0.15)),
            destructibleBodyProvider, new ExplosionDamageSharer(2.0), DestructionStrength.HelicopterExplosionResistibility, _bloodParticleByBodyPartTriggerer, enemyDestructionObserver);
        }

        private class NoBlood : IBloodParticleByBodyPartTriggerer, ISphereBloodTriggerer
        {
            void IBloodParticleByBodyPartTriggerer.TriggerBloodParticle(BodyPart bodyPart, Position3D position)
            {  
            }

            void ISphereBloodTriggerer.TriggerBloodSphere(Position3D center)
            {
            }
        }
    }
}
