using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using GameInteractionContracts;
using BaseTypes;
using IOInterface;
using Sound.Contracts;

namespace GameInteraction
{
    public class HalfCharacterRemover : ICharacterRemover
    {
        private IWorldElementProvider _characterProvider;
        private IBloodParticleByBodyPartTriggerer _bloodParticleByBodyPartTriggerer;
        private ISphereBloodTriggerer _sphereBloodTriggerer;
        private IDestructibleBodyProvider _destructibleBodyProvider;
        private IExplosionDamageSharer _explosionDamageSharer;
        private IEnemyDestructionObserver _enemyDestructionObserver;
        private bool _exploded;
        private ISound _explosionSound;

        public HalfCharacterRemover(IWorldElementProvider characterProvider, ISphereBloodTriggerer sphereBloodTriggerer,
            IDestructibleBodyProvider destructibleBodyProvider,IExplosionDamageSharer explosionDamageSharer,
            IBloodParticleByBodyPartTriggerer bloodParticleByBodyPartTriggerer, IEnemyDestructionObserver enemyDestructionObserver, ISound explosionSound)
        {
            _characterProvider = characterProvider;
            _bloodParticleByBodyPartTriggerer = bloodParticleByBodyPartTriggerer;
            _sphereBloodTriggerer = sphereBloodTriggerer;
            _destructibleBodyProvider = destructibleBodyProvider;
            _explosionDamageSharer = explosionDamageSharer;
            _enemyDestructionObserver = enemyDestructionObserver;
            _explosionSound = explosionSound;
        }

        void IExplosionVulnerable.YouGotHit(Position3D explosionPosition, double destructionStrength)
        {
            IWorldElement character = _characterProvider.GetElement();

            if (character == null)
                return;

            _explosionDamageSharer.ShareDamage(explosionPosition, destructionStrength, _destructibleBodyProvider.GetDestructibleBody().GetBodyParts(character.Position, Degree.Degree_0));      
        }

        void IDestructionObserver.NotifyFullDestruction(BodyPart bodyPart, Position3D position)
        {
            ExplodeCharacter();
        }

        void IDestructionObserver.NotifyInnerDestruction()
        {
            ExplodeCharacter();
        }

        private void ExplodeCharacter()
        {
            if (_exploded)
                return;

            IWorldElement character = _characterProvider.GetElement();

            if (character == null)
                return;

            _enemyDestructionObserver.EnemyDestroyed();

            Position3D bloodExplosionPosition = character.Position.Clone();
            
            bloodExplosionPosition.PositionZ += (character.Height / 2.0);
            _sphereBloodTriggerer.TriggerBloodSphere(bloodExplosionPosition);
            _bloodParticleByBodyPartTriggerer.TriggerBloodParticle(BodyPart.Corpse, bloodExplosionPosition);
            _explosionSound.SetPosition((float)bloodExplosionPosition.PositionX, (float)bloodExplosionPosition.PositionZ, (float)bloodExplosionPosition.PositionY);

            _exploded = true;
        }
    }
}
