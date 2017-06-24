using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using GameInteractionContracts;
using BaseTypes;
using IOInterface;

namespace GameInteraction
{
    public class MGCharacterRemover : ICharacterRemover
    {
        private IElementCreator _elementCreator;
        private IWorldElementProvider _characterProvider;
        private double _explosionStrength;
        private ISphereBloodTriggerer _sphereBloodTriggerer;
        private IDestructibleBodyProvider _destructibleBodyProvider;
        private IExplosionDamageSharer _explosionDamageSharer;
        private IParticleManager _particleManager;

        public MGCharacterRemover(IElementCreator elementCreator, IWorldElementProvider characterProvider, ISphereBloodTriggerer sphereBloodTriggerer,
            IDestructibleBodyProvider destructibleBodyProvider,IExplosionDamageSharer explosionDamageSharer, double explosionStrength, IParticleManager particleManager)
        {
            _elementCreator = elementCreator;
            _characterProvider = characterProvider;
            _explosionStrength = explosionStrength;
            _sphereBloodTriggerer = sphereBloodTriggerer;
            _destructibleBodyProvider = destructibleBodyProvider;
            _explosionDamageSharer = explosionDamageSharer;
            _particleManager = particleManager;
        }

        void IExplosionVulnerable.YouGotHit(Position3D explosionPosition, double destructionStrength)
        {
            if (destructionStrength >= _explosionStrength)
            {
                ExplodeCharacter();
                RemoveCharacter();
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
            IWorldElement character = _characterProvider.GetElement();

            if (character == null)
                return;

            Position3D bloodExplosionPosition = character.Position.Clone();

            bloodExplosionPosition.PositionZ += (character.Height / 2.0);
            _sphereBloodTriggerer.TriggerBloodSphere(bloodExplosionPosition);
            _particleManager.StartNewParticleAnimation(bloodExplosionPosition, Animation.ExplosionSmall);
        }

        void IDestructionObserver.NotifyFullDestruction(BodyPart bodyPart, Position3D position)
        {
        }

        void IDestructionObserver.NotifyInnerDestruction()
        {
            ExplodeCharacter();
            RemoveCharacter();
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
