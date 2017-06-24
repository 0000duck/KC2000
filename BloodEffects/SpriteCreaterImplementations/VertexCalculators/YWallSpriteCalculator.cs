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
    public class YWallSpriteCalculator : IWallSpriteCalculator
    {
        private bool _positive;
        private double _minimumLengthPercent;

        public YWallSpriteCalculator(bool positive, double minimumLengthPercent)
        {
            _positive = positive;
            _minimumLengthPercent = minimumLengthPercent;
        }

        SpriteVertices IWallSpriteCalculator.CalculateVertices(IWorldElement intersectedElement, Position3D spriteCenterPosition, double fullSideLength)
        {
            double highestZ = intersectedElement.Position.PositionY + (intersectedElement.LengthY / 2.0);
            double lowestZ = intersectedElement.Position.PositionY - (intersectedElement.LengthY / 2.0);
            double highestX = intersectedElement.Position.PositionX + (intersectedElement.LengthX / 2.0);
            double lowestX = intersectedElement.Position.PositionX - (intersectedElement.LengthX / 2.0);

            double highestSpriteX;
            double highestSpriteZ;
            double lowestSpriteX;
            double lowestSpriteZ;

            double highestTextureY = 1.0;
            double highestTextureX = 1.0;
            double lowestTextureY = 0.0;
            double lowestTextureX = 0.0;

            highestSpriteX = spriteCenterPosition.PositionX + (fullSideLength / 2.0);
            lowestSpriteX = spriteCenterPosition.PositionX - (fullSideLength / 2.0);
            highestSpriteZ = spriteCenterPosition.PositionZ + (fullSideLength / 2.0);
            lowestSpriteZ = spriteCenterPosition.PositionZ - (fullSideLength / 2.0);

            if (highestSpriteX > highestX)
            {
                highestTextureY = 1 - ((highestSpriteX - highestX) / fullSideLength);
                highestSpriteX = highestX;
            }

            if (lowestSpriteX < lowestX)
            {
                lowestTextureY = (lowestX - lowestSpriteX) / fullSideLength;
                lowestSpriteX = lowestX;
            }

            if (highestSpriteZ > highestZ)
            {
                highestTextureX = 1 - ((highestSpriteZ - highestZ) / fullSideLength);
                highestSpriteZ = highestZ;
            }

            if (lowestSpriteZ < lowestZ)
            {
                lowestTextureX = (lowestZ - lowestSpriteZ) / fullSideLength;
                lowestSpriteZ = lowestZ;
            }

            //check if it is outside of element
            if (highestSpriteX < lowestX || highestSpriteZ < lowestZ || lowestSpriteX > highestX || lowestSpriteZ > highestZ)
                return null;

            if (highestSpriteZ - lowestSpriteZ < fullSideLength * _minimumLengthPercent)
                return null;

            if (highestSpriteX - lowestSpriteX < fullSideLength * _minimumLengthPercent)
                return null;

            if (!_positive)
            { 
                //change vertices for clockwise culling
                double tempHighestZ = highestSpriteZ;
                highestSpriteZ = lowestSpriteZ;
                lowestSpriteZ = tempHighestZ;

                double temphighestTextureX = highestTextureX;
                highestTextureX = lowestTextureX;
                lowestTextureX = temphighestTextureX;
            }

            SpriteVertices spriteVertices = new SpriteVertices();
            spriteVertices.VertexOne = new Vertex
            {
                Position = new VertexPosition { Y = (float)spriteCenterPosition.PositionY, X = (float)lowestSpriteX, Z = (float)lowestSpriteZ },
                TextureCoordinate = new VertexTextureCoordinate { X = (float)lowestTextureX, Y = (float)lowestTextureY }
            };
            spriteVertices.VertexTwo = new Vertex
            {
                Position = new VertexPosition { Y = (float)spriteCenterPosition.PositionY, X = (float)lowestSpriteX, Z = (float)highestSpriteZ },
                TextureCoordinate = new VertexTextureCoordinate { X = (float)highestTextureX, Y = (float)lowestTextureY }
            };
            spriteVertices.VertexThree = new Vertex
            {
                Position = new VertexPosition { Y = (float)spriteCenterPosition.PositionY, X = (float)highestSpriteX, Z = (float)highestSpriteZ },
                TextureCoordinate = new VertexTextureCoordinate { X = (float)highestTextureX, Y = (float)highestTextureY }
            };
            spriteVertices.VertexFour = new Vertex
            {
                Position = new VertexPosition { Y = (float)spriteCenterPosition.PositionY, X = (float)highestSpriteX, Z = (float)lowestSpriteZ },
                TextureCoordinate = new VertexTextureCoordinate { X = (float)lowestTextureX, Y = (float)highestTextureY }
            };

            return spriteVertices;
        }
    }
}
