using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Elements;
using BaseTypes;
using CollisionDetection.Contracts;

namespace CollisionDetection.CollisionDetectors
{
    public class DetectorOfOverlappingElements : IDetectorOfOverlappingElements
    {
        public bool ElementsAreOverlapping(IWorldElement ElementOne, Position3D newPositionOfElementOne, IWorldElement ElementTwo)
        {
            //checking the height of the objects and their Z position, this is independend of the shape
            double distanceZ = newPositionOfElementOne.PositionZ > ElementTwo.Position.PositionZ ?
                    newPositionOfElementOne.PositionZ - ElementTwo.Position.PositionZ - ElementTwo.Height :
                    ElementTwo.Position.PositionZ - newPositionOfElementOne.PositionZ - ElementOne.Height;

            if (distanceZ >= 0.0)
            {
                return false;
            }

            double distanceX = newPositionOfElementOne.PositionX > ElementTwo.Position.PositionX ?
                newPositionOfElementOne.PositionX - ElementTwo.Position.PositionX :
                ElementTwo.Position.PositionX - newPositionOfElementOne.PositionX;

            double distanceY = newPositionOfElementOne.PositionY > ElementTwo.Position.PositionY ?
                newPositionOfElementOne.PositionY - ElementTwo.Position.PositionY :
                ElementTwo.Position.PositionY - newPositionOfElementOne.PositionY;

            if (ElementOne.Shape == Shape.Rectangle || ElementTwo.Shape == Shape.Rectangle)
            {
                if (distanceX < (ElementOne.LengthX / 2.0) + (ElementTwo.LengthX / 2.0) &&
                    distanceY < (ElementOne.LengthY / 2.0) + (ElementTwo.LengthY / 2.0))
                {
                    return true;
                }
            }
            else
            {
                if ((distanceX * distanceX) + (distanceY * distanceY) < (ElementOne.Radius + ElementTwo.Radius) * (ElementOne.Radius + ElementTwo.Radius))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
