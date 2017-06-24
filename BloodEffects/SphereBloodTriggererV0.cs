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
    public class SphereBloodTriggererV0 : ISphereBloodTriggerer
    {
        private IElementCreator _elementCreator;
        private int _bloodCounter;

        public SphereBloodTriggererV0(IElementCreator elementCreator)
        {
            _elementCreator = elementCreator;
        }

        void ISphereBloodTriggerer.TriggerBloodSphere(Position3D center)
        {
            for (int i = 0; i < 8; i++)
            {
                if(i % 5 == 0)
                    _elementCreator.EnqueueNewElement(new ElementImplementation { ElementTheme = ElementTheme.BloodyPart, StartPosition = center }, StartBloodFlight);
                else if (i % 7 == 0)
                    _elementCreator.EnqueueNewElement(new ElementImplementation { ElementTheme = ElementTheme.Bowls, StartPosition = center }, StartBloodFlight);
                else
                    _elementCreator.EnqueueNewElement(new ElementImplementation { ElementTheme = ElementTheme.FlyingBloodMedium, StartPosition = center }, StartBloodFlight);
            }
            _bloodCounter = 1;
        }

        private void StartBloodFlight(IWorldElement element)
        {
            if (_bloodCounter > (int)Degree.Degree_315)
                _bloodCounter = 1;

            Vector2D vector = null;
            Vector3D directionVector = null;

            if ((_bloodCounter % 2 == 0))
            {
                vector = VectorCreator.CreateVector(1, (Degree)_bloodCounter);
                directionVector = new Vector3D { X = vector.X, Y = vector.Y, Z = 0.2 };
            }
            else
            {
                vector = VectorCreator.CreateVector(MathHelper.SinusOf45Degree, (Degree)_bloodCounter);
                directionVector = new Vector3D { X = vector.X, Y = vector.Y, Z = MathHelper.SinusOf45Degree };
            }
             
            IFlyingBlood flyingBlood = (IFlyingBlood)element;

            flyingBlood.StartFlight(directionVector, 10.5, 1.3);

            _bloodCounter++;
        }
    }
}
