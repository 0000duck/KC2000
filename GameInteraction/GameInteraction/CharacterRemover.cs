using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using IOInterface;

namespace GameInteraction
{
    public class CharacterRemover : ICharacterRemover
    {
        private IElementCreator _elementCreator;
        private IWorldElementProvider _characterProvider;
        private double _explosionStrength;
        private IBloodParticleByBodyPartTriggerer _bloodParticleByBodyPartTriggerer;
        private ISphereBloodTriggerer _sphereBloodTriggerer;
        private IDestructibleBodyProvider _destructibleBodyProvider;
        private IExplosionDamageSharer _explosionDamageSharer;
        private IEnemyDestructionObserver _enemyDestructionObserver;
        private bool _exploded;

        public CharacterRemover(IElementCreator elementCreator, IWorldElementProvider characterProvider, ISphereBloodTriggerer sphereBloodTriggerer,
            IDestructibleBodyProvider destructibleBodyProvider,IExplosionDamageSharer explosionDamageSharer, double explosionStrength,
            IBloodParticleByBodyPartTriggerer bloodParticleByBodyPartTriggerer, IEnemyDestructionObserver enemyDestructionObserver)
        {
            _elementCreator = elementCreator;
            _characterProvider = characterProvider;
            _explosionStrength = explosionStrength;
            _bloodParticleByBodyPartTriggerer = bloodParticleByBodyPartTriggerer;
            _sphereBloodTriggerer = sphereBloodTriggerer;
            _destructibleBodyProvider = destructibleBodyProvider;
            _explosionDamageSharer = explosionDamageSharer;
            _enemyDestructionObserver = enemyDestructionObserver;
        }

        void IExplosionVulnerable.YouGotHit(Position3D explosionPosition, double destructionStrength)
        {
            if (destructionStrength >= _explosionStrength)
            {
                ExplodeCharacter();
                RemoveCharacter();
                _enemyDestructionObserver.EnemyDestroyed();
            }
            else
            {
                IWorldElement character = _characterProvider.GetElement();

                if (character == null)
                    return;

                _explosionDamageSharer.ShareDamage(explosionPosition, destructionStrength, _destructibleBodyProvider.GetDestructibleBody().GetBodyParts(character.Position, Degree.Degree_0));
            }
        }

        private void ExplodeCharacter()
        {
            if (_exploded)
                return;

            IWorldElement character = _characterProvider.GetElement();

            if (character == null)
                return;

            Position3D bloodExplosionPosition = character.Position.Clone();
            
            if (_destructibleBodyProvider.GetDestructibleBody().BodyStatus == MainBodyStatus.FullBody)
            {
                bloodExplosionPosition.PositionZ += (character.Height / 2.0);
                _sphereBloodTriggerer.TriggerBloodSphere(bloodExplosionPosition);
                _bloodParticleByBodyPartTriggerer.TriggerBloodParticle(BodyPart.Full, bloodExplosionPosition);
            }
            else
            {
                bloodExplosionPosition.PositionZ += (character.Height / 4.0);
                _sphereBloodTriggerer.TriggerBloodSphere(bloodExplosionPosition);
                _bloodParticleByBodyPartTriggerer.TriggerBloodParticle(BodyPart.Corpse, bloodExplosionPosition);
            }

            _exploded = true;
        }

        void IDestructionObserver.NotifyFullDestruction(BodyPart bodyPart, Position3D position)
        {
            if (bodyPart == BodyPart.Corpse)
            {
                ExplodeCharacter();
                RemoveCharacter();
            }
        }

        void IDestructionObserver.NotifyInnerDestruction()
        {
        }

        private void RemoveCharacter()
        {
            IWorldElement character = _characterProvider.GetElement();

            if(character == null)
                return;

            _elementCreator.DeleteElement(character);
        }
    }
}
