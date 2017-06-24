using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using BloodEffects.Contracts;

namespace BloodEffects.SpriteCreaterImplementations.BloodParameterCalculators
{
    public class PositiveXSpriteParameterCalculator : IBloodSpriteParameterCalculator
    {
        private IWallSpriteCalculator _wallSpriteCalculator;
        private double _distanceToWall;
        private ITextureRotater _textureRotater;

        public PositiveXSpriteParameterCalculator(IWallSpriteCalculator wallSpriteCalculator, ITextureRotater textureRotater, double distanceToWall)
        {
            _wallSpriteCalculator = wallSpriteCalculator;
            _distanceToWall = distanceToWall;
            _textureRotater = textureRotater;
        }

        WallSpriteAnimationParameters IBloodSpriteParameterCalculator.TryToCreateSprite(IWorldElement intersectedElement, Position3D centerOfSphere, double radius)
        {
            if (SphereIsAtPositiveX(centerOfSphere, intersectedElement))
            {
                return CreateSpriteAtPositiveX(intersectedElement, centerOfSphere, radius);
            }
            return null;
        }

        private WallSpriteAnimationParameters CreateSpriteAtPositiveX(IWorldElement intersectedElement, Position3D centerOfSphere, double radius)
        {
            Position3D spriteCenterPosition = new Position3D();

            spriteCenterPosition.PositionX = intersectedElement.Position.PositionX + (intersectedElement.LengthX / 2.0) + _distanceToWall;
            spriteCenterPosition.PositionY = centerOfSphere.PositionZ;
            spriteCenterPosition.PositionZ = centerOfSphere.PositionY;

            double fullSideLength = radius * 2;

            SpriteVertices vertices = _wallSpriteCalculator.CalculateVertices(intersectedElement, spriteCenterPosition, fullSideLength);

            if (vertices == null)
                return null;

            _textureRotater.Rotate(vertices);

            WallSpriteAnimationParameters wallSpriteAnimationParameters = new WallSpriteAnimationParameters 
            { 
                SpriteVertices = vertices,
                SpriteCenterPosition = spriteCenterPosition,
                Normal = new Vector3D { X = 1 }
            };

            return wallSpriteAnimationParameters;
        }

        private bool SphereIsAtPositiveX(Position3D centerOfSphere, IWorldElement intersectedElement)
        {
            return centerOfSphere.PositionX > intersectedElement.Position.PositionX + (intersectedElement.LengthX / 2.0);
        }
    }
}
