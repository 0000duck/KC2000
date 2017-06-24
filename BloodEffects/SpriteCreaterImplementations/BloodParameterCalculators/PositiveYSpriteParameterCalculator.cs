using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using BloodEffects.Contracts;

namespace BloodEffects.SpriteCreaterImplementations.BloodParameterCalculators
{
    public class PositiveYSpriteParameterCalculator : IBloodSpriteParameterCalculator
    {
        private IWallSpriteCalculator _wallSpriteCalculator;
        private double _distanceToWall;
        private ITextureRotater _textureRotater;

        public PositiveYSpriteParameterCalculator(IWallSpriteCalculator wallSpriteCalculator, ITextureRotater textureRotater, double distanceToWall)
        {
            _wallSpriteCalculator = wallSpriteCalculator;
            _distanceToWall = distanceToWall;
            _textureRotater = textureRotater;
        }

        WallSpriteAnimationParameters IBloodSpriteParameterCalculator.TryToCreateSprite(IWorldElement intersectedElement, Position3D centerOfSphere, double radius)
        {
            if (SphereIsAtPositiveY(centerOfSphere, intersectedElement))
            {
                return CreateSpriteAtPositiveY(intersectedElement, centerOfSphere, radius);
            }
            return null;
        }

        private WallSpriteAnimationParameters CreateSpriteAtPositiveY(IWorldElement intersectedElement, Position3D centerOfSphere, double radius)
        {
            Position3D spriteCenterPosition = new Position3D();

            spriteCenterPosition.PositionX = centerOfSphere.PositionX;
            spriteCenterPosition.PositionY = intersectedElement.Position.PositionZ + intersectedElement.Height + _distanceToWall;
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
                Normal = new Vector3D { Y = 1 }
            };

            return wallSpriteAnimationParameters;
        }

        private bool SphereIsAtPositiveY(Position3D centerOfSphere, IWorldElement intersectedElement)
        {
            return centerOfSphere.PositionZ > intersectedElement.Position.PositionZ + intersectedElement.Height;
        }
    }
}
