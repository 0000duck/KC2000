using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection;
using EnvironmentAnalysis.RayTest.Rays;
using GameInteraction.BaseImplementations;
using BaseTypes;
using GameInteraction.Weapons;
using GameInteraction.ThemeMapping;
using IOInterface;
using GameInteractionContracts;
using ArtificialIntelligence.Contracts;
using BaseContracts;
using CollisionDetection.Contracts;

namespace ElementImplementations.CharacterImplementations
{
    public class VolitionDrivenElement : ImpulseProcessingAnimatableElement, IStorable, IExecuteble, IHighLevelOfDetail, IExplosionVulnerable
    {
        private IBehaviourStrategy _strategy;
        private IDestructibleBody _destructibleBody;
        private IImpulseConverter _degreeToImpulseConverter;
        private IBehaviourMapper _behaviourMapper;
        private IExplosionVulnerable _explosionObserver;

        public VolitionDrivenElement(IBehaviourStrategy strategy, IDestructibleBody destructibleBody, IListProvider<IWorldElement> listProvider,
            IImpulseConverter degreeToImpulseConverter, IBehaviourMapper behaviourMapper, IExplosionVulnerable explosionObserver, IComplexElementFinder complexElementFinder)
            : base(listProvider, complexElementFinder)
        {
            _strategy = strategy;
            _destructibleBody = destructibleBody;
            _degreeToImpulseConverter = degreeToImpulseConverter; 
            _behaviourMapper = behaviourMapper;
            _explosionObserver = explosionObserver;
            Orientation = Degree.Degree_0;
        }

        public virtual void ExecuteLogic()
        {
            BehaviourInstruction behaviourInstruction = _strategy.GetInstruction(
            new BehaviourParameters
            {
                Orientation = Orientation,
                Position = Position
            });

            AnimationPercent = behaviourInstruction.Percent;
            Orientation = behaviourInstruction.ViewDegree;

            if (behaviourInstruction.Speed.HasValue)
            {
                if (behaviourInstruction.MovementDegree.HasValue)
                {
                    foreach (Impulse impulse in _degreeToImpulseConverter.ConvertDegreeToImplse(behaviourInstruction.MovementDegree.Value, Weight, behaviourInstruction.Speed.Value))
                        AddImpulse(impulse);
                }
                if (behaviourInstruction.MovementVector != null)
                {
                    foreach (Impulse impulse in _degreeToImpulseConverter.ConvertVectorToImplse(behaviourInstruction.MovementVector, Weight, behaviourInstruction.Speed.Value))
                        AddImpulse(impulse);
                }
                if (behaviourInstruction.Direction.HasValue)
                {
                    AddImpulse(new Impulse { ImpulseDirection = behaviourInstruction.Direction.Value, Strength = behaviourInstruction.Speed.Value });
                }
            }

            AnimationBehaviour = _behaviourMapper.MapBehaviour(behaviourInstruction.Behaviour, _destructibleBody.BodyStatus);
        }

        public virtual void SetState(IInitInformation initInformation)
        {
            ((IStorable)_destructibleBody).SetState(initInformation);
        }

        public virtual IInitInformation GetState()
        {
            return ((IStorable)_destructibleBody).GetState();
        }

        IList<IWorldElement> IHighLevelOfDetail.GetHigherDetails()
        {
            return _destructibleBody.GetBodyParts(Position, Orientation);
        }

        void IExplosionVulnerable.YouGotHit(Position3D explosionPosition, double destructionStrength)
        {
            _explosionObserver.YouGotHit(explosionPosition, destructionStrength);
        }
    }
}

