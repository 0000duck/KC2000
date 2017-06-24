using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using IOImplementation;
using IOInterface;

namespace BloodEffects
{
    public class SphereBloodTriggerer : ISphereBloodTriggerer
    {
        private IElementCreator _elementCreator;
        private int _bloodCounter;

        public SphereBloodTriggerer(IElementCreator elementCreator)
        {
            _elementCreator = elementCreator;
        }

        void ISphereBloodTriggerer.TriggerBloodSphere(Position3D center)
        {
            for (int i = 0; i < 16; i++)
            {
                _elementCreator.EnqueueNewElement(new ElementImplementation { ElementTheme = ElementTheme.FlyingBloodMedium, StartPosition = center }, StartBloodFlight);
            }

            Position3D bodyPartPosition = center.Clone();
            bodyPartPosition.PositionZ += 0.25;

            if (MathHelper.GetRandomValueInARange(1, false) > 0.5)
                _elementCreator.EnqueueNewElement(new ElementImplementation { ElementTheme = ElementTheme.FlyingBloodSmall, StartPosition = center }, StartBloodFlight);

            if (MathHelper.GetRandomValueInARange(1, false) > 0.5)
                _elementCreator.EnqueueNewElement(new ElementImplementation { ElementTheme = ElementTheme.BloodyPart, StartPosition = bodyPartPosition }, StartBloodFlight);

            if (MathHelper.GetRandomValueInARange(1, false) > 0.5)
                _elementCreator.EnqueueNewElement(new ElementImplementation { ElementTheme = ElementTheme.FlyingBloodSmall, StartPosition = center }, StartBloodFlight);

            if (MathHelper.GetRandomValueInARange(1, false) > 0.5)
                _elementCreator.EnqueueNewElement(new ElementImplementation { ElementTheme = ElementTheme.Bowls, StartPosition = bodyPartPosition }, StartBloodFlight);

            _bloodCounter = 1;
        }

        private void StartBloodFlight(IWorldElement element)
        {
            if (_bloodCounter > (int)Degree.Degree_315)
                _bloodCounter = 1;

            Vector2D vector = VectorCreator.CreateVector(1, (Degree)_bloodCounter);
            Vector3D directionVector = new Vector3D { X = vector.X, Y = vector.Y, Z = MathHelper.GetRandomValueInARange(2, false) / 6 };

            IFlyingBlood flyingBlood = (IFlyingBlood)element;

            flyingBlood.StartFlight(directionVector, 9 + MathHelper.GetRandomValueInARange(4, false), 1.3);

            _bloodCounter++;
        }
    }
}
