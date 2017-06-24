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
    public class XWallSpriteCalculator : IWallSpriteCalculator
    {
        private bool _positive;
        private double _minimumLengthPercent;

        public XWallSpriteCalculator(bool positive, double minimumLengthPercent)
        {
            _positive = positive;
            _minimumLengthPercent = minimumLengthPercent;
        }

        SpriteVertices IWallSpriteCalculator.CalculateVertices(IWorldElement intersectedElement, Position3D spriteCenterPosition, double fullSideLength)
        {
            double highestZ = intersectedElement.Position.PositionY + (intersectedElement.LengthY / 2.0);
            double lowestZ = intersectedElement.Position.PositionY - (intersectedElement.LengthY / 2.0);
            double highestY = intersectedElement.Position.PositionZ + intersectedElement.Height;
            double lowestY = intersectedElement.Position.PositionZ;

            double highestSpriteY;
            double highestSpriteZ;
            double lowestSpriteY;
            double lowestSpriteZ;

            double highestTextureY = 1.0;
            double highestTextureX = 1.0;
            double lowestTextureY = 0.0;
            double lowestTextureX = 0.0;

            highestSpriteY = spriteCenterPosition.PositionY + (fullSideLength / 2.0);
            lowestSpriteY = spriteCenterPosition.PositionY - (fullSideLength / 2.0);
            highestSpriteZ = spriteCenterPosition.PositionZ + (fullSideLength / 2.0);
            lowestSpriteZ = spriteCenterPosition.PositionZ - (fullSideLength / 2.0);

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
            if (highestSpriteY < lowestY || highestSpriteZ < lowestZ || lowestSpriteY > highestY || lowestSpriteZ > highestZ)
                return null;

            if (highestSpriteZ - lowestSpriteZ < fullSideLength * _minimumLengthPercent)
                return null;

            if (highestSpriteY - lowestSpriteY < fullSideLength * _minimumLengthPercent)
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
            spriteVertices.VertexFour = new Vertex
            {
                Position = new VertexPosition { X = (float)spriteCenterPosition.PositionX, Y = (float)lowestSpriteY, Z = (float)lowestSpriteZ },
                TextureCoordinate = new VertexTextureCoordinate { X = (float)lowestTextureX, Y = (float)lowestTextureY }
            };
            spriteVertices.VertexThree = new Vertex
            {
                Position = new VertexPosition { X = (float)spriteCenterPosition.PositionX, Y = (float)lowestSpriteY, Z = (float)highestSpriteZ },
                TextureCoordinate = new VertexTextureCoordinate { X = (float)highestTextureX, Y = (float)lowestTextureY }
            };
            spriteVertices.VertexTwo = new Vertex
            {
                Position = new VertexPosition { X = (float)spriteCenterPosition.PositionX, Y = (float)highestSpriteY, Z = (float)highestSpriteZ },
                TextureCoordinate = new VertexTextureCoordinate { X = (float)highestTextureX, Y = (float)highestTextureY }
            };
            spriteVertices.VertexOne = new Vertex
            {
                Position = new VertexPosition { X = (float)spriteCenterPosition.PositionX, Y = (float)highestSpriteY, Z = (float)lowestSpriteZ },
                TextureCoordinate = new VertexTextureCoordinate { X = (float)lowestTextureX, Y = (float)highestTextureY }
            };

            return spriteVertices;
        }
    }
}
