using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using Render.Contracts;
using BloodEffects.Contracts;

namespace BloodEffects.SpriteCreaterImplementations.VertexCalculators
{
    public class ZWallSpriteCalculator : IWallSpriteCalculator
    {
        private bool _positive;
        private double _minimumLengthPercent;

        public ZWallSpriteCalculator(bool positive, double minimumLengthPercent)
        {
            _positive = positive;
            _minimumLengthPercent = minimumLengthPercent;
        }

        SpriteVertices IWallSpriteCalculator.CalculateVertices(IWorldElement intersectedElement, Position3D spriteCenterPosition, double fullSideLength)
        {
            double highestX = intersectedElement.Position.PositionX + (intersectedElement.LengthX / 2.0);
            double lowestX = intersectedElement.Position.PositionX - (intersectedElement.LengthX / 2.0);
            double highestY = intersectedElement.Position.PositionZ + intersectedElement.Height;
            double lowestY = intersectedElement.Position.PositionZ;

            double highestSpriteY;
            double highestSpriteX;
            double lowestSpriteY;
            double lowestSpriteX;

            double highestTextureY = 1.0;
            double highestTextureX = 1.0;
            double lowestTextureY = 0.0;
            double lowestTextureX = 0.0;

            highestSpriteY = spriteCenterPosition.PositionY + (fullSideLength / 2.0);
            lowestSpriteY = spriteCenterPosition.PositionY - (fullSideLength / 2.0);
            highestSpriteX = spriteCenterPosition.PositionX + (fullSideLength / 2.0);
            lowestSpriteX = spriteCenterPosition.PositionX - (fullSideLength / 2.0);

            if (highestSpriteY > highestY)
            {
                highestTextureY = 1 - ((highestSpriteY - highestY) / fullSideLength);
                highestSpriteY = highestY;
            }

            if (lowestSpriteY < lowestY)
            {
                lowestTextureY = (lowestY - lowestSpriteY) / fullSideLength;
                lowestSpriteY = lowestY;
            }

            if (highestSpriteX > highestX)
            {
                highestTextureX = 1 - ((highestSpriteX - highestX) / fullSideLength);
                highestSpriteX = highestX;
            }

            if (lowestSpriteX < lowestX)
            {
                lowestTextureX = (lowestX - lowestSpriteX) / fullSideLength;
                lowestSpriteX = lowestX;
            }

            //check if it is outside of element
            if (highestSpriteY < lowestY || highestSpriteX < lowestX || lowestSpriteY > highestY || lowestSpriteX > highestX)
                return null;

            if (highestSpriteY - lowestSpriteY < fullSideLength * _minimumLengthPercent)
                return null;
            if (highestSpriteX - lowestSpriteX < fullSideLength * _minimumLengthPercent)
                return null;

            if (!_positive)
            { 
                //change vertices for clockwise culling
                double tempHighestX = highestSpriteX;
                highestSpriteX = lowestSpriteX;
                lowestSpriteX = tempHighestX;

                double temphighestTextureX = highestTextureX;
                highestTextureX = lowestTextureX;
                lowestTextureX = temphighestTextureX;
            }

            SpriteVertices spriteVertices = new SpriteVertices();
            spriteVertices.VertexOne = new Vertex
            {
                Position = new VertexPosition { Z = (float)spriteCenterPosition.PositionZ, Y = (float)lowestSpriteY, X = (float)lowestSpriteX },
                TextureCoordinate = new VertexTextureCoordinate { X = (float)lowestTextureX, Y = (float)lowestTextureY }
            };
            spriteVertices.VertexTwo = new Vertex
            {
                Position = new VertexPosition { Z = (float)spriteCenterPosition.PositionZ, Y = (float)lowestSpriteY, X = (float)highestSpriteX },
                TextureCoordinate = new VertexTextureCoordinate { X = (float)highestTextureX, Y = (float)lowestTextureY }
            };
            spriteVertices.VertexThree = new Vertex
            {
                Position = new VertexPosition { Z = (float)spriteCenterPosition.PositionZ, Y = (float)highestSpriteY, X = (float)highestSpriteX },
                TextureCoordinate = new VertexTextureCoordinate { X = (float)highestTextureX, Y = (float)highestTextureY }
            };
            spriteVertices.VertexFour = new Vertex
            {
                Position = new VertexPosition { Z = (float)spriteCenterPosition.PositionZ, Y = (float)highestSpriteY, X = (float)lowestSpriteX },
                TextureCoordinate = new VertexTextureCoordinate { X = (float)lowestTextureX, Y = (float)highestTextureY }
            };

            return spriteVertices;
        }
    }
}
