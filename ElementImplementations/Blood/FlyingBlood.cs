using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using GameInteraction.BaseImplementations;
using BaseContracts;
using FrameworkContracts;
using IOInterface;
using CollisionDetection.Elements;

namespace ElementImplementations.Blood
{
    //public class FlyingBlood : ImpulseProcessingElement, IFlyingBlood, IExecuteble
    //{
    //    private double _speed;
    //    private IElementCreator _elementCreator;
    //    private IBloodEffectCreator _bloodEffectCreator;
    //    private Animation _animation;
    //    private double _bloodRadius;
    //    private double _timeToLiveInSeconds;
    //    private double _startTime;
    //    private IStraightFlightSimulator _straightFlightSimulator;

    //    public FlyingBlood(IListProvider<IWorldElement> listProvider, IElementCreator elementCreator, IBloodEffectCreator bloodEffectCreator, IStraightFlightSimulator straightFlightSimulator, Animation animation, double bloodRadius)
    //        :base(listProvider)
    //    {
    //        _elementCreator = elementCreator;
    //        _bloodEffectCreator = bloodEffectCreator;
    //        _animation = animation;
    //        _bloodRadius = bloodRadius;
    //        _straightFlightSimulator = straightFlightSimulator;
    //    }

    //    void IFlyingBlood.StartFlight(Vector3D directionVector, double speed, double timeToLiveInSeconds)
    //    {
    //        _straightFlightSimulator.Initialize(directionVector, Weight);
    //        _speed = speed;
    //        _timeToLiveInSeconds = timeToLiveInSeconds;
    //        _startTime = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
            
    //    }
    //    void IExecuteble.ExecuteLogic()
    //    {
    //        if (TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - _startTime > _timeToLiveInSeconds)
    //        {
    //            _elementCreator.RegisterElementChange(this, ElementChange.Deleted);
    //        }
    //        else if (CollisionProtocol.IsThereAnyCollision)
    //        {
    //            _elementCreator.RegisterElementChange(this, ElementChange.Deleted);
    //            _bloodEffectCreator.CreateBloodEffect(_animation, _bloodRadius, _bloodRadius, Position);
    //        }
    //        else
    //        {
    //            Fly();
    //        }
    //    }

    //    private void Fly()
    //    {
    //        double speedStrength = TimeAndSpeedManager.ConvertSpeedToStrength(_speed);

    //        IList<Impulse> impulses = _straightFlightSimulator.GetFlightImpulses(speedStrength);

    //        foreach (Impulse impulse in impulses)
    //        {
    //            AddImpulse(impulse);
    //        }
    //    }
    //}
}
