using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;
using BaseTypes;
using BloodEffects;
using BloodEffects.Contracts;

namespace DrawableElements.WallEffects
{
    public class BloodAnimationSpriteFactory : IBloodAnimationSpriteFactory
    {
        private IAnimationLoader _animationLoader;
        private string _animationPath;
        private double _delay;
        private ITextureChanger _textureChanger;
        private IWorldElementProvider _playerProvider;
        private IPolygonRenderer _polygonRenderer;

        public BloodAnimationSpriteFactory(IAnimationLoader animationLoader, ITextureChanger textureChanger, string animationPath, double delay, IWorldElementProvider playerProvider, IPolygonRenderer polygonRenderer)
        {
            _animationLoader = animationLoader;
            _animationPath = animationPath;
            _delay = delay;
            _textureChanger = textureChanger;
            _playerProvider = playerProvider;
            _polygonRenderer = polygonRenderer;
        }

        IDrawable IBloodAnimationSpriteFactory.CreateBloodSprite(WallSpriteAnimationParameters wallSpriteAnimationParameters)
        {
            IAnimation animation = _animationLoader.LoadAnimation(_animationPath + "\\" + wallSpriteAnimationParameters.Animation.ToString());
            IDrawable simpleSpriteVeryNear = new SimpleSprite(_polygonRenderer, wallSpriteAnimationParameters.SpriteVertices.VertexOne, wallSpriteAnimationParameters.SpriteVertices.VertexTwo,
                wallSpriteAnimationParameters.SpriteVertices.VertexThree, wallSpriteAnimationParameters.SpriteVertices.VertexFour);

            SpriteVertices nearVertices = AddNormal(wallSpriteAnimationParameters.SpriteVertices, wallSpriteAnimationParameters.Normal, 0.003);
            IDrawable simpleSpriteNear = new SimpleSprite(_polygonRenderer, nearVertices.VertexOne, nearVertices.VertexTwo, nearVertices.VertexThree, nearVertices.VertexFour);

            SpriteVertices farVertices = AddNormal(wallSpriteAnimationParameters.SpriteVertices, wallSpriteAnimationParameters.Normal, 0.002);
            IDrawable simpleSpriteFar = new SimpleSprite(_polygonRenderer, farVertices.VertexOne, farVertices.VertexTwo, farVertices.VertexThree, farVertices.VertexFour);

            SpriteVertices veryFarVertices = AddNormal(wallSpriteAnimationParameters.SpriteVertices, wallSpriteAnimationParameters.Normal, 0.05);
            IDrawable simpleSpriteVeryFar = new SimpleSprite(_polygonRenderer, veryFarVertices.VertexOne, veryFarVertices.VertexTwo, veryFarVertices.VertexThree, veryFarVertices.VertexFour);

            IPlayerDistanceAnalyser playerDistanceAnalyser = new PlayerDistanceAnalyser(wallSpriteAnimationParameters.SpriteCenterPosition, _playerProvider);

            return new FourDistanceLayersAnimationSprite(animation, _textureChanger, simpleSpriteVeryNear, simpleSpriteNear, simpleSpriteFar, simpleSpriteVeryFar, playerDistanceAnalyser, _delay, wallSpriteAnimationParameters.AnimationPercent);
        }

        private SpriteVertices AddNormal(SpriteVertices source, Vector3D normal, double distance)
        {
            SpriteVertices spriteVertices = new SpriteVertices();

            spriteVertices.VertexOne = new Vertex 
            {
                TextureCoordinate = source.VertexOne.TextureCoordinate, 
                Position = new VertexPosition 
                {
                    X = (float) (source.VertexOne.Position.X + (normal.X * distance)),
                    Y = (float) (source.VertexOne.Position.Y + (normal.Y * distance)),
                    Z = (float) (source.VertexOne.Position.Z + (normal.Z * distance))
                }
            };

            spriteVertices.VertexTwo = new Vertex
            {
                TextureCoordinate = source.VertexTwo.TextureCoordinate,
                Position = new VertexPosition
                {
                    X = (float)(source.VertexTwo.Position.X + (normal.X * distance)),
                    Y = (float)(source.VertexTwo.Position.Y + (normal.Y * distance)),
                    Z = (float)(source.VertexTwo.Position.Z + (normal.Z * distance))
                }
            };

            spriteVertices.VertexThree = new Vertex
            {
                TextureCoordinate = source.VertexThree.TextureCoordinate,
                Position = new VertexPosition
                {
                    X = (float)(source.VertexThree.Position.X + (normal.X * distance)),
                    Y = (float)(source.VertexThree.Position.Y + (normal.Y * distance)),
                    Z = (float)(source.VertexThree.Position.Z + (normal.Z * distance))
                }
            };

            spriteVertices.VertexFour = new Vertex
            {
                TextureCoordinate = source.VertexFour.TextureCoordinate,
                Position = new VertexPosition
                {
                    X = (float)(source.VertexFour.Position.X + (normal.X * distance)),
                    Y = (float)(source.VertexFour.Position.Y + (normal.Y * distance)),
                    Z = (float)(source.VertexFour.Position.Z + (normal.Z * distance))
                }
            };

            return spriteVertices;
        }
    }
}
