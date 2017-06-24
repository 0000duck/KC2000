using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteraction.BaseImplementations;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using GameInteractionContracts;
using IOInterface;
using Sound.Contracts;
using BaseContracts;

namespace ElementImplementations.CharacterImplementations
{
    public class BandMember : AnimatibleElement, IVulnerable, IExplosionVulnerable, IExecuteble
    {
        private IElementCreator _elementCreator;
        private IBloodParticleByBodyPartTriggerer _bloodParticleByBodyPartTriggerer;
        private ISound _instrument;
        private bool _instrumentStarted;
        private IPercentLooper _percentLooper;

        public BandMember(IElementCreator elementCreator, IBloodParticleByBodyPartTriggerer bloodParticleByBodyPartTriggerer, ISound instrument, IPercentLooper percentLooper)
        {
            _elementCreator = elementCreator;
            _bloodParticleByBodyPartTriggerer = bloodParticleByBodyPartTriggerer;
            _instrument = instrument;
            _percentLooper = percentLooper;
            AnimationBehaviour = Behaviour.StandardBehaviour;
        }

        void IVulnerable.YouGotHit(Position3D position, double destructionStrength, Vector3D directionVector)
        {
            ExplodeBandMember();
        }

        void IExplosionVulnerable.YouGotHit(Position3D explosionPosition, double destructionStrength)
        {
            ExplodeBandMember();
        }

        private void ExplodeBandMember()
        {
            _instrument.Stop();
            Position3D explosionPosition = Position.Clone();
            explosionPosition.PositionZ += Height / 2.0;
            _bloodParticleByBodyPartTriggerer.TriggerBloodParticle(BodyPart.Torso, explosionPosition);
            _elementCreator.DeleteElement(this);
        }

        void IExecuteble.ExecuteLogic()
        {
            if (!_instrumentStarted)
            {
                _instrument.Play();
                _instrumentStarted = true;
                _instrument.SetPosition((float)Position.PositionX, (float)Position.PositionZ, (float)Position.PositionY);
            }

            AnimationPercent = _percentLooper.GetPercent();
        }
    }
}
