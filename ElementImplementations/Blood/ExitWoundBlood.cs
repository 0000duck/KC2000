using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using FrameworkContracts;
using IOInterface;
using BloodEffects.Contracts;

namespace ElementImplementations.Blood
{
    public class ExitWoundBlood : IAnimationInstructionProvider
    {
        private IBloodEffectCreator _bloodEffectCreator;
        private IBloodAnimationSizeMapper _bloodAnimationSizeMapper;
        private PercentFader _percentFader;
        private double _radius;
        private Position3D _startPosition;

        public ExitWoundBlood(IBloodEffectCreator bloodEffectCreator, IBloodAnimationSizeMapper bloodAnimationSizeMapper, double radius, double timeToLiveInSeconds, Position3D startPosition)
        {
            _bloodEffectCreator = bloodEffectCreator;
            _bloodAnimationSizeMapper = bloodAnimationSizeMapper;
            _radius = radius;
            _startPosition = startPosition;
            _percentFader = new PercentFader(timeToLiveInSeconds);
            _percentFader.Start();
        }

        AnimationInstruction IAnimationInstructionProvider.GetInstructions(bool collisionWithWorld, Position3D position)
        {
            if (collisionWithWorld)
            {
                Position3D positionAboveFloor = position.Clone();
                positionAboveFloor.PositionZ += _radius;
                DistanceBetweenTwoPositions distance = new DistanceBetweenTwoPositions(_startPosition, position);
                _bloodEffectCreator.CreateBloodEffect(_bloodAnimationSizeMapper.MapAnimation(distance.SquareDistanceXYZ), positionAboveFloor);
            }

            double percent = _percentFader.GetPercent();

            return new AnimationInstruction
            {
                Behaviour = Behaviour.StandardBehaviour,
                Percent = percent,
                ElementIsFinished = collisionWithWorld || percent > 0.999
            };
        }
    }
}
